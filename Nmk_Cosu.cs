// Decompiled with JetBrains decompiler
// Type: dorajx2.Nmk_Cosu
// Assembly: T2Auto, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3D2B1643-7C06-428B-9BDA-29369F42091D
// Assembly location: C:\Users\itoutsource06\Desktop\AutoT2\Auto Jx2\T2Auto.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace dorajx2
{
  public class Nmk_Cosu : Form
  {
    private List<Player.NPCinfo> listItem = new List<Player.NPCinfo>();
    private List<Player.NPCinfo> listItemOld = new List<Player.NPCinfo>();
    private Player.NPCinfo oldKX = new Player.NPCinfo();
    private IContainer components = (IContainer) null;
    private List<Player.NPCinfo> _listItem = new List<Player.NPCinfo>();
    private Player player;
    private Button button3;
    private Button button4;
    private ListView listView1;
    private ColumnHeader columnHeader1;
    private Button button1;
    private Label label1;
    private ComboBox comboBox1;
    private Button button5;
    private Button button2;

    public Nmk_Cosu(Client client)
    {
      this.InitializeComponent();
      this.player = client.player;
      if (!client.IsChecked)
        return;
      if (this.player.buffnpclist != null)
      {
        foreach (Player.NPCinfo npCinfo in this.player.buffnpclist)
          this.listView1.Items.Add(new ListViewItem(new string[1]
          {
            npCinfo.Name
          }));
      }
      else
        this.player.buffnpclist = new List<Player.NPCinfo>();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Nmk_Cosu));
      this.button3 = new Button();
      this.button4 = new Button();
      this.listView1 = new ListView();
      this.columnHeader1 = new ColumnHeader();
      this.button1 = new Button();
      this.label1 = new Label();
      this.comboBox1 = new ComboBox();
      this.button5 = new Button();
      this.button2 = new Button();
      this.SuspendLayout();
      this.button3.Location = new Point(76, 12);
      this.button3.Name = "button3";
      this.button3.Size = new Size(132, 23);
      this.button3.TabIndex = 13;
      this.button3.Text = "Thêm ";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new EventHandler(this.Button3_Click_1);
      this.button4.Location = new Point(214, 12);
      this.button4.Name = "button4";
      this.button4.Size = new Size(99, 23);
      this.button4.TabIndex = 14;
      this.button4.Text = "Xóa";
      this.button4.UseVisualStyleBackColor = true;
      this.button4.Click += new EventHandler(this.Button4_Click);
      this.listView1.Columns.AddRange(new ColumnHeader[1]
      {
        this.columnHeader1
      });
      this.listView1.FullRowSelect = true;
      this.listView1.GridLines = true;
      this.listView1.HideSelection = false;
      this.listView1.Location = new Point(3, 92);
      this.listView1.Name = "listView1";
      this.listView1.Size = new Size(317, 427);
      this.listView1.TabIndex = 15;
      this.listView1.UseCompatibleStateImageBehavior = false;
      this.listView1.View = View.Details;
      this.columnHeader1.Text = "Name";
      this.columnHeader1.Width = 311;
      this.button1.Location = new Point(254, 39);
      this.button1.Name = "button1";
      this.button1.Size = new Size(59, 23);
      this.button1.TabIndex = 20;
      this.button1.Text = "Get";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.Button1_Click);
      this.label1.AutoSize = true;
      this.label1.Location = new Point(5, 44);
      this.label1.Name = "label1";
      this.label1.Size = new Size(73, 13);
      this.label1.TabIndex = 19;
      this.label1.Text = "Player_Name:";
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Location = new Point(84, 41);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(164, 21);
      this.comboBox1.TabIndex = 18;
      this.button5.Location = new Point(3, 12);
      this.button5.Name = "button5";
      this.button5.Size = new Size(67, 23);
      this.button5.TabIndex = 21;
      this.button5.Text = "Xóa All";
      this.button5.UseVisualStyleBackColor = true;
      this.button5.Click += new EventHandler(this.Button5_Click);
      this.button2.Location = new Point(3, 68);
      this.button2.Name = "button2";
      this.button2.Size = new Size(310, 23);
      this.button2.TabIndex = 22;
      this.button2.Text = "List Player gần nhất";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new EventHandler(this.Button2_Click_1);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(325, 531);
      this.Controls.Add((Control) this.button2);
      this.Controls.Add((Control) this.button5);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.comboBox1);
      this.Controls.Add((Control) this.listView1);
      this.Controls.Add((Control) this.button4);
      this.Controls.Add((Control) this.button3);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (Nmk_Cosu);
      this.Text = "Sell items";
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private void Button3_Click_1(object sender, EventArgs e)
    {
      if (this.comboBox1.Items.Count <= 0)
        return;
      this.listView1.Items.Add(new ListViewItem(new string[1]
      {
        this.Name = this.comboBox1.Text
      }));
      this.player.buffnpclist.Add(new Player.NPCinfo()
      {
        Name = this.comboBox1.Text
      });
    }

    private void Button4_Click(object sender, EventArgs e)
    {
      if (this.listView1.SelectedItems.Count <= 0)
        return;
      this.player.buffnpclist.Remove(this.player.buffnpclist.FirstOrDefault<Player.NPCinfo>((Func<Player.NPCinfo, bool>) (x => x.Name == this.listView1.SelectedItems[0].SubItems[0].Text)));
      this.listView1.Items.Clear();
      foreach (Player.NPCinfo npCinfo in this.player.buffnpclist)
        this.listView1.Items.Add(new ListViewItem(new string[1]
        {
          npCinfo.Name
        }));
    }

    private void Button1_Click(object sender, EventArgs e)
    {
      this.comboBox1.Items.Clear();
      foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
      {
        if (npc.type == 5U)
        {
          this.comboBox1.Items.Add((object) npc.Name);
          this.oldKX.Name = npc.Name;
          this.oldKX.id = npc.id;
          this.comboBox1.SelectedIndex = 0;
        }
      }
    }

    private void Button5_Click(object sender, EventArgs e)
    {
      this.listView1.Items.Clear();
      this.player.buffnpclist.Clear();
    }

    private void Button2_Click_1(object sender, EventArgs e)
    {
      this.listView1.Items.Clear();
      this.player.buffnpclist.Clear();
      foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
      {
        if (npc.type == 5U && Convert.ToInt32(ReadMem.Distance((float) this.player.postx(), (float) this.player.posty(), (float) npc.postx, (float) npc.posty)) < 600)
        {
          this.listView1.Items.Add(new ListViewItem(new string[1]
          {
            npc.Name
          }));
          this.player.buffnpclist.Add(new Player.NPCinfo()
          {
            Name = npc.Name
          });
        }
      }
    }
  }
}
