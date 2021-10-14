// Decompiled with JetBrains decompiler
// Type: dorajx2.TaoNhom
// Assembly: T2Auto, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3D2B1643-7C06-428B-9BDA-29369F42091D
// Assembly location: C:\Users\itoutsource06\Desktop\AutoT2\Auto Jx2\T2Auto.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace dorajx2
{
  public class TaoNhom : Form
  {
    public static string[] NameDong = new string[31]
    {
      "Không Sử Dụng",
      "Dòng 1",
      "Dòng 2",
      "Dòng 3",
      "Dòng 4",
      "Dòng 5",
      "Dòng 6",
      "Dòng 7",
      "Dòng 8",
      "Dòng 9",
      "Dòng 10",
      "Dòng 11",
      "Dòng 12",
      "Dòng 13",
      "Dòng 14",
      "Dòng 15",
      "Dòng 16",
      "Dòng 17",
      "Dòng 18",
      "Dòng 19",
      "Dòng 20",
      "Dòng 21",
      "Dòng 22",
      "Dòng 23",
      "Dòng 24",
      "Dòng 25",
      "Dòng 26",
      "Dòng 27",
      "Dòng 28",
      "Dòng 29",
      "Dòng 30"
    };
    private List<Player.Item> listItem = new List<Player.Item>();
    private IContainer components = (IContainer) null;
    private Player player;
    private IntPtr Module;
    private ComboBox comboBox1;
    private Label label2;
    private CheckBox cbTheoSau;
    private GroupBox groupBox1;
    private CheckBox checkBox1;
    private CheckBox checkBox2;
    private GroupBox groupBox2;
    private Button button1;

    public TaoNhom(Client client)
    {
      this.InitializeComponent();
      this.player = client.player;
      this.Module = client.Module;
      if (!client.IsChecked)
        return;
      this.cbTheoSau.Checked = this.player.isTheoSau;
      this.comboBox1.Text = this.player.PT.nametheosau;
      this.checkBox1.Checked = this.player.isTruongNhom;
      this.checkBox2.Checked = this.player.isNhanLM;
    }

    private void Button1_Click(object sender, EventArgs e)
    {
      this.comboBox1.Items.Clear();
      this.listItem.Clear();
      foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
      {
        if (npc.type == 5U)
        {
          this.comboBox1.Items.Add((object) npc.Name);
          this.comboBox1.SelectedIndex = 0;
        }
      }
    }

    private void UseGmItem_Load(object sender, EventArgs e)
    {
    }

    private void Button2_Click(object sender, EventArgs e)
    {
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (TaoNhom));
      this.comboBox1 = new ComboBox();
      this.label2 = new Label();
      this.button1 = new Button();
      this.cbTheoSau = new CheckBox();
      this.groupBox1 = new GroupBox();
      this.checkBox1 = new CheckBox();
      this.checkBox2 = new CheckBox();
      this.groupBox2 = new GroupBox();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Location = new Point(85, 16);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(149, 21);
      this.comboBox1.TabIndex = 0;
      this.comboBox1.SelectedIndexChanged += new EventHandler(this.comboBox1_SelectedIndexChanged);
      this.label2.AutoSize = true;
      this.label2.Location = new Point(27, 19);
      this.label2.Name = "label2";
      this.label2.Size = new Size(45, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "Bắt đầu";
      this.label2.Visible = false;
      this.button1.Location = new Point(254, 14);
      this.button1.Name = "button1";
      this.button1.Size = new Size(75, 23);
      this.button1.TabIndex = 4;
      this.button1.Text = "Get";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.Button1_Click);
      this.cbTheoSau.AutoSize = true;
      this.cbTheoSau.Location = new Point(6, 19);
      this.cbTheoSau.Name = "cbTheoSau";
      this.cbTheoSau.Size = new Size(15, 14);
      this.cbTheoSau.TabIndex = 5;
      this.cbTheoSau.UseVisualStyleBackColor = true;
      this.cbTheoSau.Visible = false;
      this.cbTheoSau.CheckedChanged += new EventHandler(this.checkBox1_CheckedChanged);
      this.groupBox1.Controls.Add((Control) this.comboBox1);
      this.groupBox1.Controls.Add((Control) this.button1);
      this.groupBox1.Controls.Add((Control) this.cbTheoSau);
      this.groupBox1.Controls.Add((Control) this.label2);
      this.groupBox1.Location = new Point(12, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(335, 50);
      this.groupBox1.TabIndex = 6;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Theo sau";
      this.checkBox1.AutoSize = true;
      this.checkBox1.Location = new Point(6, 23);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new Size(123, 17);
      this.checkBox1.TabIndex = 6;
      this.checkBox1.Text = "Tạo nhóm mời tất cả";
      this.checkBox1.UseVisualStyleBackColor = true;
      this.checkBox1.CheckedChanged += new EventHandler(this.checkBox1_CheckedChanged_1);
      this.checkBox2.AutoSize = true;
      this.checkBox2.Location = new Point(6, 46);
      this.checkBox2.Name = "checkBox2";
      this.checkBox2.Size = new Size(84, 17);
      this.checkBox2.TabIndex = 7;
      this.checkBox2.Text = "Nhận lời mời";
      this.checkBox2.UseVisualStyleBackColor = true;
      this.checkBox2.CheckedChanged += new EventHandler(this.checkBox2_CheckedChanged);
      this.groupBox2.Controls.Add((Control) this.checkBox1);
      this.groupBox2.Controls.Add((Control) this.checkBox2);
      this.groupBox2.Enabled = false;
      this.groupBox2.Location = new Point(12, 68);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(335, 68);
      this.groupBox2.TabIndex = 8;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "AutoPt";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(359, 67);
      this.Controls.Add((Control) this.groupBox2);
      this.Controls.Add((Control) this.groupBox1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (TaoNhom);
      this.Text = "UseGmItem";
      this.Load += new EventHandler(this.UseGmItem_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.ResumeLayout(false);
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
      this.player.isTheoSau = this.cbTheoSau.Checked;
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.player.PT.nametheosau = this.comboBox1.Text;
    }

    private void button2_Click_1(object sender, EventArgs e)
    {
      this.player.PT.nametheosau = this.comboBox1.Text;
      this.player.SaveData();
    }

    private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
    {
      this.player.isTruongNhom = this.checkBox1.Checked;
    }

    private void checkBox2_CheckedChanged(object sender, EventArgs e)
    {
      this.player.isNhanLM = this.checkBox2.Checked;
    }
  }
}
