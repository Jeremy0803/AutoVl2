// Decompiled with JetBrains decompiler
// Type: dorajx2.Login
// Assembly: T2Auto, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3D2B1643-7C06-428B-9BDA-29369F42091D
// Assembly location: C:\Users\itoutsource06\Desktop\AutoT2\Auto Jx2\T2Auto.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace dorajx2
{
  public class Login : Form
  {
    public static int BaseSV = 12423048;
    public static int BaseMenu = 8840676;
    private Player.Item oldKX = new Player.Item();
    private IContainer components = (IContainer) null;
    private List<Player.Item> _listItem = new List<Player.Item>();
    private readonly List<List<string>> _list = new List<List<string>>(100);
    private List<string> Acc = new List<string>();
    private int _indexSelected = -1;
    private int SttNV;
    private Button button3;
    private Button button4;
    private Button button5;
    private TextBox Txbduongdan;
    private Button button1;
    private Label label3;
    private TextBox Txbtaikhoan;
    private TextBox Txbmatkhau;
    private Label label1;
    private Label label2;
    private ComboBox CobSTTNV;
    private Label label4;
    private Label label5;
    private ComboBox CobServer;
    private Button button6;
    private Button button7;
    private Button button8;
    private ComboBox cb_cum;
    private Label label6;
    private Button button2;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem checkAllToolStripMenuItem;
    private ToolStripMenuItem uncheckAllToolStripMenuItem;
    private ToolStripMenuItem exitAllToolStripMenuItem;
    private ListView lsvAcout;
    private ColumnHeader lvEnable;
    private ColumnHeader lvName;
    private ColumnHeader lvHide;
    private ToolStripMenuItem loginStartToolStripMenuItem;
    private FolderBrowserDialog folderBrowserDialog1;
    private bool _changeInfor;
    public AutoLogin SettingAutoLogin;
    private bool _isExit;

    public Login()
    {
      this.InitializeComponent();
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Login));
      this.button3 = new Button();
      this.button4 = new Button();
      this.button5 = new Button();
      this.Txbduongdan = new TextBox();
      this.button1 = new Button();
      this.label3 = new Label();
      this.Txbtaikhoan = new TextBox();
      this.Txbmatkhau = new TextBox();
      this.label1 = new Label();
      this.label2 = new Label();
      this.CobSTTNV = new ComboBox();
      this.label4 = new Label();
      this.label5 = new Label();
      this.CobServer = new ComboBox();
      this.button6 = new Button();
      this.button7 = new Button();
      this.button8 = new Button();
      this.cb_cum = new ComboBox();
      this.label6 = new Label();
      this.button2 = new Button();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.checkAllToolStripMenuItem = new ToolStripMenuItem();
      this.uncheckAllToolStripMenuItem = new ToolStripMenuItem();
      this.exitAllToolStripMenuItem = new ToolStripMenuItem();
      this.loginStartToolStripMenuItem = new ToolStripMenuItem();
      this.lsvAcout = new ListView();
      this.lvEnable = new ColumnHeader();
      this.lvName = new ColumnHeader();
      this.lvHide = new ColumnHeader();
      this.contextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      this.button3.Location = new Point(12, 198);
      this.button3.Name = "button3";
      this.button3.Size = new Size(132, 23);
      this.button3.TabIndex = 13;
      this.button3.Text = "Thêm ";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new EventHandler(this.Button3_Click_1);
      this.button4.Location = new Point(150, 198);
      this.button4.Name = "button4";
      this.button4.Size = new Size(87, 23);
      this.button4.TabIndex = 14;
      this.button4.Text = "Xóa";
      this.button4.UseVisualStyleBackColor = true;
      this.button4.Click += new EventHandler(this.Button4_Click);
      this.button5.Location = new Point(243, 198);
      this.button5.Name = "button5";
      this.button5.Size = new Size(107, 23);
      this.button5.TabIndex = 21;
      this.button5.Text = "Xóa All";
      this.button5.UseVisualStyleBackColor = true;
      this.button5.Click += new EventHandler(this.Button5_Click);
      this.Txbduongdan.Location = new Point(15, 25);
      this.Txbduongdan.Name = "Txbduongdan";
      this.Txbduongdan.Size = new Size(210, 20);
      this.Txbduongdan.TabIndex = 23;
      this.Txbduongdan.TextChanged += new EventHandler(this.Txbduongdan_TextChanged);
      this.button1.Location = new Point(231, 25);
      this.button1.Name = "button1";
      this.button1.Size = new Size(122, 20);
      this.button1.TabIndex = 24;
      this.button1.Text = "........";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.Button1_Click_2);
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Italic, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = SystemColors.ButtonShadow;
      this.label3.Location = new Point(21, 9);
      this.label3.Margin = new Padding(0);
      this.label3.Name = "label3";
      this.label3.Size = new Size(163, 13);
      this.label3.TabIndex = 25;
      this.label3.Text = "Đường dẫn tới thư mục Võ Lâm II";
      this.Txbtaikhoan.Location = new Point(94, 62);
      this.Txbtaikhoan.Name = "Txbtaikhoan";
      this.Txbtaikhoan.Size = new Size(259, 20);
      this.Txbtaikhoan.TabIndex = 26;
      this.Txbmatkhau.Location = new Point(94, 88);
      this.Txbmatkhau.Name = "Txbmatkhau";
      this.Txbmatkhau.Size = new Size(259, 20);
      this.Txbmatkhau.TabIndex = 27;
      this.Txbmatkhau.UseSystemPasswordChar = true;
      this.label1.AutoSize = true;
      this.label1.Location = new Point(21, 62);
      this.label1.Name = "label1";
      this.label1.Size = new Size(55, 13);
      this.label1.TabIndex = 28;
      this.label1.Text = "Tài khoản";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(21, 91);
      this.label2.Name = "label2";
      this.label2.Size = new Size(52, 13);
      this.label2.TabIndex = 29;
      this.label2.Text = "Mật khẩu";
      this.CobSTTNV.DropDownStyle = ComboBoxStyle.DropDownList;
      this.CobSTTNV.FormattingEnabled = true;
      this.CobSTTNV.Items.AddRange(new object[3]
      {
        (object) "1",
        (object) "2",
        (object) "3"
      });
      this.CobSTTNV.Location = new Point(94, 114);
      this.CobSTTNV.Name = "CobSTTNV";
      this.CobSTTNV.Size = new Size(121, 21);
      this.CobSTTNV.TabIndex = 30;
      this.CobSTTNV.SelectedIndexChanged += new EventHandler(this.CobSTTNV_SelectedIndexChanged);
      this.label4.AutoSize = true;
      this.label4.Location = new Point(21, 122);
      this.label4.Name = "label4";
      this.label4.Size = new Size(51, 13);
      this.label4.TabIndex = 31;
      this.label4.Text = "Nhân vật";
      this.label5.AutoSize = true;
      this.label5.Location = new Point(21, 169);
      this.label5.Name = "label5";
      this.label5.Size = new Size(38, 13);
      this.label5.TabIndex = 32;
      this.label5.Text = "Server";
      this.CobServer.DropDownStyle = ComboBoxStyle.DropDownList;
      this.CobServer.FormattingEnabled = true;
      this.CobServer.Items.AddRange(new object[1]
      {
        (object) "VNG"
      });
      this.CobServer.Location = new Point(94, 166);
      this.CobServer.Name = "CobServer";
      this.CobServer.Size = new Size(121, 21);
      this.CobServer.TabIndex = 33;
      this.CobServer.SelectedIndexChanged += new EventHandler(this.comboBox2_SelectedIndexChanged);
      this.button6.Location = new Point(150, 227);
      this.button6.Name = "button6";
      this.button6.Size = new Size(87, 23);
      this.button6.TabIndex = 35;
      this.button6.Text = "Hủy";
      this.button6.UseVisualStyleBackColor = true;
      this.button6.Click += new EventHandler(this.Button6_Click);
      this.button7.Location = new Point(246, 114);
      this.button7.Name = "button7";
      this.button7.Size = new Size(107, 51);
      this.button7.TabIndex = 36;
      this.button7.Text = "Start";
      this.button7.UseVisualStyleBackColor = true;
      this.button7.Click += new EventHandler(this.Button7_Click);
      this.button8.Location = new Point(243, 227);
      this.button8.Name = "button8";
      this.button8.Size = new Size(107, 23);
      this.button8.TabIndex = 37;
      this.button8.Text = "Sửa";
      this.button8.UseVisualStyleBackColor = true;
      this.button8.Click += new EventHandler(this.Button8_Click);
      this.cb_cum.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cb_cum.Font = new Font("Segoe UI", 7.9f);
      this.cb_cum.FormattingEnabled = true;
      this.cb_cum.Items.AddRange(new object[2]
      {
        (object) "TP Hồ Chí Minh",
        (object) "Hà Nội"
      });
      this.cb_cum.Location = new Point(93, 139);
      this.cb_cum.Name = "cb_cum";
      this.cb_cum.Size = new Size(122, 21);
      this.cb_cum.TabIndex = 39;
      this.cb_cum.SelectedIndexChanged += new EventHandler(this.cb_cum_SelectedIndexChanged);
      this.label6.AutoSize = true;
      this.label6.Location = new Point(21, 147);
      this.label6.Name = "label6";
      this.label6.Size = new Size(28, 13);
      this.label6.TabIndex = 40;
      this.label6.Text = "Cụm";
      this.button2.Location = new Point(12, 227);
      this.button2.Name = "button2";
      this.button2.Size = new Size(132, 23);
      this.button2.TabIndex = 34;
      this.button2.Text = "Lưu";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new EventHandler(this.Button2_Click_1);
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[4]
      {
        (ToolStripItem) this.checkAllToolStripMenuItem,
        (ToolStripItem) this.uncheckAllToolStripMenuItem,
        (ToolStripItem) this.exitAllToolStripMenuItem,
        (ToolStripItem) this.loginStartToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(135, 92);
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
      this.exitAllToolStripMenuItem.Text = "Remove";
      this.exitAllToolStripMenuItem.Click += new EventHandler(this.exitAllToolStripMenuItem_Click);
      this.loginStartToolStripMenuItem.Checked = true;
      this.loginStartToolStripMenuItem.CheckState = CheckState.Checked;
      this.loginStartToolStripMenuItem.Name = "loginStartToolStripMenuItem";
      this.loginStartToolStripMenuItem.Size = new Size(134, 22);
      this.loginStartToolStripMenuItem.Text = "LoginStart";
      this.loginStartToolStripMenuItem.Click += new EventHandler(this.loginStartToolStripMenuItem_Click);
      this.lsvAcout.CheckBoxes = true;
      this.lsvAcout.Columns.AddRange(new ColumnHeader[3]
      {
        this.lvEnable,
        this.lvName,
        this.lvHide
      });
      this.lsvAcout.ContextMenuStrip = this.contextMenuStrip1;
      this.lsvAcout.FullRowSelect = true;
      this.lsvAcout.GridLines = true;
      this.lsvAcout.HideSelection = false;
      this.lsvAcout.Location = new Point(2, 256);
      this.lsvAcout.Name = "lsvAcout";
      this.lsvAcout.Size = new Size(360, 309);
      this.lsvAcout.TabIndex = 42;
      this.lsvAcout.UseCompatibleStateImageBehavior = false;
      this.lsvAcout.View = View.Details;
      this.lsvAcout.SelectedIndexChanged += new EventHandler(this.lsvAcout_SelectedIndexChanged_1);
      this.lvEnable.Text = "Tài khoản";
      this.lvEnable.Width = 149;
      this.lvName.Text = "Nhân vật";
      this.lvName.Width = 62;
      this.lvHide.Text = "Server";
      this.lvHide.Width = 117;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(364, 568);
      this.Controls.Add((Control) this.lsvAcout);
      this.Controls.Add((Control) this.label6);
      this.Controls.Add((Control) this.cb_cum);
      this.Controls.Add((Control) this.button8);
      this.Controls.Add((Control) this.button7);
      this.Controls.Add((Control) this.button6);
      this.Controls.Add((Control) this.button2);
      this.Controls.Add((Control) this.CobServer);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.CobSTTNV);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.Txbmatkhau);
      this.Controls.Add((Control) this.Txbtaikhoan);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.Txbduongdan);
      this.Controls.Add((Control) this.button5);
      this.Controls.Add((Control) this.button4);
      this.Controls.Add((Control) this.button3);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (Login);
      this.Text = "AutoLogin";
      this.FormClosing += new FormClosingEventHandler(this.Login_FormClosing);
      this.FormClosed += new FormClosedEventHandler(this.Login_FormClosed);
      this.Load += new EventHandler(this.Login_Load);
      this.contextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private void Button3_Click_1(object sender, EventArgs e)
    {
      ThongTinDangNhap thongTinDangNhap = new ThongTinDangNhap();
      if (this.Txbtaikhoan.Text.Equals(""))
      {
        int num1 = (int) MessageBox.Show("Tài khoản không được để trống", "Lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else if (this.Txbmatkhau.Text.Equals(""))
      {
        int num2 = (int) MessageBox.Show("Mật khẩu không được để trống", "Lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else if (this.cb_cum.SelectedIndex < 0 || this.CobServer.SelectedIndex < 0)
      {
        int num3 = (int) MessageBox.Show("Kiểm tra lại thông tin", "Lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
      {
        thongTinDangNhap.Id = this.Txbtaikhoan.Text;
        thongTinDangNhap.Password = this.Txbmatkhau.Text;
        thongTinDangNhap.Regin = this.cb_cum.SelectedIndex;
        thongTinDangNhap.ServerName = (string) this.CobServer.SelectedItem;
        thongTinDangNhap.Server = this.CobServer.SelectedIndex;
        thongTinDangNhap.NhanVat = this.CobSTTNV.SelectedIndex;
        this.SettingAutoLogin.ListDanhSach.Add(thongTinDangNhap);
        ListViewItem owner = new ListViewItem(this.Txbtaikhoan.Text);
        ListViewItem.ListViewSubItem listViewSubItem1 = new ListViewItem.ListViewSubItem(owner, (this.CobSTTNV.SelectedIndex + 1).ToString());
        ListViewItem.ListViewSubItem listViewSubItem2 = new ListViewItem.ListViewSubItem(owner, (string) this.CobServer.SelectedItem);
        owner.SubItems.Add(listViewSubItem1);
        owner.SubItems.Add(listViewSubItem2);
        this.lsvAcout.Items.Add(owner);
        this._changeInfor = true;
        this.lsvAcout.Focus();
      }
    }

    private void Button4_Click(object sender, EventArgs e)
    {
      if (this.lsvAcout.SelectedIndices.Count > 0)
      {
        int selectedIndex = this.lsvAcout.SelectedIndices[0];
        if (MessageBox.Show("Bạn muốn xóa ID:" + this.lsvAcout.Items[selectedIndex].Text, "Xác thực thao tác", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
        {
          this.SettingAutoLogin.ListDanhSach.RemoveAt(selectedIndex);
          this.lsvAcout.Items.RemoveAt(selectedIndex);
          this._changeInfor = true;
        }
      }
      this.lsvAcout.Focus();
    }

    private void Button1_Click_1(object sender, EventArgs e)
    {
    }

    private void Button1_Click(object sender, EventArgs e)
    {
    }

    private void Button5_Click(object sender, EventArgs e)
    {
      this.lsvAcout.Items.Clear();
    }

    private void Button1_Click_2(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog1 = new OpenFileDialog();
      openFileDialog1.InitialDirectory = "E:\\";
      openFileDialog1.Title = "Browse Text Files";
      openFileDialog1.CheckFileExists = true;
      openFileDialog1.CheckPathExists = true;
      openFileDialog1.DefaultExt = "exe";
      openFileDialog1.Filter = "exe files (*.exe)|*.exe";
      openFileDialog1.FilterIndex = 2;
      openFileDialog1.RestoreDirectory = true;
      openFileDialog1.ReadOnlyChecked = true;
      openFileDialog1.ShowReadOnly = true;
      OpenFileDialog openFileDialog2 = openFileDialog1;
      if (openFileDialog2.ShowDialog() != DialogResult.OK)
        return;
      this.Txbduongdan.Text = openFileDialog2.FileName.Substring(0, openFileDialog2.FileName.LastIndexOf("\\") + 1);
      this.SettingAutoLogin.FileGame = this.Txbduongdan.Text;
    }

    private void Login_Load(object sender, EventArgs e)
    {
      try
      {
        XmlReader xmlReader = (XmlReader) new XmlTextReader(Directory.GetCurrentDirectory() + "\\AutoLogin\\account.xml");
        XmlSerializer xmlSerializer = new XmlSerializer(typeof (AutoLogin));
        this.SettingAutoLogin = !xmlSerializer.CanDeserialize(xmlReader) ? new AutoLogin() : (AutoLogin) xmlSerializer.Deserialize(xmlReader);
        for (int index = 0; index < this.SettingAutoLogin.ListDanhSach.Count; ++index)
        {
          ListViewItem owner = new ListViewItem(this.SettingAutoLogin.ListDanhSach[index].Id);
          ListViewItem.ListViewSubItem listViewSubItem1 = new ListViewItem.ListViewSubItem(owner, this.SettingAutoLogin.ListDanhSach[index].ServerName);
          ListViewItem.ListViewSubItem listViewSubItem2 = new ListViewItem.ListViewSubItem(owner, (this.SettingAutoLogin.ListDanhSach[index].NhanVat + 1).ToString());
          owner.SubItems.Add(listViewSubItem2);
          owner.SubItems.Add(listViewSubItem1);
          this.lsvAcout.Items.Add(owner);
        }
        if (Directory.Exists(this.SettingAutoLogin.FileGame))
          this.Txbduongdan.Text = this.SettingAutoLogin.FileGame;
        xmlReader.Close();
      }
      catch (Exception ex)
      {
        this.SettingAutoLogin = new AutoLogin();
      }
    }

    private void CobSTTNV_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.SttNV = int.Parse(this.CobSTTNV.Text.ToString());
    }

    private void Button8_Click(object sender, EventArgs e)
    {
      if (this.Txbtaikhoan.Text.Equals(""))
      {
        int num1 = (int) MessageBox.Show("Tài khoản không được để trống", "Lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else if (this.Txbmatkhau.Text.Equals(""))
      {
        int num2 = (int) MessageBox.Show("Mật khẩu không được để trống", "Lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else if (this.cb_cum.SelectedIndex < 0 || this.CobServer.SelectedIndex < 0)
      {
        int num3 = (int) MessageBox.Show("Kiểm tra lại thông tin", "Lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
      {
        this.lsvAcout.Items[this._indexSelected].Text = this.Txbtaikhoan.Text;
        this.lsvAcout.Items[this._indexSelected].SubItems[2].Text = (string) this.CobServer.SelectedItem;
        this.lsvAcout.Items[this._indexSelected].SubItems[1].Text = (this.CobSTTNV.SelectedIndex + 1).ToString();
        this.SettingAutoLogin.ListDanhSach[this._indexSelected].Id = this.Txbtaikhoan.Text;
        this.SettingAutoLogin.ListDanhSach[this._indexSelected].Password = this.Txbmatkhau.Text;
        this.SettingAutoLogin.ListDanhSach[this._indexSelected].Regin = this.cb_cum.SelectedIndex;
        this.SettingAutoLogin.ListDanhSach[this._indexSelected].ServerName = (string) this.CobServer.SelectedItem;
        this.SettingAutoLogin.ListDanhSach[this._indexSelected].Server = this.CobServer.SelectedIndex;
        this.SettingAutoLogin.ListDanhSach[this._indexSelected].NhanVat = this.CobSTTNV.SelectedIndex;
        this._changeInfor = true;
        this.lsvAcout.Focus();
      }
    }

    private void Button6_Click(object sender, EventArgs e)
    {
      this.Txbduongdan.Text = "";
      this.Txbmatkhau.Text = "";
      this.Txbtaikhoan.Text = "";
      this.CobServer.Text = "";
      this.CobSTTNV.Text = "";
    }

    private void Button2_Click_1(object sender, EventArgs e)
    {
      try
      {
        this._isExit = true;
        if (this._changeInfor)
        {
          StreamWriter streamWriter = new StreamWriter(Directory.GetCurrentDirectory() + "\\AutoLogin\\account.xml");
          XmlSerializer xmlSerializer = new XmlSerializer(typeof (AutoLogin));
          XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
          namespaces.Add("", "");
          xmlSerializer.Serialize((TextWriter) streamWriter, (object) this.SettingAutoLogin, namespaces);
          streamWriter.Close();
        }
        int num = (int) MessageBox.Show("Đã lưu thông tin tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, "Lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    private void Button7_Click(object sender, EventArgs e)
    {
      List<int> intList = new List<int>();
      foreach (ListViewItem listViewItem in this.lsvAcout.Items)
      {
        if (listViewItem.Checked)
          intList.Add(listViewItem.Index);
      }
      if (intList.Count <= 0)
        return;
      this.button7.Enabled = false;
      new Thread(new ParameterizedThreadStart(this.ThreadManagerLogin)).Start((object) intList);
      this.lsvAcout.Focus();
    }

    private void LsvAcout_ItemCheck(object sender, ItemCheckEventArgs e)
    {
      this.lsvAcout.Items[e.Index].Selected = true;
    }

    public void LoginVl2(object index)
    {
      new Thread((ThreadStart) (() =>
      {
        Process process = new Process();
        process.StartInfo.Arguments = Path.GetFileName(this.SettingAutoLogin.FileGame + "\\so2game.exe");
        process.StartInfo.Verb = "OPEN";
        process.StartInfo.FileName = this.SettingAutoLogin.FileGame + "\\so2game.exe";
        process.StartInfo.WorkingDirectory = this.SettingAutoLogin.FileGame;
        if (File.Exists(this.SettingAutoLogin.FileGame + "//userdata//uicommon.ini"))
          File.Delete(this.SettingAutoLogin.FileGame + "//userdata//uicommon.ini");
        process.StartInfo.UseShellExecute = true;
        process.Start();
        process.WaitForInputIdle();
        IntPtr mainWindowHandle = process.MainWindowHandle;
        WinAPI.UnmapDll(mainWindowHandle);
        if (WinAPI.InjectDll(mainWindowHandle) > 0 && HookCall.Msg == 0U)
          HookCall.Msg = WinAPI.GetMsg();
        Thread.Sleep(500);
        HookCall.BatDau(mainWindowHandle);
        HookCall.ChonSever(mainWindowHandle, (uint) this.SettingAutoLogin.ListDanhSach[(int) index].Regin, (uint) this.SettingAutoLogin.ListDanhSach[(int) index].Server, (uint) Login.BaseSV);
        Thread.Sleep(25);
        this.sendstring(mainWindowHandle, this.SettingAutoLogin.ListDanhSach[(int) index].Id);
        this.sendphim(mainWindowHandle, 9U);
        this.sendstring(mainWindowHandle, this.SettingAutoLogin.ListDanhSach[(int) index].Password);
        this.sendphim(mainWindowHandle, 13U);
        int nhanVat = this.SettingAutoLogin.ListDanhSach[(int) index].NhanVat;
        Thread.Sleep(5000);
        if (nhanVat == 0)
          HookCall.ChonNhanVat(mainWindowHandle, 0U);
        if (nhanVat == 1)
          HookCall.ChonNhanVat(mainWindowHandle, 1U);
        if (nhanVat != 2)
          return;
        HookCall.ChonNhanVat(mainWindowHandle, 2U);
      })).Start();
    }

    public void ThreadManagerLogin(object obj)
    {
      try
      {
        if (File.Exists(this.SettingAutoLogin.FileGame + "\\so2game.exe"))
        {
          List<int> intList = (List<int>) obj;
          int index = 0;
          do
          {
            this.LoginVl2((object) intList[index]);
            ++index;
            Thread.Sleep(100);
            if (index >= intList.Count)
              break;
          }
          while (!this._isExit);
        }
        else
        {
          int num = (int) MessageBox.Show("Không tìm thấy so2game trong thư mục: " + this.SettingAutoLogin.FileGame, "Lỗi không tìm thấy file", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
      try
      {
        this.button7.Invoke((Action) (() =>
        {
          if (this._isExit)
            return;
          this.button7.Enabled = true;
        }));
      }
      catch (Exception ex)
      {
      }
    }

    public void sendphim(IntPtr hwnd, uint A)
    {
      WinAPI.PostMessage(hwnd, 256U, A, A);
    }

    public void sendstring(IntPtr hwnd, string A)
    {
      foreach (uint wParam in Encoding.Default.GetBytes(A))
        WinAPI.PostMessage(hwnd, 258U, wParam, 1U);
    }

    private void Login_FormClosing(object sender, FormClosingEventArgs e)
    {
    }

    private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
      if (((CheckBox) sender).Checked)
      {
        for (int index = 0; index < this.lsvAcout.Items.Count; ++index)
          this.lsvAcout.Items[index].Checked = true;
      }
      else
      {
        for (int index = 0; index < this.lsvAcout.Items.Count; ++index)
          this.lsvAcout.Items[index].Checked = false;
      }
    }

    private void Login_FormClosed(object sender, FormClosedEventArgs e)
    {
    }

    private void cb_cum_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.cb_cum.SelectedIndex == 0)
      {
        this.CobServer.Items.Clear();
        this.CobServer.Items.AddRange((object[]) new string[5]
        {
          "Bạch Hổ",
          "Phục Hổ",
          "Quán Hổ",
          "Họa Hổ",
          "Phong Hổ"
        });
      }
      if (this.cb_cum.SelectedIndex != 1)
        return;
      this.CobServer.Items.Clear();
      this.CobServer.Items.AddRange((object[]) new string[4]
      {
        "Tàng Long",
        "Thiên Long",
        "Linh Bảo Sơn",
        "Phá Long"
      });
    }

    private void Txbduongdan_TextChanged(object sender, EventArgs e)
    {
    }

    private void checkAllToolStripMenuItem_Click(object sender, EventArgs e)
    {
      for (int index = 0; index < this.lsvAcout.Items.Count; ++index)
        this.lsvAcout.Items[index].Checked = true;
    }

    private void uncheckAllToolStripMenuItem_Click(object sender, EventArgs e)
    {
      for (int index = 0; index < this.lsvAcout.Items.Count; ++index)
        this.lsvAcout.Items[index].Checked = false;
    }

    private void exitAllToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.lsvAcout.SelectedIndices.Count > 0)
      {
        int selectedIndex = this.lsvAcout.SelectedIndices[0];
        this.SettingAutoLogin.ListDanhSach.RemoveAt(selectedIndex);
        this.lsvAcout.Items.RemoveAt(selectedIndex);
        this._changeInfor = true;
      }
      this.lsvAcout.Focus();
    }

    private void loginStartToolStripMenuItem_Click(object sender, EventArgs e)
    {
      List<int> intList = new List<int>();
      foreach (ListViewItem listViewItem in this.lsvAcout.Items)
      {
        if (listViewItem.Checked)
          intList.Add(listViewItem.Index);
      }
      if (intList.Count <= 0)
        return;
      this.button7.Enabled = false;
      new Thread(new ParameterizedThreadStart(this.ThreadManagerLogin)).Start((object) intList);
      this.lsvAcout.Focus();
    }

    private void lsvAcout_SelectedIndexChanged_1(object sender, EventArgs e)
    {
      if (this.lsvAcout.Items.Count <= 0 || this.lsvAcout.SelectedIndices.Count <= 0)
        return;
      this._indexSelected = this.lsvAcout.SelectedIndices[0];
      this.Txbtaikhoan.Text = this.SettingAutoLogin.ListDanhSach[this._indexSelected].Id;
      this.Txbmatkhau.Text = this.SettingAutoLogin.ListDanhSach[this._indexSelected].Password;
      this.CobSTTNV.SelectedIndex = this.SettingAutoLogin.ListDanhSach[this._indexSelected].NhanVat;
      this.cb_cum.SelectedIndex = this.SettingAutoLogin.ListDanhSach[this._indexSelected].Regin;
      this.CobServer.SelectedIndex = this.SettingAutoLogin.ListDanhSach[this._indexSelected].Server;
    }

    private delegate void dlgAddItem();
  }
}
