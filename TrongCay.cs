// Decompiled with JetBrains decompiler
// Type: dorajx2.TrongCay
// Assembly: T2Auto, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3D2B1643-7C06-428B-9BDA-29369F42091D
// Assembly location: C:\Users\itoutsource06\Desktop\AutoT2\Auto Jx2\T2Auto.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace dorajx2
{
  public class TrongCay : Form
  {
    private Player.TrongCayinfo trongcay = new Player.TrongCayinfo();
    private IContainer components = (IContainer) null;
    private Player player;
    private CheckBox checkBox1;
    private CheckBox checkBox2;
    private CheckBox checkBox3;
    private Button button1;

    public TrongCay(Client client)
    {
      this.InitializeComponent();
      this.player = client.player;
      if (!client.IsChecked)
        return;
      this.checkBox1.Checked = this.player.TrongCaylist.HG;
      this.checkBox2.Checked = this.player.TrongCaylist.BNN;
      this.checkBox3.Checked = this.player.TrongCaylist.BNL;
    }

    private void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
      if (this.checkBox1.Checked)
        this.trongcay.HG = true;
      else
        this.trongcay.HG = false;
    }

    private void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {
      if (this.checkBox2.Checked)
        this.trongcay.BNN = true;
      else
        this.trongcay.BNN = false;
    }

    private void CheckBox3_CheckedChanged(object sender, EventArgs e)
    {
      if (this.checkBox3.Checked)
        this.trongcay.BNL = true;
      else
        this.trongcay.BNL = false;
    }

    private void Button1_Click(object sender, EventArgs e)
    {
      this.player.TrongCaylist = this.trongcay;
      this.Close();
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
      this.checkBox3 = new CheckBox();
      this.button1 = new Button();
      this.SuspendLayout();
      this.checkBox1.AutoSize = true;
      this.checkBox1.Location = new Point(6, 12);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new Size(72, 17);
      this.checkBox1.TabIndex = 0;
      this.checkBox1.Text = "Hạt giống";
      this.checkBox1.UseVisualStyleBackColor = true;
      this.checkBox1.CheckedChanged += new EventHandler(this.CheckBox1_CheckedChanged);
      this.checkBox2.AutoSize = true;
      this.checkBox2.Location = new Point(6, 35);
      this.checkBox2.Name = "checkBox2";
      this.checkBox2.Size = new Size(107, 17);
      this.checkBox2.TabIndex = 1;
      this.checkBox2.Text = "Cây Bát Nhã nhỏ";
      this.checkBox2.UseVisualStyleBackColor = true;
      this.checkBox2.CheckedChanged += new EventHandler(this.CheckBox2_CheckedChanged);
      this.checkBox3.AutoSize = true;
      this.checkBox3.Location = new Point(6, 58);
      this.checkBox3.Name = "checkBox3";
      this.checkBox3.Size = new Size(103, 17);
      this.checkBox3.TabIndex = 2;
      this.checkBox3.Text = "Cây Bát Nhã lớn";
      this.checkBox3.UseVisualStyleBackColor = true;
      this.checkBox3.CheckedChanged += new EventHandler(this.CheckBox3_CheckedChanged);
      this.button1.Location = new Point(60, 86);
      this.button1.Name = "button1";
      this.button1.Size = new Size(75, 23);
      this.button1.TabIndex = 3;
      this.button1.Text = "Save";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.Button1_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(214, 121);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.checkBox3);
      this.Controls.Add((Control) this.checkBox2);
      this.Controls.Add((Control) this.checkBox1);
      this.Name = nameof (TrongCay);
      this.Text = nameof (TrongCay);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
