// Decompiled with JetBrains decompiler

// Type: dorajx2.Form1
// Assembly: T2Auto, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3D2B1643-7C06-428B-9BDA-29369F42091D

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;


namespace dorajx2
{
  public class Form1 : Form
  {
    public static bool ActiveByvn = true;
    public static int BasePass = 12079968;
    public CookieContainer cc = new CookieContainer();
    public List<Client> _listClient = new List<Client>();
    private IContainer components = (IContainer) null;
    public bool IsExit = true;
    public bool active = true;
    public bool IsVIP = true;
    public string _licenseKey = "";
    public string _succet = "";
    public string session = "";
    public string idcomputer = "";
    public string version = "beta";
    public bool vip1 = false;
    public bool vip2 = false;
    public bool vip3 = false;
    private Client _currentPlayer;
    private TabControl tabControl1;
    private TabPage tabtinhnang;
    private ListView listViewPlayers;
    private ColumnHeader lvEnable;
    private ColumnHeader lvName;
    private ColumnHeader lvHide;
    private ColumnHeader lvhp;
    private ColumnHeader lvmp;
    private System.Windows.Forms.Timer time_client;
    private GroupBox groupBox3;
    private LinkLabel linkLabel2;
    private LinkLabel linkLabel1;
    private Label label7;
    private Button button5;
    private LinkLabel linkLabel3;
    private CheckBox cbbuff;
    private Button button6;
    private CheckBox cbChat;
    private Button button8;
    private CheckBox cbthaydo;
    private Button button9;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem showToolStripMenuItem;
    private ToolStripMenuItem hideToolStripMenuItem;
    private ToolStripMenuItem showAllToolStripMenuItem;
    private ToolStripMenuItem hideAllToolStripMenuItem;
    private ToolStripMenuItem checkAllToolStripMenuItem;
    private ToolStripMenuItem uncheckAllToolStripMenuItem;
    private ToolStripMenuItem exitAllToolStripMenuItem;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem đăngNhậpToolStripMenuItem;
    private ToolStripMenuItem muaCoinToolStripMenuItem;
    private Button btTaoNhom;
    private CheckBox cbTaoNhom;
    private TabPage tabPage1;
    private Button button15;
    private CheckBox checkBox3;
    private LinkLabel linkLabel4;
    private ColumnHeader lvmap;
    private const int MF_BYPOSITION = 1024;
    private Thread otactive;
    public UyHoLenh UyHoLenh;
    private Thread othread1;
    private Thread othread2;
    private Thread othread4;

    public Form1()
    {
      this.InitializeComponent();
      this.MaximizeBox = false;
      this.removeandreplace();
    }

    [DllImport("User32")]
    private static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);

    [DllImport("User32")]
    private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

    [DllImport("User32")]
    private static extern int GetMenuItemCount(IntPtr hWnd);

    private void Time_client_Tick(object sender, EventArgs e)
    {
      try
      {
        ProcessJx2[] listjx2 = WinAPI.GetListjx2();
        for (int index = 0; index < Math.Max(this._listClient.Count, listjx2.Length); ++index)
        {
          if (listjx2.Length > this._listClient.Count && this.active)
          {
            Client client1 = new Client(listjx2[index].hWnd, listjx2[index].PId, this._licenseKey);
            if (!this._listClient.Exists((Predicate<Client>) (x => x.hWnd == client1.hWnd)))
            {
              string str = client1.player.Name();
              ListViewItem listViewItem = new ListViewItem(new string[6]
              {
                "",
                str.Equals("") ? "DangKetNoi" : str,
                WinAPI.IsWindowVisible(client1.hWnd) ? "0" : "1",
                client1.player.Map().ToString(),
                client1.player.Hp().ToString(),
                client1.player.Mp().ToString()
              });
              if (this._listClient.Count < 21)
              {
                this._listClient.Add(client1);
                this.listViewPlayers.Items.Add(listViewItem);
              }
            }
          }
          else if (!WinAPI.IsWindow(this._listClient[index].hWnd) || !this.active)
          {
            if (this._listClient[index].player.Name() != "" && this._listClient[index].IsChecked)
              this._listClient[index].player.SaveData();
            this._listClient[index].Exit = true;
            this._listClient.RemoveAt(index);
            this.listViewPlayers.Items.RemoveAt(index);
          }
          else
          {
            this._listClient[index].player.Address = ReadMem.AddressPlayer(this._listClient[index].player.HProcess);
            this._listClient[index].vip1 = this.vip1;
            this._listClient[index].vip2 = this.vip2;
            this._listClient[index].vip3 = this.vip3;
            string str1 = this._listClient[index].player.Name();
            string str2 = this._listClient[index].player.Hp().ToString();
            string str3 = this._listClient[index].player.Mp().ToString();
            string str4 = this._listClient[index].player.Map().ToString();
            string str5 = WinAPI.IsWindowVisible(this._listClient[index].hWnd) ? "0" : "1";
            if (!str1.Equals(this.listViewPlayers.Items[index].SubItems[1].Text))
              this.listViewPlayers.Items[index].SubItems[1].Text = str1.Equals("") ? "DangKetNoi" : str1;
            if (!this.listViewPlayers.Items[index].SubItems[2].Text.Equals(str5))
              this.listViewPlayers.Items[index].SubItems[2].Text = str5;
            if (!this.listViewPlayers.Items[index].SubItems[3].Text.Equals(str4))
              this.listViewPlayers.Items[index].SubItems[3].Text = str1.Equals("DangKetNoi") ? "0" : str4;
            if (!this.listViewPlayers.Items[index].SubItems[4].Text.Equals(str2))
              this.listViewPlayers.Items[index].SubItems[4].Text = str1.Equals("DangKetNoi") ? "0" : str2;
            if (!this.listViewPlayers.Items[index].SubItems[5].Text.Equals(str3))
              this.listViewPlayers.Items[index].SubItems[5].Text = str3;
            if ((uint) this._listClient[index].player.Hp() > 0U)
              this.DoRunGame(this._listClient[index], this._listClient[index].player);
            if (str1 != "" && this._listClient[index].IsChecked)
              this._listClient[index].player.SaveData();
          }
        }
        this.Text = "Trinh2 Auto (" + this.version + ") account: " + (object) this._listClient.Count;
      }
      catch
      {
      }
    }

    private void loadothersetting(Client client)
    {
      try
      {
        Player player1 = client.player;
        string str = player1.Name();
        if (!(player1._Name == str))
          return;
        string path = Directory.GetCurrentDirectory() + "\\Player\\" + str + ".json";
        if (System.IO.File.Exists(path))
        {
          Player player2 = (Player) JsonConvert.DeserializeObject(System.IO.File.ReadAllText(path), typeof (Player));
          if (player2.TimeDelayChat == 0)
            player2.TimeDelayChat = 2;
          this.cbthaydo.Checked = player2.isthaydo;
          player1.isxdame = player2.isxdame;
          player1.isthaydo = player2.isthaydo;
          this.cbChat.Checked = player2.isChat;
          player1.isChat = player2.isChat;
          player1.isSell = player2.isSell;
          player1.minhgiaoanco = player2.minhgiaoanco;
          player1.cobophimanco = player2.cobophimanco;
          player1.cobophimanco1 = player2.cobophimanco1;
          player1.isGiaodich = player2.isGiaodich;
          player1.Msg = player2.Msg;
          player1.TimeDelayChat = player2.TimeDelayChat;
          player1.timechat = player2.timechat;
          player1.loichat = player2.loichat;
          player1.DiPhoBan.KieuDiAi = player2.DiPhoBan.KieuDiAi;
          player1.DiPhoBan.CheDo = player2.DiPhoBan.CheDo;
          player1.DiPhoBan.isLatBaiMP = player2.DiPhoBan.isLatBaiMP;
          player1.DiPhoBan.isLatBaiTP = player2.DiPhoBan.isLatBaiTP;
          player1.DiPhoBan.loaipb = player2.DiPhoBan.loaipb;
          player1.DiPhoBan.isRuongDong = player2.DiPhoBan.isRuongDong;
          player1.DiPhoBan.Map = player2.DiPhoBan.Map;
          player1.isPhoBan = player2.isPhoBan;
          player1.buffchedo = player2.buffchedo;
          player1.buffchedo1 = player2.buffchedo1;
          player1.buffchedo2 = player2.buffchedo2;
          player1.DiPhoBan.isbatdaudi = player2.DiPhoBan.isbatdaudi;
          player1.DiPhoBan.thanhvien = player2.DiPhoBan.thanhvien;
          player1.sellitemlist = player2.sellitemlist;
          player1.sellnpclist = player2.sellnpclist;
          player1.buffnpclist = player2.buffnpclist;
          player1.buffnpclistcosu = player2.buffnpclistcosu;
          player1.buffnpclistkill = player2.buffnpclistkill;
          player1.itemlistgd = player2.itemlistgd;
          player1.chatlist = player2.chatlist;
          player1.setthaydo = player2.setthaydo;
          player1.setthaydo2 = player2.setthaydo2;
          player1.setthaydo3 = player2.setthaydo3;
          player1.setthaydo4 = player2.setthaydo4;
          player1.cobophim1 = player2.cobophim1;
          player1.cobophim2 = player2.cobophim2;
          player1.cobophim3 = player2.cobophim3;
          player1.cobophim4 = player2.cobophim4;
          player1.cobophimxdame = player2.cobophimxdame;
          player1.txdame = player2.txdame;
          player1.phatdongxdame = player2.phatdongxdame;
          player1.xdame = player2.xdame;
          player1.isBuff = player2.isBuff;
          this.cbbuff.Checked = player2.isBuff;
          player1.isBuffALL = player2.isBuffALL;
          player1.isKsTui = player2.isKsTui;
          player1.isUseSkillCs = player2.isUseSkillCs;
          player1.TrongCaylist = player2.TrongCaylist;
          player1.isTrongCay = player2.isTrongCay;
          player1.isNhatAll = player2.isNhatAll;
          player1.isBaoDanh = player2.isBaoDanh;
          player1.NPCBB_Name = player2.NPCBB_Name;
          player1.CTP_Name = player2.CTP_Name;
          player1.TaoNhomlist = player2.TaoNhomlist;
          player1.isTaoNhom = player2.isTaoNhom;
          this.cbTaoNhom.Checked = player2.isTaoNhom;
          player1.isTruongNhom = player2.isTruongNhom;
          player1.isTheoSau = player2.isTheoSau;
          player1.isCosu = player2.isCosu;
          player1.isKillquai = player2.isKillquai;
          this.checkBox3.Checked = player2.AutoPK;
          player1.AutoPK = player2.AutoPK;
          player1.SDBomMau = player2.SDBomMau;
          player1.PT = player2.PT;
          player1.isBomMau = player2.isBomMau;
          player1.isTruongNhom = player2.isTruongNhom;
          player1.isNhanLM = player2.isNhanLM;
          player1.cbuyholenh = player2.cbuyholenh;
          player1.skillcosu = player2.skillcosu;
          player1.ischetao = player2.ischetao;
          player1.skill1 = player2.skill1;
          player1.skill2 = player2.skill2;
          player1.skill3 = player2.skill3;
          player1.namechetao = player2.namechetao;
          player1.idchetao = player2.idchetao;
          player1.IDmap = player2.IDmap;
          player1.playergd = player2.playergd;
          player1.Itemgd = player2.Itemgd;
          Thread thread1 = new Thread(new ThreadStart(client.AutoComBo));
          thread1.IsBackground = true;
          thread1.Start();
          client.listthread.Add(thread1);
          Thread thread2 = new Thread(new ThreadStart(client.pickupitem));
          thread2.IsBackground = true;
          thread2.Start();
          client.listthread.Add(thread2);
          Thread thread3 = new Thread(new ThreadStart(client.spam));
          thread3.IsBackground = true;
          thread3.Start();
          client.listthread.Add(thread3);
          Thread thread4 = new Thread(new ThreadStart(client.buffnmkpb));
          thread4.IsBackground = true;
          thread4.Start();
          client.listthread.Add(thread4);
          Thread thread5 = new Thread(new ThreadStart(client.CoSu));
          thread5.IsBackground = true;
          thread5.Start();
          client.listthread.Add(thread5);
          Thread thread6 = new Thread(new ThreadStart(client.killplayer));
          thread6.IsBackground = true;
          thread6.Start();
          client.listthread.Add(thread6);
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, "Xuất hiện lỗi ", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    private void DoRunGame(Client client, Player player)
    {
      this.UyHoLenh = new UyHoLenh(client);
      if (player.isthaydo && client.IsChecked || player.isxdame && client.IsChecked || player.AutoPK && client.IsChecked)
        client.Start();
      else
        client.Stop();
    }

    private void ListViewPlayers_ItemCheck(object sender, ItemCheckEventArgs e)
    {
      if (this.listViewPlayers.Items[e.Index].Name.Equals("DangKetNoi"))
        e.NewValue = e.CurrentValue;
      else
        this._currentPlayer = this._listClient[e.Index];
    }

    private void ListViewPlayers_ItemChecked(object sender, ItemCheckedEventArgs e)
    {
      if (e.Item.Index < 0)
        return;
      this._currentPlayer = this._listClient[e.Item.Index];
      if (this._currentPlayer.player.Hp() == 0)
        this.listViewPlayers.Items[e.Item.Index].Checked = false;
      if (!e.Item.Checked)
      {
        try
        {
          if (this._currentPlayer.IsChecked)
            WinAPI.UnmapDll(this._currentPlayer.hWnd);
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show(ex.Message);
        }
      }
      else
      {
        try
        {
          this.loadothersetting(this._currentPlayer);
          if (WinAPI.InjectDll(this._currentPlayer.hWnd) > 0 && HookCall.Msg == 0U)
            HookCall.Msg = WinAPI.GetMsg();
        }
        catch (DllNotFoundException ex)
        {
          int num = (int) MessageBox.Show("Thiếu file athook.dll " + ex.Message, "Thiếu tệp tin", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          e.Item.Checked = false;
        }
      }
      this._currentPlayer.IsChecked = e.Item.Checked;
    }

    private void Form1_FormClosed(object sender, FormClosedEventArgs e)
    {
      this.Dispose();
      GC.Collect();
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      this.time_client.Stop();
      for (int index = 0; index < this._listClient.Count; ++index)
      {
        foreach (Thread thread in this._listClient[index].listthread)
        {
          try
          {
            thread.Abort();
          }
          catch
          {
          }
        }
        if (this._listClient[index].thread != null && this._listClient[index].IsChecked)
        {
          this._listClient[index].player.SaveData();
          WinAPI.UnmapDll(this._listClient[index].hWnd);
        }
        this._listClient[index].Exit = true;
        try
        {
          WinAPI.CloseHandle(this._listClient[index].player.HProcess);
        }
        catch
        {
        }
      }
      if (this.otactive != null)
        this.otactive.Abort();
      Application.Exit();
      Application.ExitThread();
    }

    private void ListViewPlayers_ItemSelectionChanged(
      object sender,
      ListViewItemSelectionChangedEventArgs e)
    {
      try
      {
        if (!e.IsSelected)
          return;
        if (e.ItemIndex >= 0)
          this._currentPlayer = this._listClient[e.ItemIndex];
        if (this._currentPlayer != null && e.ItemIndex >= 0)
          this.loadothersetting(this._currentPlayer);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, "Xuất hiện lỗi ", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    private void ListViewPlayers_DoubleClick(object sender, EventArgs e)
    {
    }

    private void ListViewPlayers_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      this.listViewPlayers.Invoke((Action)(() => WinAPI.ShowWindow(this._currentPlayer.hWnd, WinAPI.ShowWindowCommands.Normal)));
    }

    private void ShowToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.listViewPlayers.SelectedItems.Count <= 0)
        return;
      int index = this.listViewPlayers.Items.IndexOf(this.listViewPlayers.SelectedItems[0]);
      if (!WinAPI.IsWindowVisible(this._listClient[index].hWnd))
        WinAPI.ShowWindow(this._listClient[index].hWnd, WinAPI.ShowWindowCommands.Restore);
      else
        WinAPI.SetForegroundWindow(this._listClient[index].hWnd);
    }

    private void ListViewPlayers_MouseDown(object sender, MouseEventArgs e)
    {
    }

    private void removeandreplace()
    {
      if (AppDomain.CurrentDomain.FriendlyName == "_dorajx2.exe")
      {
        Thread.Sleep(100);
        Process[] processesByName = Process.GetProcessesByName("dorajx2");
        while (((IEnumerable<Process>) processesByName).Count<Process>() > 0)
        {
          foreach (Process process in processesByName)
          {
            try
            {
              process.Kill();
            }
            catch (Exception ex)
            {
            }
          }
          processesByName = Process.GetProcessesByName("dorajx2");
          Thread.Sleep(100);
        }
        System.IO.File.Delete(AppDomain.CurrentDomain.BaseDirectory + "dorajx2.exe");
        System.IO.File.Copy(AppDomain.CurrentDomain.BaseDirectory + "_dorajx2.exe", AppDomain.CurrentDomain.BaseDirectory + "dorajx2.exe", true);
        Process.Start(new ProcessStartInfo()
        {
          FileName = "dorajx2.exe",
          WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory
        });
        Application.Exit();
        Environment.Exit(0);
      }
      else
      {
        for (Process[] processesByName = Process.GetProcessesByName("_dorajx2"); ((IEnumerable<Process>) processesByName).Count<Process>() > 0; processesByName = Process.GetProcessesByName("_dorajx2"))
        {
          Thread.Sleep(100);
          foreach (Process process in processesByName)
          {
            try
            {
              process.Kill();
            }
            catch (Exception ex)
            {
            }
          }
        }
        try
        {
          if (!System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + "_dorajx2.exe"))
            ;
          System.IO.File.Delete(AppDomain.CurrentDomain.BaseDirectory + "_dorajx2.exe");
        }
        catch (Exception ex)
        {
        }
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Form1));
      this.tabControl1 = new TabControl();
      this.tabtinhnang = new TabPage();
      this.groupBox3 = new GroupBox();
      this.btTaoNhom = new Button();
      this.cbTaoNhom = new CheckBox();
      this.cbthaydo = new CheckBox();
      this.button9 = new Button();
      this.cbChat = new CheckBox();
      this.button8 = new Button();
      this.cbbuff = new CheckBox();
      this.button6 = new Button();
      this.label7 = new Label();
      this.button5 = new Button();
      this.linkLabel3 = new LinkLabel();
      this.linkLabel2 = new LinkLabel();
      this.linkLabel1 = new LinkLabel();
      this.tabPage1 = new TabPage();
      this.button15 = new Button();
      this.checkBox3 = new CheckBox();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.showToolStripMenuItem = new ToolStripMenuItem();
      this.hideToolStripMenuItem = new ToolStripMenuItem();
      this.showAllToolStripMenuItem = new ToolStripMenuItem();
      this.hideAllToolStripMenuItem = new ToolStripMenuItem();
      this.checkAllToolStripMenuItem = new ToolStripMenuItem();
      this.uncheckAllToolStripMenuItem = new ToolStripMenuItem();
      this.exitAllToolStripMenuItem = new ToolStripMenuItem();
      this.listViewPlayers = new ListView();
      this.lvEnable = new ColumnHeader();
      this.lvName = new ColumnHeader();
      this.lvHide = new ColumnHeader();
      this.lvhp = new ColumnHeader();
      this.lvmp = new ColumnHeader();
      this.lvmap = new ColumnHeader();
      this.time_client = new System.Windows.Forms.Timer(this.components);
      this.menuStrip1 = new MenuStrip();
      this.đăngNhậpToolStripMenuItem = new ToolStripMenuItem();
      this.muaCoinToolStripMenuItem = new ToolStripMenuItem();
      this.linkLabel4 = new LinkLabel();
      this.tabControl1.SuspendLayout();
      this.tabtinhnang.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.contextMenuStrip1.SuspendLayout();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      this.tabControl1.Controls.Add((Control) this.tabtinhnang);
      this.tabControl1.Controls.Add((Control) this.tabPage1);
      this.tabControl1.Location = new Point(2, 211);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new Size(354, 144);
      this.tabControl1.TabIndex = 3;
      this.tabtinhnang.Controls.Add((Control) this.groupBox3);
      this.tabtinhnang.Location = new Point(4, 22);
      this.tabtinhnang.Name = "tabtinhnang";
      this.tabtinhnang.Padding = new Padding(3);
      this.tabtinhnang.Size = new Size(346, 118);
      this.tabtinhnang.TabIndex = 0;
      this.tabtinhnang.Text = "Tính Năng";
      this.tabtinhnang.UseVisualStyleBackColor = true;
      this.groupBox3.Controls.Add((Control) this.btTaoNhom);
      this.groupBox3.Controls.Add((Control) this.cbTaoNhom);
      this.groupBox3.Controls.Add((Control) this.cbthaydo);
      this.groupBox3.Controls.Add((Control) this.button9);
      this.groupBox3.Controls.Add((Control) this.cbChat);
      this.groupBox3.Controls.Add((Control) this.button8);
      this.groupBox3.Controls.Add((Control) this.cbbuff);
      this.groupBox3.Controls.Add((Control) this.button6);
      this.groupBox3.Controls.Add((Control) this.label7);
      this.groupBox3.Controls.Add((Control) this.button5);
      this.groupBox3.Controls.Add((Control) this.linkLabel3);
      this.groupBox3.Controls.Add((Control) this.linkLabel2);
      this.groupBox3.Controls.Add((Control) this.linkLabel1);
      this.groupBox3.Location = new Point(6, 6);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new Size(331, 105);
      this.groupBox3.TabIndex = 4;
      this.groupBox3.TabStop = false;
      this.groupBox3.Enter += new EventHandler(this.groupBox3_Enter);
      this.btTaoNhom.BackColor = Color.Aqua;
      this.btTaoNhom.Location = new Point(222, 76);
      this.btTaoNhom.Name = "btTaoNhom";
      this.btTaoNhom.Size = new Size(75, 23);
      this.btTaoNhom.TabIndex = 54;
      this.btTaoNhom.Text = "Cài Đặt";
      this.btTaoNhom.UseVisualStyleBackColor = false;
      this.btTaoNhom.Click += new EventHandler(this.btTaoNhom_Click);
      this.cbTaoNhom.AutoSize = true;
      this.cbTaoNhom.ForeColor = Color.Blue;
      this.cbTaoNhom.Location = new Point(222, 59);
      this.cbTaoNhom.Name = "cbTaoNhom";
      this.cbTaoNhom.Size = new Size(71, 17);
      this.cbTaoNhom.TabIndex = 53;
      this.cbTaoNhom.Text = "Theo sau";
      this.cbTaoNhom.UseVisualStyleBackColor = true;
      this.cbTaoNhom.CheckedChanged += new EventHandler(this.cbTaoNhom_CheckedChanged);
      this.cbthaydo.AutoSize = true;
      this.cbthaydo.ForeColor = Color.Blue;
      this.cbthaydo.Location = new Point(116, 59);
      this.cbthaydo.Name = "cbthaydo";
      this.cbthaydo.Size = new Size(66, 17);
      this.cbthaydo.TabIndex = 33;
      this.cbthaydo.Text = "Thay đồ";
      this.cbthaydo.UseVisualStyleBackColor = true;
      this.cbthaydo.CheckedChanged += new EventHandler(this.Cbthaydo_CheckedChanged);
      this.button9.BackColor = Color.Aqua;
      this.button9.Location = new Point(116, 76);
      this.button9.Name = "button9";
      this.button9.Size = new Size(75, 23);
      this.button9.TabIndex = 32;
      this.button9.Text = "Cài Đặt";
      this.button9.UseVisualStyleBackColor = false;
      this.button9.Click += new EventHandler(this.Button9_Click);
      this.cbChat.AutoSize = true;
      this.cbChat.ForeColor = Color.Blue;
      this.cbChat.Location = new Point(17, 59);
      this.cbChat.Name = "cbChat";
      this.cbChat.Size = new Size(73, 17);
      this.cbChat.TabIndex = 31;
      this.cbChat.Text = "Auto Chat";
      this.cbChat.UseVisualStyleBackColor = true;
      this.cbChat.CheckedChanged += new EventHandler(this.CbChat_CheckedChanged);
      this.button8.BackColor = Color.Aqua;
      this.button8.Location = new Point(15, 75);
      this.button8.Name = "button8";
      this.button8.Size = new Size(75, 23);
      this.button8.TabIndex = 30;
      this.button8.Text = "Cài Đặt";
      this.button8.UseVisualStyleBackColor = false;
      this.button8.Click += new EventHandler(this.Button8_Click);
      this.cbbuff.AutoSize = true;
      this.cbbuff.ForeColor = Color.Blue;
      this.cbbuff.Location = new Point(17, 14);
      this.cbbuff.Name = "cbbuff";
      this.cbbuff.Size = new Size(70, 17);
      this.cbbuff.TabIndex = 27;
      this.cbbuff.Text = "Auto Buff";
      this.cbbuff.UseVisualStyleBackColor = true;
      this.cbbuff.CheckedChanged += new EventHandler(this.Cbbuff_CheckedChanged);
      this.button6.BackColor = Color.Aqua;
      this.button6.Location = new Point(15, 30);
      this.button6.Name = "button6";
      this.button6.Size = new Size(75, 23);
      this.button6.TabIndex = 26;
      this.button6.Text = "Cài Đặt";
      this.button6.UseVisualStyleBackColor = false;
      this.button6.Click += new EventHandler(this.Button6_Click);
      this.label7.AutoSize = true;
      this.label7.ForeColor = Color.Blue;
      this.label7.Location = new Point(125, 14);
      this.label7.Name = "label7";
      this.label7.Size = new Size(58, 13);
      this.label7.TabIndex = 25;
      this.label7.Text = "Auto Login";
      this.button5.BackColor = Color.Aqua;
      this.button5.Location = new Point(116, 30);
      this.button5.Name = "button5";
      this.button5.Size = new Size(75, 23);
      this.button5.TabIndex = 24;
      this.button5.Text = "Cài Đặt";
      this.button5.UseVisualStyleBackColor = false;
      this.button5.Click += new EventHandler(this.Button5_Click);
      this.linkLabel3.AutoSize = true;
      this.linkLabel3.LinkColor = Color.Black;
      this.linkLabel3.Location = new Point(-81, 501);
      this.linkLabel3.Name = "linkLabel3";
      this.linkLabel3.Size = new Size(275, 13);
      this.linkLabel3.TabIndex = 23;
      this.linkLabel3.TabStop = true;
      this.linkLabel3.Text = "https://www.facebook.com/groups/418024609067827/";
      this.linkLabel2.AutoSize = true;
      this.linkLabel2.LinkColor = Color.Black;
      this.linkLabel2.Location = new Point(9, 457);
      this.linkLabel2.Name = "linkLabel2";
      this.linkLabel2.Size = new Size(275, 13);
      this.linkLabel2.TabIndex = 16;
      this.linkLabel2.TabStop = true;
      this.linkLabel2.Text = "https://www.facebook.com/groups/418024609067827/";
      this.linkLabel1.AutoSize = true;
      this.linkLabel1.LinkColor = Color.Black;
      this.linkLabel1.Location = new Point(9, 457);
      this.linkLabel1.Name = "linkLabel1";
      this.linkLabel1.Size = new Size(275, 13);
      this.linkLabel1.TabIndex = 15;
      this.linkLabel1.TabStop = true;
      this.linkLabel1.Text = "https://www.facebook.com/groups/418024609067827/";
      this.tabPage1.Controls.Add((Control) this.button15);
      this.tabPage1.Controls.Add((Control) this.checkBox3);
      this.tabPage1.Location = new Point(4, 22);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new Padding(3);
      this.tabPage1.Size = new Size(346, 118);
      this.tabPage1.TabIndex = 1;
      this.tabPage1.Text = "Auto PK";
      this.tabPage1.UseVisualStyleBackColor = true;
      this.button15.Location = new Point(13, 32);
      this.button15.Name = "button15";
      this.button15.Size = new Size(75, 23);
      this.button15.TabIndex = 63;
      this.button15.Text = "Cài Đặt";
      this.button15.UseVisualStyleBackColor = true;
      this.button15.Click += new EventHandler(this.button15_Click_5);
      this.checkBox3.AutoSize = true;
      this.checkBox3.Enabled = false;
      this.checkBox3.Location = new Point(15, 15);
      this.checkBox3.Name = "checkBox3";
      this.checkBox3.Size = new Size(62, 17);
      this.checkBox3.TabIndex = 62;
      this.checkBox3.Text = "AutoPK";
      this.checkBox3.UseVisualStyleBackColor = true;
      this.checkBox3.CheckedChanged += new EventHandler(this.checkBox3_CheckedChanged);
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[7]
      {
        (ToolStripItem) this.showToolStripMenuItem,
        (ToolStripItem) this.hideToolStripMenuItem,
        (ToolStripItem) this.showAllToolStripMenuItem,
        (ToolStripItem) this.hideAllToolStripMenuItem,
        (ToolStripItem) this.checkAllToolStripMenuItem,
        (ToolStripItem) this.uncheckAllToolStripMenuItem,
        (ToolStripItem) this.exitAllToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(135, 158);
      this.contextMenuStrip1.Opening += new CancelEventHandler(this.contextMenuStrip1_Opening_1);
      this.showToolStripMenuItem.Checked = true;
      this.showToolStripMenuItem.CheckState = CheckState.Checked;
      this.showToolStripMenuItem.Name = "showToolStripMenuItem";
      this.showToolStripMenuItem.Size = new Size(134, 22);
      this.showToolStripMenuItem.Text = "Show";
      this.showToolStripMenuItem.Click += new EventHandler(this.ShowToolStripMenuItem_Click);
      this.hideToolStripMenuItem.Checked = true;
      this.hideToolStripMenuItem.CheckState = CheckState.Checked;
      this.hideToolStripMenuItem.Name = "hideToolStripMenuItem";
      this.hideToolStripMenuItem.Size = new Size(134, 22);
      this.hideToolStripMenuItem.Text = "ShowAll";
      this.hideToolStripMenuItem.Click += new EventHandler(this.hideToolStripMenuItem_Click);
      this.showAllToolStripMenuItem.Checked = true;
      this.showAllToolStripMenuItem.CheckState = CheckState.Checked;
      this.showAllToolStripMenuItem.Name = "showAllToolStripMenuItem";
      this.showAllToolStripMenuItem.Size = new Size(134, 22);
      this.showAllToolStripMenuItem.Text = "Hide";
      this.showAllToolStripMenuItem.Click += new EventHandler(this.showAllToolStripMenuItem_Click);
      this.hideAllToolStripMenuItem.Checked = true;
      this.hideAllToolStripMenuItem.CheckState = CheckState.Checked;
      this.hideAllToolStripMenuItem.Name = "hideAllToolStripMenuItem";
      this.hideAllToolStripMenuItem.Size = new Size(134, 22);
      this.hideAllToolStripMenuItem.Text = "HideAll";
      this.hideAllToolStripMenuItem.Click += new EventHandler(this.hideAllToolStripMenuItem_Click);
      this.checkAllToolStripMenuItem.Checked = true;
      this.checkAllToolStripMenuItem.CheckState = CheckState.Checked;
      this.checkAllToolStripMenuItem.Name = "checkAllToolStripMenuItem";
      this.checkAllToolStripMenuItem.Size = new Size(134, 22);
      this.checkAllToolStripMenuItem.Text = "CheckAll";
      this.checkAllToolStripMenuItem.Click += new EventHandler(this.checkAllToolStripMenuItem_Click);
      this.uncheckAllToolStripMenuItem.Checked = true;
      this.uncheckAllToolStripMenuItem.CheckState = CheckState.Checked;
      this.uncheckAllToolStripMenuItem.Name = "uncheckAllToolStripMenuItem";
      this.uncheckAllToolStripMenuItem.Size = new Size(134, 22);
      this.uncheckAllToolStripMenuItem.Text = "UncheckAll";
      this.uncheckAllToolStripMenuItem.Click += new EventHandler(this.uncheckAllToolStripMenuItem_Click);
      this.exitAllToolStripMenuItem.Checked = true;
      this.exitAllToolStripMenuItem.CheckState = CheckState.Checked;
      this.exitAllToolStripMenuItem.Name = "exitAllToolStripMenuItem";
      this.exitAllToolStripMenuItem.Size = new Size(134, 22);
      this.exitAllToolStripMenuItem.Text = "ExitAll";
      this.exitAllToolStripMenuItem.Click += new EventHandler(this.exitAllToolStripMenuItem_Click);
      this.listViewPlayers.CheckBoxes = true;
      this.listViewPlayers.Columns.AddRange(new ColumnHeader[6]
      {
        this.lvEnable,
        this.lvName,
        this.lvHide,
        this.lvhp,
        this.lvmp,
        this.lvmap
      });
      this.listViewPlayers.ContextMenuStrip = this.contextMenuStrip1;
      this.listViewPlayers.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.listViewPlayers.ForeColor = Color.Blue;
      this.listViewPlayers.FullRowSelect = true;
      this.listViewPlayers.GridLines = true;
      this.listViewPlayers.HideSelection = false;
      this.listViewPlayers.Location = new Point(2, 3);
      this.listViewPlayers.Name = "listViewPlayers";
      this.listViewPlayers.Size = new Size(354, 202);
      this.listViewPlayers.TabIndex = 2;
      this.listViewPlayers.UseCompatibleStateImageBehavior = false;
      this.listViewPlayers.View = View.Details;
      this.listViewPlayers.ItemCheck += new ItemCheckEventHandler(this.ListViewPlayers_ItemCheck);
      this.listViewPlayers.ItemChecked += new ItemCheckedEventHandler(this.ListViewPlayers_ItemChecked);
      this.listViewPlayers.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(this.ListViewPlayers_ItemSelectionChanged);
      this.listViewPlayers.DoubleClick += new EventHandler(this.ListViewPlayers_DoubleClick);
      this.listViewPlayers.MouseDoubleClick += new MouseEventHandler(this.ListViewPlayers_MouseDoubleClick);
      this.listViewPlayers.MouseDown += new MouseEventHandler(this.ListViewPlayers_MouseDown);
      this.lvEnable.Text = "";
      this.lvEnable.Width = 18;
      this.lvName.Text = "Name";
      this.lvName.Width = 118;
      this.lvHide.Text = "Ẩn";
      this.lvHide.Width = 33;
      this.lvhp.Text = "HP";
      this.lvhp.Width = 50;
      this.lvmp.Text = "Mana";
      this.time_client.Enabled = true;
      this.time_client.Interval = 1500;
      this.time_client.Tick += new EventHandler(this.Time_client_Tick);
      this.menuStrip1.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.đăngNhậpToolStripMenuItem,
        (ToolStripItem) this.muaCoinToolStripMenuItem
      });
      this.menuStrip1.Location = new Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new Size(348, 24);
      this.menuStrip1.TabIndex = 4;
      this.menuStrip1.Text = "menuStrip1";
      this.đăngNhậpToolStripMenuItem.ForeColor = Color.Blue;
      this.đăngNhậpToolStripMenuItem.Name = "đăngNhậpToolStripMenuItem";
      this.đăngNhậpToolStripMenuItem.Size = new Size(62, 20);
      this.đăngNhậpToolStripMenuItem.Text = "Đăng ký";
      this.đăngNhậpToolStripMenuItem.Click += new EventHandler(this.đăngNhậpToolStripMenuItem_Click);
      this.muaCoinToolStripMenuItem.ForeColor = Color.Blue;
      this.muaCoinToolStripMenuItem.Name = "muaCoinToolStripMenuItem";
      this.muaCoinToolStripMenuItem.Size = new Size(77, 20);
      this.muaCoinToolStripMenuItem.Text = "Đăng nhập";
      this.muaCoinToolStripMenuItem.Click += new EventHandler(this.muaCoinToolStripMenuItem_Click);
      this.linkLabel4.AutoSize = true;
      this.linkLabel4.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.linkLabel4.ForeColor = Color.Blue;
      this.linkLabel4.LinkColor = Color.Crimson;
      this.linkLabel4.Location = new Point(252, 3);
      this.linkLabel4.Name = "linkLabel4";
      this.linkLabel4.Size = new Size(91, 15);
      this.linkLabel4.TabIndex = 5;
      this.linkLabel4.TabStop = true;
      this.linkLabel4.Text = "Inbox FB Hỗ trợ";
      this.linkLabel4.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(348, 356);
      this.Controls.Add((Control) this.linkLabel4);
      this.Controls.Add((Control) this.menuStrip1);
      this.Controls.Add((Control) this.tabControl1);
      this.Controls.Add((Control) this.listViewPlayers);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MainMenuStrip = this.menuStrip1;
      this.Name = nameof (Form1);
      this.StartPosition = FormStartPosition.Manual;
      this.Text = "Trinh2 Auto";
      this.FormClosing += new FormClosingEventHandler(this.Form1_FormClosing);
      this.FormClosed += new FormClosedEventHandler(this.Form1_FormClosed);
      this.Load += new EventHandler(this.Form1_Load);
      this.tabControl1.ResumeLayout(false);
      this.tabtinhnang.ResumeLayout(false);
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.tabPage1.ResumeLayout(false);
      this.tabPage1.PerformLayout();
      this.contextMenuStrip1.ResumeLayout(false);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private void TextBox1_TextChanged(object sender, EventArgs e)
    {
    }

    private void Button4_Click(object sender, EventArgs e)
    {
      if (this._currentPlayer == null)
        return;
      Sell sell = new Sell(this._currentPlayer);
      sell.Text = this._currentPlayer.player.Name();
      sell.StartPosition = FormStartPosition.Manual;
      sell.Left = Convert.ToInt32(this.Left - 360);
      sell.Top = Convert.ToInt32(this.Top);
      sell.Show();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      this.Top = 0;
      this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
      this.enableall();
      try
      {
        this.idcomputer = WinAPI.getSN() + WinAPI.GetCPUId() + WinAPI.GetCPUId2();
        Form1.lic lic = (Form1.lic) JsonConvert.DeserializeObject(System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "license"), typeof (Form1.lic));
        if (lic == null)
          return;
        this._succet = lic.success;
        this._licenseKey = lic.user_name;
        try
        {
          string str = Decrypt.DecryptData(this._licenseKey, "dorajx2").Split('|')[1];
          if (str != null)
          {
            if (!(str == "vip1"))
            {
              if (str == "vip2")
                this.vip2 = true;
              else if (str == "vip3")
                this.vip3 = true;
            }
            else
              this.vip1 = true;
          }
        }
        catch
        {
        }
      }
      catch
      {
      }
    }

    private void Button2_Click(object sender, EventArgs e)
    {
      if (this._currentPlayer == null)
        return;
      ClickNPC clickNpc = new ClickNPC(this._currentPlayer);
      clickNpc.Text = this._currentPlayer.player.Name();
      clickNpc.StartPosition = FormStartPosition.Manual;
      clickNpc.Left = Convert.ToInt32(this.Left - 360);
      clickNpc.Top = Convert.ToInt32(this.Top);
      clickNpc.Show();
    }

    private void Button5_Click(object sender, EventArgs e)
    {
      Login login = new Login();
      login.StartPosition = FormStartPosition.Manual;
      login.Left = Convert.ToInt32(this.Left - 360);
      login.Top = Convert.ToInt32(this.Top);
      login.Show();
    }

    private void Cbbuff_CheckedChanged(object sender, EventArgs e)
    {
      if (this.cbbuff.Checked)
      {
        if (this._currentPlayer == null || !this._currentPlayer.IsChecked)
          return;
        this._currentPlayer.player.isBuff = true;
      }
      else
      {
        if (this._currentPlayer == null || !this._currentPlayer.IsChecked)
          return;
        this._currentPlayer.player.isBuff = false;
      }
    }

    private void Button6_Click(object sender, EventArgs e)
    {
      if (this._currentPlayer == null)
        return;
      Nmk_Cosu nmkCosu = new Nmk_Cosu(this._currentPlayer);
      nmkCosu.Text = this._currentPlayer.player.Name();
      nmkCosu.StartPosition = FormStartPosition.Manual;
      nmkCosu.Left = Convert.ToInt32(this.Left - 360);
      nmkCosu.Top = Convert.ToInt32(this.Top);
      nmkCosu.Show();
    }

    private void CbChat_CheckedChanged(object sender, EventArgs e)
    {
      if (this.cbChat.Checked)
      {
        if (this._currentPlayer == null || !this._currentPlayer.IsChecked)
          return;
        this._currentPlayer.player.isChat = true;
      }
      else
      {
        if (this._currentPlayer == null || !this._currentPlayer.IsChecked)
          return;
        this._currentPlayer.player.isChat = false;
      }
    }

    private void Button8_Click(object sender, EventArgs e)
    {
      if (this._currentPlayer == null)
        return;
      Chats chats = new Chats(this._currentPlayer);
      chats.Text = this._currentPlayer.player.Name();
      chats.StartPosition = FormStartPosition.Manual;
      chats.Left = Convert.ToInt32(this.Left - 360);
      chats.Top = Convert.ToInt32(this.Top);
      chats.Show();
    }

    private void Button9_Click(object sender, EventArgs e)
    {
      if (this._currentPlayer == null)
        return;
      ThayDo thayDo = new ThayDo(this._currentPlayer);
      thayDo.Text = this._currentPlayer.player.Name();
      thayDo.StartPosition = FormStartPosition.Manual;
      thayDo.Left = Convert.ToInt32(this.Left - 630);
      thayDo.Top = Convert.ToInt32(this.Top);
      thayDo.Show();
    }

    private void Cbthaydo_CheckedChanged(object sender, EventArgs e)
    {
      if (this.cbthaydo.Checked)
      {
        if (this._currentPlayer == null || !this._currentPlayer.IsChecked)
          return;
        this._currentPlayer.player.isthaydo = true;
      }
      else
      {
        if (this._currentPlayer == null || !this._currentPlayer.IsChecked)
          return;
        this._currentPlayer.player.isthaydo = false;
      }
    }

    private void Button7_Click(object sender, EventArgs e)
    {
      if (this._currentPlayer == null)
        return;
      xdame xdame = new xdame(this._currentPlayer);
      xdame.Text = this._currentPlayer.player.Name();
      xdame.StartPosition = FormStartPosition.Manual;
      xdame.Left = Convert.ToInt32(this.Left - 470);
      xdame.Top = Convert.ToInt32(this.Top);
      xdame.Show();
    }

    private void button10_Click_1(object sender, EventArgs e)
    {
      if (this._currentPlayer == null)
        return;
      Pho_Ban phoBan = new Pho_Ban(this._currentPlayer, this._listClient);
      phoBan.Text = this._currentPlayer.player.Name();
      phoBan.StartPosition = FormStartPosition.Manual;
      phoBan.Left = Convert.ToInt32(this.Left - 260);
      phoBan.Top = Convert.ToInt32(this.Top);
      phoBan.Show();
    }

    private void button11_Click_1(object sender, EventArgs e)
    {
      if (this._currentPlayer == null)
        return;
      BomMau bomMau = new BomMau(this._currentPlayer, this._listClient);
      bomMau.Text = this._currentPlayer.player.Name();
      bomMau.StartPosition = FormStartPosition.Manual;
      bomMau.Left = Convert.ToInt32(this.Left - 450);
      bomMau.Top = Convert.ToInt32(this.Top);
      bomMau.Show();
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
      if (((CheckBox) sender).Checked)
      {
        for (int index = 0; index < this.listViewPlayers.Items.Count; ++index)
          this.listViewPlayers.Items[index].Checked = true;
      }
      else
      {
        for (int index = 0; index < this.listViewPlayers.Items.Count; ++index)
          this.listViewPlayers.Items[index].Checked = false;
      }
    }

    private void checkBox2_CheckedChanged(object sender, EventArgs e)
    {
    }

    private void label3_Click(object sender, EventArgs e)
    {
    }

    private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void button12_Click(object sender, EventArgs e)
    {
      foreach (Client client in this._listClient)
      {
        Client current = client;
        if (current.IsChecked)
        {
          this.othread2 = new Thread((ThreadStart) (() => current.CodeUyHo()));
          this.othread2.Start();
        }
      }
    }

    private void groupBox3_Enter(object sender, EventArgs e)
    {
    }

    private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
    {
    }

    private void exitAllToolStripMenuItem_Click(object sender, EventArgs e)
    {
      switch (MessageBox.Show("Bạn muôn thoát tất cả cửa sổ?", "Exit All", MessageBoxButtons.YesNo))
      {
        case DialogResult.Yes:
          foreach (Process process in Process.GetProcessesByName("so2game"))
            process.Kill();
          break;
      }
    }

    private void showAllToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.listViewPlayers.SelectedItems.Count <= 0)
        return;
      int index = this.listViewPlayers.Items.IndexOf(this.listViewPlayers.SelectedItems[0]);
      if (WinAPI.IsWindowVisible(this._listClient[index].hWnd))
      {
        WinAPI.ShowWindow(this._listClient[index].hWnd, WinAPI.ShowWindowCommands.ShowMinNoActive);
        WinAPI.ShowWindow(this._listClient[index].hWnd, WinAPI.ShowWindowCommands.Hide);
      }
    }

    private void contextMenuStrip1_Opening_1(object sender, CancelEventArgs e)
    {
    }

    private void hideToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this._listClient.Count <= 0)
        return;
      foreach (Client client in this._listClient)
      {
        Client current = client;
        this.othread4 = new Thread((ThreadStart) (() => this.ShowAll(current.hWnd)));
        this.othread4.Start();
        Thread.Sleep(50);
      }
    }

    private void ShowAll(IntPtr hWnd)
    {
      if (!WinAPI.IsWindowVisible(hWnd))
        WinAPI.ShowWindow(hWnd, WinAPI.ShowWindowCommands.Restore);
      else
        WinAPI.SetForegroundWindow(hWnd);
    }

    private void hideall(IntPtr hWnd)
    {
      if (!WinAPI.IsWindowVisible(hWnd))
        return;
      WinAPI.ShowWindow(hWnd, WinAPI.ShowWindowCommands.ShowMinNoActive);
      WinAPI.ShowWindow(hWnd, WinAPI.ShowWindowCommands.Hide);
    }

    private void hideAllToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this._listClient.Count <= 0)
        return;
      foreach (Client client in this._listClient)
      {
        Client current = client;
        this.othread1 = new Thread((ThreadStart) (() => this.hideall(current.hWnd)));
        this.othread1.Start();
        Thread.Sleep(50);
      }
    }

    private void checkAllToolStripMenuItem_Click(object sender, EventArgs e)
    {
      for (int index = 0; index < this.listViewPlayers.Items.Count; ++index)
        this.listViewPlayers.Items[index].Checked = true;
    }

    private void uncheckAllToolStripMenuItem_Click(object sender, EventArgs e)
    {
      for (int index = 0; index < this.listViewPlayers.Items.Count; ++index)
        this.listViewPlayers.Items[index].Checked = false;
    }

    private void enableall()
    {
      this.button5.Enabled = true;
      this.button6.Enabled = true;
      this.button9.Enabled = true;
      this.cbbuff.Enabled = true;
      this.cbthaydo.Enabled = true;
    }

    private void disableall()
    {
      this.button5.Enabled = false;
      this.button6.Enabled = false;
      this.button9.Enabled = false;
      this.cbbuff.Enabled = false;
      this.cbthaydo.Enabled = false;
      try
      {
        for (int index = 0; index < this._listClient.Count; ++index)
        {
          foreach (Thread thread in this._listClient[index].listthread)
          {
            try
            {
              thread.Abort();
            }
            catch
            {
            }
          }
          if (this._listClient[index].IsChecked)
            WinAPI.UnmapDll(this._listClient[index].hWnd);
          this._listClient[index].IsChecked = false;
          this._listClient[index].Exit = true;
          try
          {
            WinAPI.CloseHandle(this._listClient[index].player.HProcess);
          }
          catch
          {
          }
          this.listViewPlayers.Items.Clear();
          this._listClient.Clear();
        }
      }
      catch
      {
      }
    }

    private void button19_Click(object sender, EventArgs e)
    {
    }

    private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void muaCoinToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void button1_Click(object sender, EventArgs e)
    {
    }

    private void button12_Click_1(object sender, EventArgs e)
    {
      int num = (int) MessageBox.Show(WinAPI.getSN().ToString());
    }

    private void button12_Click_2(object sender, EventArgs e)
    {
    }

    private void button12_Click_3(object sender, EventArgs e)
    {
    }

    private void button13_Click(object sender, EventArgs e)
    {
    }

    private void button12_Click_4(object sender, EventArgs e)
    {
    }

    private void button12_Click_5(object sender, EventArgs e)
    {
    }

    private void cbTaoNhom_CheckedChanged(object sender, EventArgs e)
    {
      if (this.cbTaoNhom.Checked)
      {
        if (this._currentPlayer == null || !this._currentPlayer.IsChecked)
          return;
        this._currentPlayer.player.isTaoNhom = true;
      }
      else
      {
        if (this._currentPlayer == null || !this._currentPlayer.IsChecked)
          return;
        this._currentPlayer.player.isTaoNhom = false;
      }
    }

    private void btTaoNhom_Click(object sender, EventArgs e)
    {
      if (this._currentPlayer == null)
        return;
      TaoNhom taoNhom = new TaoNhom(this._currentPlayer);
      taoNhom.Text = this._currentPlayer.player.Name();
      taoNhom.StartPosition = FormStartPosition.Manual;
      taoNhom.Left = Convert.ToInt32(this.Left - 450);
      taoNhom.Top = Convert.ToInt32(this.Top);
      taoNhom.Show();
    }

    private void button12_Click_6(object sender, EventArgs e)
    {
      foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this._currentPlayer.player.HProcess))
      {
        if (npc.type == 5U && (long) npc.id != (long) this._currentPlayer.player.id())
        {
          HookCall.Buffnpc(this._currentPlayer.player.hWnd, npc.id, 262225U, this._currentPlayer.player.Address);
          Thread.Sleep(100);
          int num = (int) MessageBox.Show(npc.Name);
        }
      }
    }

    private void button13_Click_1(object sender, EventArgs e)
    {
    }

    private void button13_Click_2(object sender, EventArgs e)
    {
      if (this._currentPlayer == null)
        return;
      Cosu cosu = new Cosu(this._currentPlayer);
      cosu.Text = this._currentPlayer.player.Name();
      cosu.StartPosition = FormStartPosition.Manual;
      cosu.Left = Convert.ToInt32(this.Left - 450);
      cosu.Top = Convert.ToInt32(this.Top);
      cosu.Show();
    }

    private void button14_Click(object sender, EventArgs e)
    {
      if (this._currentPlayer == null)
        return;
      KillNPC killNpc = new KillNPC(this._currentPlayer);
      killNpc.Text = this._currentPlayer.player.Name();
      killNpc.StartPosition = FormStartPosition.Manual;
      killNpc.Left = Convert.ToInt32(this.Left - 450);
      killNpc.Top = Convert.ToInt32(this.Top);
      killNpc.Show();
    }

    private void button15_Click(object sender, EventArgs e)
    {
    }

    private void button15_Click_1(object sender, EventArgs e)
    {
    }

    private void button15_Click_2(object sender, EventArgs e)
    {
    }

    private void button15_Click_3(object sender, EventArgs e)
    {
    }

    private void button15_Click_4(object sender, EventArgs e)
    {
      int num = (int) MessageBox.Show(this._currentPlayer.player.status().ToString());
    }

    private void button15_Click_5(object sender, EventArgs e)
    {
      if (this._currentPlayer == null)
        return;
      AutoPK autoPk = new AutoPK(this._currentPlayer);
      autoPk.Text = this._currentPlayer.player.Name();
      autoPk.StartPosition = FormStartPosition.Manual;
      autoPk.Left = Convert.ToInt32(this.Left - 450);
      autoPk.Top = Convert.ToInt32(this.Top);
      autoPk.Show();
    }

    private void checkBox3_CheckedChanged(object sender, EventArgs e)
    {
      if (this.checkBox3.Checked)
      {
        if (this._currentPlayer == null || !this._currentPlayer.IsChecked)
          return;
        this._currentPlayer.player.AutoPK = true;
      }
      else
      {
        if (this._currentPlayer == null || !this._currentPlayer.IsChecked)
          return;
        this._currentPlayer.player.AutoPK = false;
      }
    }

    private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Process.Start("https://www.facebook.com/js.7929/");
    }

    [StructLayout(LayoutKind.Sequential, Size = 8)]
    private class Ideregs
    {
      public byte Features;
      public byte SectorCount;
      public byte SectorNumber;
      public byte CylinderLow;
      public byte CylinderHigh;
      public byte DriveHead;
      public byte Command;
      public byte Reserved;
    }

    [StructLayout(LayoutKind.Sequential, Size = 32)]
    private class Sendcmdinparams
    {
      public int BufferSize;
      public readonly Form1.Ideregs DriveRegs;
      public byte DriveNumber;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
      public byte[] Reserved;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
      public int[] Reserved2;

      public Sendcmdinparams()
      {
        this.DriveRegs = new Form1.Ideregs();
        this.Reserved = new byte[3];
        this.Reserved2 = new int[4];
      }
    }

    [StructLayout(LayoutKind.Sequential, Size = 12)]
    private class Driverstatus
    {
      public byte DriveError;
      public byte IDEStatus;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
      public byte[] Reserved;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
      public int[] Reserved2;

      public Driverstatus()
      {
        this.Reserved = new byte[2];
        this.Reserved2 = new int[2];
      }
    }

    [StructLayout(LayoutKind.Sequential)]
    private class Idsector
    {
      public short GenConfig;
      public short NumberCylinders;
      public short Reserved;
      public short NumberHeads;
      public short BytesPerTrack;
      public short BytesPerSector;
      public short SectorsPerTrack;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
      public short[] VendorUnique;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
      public readonly char[] SerialNumber;
      public short BufferClass;
      public short BufferSize;
      public short ECCSize;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
      public readonly char[] FirmwareRevision;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
      public readonly char[] ModelNumber;
      public short MoreVendorUnique;
      public short DoubleWordIO;
      public short Capabilities;
      public short Reserved1;
      public short PIOTiming;
      public short DMATiming;
      public short BS;
      public short NumberCurrentCyls;
      public short NumberCurrentHeads;
      public short NumberCurrentSectorsPerTrack;
      public int CurrentSectorCapacity;
      public short MultipleSectorCapacity;
      public short MultipleSectorStuff;
      public int TotalAddressableSectors;
      public short SingleWordDMA;
      public short MultiWordDMA;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 382)]
      public byte[] Reserved2;

      public Idsector()
      {
        this.VendorUnique = new short[3];
        this.Reserved2 = new byte[382];
        this.FirmwareRevision = new char[8];
        this.SerialNumber = new char[20];
        this.ModelNumber = new char[40];
      }
    }

    [StructLayout(LayoutKind.Sequential)]
    private class Sendcmdoutparams
    {
      public int BufferSize;
      public Form1.Driverstatus Status;
      public readonly Form1.Idsector IDS;

      public Sendcmdoutparams()
      {
        this.Status = new Form1.Driverstatus();
        this.IDS = new Form1.Idsector();
      }
    }

    public class lic
    {
      public int id { get; set; }

      public string user_name { get; set; }

      public string key { get; set; }

      public string Full { get; set; }

      public DateTime hsd { get; set; }

      public string computer { get; set; }

      public string status { get; set; }

      public string success { get; set; }

      public string VND { get; set; }

      public string Message { get; set; }
    }
  }
}
