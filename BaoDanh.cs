// Decompiled with JetBrains decompiler
// Type: dorajx2.BaoDanh
// Assembly: T2Auto, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3D2B1643-7C06-428B-9BDA-29369F42091D
// Assembly location: C:\Users\itoutsource06\Desktop\AutoT2\Auto Jx2\T2Auto.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace dorajx2
{
  public class BaoDanh : Form
  {
    private IContainer components = (IContainer) null;
    private Player player;
    private CheckBox checkBox1;
    private CheckBox checkBox2;
    private ComboBox comboBox1;
    private Label label1;
    private ComboBox comboBox2;

    public BaoDanh(Client client)
    {
      this.InitializeComponent();
      this.player = client.player;
      if (!client.IsChecked)
        return;
      this.checkBox1.Checked = this.player.isDBCTC;
      this.checkBox2.Checked = !this.checkBox1.Checked;
      this.comboBox1.Items.AddRange((object[]) new string[4]
      {
        "Tiểu Phương",
        "Mộ Binh Quan phe Tống",
        "Tiểu Ngọc",
        "Mộ Binh Quan phe Liêu"
      });
      this.comboBox1.SelectedIndex = 0;
      this.comboBox2.Items.AddRange((object[]) new string[3]
      {
        "Thôn Trang",
        "Tài Nguyên",
        "Pháo Đài"
      });
      this.comboBox2.SelectedIndex = 0;
    }

    private void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.checkBox1.Checked)
        return;
      this.player.isDBCTC = true;
      this.checkBox2.Checked = false;
      this.comboBox2.Enabled = false;
    }

    private void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.checkBox2.Checked)
        return;
      this.player.isDBCTC = false;
      this.checkBox1.Checked = false;
      this.comboBox2.Enabled = true;
    }

    private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.player.NPCBB_Name = this.comboBox1.Text;
    }

    private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.player.CTP_Name = this.comboBox2.Text;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.checkBox1 = new CheckBox();
      this.checkBox2 = new CheckBox();
      this.comboBox1 = new ComboBox();
      this.label1 = new Label();
      this.comboBox2 = new ComboBox();
      this.SuspendLayout();
      this.checkBox1.AutoSize = true;
      this.checkBox1.Location = new Point(11, 52);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new Size(122, 17);
      this.checkBox1.TabIndex = 0;
      this.checkBox1.Text = "Chiến Trường Chính";
      this.checkBox1.UseVisualStyleBackColor = true;
      this.checkBox1.CheckedChanged += new EventHandler(this.CheckBox1_CheckedChanged);
      this.checkBox2.AutoSize = true;
      this.checkBox2.Location = new Point(11, 85);
      this.checkBox2.Name = "checkBox2";
      this.checkBox2.Size = new Size(112, 17);
      this.checkBox2.TabIndex = 1;
      this.checkBox2.Text = "Chiến Trường Phụ";
      this.checkBox2.UseVisualStyleBackColor = true;
      this.checkBox2.CheckedChanged += new EventHandler(this.CheckBox2_CheckedChanged);
      this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Location = new Point(41, 12);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(166, 21);
      this.comboBox1.TabIndex = 2;
      this.comboBox1.SelectedIndexChanged += new EventHandler(this.ComboBox1_SelectedIndexChanged);
      this.label1.AutoSize = true;
      this.label1.Location = new Point(6, 15);
      this.label1.Name = "label1";
      this.label1.Size = new Size(29, 13);
      this.label1.TabIndex = 3;
      this.label1.Text = "NPC";
      this.comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox2.Enabled = false;
      this.comboBox2.FormattingEnabled = true;
      this.comboBox2.Location = new Point(135, 83);
      this.comboBox2.Name = "comboBox2";
      this.comboBox2.Size = new Size(123, 21);
      this.comboBox2.TabIndex = 4;
      this.comboBox2.SelectedIndexChanged += new EventHandler(this.ComboBox2_SelectedIndexChanged);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(270, 116);
      this.Controls.Add((Control) this.comboBox2);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.comboBox1);
      this.Controls.Add((Control) this.checkBox2);
      this.Controls.Add((Control) this.checkBox1);
      this.Name = nameof (BaoDanh);
      this.Text = nameof (BaoDanh);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
