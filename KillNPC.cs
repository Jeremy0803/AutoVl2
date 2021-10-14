// Decompiled with JetBrains decompiler
// Type: dorajx2.KillNPC
// Assembly: T2Auto, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3D2B1643-7C06-428B-9BDA-29369F42091D
// Assembly location: C:\Users\itoutsource06\Desktop\AutoT2\Auto Jx2\T2Auto.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace dorajx2
{
  public class KillNPC : Form
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
    private RadioButton radioButton1;
    private RadioButton radioButton2;
    private Button button6;
    private TextBox textBox1;
    private TextBox textBox2;
    private Button button7;
    private Button button8;
    private TextBox textBox3;
    private CheckBox checkBox1;
    private CheckBox checkBox2;
    private Button button2;

    public KillNPC(Client client)
    {
      this.InitializeComponent();
      this.player = client.player;
      if (!client.IsChecked)
        return;
      if (this.player.buffchedo1 == 0)
      {
        this.radioButton2.Checked = false;
        this.radioButton1.Checked = true;
      }
      else if (this.player.buffchedo1 == 1)
      {
        this.radioButton2.Checked = true;
        this.radioButton1.Checked = false;
      }
      if (this.player.buffchedo2 == 0)
      {
        this.checkBox2.Checked = false;
        this.checkBox1.Checked = true;
      }
      else if (this.player.buffchedo2 == 1)
      {
        this.checkBox2.Checked = true;
        this.checkBox1.Checked = false;
      }
      this.textBox1.Text = this.player.skill1.ToString();
      TextBox textBox2 = this.textBox2;
      int num = this.player.skill2;
      string str1 = num.ToString();
      textBox2.Text = str1;
      TextBox textBox3 = this.textBox3;
      num = this.player.skill3;
      string str2 = num.ToString();
      textBox3.Text = str2;
      if (this.player.buffnpclistkill != null)
      {
        foreach (Player.NPCinfo npCinfo in this.player.buffnpclistkill)
          this.listView1.Items.Add(new ListViewItem(new string[1]
          {
            npCinfo.Name
          }));
      }
      else
        this.player.buffnpclistkill = new List<Player.NPCinfo>();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (KillNPC));
      this.button3 = new Button();
      this.button4 = new Button();
      this.listView1 = new ListView();
      this.columnHeader1 = new ColumnHeader();
      this.button1 = new Button();
      this.label1 = new Label();
      this.comboBox1 = new ComboBox();
      this.button5 = new Button();
      this.button2 = new Button();
      this.radioButton1 = new RadioButton();
      this.radioButton2 = new RadioButton();
      this.button6 = new Button();
      this.textBox1 = new TextBox();
      this.textBox2 = new TextBox();
      this.button7 = new Button();
      this.button8 = new Button();
      this.textBox3 = new TextBox();
      this.checkBox1 = new CheckBox();
      this.checkBox2 = new CheckBox();
      this.SuspendLayout();
      this.button3.Location = new Point(74, 160);
      this.button3.Name = "button3";
      this.button3.Size = new Size(132, 23);
      this.button3.TabIndex = 13;
      this.button3.Text = "Thêm ";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new EventHandler(this.Button3_Click_1);
      this.button4.Location = new Point(212, 160);
      this.button4.Name = "button4";
      this.button4.Size = new Size(106, 23);
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
      this.listView1.Location = new Point(1, 245);
      this.listView1.Name = "listView1";
      this.listView1.Size = new Size(317, 238);
      this.listView1.TabIndex = 15;
      this.listView1.UseCompatibleStateImageBehavior = false;
      this.listView1.View = View.Details;
      this.columnHeader1.Text = "Name";
      this.columnHeader1.Width = 311;
      this.button1.Location = new Point(252, 187);
      this.button1.Name = "button1";
      this.button1.Size = new Size(66, 23);
      this.button1.TabIndex = 20;
      this.button1.Text = "Get";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.Button1_Click);
      this.label1.AutoSize = true;
      this.label1.Location = new Point(12, 192);
      this.label1.Name = "label1";
      this.label1.Size = new Size(38, 13);
      this.label1.TabIndex = 19;
      this.label1.Text = "Name:";
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Location = new Point(82, 189);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(164, 21);
      this.comboBox1.TabIndex = 18;
      this.button5.Location = new Point(1, 160);
      this.button5.Name = "button5";
      this.button5.Size = new Size(67, 23);
      this.button5.TabIndex = 21;
      this.button5.Text = "Xóa All";
      this.button5.UseVisualStyleBackColor = true;
      this.button5.Click += new EventHandler(this.Button5_Click);
      this.button2.Location = new Point(1, 216);
      this.button2.Name = "button2";
      this.button2.Size = new Size(317, 23);
      this.button2.TabIndex = 22;
      this.button2.Text = "List ";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new EventHandler(this.Button2_Click_1);
      this.radioButton1.AutoSize = true;
      this.radioButton1.Location = new Point(43, 97);
      this.radioButton1.Name = "radioButton1";
      this.radioButton1.Size = new Size(56, 17);
      this.radioButton1.TabIndex = 23;
      this.radioButton1.TabStop = true;
      this.radioButton1.Text = "Tất cả";
      this.radioButton1.UseVisualStyleBackColor = true;
      this.radioButton1.CheckedChanged += new EventHandler(this.radioButton1_CheckedChanged);
      this.radioButton2.AutoSize = true;
      this.radioButton2.Location = new Point(191, 97);
      this.radioButton2.Name = "radioButton2";
      this.radioButton2.Size = new Size(77, 17);
      this.radioButton2.TabIndex = 24;
      this.radioButton2.TabStop = true;
      this.radioButton2.Text = "Danh sách";
      this.radioButton2.UseVisualStyleBackColor = true;
      this.radioButton2.CheckedChanged += new EventHandler(this.radioButton2_CheckedChanged);
      this.button6.Location = new Point(191, 8);
      this.button6.Name = "button6";
      this.button6.Size = new Size(83, 23);
      this.button6.TabIndex = 42;
      this.button6.Text = "Add Skill buff";
      this.button6.UseVisualStyleBackColor = true;
      this.button6.Click += new EventHandler(this.button6_Click);
      this.textBox1.Location = new Point(43, 11);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(142, 20);
      this.textBox1.TabIndex = 41;
      this.textBox2.Location = new Point(43, 37);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new Size(142, 20);
      this.textBox2.TabIndex = 43;
      this.button7.Location = new Point(191, 34);
      this.button7.Name = "button7";
      this.button7.Size = new Size(83, 23);
      this.button7.TabIndex = 44;
      this.button7.Text = "Add Skill buff";
      this.button7.UseVisualStyleBackColor = true;
      this.button7.Click += new EventHandler(this.button7_Click);
      this.button8.Location = new Point(191, 60);
      this.button8.Name = "button8";
      this.button8.Size = new Size(83, 23);
      this.button8.TabIndex = 46;
      this.button8.Text = "Add Skill buff";
      this.button8.UseVisualStyleBackColor = true;
      this.button8.Click += new EventHandler(this.button8_Click);
      this.textBox3.Location = new Point(43, 63);
      this.textBox3.Name = "textBox3";
      this.textBox3.Size = new Size(142, 20);
      this.textBox3.TabIndex = 45;
      this.checkBox1.AutoSize = true;
      this.checkBox1.Location = new Point(43, 137);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new Size(48, 17);
      this.checkBox1.TabIndex = 49;
      this.checkBox1.Text = "Quái";
      this.checkBox1.UseVisualStyleBackColor = true;
      this.checkBox1.CheckedChanged += new EventHandler(this.checkBox1_CheckedChanged);
      this.checkBox2.AutoSize = true;
      this.checkBox2.Location = new Point(191, 137);
      this.checkBox2.Name = "checkBox2";
      this.checkBox2.Size = new Size(77, 17);
      this.checkBox2.TabIndex = 50;
      this.checkBox2.Text = "Người chơi";
      this.checkBox2.UseVisualStyleBackColor = true;
      this.checkBox2.CheckedChanged += new EventHandler(this.checkBox2_CheckedChanged);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(320, 495);
      this.Controls.Add((Control) this.checkBox2);
      this.Controls.Add((Control) this.checkBox1);
      this.Controls.Add((Control) this.button8);
      this.Controls.Add((Control) this.textBox3);
      this.Controls.Add((Control) this.button7);
      this.Controls.Add((Control) this.textBox2);
      this.Controls.Add((Control) this.button6);
      this.Controls.Add((Control) this.textBox1);
      this.Controls.Add((Control) this.radioButton2);
      this.Controls.Add((Control) this.radioButton1);
      this.Controls.Add((Control) this.button2);
      this.Controls.Add((Control) this.button5);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.comboBox1);
      this.Controls.Add((Control) this.listView1);
      this.Controls.Add((Control) this.button4);
      this.Controls.Add((Control) this.button3);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (KillNPC);
      this.Text = "Chém nhau";
      this.Load += new EventHandler(this.KillNPC_Load);
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
      this.player.buffnpclistkill.Add(new Player.NPCinfo()
      {
        Name = this.comboBox1.Text
      });
    }

    private void Button4_Click(object sender, EventArgs e)
    {
      if (this.listView1.SelectedItems.Count <= 0)
        return;
      this.player.buffnpclistkill.Remove(this.player.buffnpclistkill.FirstOrDefault<Player.NPCinfo>((Func<Player.NPCinfo, bool>) (x => x.Name == this.listView1.SelectedItems[0].SubItems[0].Text)));
      this.listView1.Items.Clear();
      foreach (Player.NPCinfo npCinfo in this.player.buffnpclistkill)
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
        if (this.player.buffchedo2 == 0 && npc.type == 0U)
        {
          this.comboBox1.Items.Add((object) npc.Name);
          this.oldKX.Name = npc.Name;
          this.oldKX.id = npc.id;
          this.comboBox1.SelectedIndex = 0;
        }
        if (this.player.buffchedo2 == 1 && npc.type == 5U)
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
      this.player.buffnpclistkill.Clear();
    }

    private void Button2_Click_1(object sender, EventArgs e)
    {
      this.listView1.Items.Clear();
      this.player.buffnpclistkill.Clear();
      foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
      {
        if (this.player.buffchedo2 == 0 && npc.type == 0U)
        {
          this.listView1.Items.Add(new ListViewItem(new string[1]
          {
            npc.Name
          }));
          this.player.buffnpclistkill.Add(new Player.NPCinfo()
          {
            Name = npc.Name
          });
        }
        if (this.player.buffchedo2 == 1 && npc.type == 5U)
        {
          this.listView1.Items.Add(new ListViewItem(new string[1]
          {
            npc.Name
          }));
          this.player.buffnpclistkill.Add(new Player.NPCinfo()
          {
            Name = npc.Name
          });
        }
      }
    }

    private void button6_Click(object sender, EventArgs e)
    {
      if (ReadMem.Idskill(this.player.HProcess) == 0U)
      {
        int num = (int) MessageBox.Show("Bạn phải chọn skill trước!!", "Thông báo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      if (ReadMem.Idskill(this.player.HProcess) < 100U && ReadMem.Idskill(this.player.HProcess) > 0U)
      {
        this.textBox1.Text = int.Parse(Convert.ToString((long) ReadMem.Lvskill(this.player.HProcess), 16) + "00" + Convert.ToString((long) ReadMem.Idskill(this.player.HProcess), 16), NumberStyles.HexNumber).ToString();
        this.player.skill1 = int.Parse(this.textBox1.Text);
      }
      if (ReadMem.Idskill(this.player.HProcess) >= 100U && ReadMem.Idskill(this.player.HProcess) < 256U)
      {
        this.textBox1.Text = int.Parse(Convert.ToString((long) ReadMem.Lvskill(this.player.HProcess), 16) + "00" + Convert.ToString((long) ReadMem.Idskill(this.player.HProcess), 16), NumberStyles.HexNumber).ToString();
        this.player.skill1 = int.Parse(this.textBox1.Text);
      }
      if (ReadMem.Idskill(this.player.HProcess) < 256U)
        return;
      this.textBox1.Text = int.Parse(Convert.ToString((long) ReadMem.Lvskill(this.player.HProcess), 16) + "0" + Convert.ToString((long) ReadMem.Idskill(this.player.HProcess), 16), NumberStyles.HexNumber).ToString();
      this.player.skill1 = int.Parse(this.textBox1.Text);
    }

    private void radioButton1_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.radioButton1.Checked)
        return;
      this.player.buffchedo1 = 0;
      this.radioButton2.Checked = false;
    }

    private void radioButton2_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.radioButton2.Checked)
        return;
      this.player.buffchedo1 = 1;
      this.radioButton1.Checked = false;
    }

    private void button7_Click(object sender, EventArgs e)
    {
      if (ReadMem.Idskill(this.player.HProcess) == 0U)
      {
        int num = (int) MessageBox.Show("Bạn phải chọn skill trước!!", "Thông báo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      if (ReadMem.Idskill(this.player.HProcess) < 100U && ReadMem.Idskill(this.player.HProcess) > 0U)
      {
        this.textBox2.Text = int.Parse(Convert.ToString((long) ReadMem.Lvskill(this.player.HProcess), 16) + "00" + Convert.ToString((long) ReadMem.Idskill(this.player.HProcess), 16), NumberStyles.HexNumber).ToString();
        this.player.skill2 = int.Parse(this.textBox2.Text);
      }
      if (ReadMem.Idskill(this.player.HProcess) >= 100U && ReadMem.Idskill(this.player.HProcess) < 256U)
      {
        this.textBox2.Text = int.Parse(Convert.ToString((long) ReadMem.Lvskill(this.player.HProcess), 16) + "00" + Convert.ToString((long) ReadMem.Idskill(this.player.HProcess), 16), NumberStyles.HexNumber).ToString();
        this.player.skill2 = int.Parse(this.textBox2.Text);
      }
      if (ReadMem.Idskill(this.player.HProcess) < 256U)
        return;
      this.textBox2.Text = int.Parse(Convert.ToString((long) ReadMem.Lvskill(this.player.HProcess), 16) + "0" + Convert.ToString((long) ReadMem.Idskill(this.player.HProcess), 16), NumberStyles.HexNumber).ToString();
      this.player.skill2 = int.Parse(this.textBox2.Text);
    }

    private void button8_Click(object sender, EventArgs e)
    {
      if (ReadMem.Idskill(this.player.HProcess) == 0U)
      {
        int num = (int) MessageBox.Show("Bạn phải chọn skill trước!!", "Thông báo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      if (ReadMem.Idskill(this.player.HProcess) < 100U && ReadMem.Idskill(this.player.HProcess) > 0U)
      {
        this.textBox3.Text = int.Parse(Convert.ToString((long) ReadMem.Lvskill(this.player.HProcess), 16) + "00" + Convert.ToString((long) ReadMem.Idskill(this.player.HProcess), 16), NumberStyles.HexNumber).ToString();
        this.player.skill3 = int.Parse(this.textBox3.Text);
      }
      if (ReadMem.Idskill(this.player.HProcess) >= 100U && ReadMem.Idskill(this.player.HProcess) < 256U)
      {
        this.textBox3.Text = int.Parse(Convert.ToString((long) ReadMem.Lvskill(this.player.HProcess), 16) + "00" + Convert.ToString((long) ReadMem.Idskill(this.player.HProcess), 16), NumberStyles.HexNumber).ToString();
        this.player.skill3 = int.Parse(this.textBox3.Text);
      }
      if (ReadMem.Idskill(this.player.HProcess) < 256U)
        return;
      this.textBox3.Text = int.Parse(Convert.ToString((long) ReadMem.Lvskill(this.player.HProcess), 16) + "0" + Convert.ToString((long) ReadMem.Idskill(this.player.HProcess), 16), NumberStyles.HexNumber).ToString();
      this.player.skill3 = int.Parse(this.textBox3.Text);
    }

    private void KillNPC_Load(object sender, EventArgs e)
    {
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.checkBox1.Checked)
        return;
      this.player.buffchedo2 = 0;
      this.checkBox2.Checked = false;
    }

    private void checkBox2_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.checkBox2.Checked)
        return;
      this.player.buffchedo2 = 1;
      this.checkBox1.Checked = false;
    }
  }
}
