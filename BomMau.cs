// Decompiled with JetBrains decompiler
// Type: dorajx2.BomMau
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
  public class BomMau : Form
  {
    private IContainer components = (IContainer) null;
    private List<Client> listClient;
    private Player player;
    private Client client;
    private ComboBox cbbDo;
    private ComboBox cbbXanh;
    private ComboBox cbbVang;
    private CheckBox cbDo;
    private CheckBox cbXanh;
    private CheckBox cbVang;
    private NumericUpDown numericUpDown1;
    private NumericUpDown numericUpDown2;
    private NumericUpDown numericUpDown3;
    private Label label1;
    private Label label2;
    private Label label3;
    private Button button1;
    private Button button2;
    private Button button3;

    public BomMau(Client _client, List<Client> _listClient)
    {
      this.InitializeComponent();
      this.player = _client.player;
      this.client = _client;
      this.listClient = _listClient;
      if (!this.client.IsChecked)
        return;
      this.cbDo.Checked = this.player.SDBomMau.isdo;
      this.cbXanh.Checked = this.player.SDBomMau.isxanh;
      this.cbVang.Checked = this.player.SDBomMau.isvang;
      this.cbbDo.Text = this.player.SDBomMau.Do;
      this.cbbXanh.Text = this.player.SDBomMau.Xanh;
      this.cbbVang.Text = this.player.SDBomMau.Vang;
      this.numericUpDown1.Value = (Decimal) this.player.SDBomMau.dopercent;
      this.numericUpDown2.Value = (Decimal) this.player.SDBomMau.xanhpercent;
      this.numericUpDown3.Value = (Decimal) this.player.SDBomMau.vangpercent;
    }

    private void Button1_Click(object sender, EventArgs e)
    {
      this.cbbDo.Items.Clear();
      this.cbbXanh.Items.Clear();
      this.cbbVang.Items.Clear();
      foreach (Player.Item obj in ReadMem.GetItemList(this.player.HProcess))
      {
        if (obj.type == 2U && obj.Duocpham == "Dược phẩm")
        {
          this.cbbDo.Items.Add((object) obj.Name);
          this.cbbXanh.Items.Add((object) obj.Name);
          this.cbbVang.Items.Add((object) obj.Name);
        }
      }
      try
      {
        this.cbbDo.SelectedIndex = 0;
        this.cbbXanh.SelectedIndex = 0;
        this.cbbVang.SelectedIndex = 0;
      }
      catch
      {
      }
    }

    private void Button2_Click(object sender, EventArgs e)
    {
      this.player.SDBomMau.isdo = this.cbDo.Checked;
      this.player.SDBomMau.isxanh = this.cbXanh.Checked;
      this.player.SDBomMau.isvang = this.cbVang.Checked;
      this.player.SDBomMau.Do = this.cbbDo.Text;
      this.player.SDBomMau.Xanh = this.cbbXanh.Text;
      this.player.SDBomMau.Vang = this.cbbVang.Text;
      this.player.SDBomMau.dopercent = (int) this.numericUpDown1.Value;
      this.player.SDBomMau.xanhpercent = (int) this.numericUpDown2.Value;
      this.player.SDBomMau.vangpercent = (int) this.numericUpDown3.Value;
      this.player.SaveData();
    }

    private void Button3_Click(object sender, EventArgs e)
    {
      foreach (Client client in this.listClient)
      {
        client.player.SDBomMau.isdo = this.cbDo.Checked;
        client.player.SDBomMau.isxanh = this.cbXanh.Checked;
        client.player.SDBomMau.isvang = this.cbVang.Checked;
        client.player.SDBomMau.Do = this.cbbDo.Text;
        client.player.SDBomMau.Xanh = this.cbbXanh.Text;
        client.player.SDBomMau.Vang = this.cbbVang.Text;
        client.player.SDBomMau.dopercent = (int) this.numericUpDown1.Value;
        client.player.SDBomMau.xanhpercent = (int) this.numericUpDown2.Value;
        client.player.SDBomMau.vangpercent = (int) this.numericUpDown3.Value;
        client.player.SaveData();
      }
    }

    private void cbDo_CheckedChanged(object sender, EventArgs e)
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (BomMau));
      this.cbbDo = new ComboBox();
      this.cbbXanh = new ComboBox();
      this.cbbVang = new ComboBox();
      this.cbDo = new CheckBox();
      this.cbXanh = new CheckBox();
      this.cbVang = new CheckBox();
      this.numericUpDown1 = new NumericUpDown();
      this.numericUpDown2 = new NumericUpDown();
      this.numericUpDown3 = new NumericUpDown();
      this.label1 = new Label();
      this.label2 = new Label();
      this.label3 = new Label();
      this.button1 = new Button();
      this.button2 = new Button();
      this.button3 = new Button();
      this.numericUpDown1.BeginInit();
      this.numericUpDown2.BeginInit();
      this.numericUpDown3.BeginInit();
      this.SuspendLayout();
      this.cbbDo.FormattingEnabled = true;
      this.cbbDo.Location = new Point(65, 12);
      this.cbbDo.Name = "cbbDo";
      this.cbbDo.Size = new Size(178, 21);
      this.cbbDo.TabIndex = 0;
      this.cbbXanh.FormattingEnabled = true;
      this.cbbXanh.Location = new Point(65, 39);
      this.cbbXanh.Name = "cbbXanh";
      this.cbbXanh.Size = new Size(178, 21);
      this.cbbXanh.TabIndex = 1;
      this.cbbVang.FormattingEnabled = true;
      this.cbbVang.Location = new Point(65, 66);
      this.cbbVang.Name = "cbbVang";
      this.cbbVang.Size = new Size(178, 21);
      this.cbbVang.TabIndex = 2;
      this.cbDo.AutoSize = true;
      this.cbDo.Location = new Point(8, 14);
      this.cbDo.Name = "cbDo";
      this.cbDo.Size = new Size(40, 17);
      this.cbDo.TabIndex = 3;
      this.cbDo.Text = "Đỏ";
      this.cbDo.UseVisualStyleBackColor = true;
      this.cbDo.CheckedChanged += new EventHandler(this.cbDo_CheckedChanged);
      this.cbXanh.AutoSize = true;
      this.cbXanh.Location = new Point(8, 41);
      this.cbXanh.Name = "cbXanh";
      this.cbXanh.Size = new Size(51, 17);
      this.cbXanh.TabIndex = 4;
      this.cbXanh.Text = "Xanh";
      this.cbXanh.UseVisualStyleBackColor = true;
      this.cbVang.AutoSize = true;
      this.cbVang.Location = new Point(8, 68);
      this.cbVang.Name = "cbVang";
      this.cbVang.Size = new Size(51, 17);
      this.cbVang.TabIndex = 5;
      this.cbVang.Text = "Vàng";
      this.cbVang.UseVisualStyleBackColor = true;
      this.numericUpDown1.Location = new Point(272, 13);
      this.numericUpDown1.Name = "numericUpDown1";
      this.numericUpDown1.Size = new Size(66, 20);
      this.numericUpDown1.TabIndex = 6;
      this.numericUpDown2.Location = new Point(272, 40);
      this.numericUpDown2.Name = "numericUpDown2";
      this.numericUpDown2.Size = new Size(66, 20);
      this.numericUpDown2.TabIndex = 7;
      this.numericUpDown3.Location = new Point(272, 67);
      this.numericUpDown3.Name = "numericUpDown3";
      this.numericUpDown3.Size = new Size(66, 20);
      this.numericUpDown3.TabIndex = 8;
      this.label1.AutoSize = true;
      this.label1.Location = new Point(249, 15);
      this.label1.Name = "label1";
      this.label1.Size = new Size(15, 13);
      this.label1.TabIndex = 9;
      this.label1.Text = "%";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(251, 42);
      this.label2.Name = "label2";
      this.label2.Size = new Size(15, 13);
      this.label2.TabIndex = 10;
      this.label2.Text = "%";
      this.label3.AutoSize = true;
      this.label3.Location = new Point(249, 69);
      this.label3.Name = "label3";
      this.label3.Size = new Size(15, 13);
      this.label3.TabIndex = 11;
      this.label3.Text = "%";
      this.button1.Location = new Point(360, 12);
      this.button1.Name = "button1";
      this.button1.Size = new Size(75, 23);
      this.button1.TabIndex = 12;
      this.button1.Text = "Get";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.Button1_Click);
      this.button2.Location = new Point(360, 39);
      this.button2.Name = "button2";
      this.button2.Size = new Size(75, 23);
      this.button2.TabIndex = 13;
      this.button2.Text = "Lưu";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new EventHandler(this.Button2_Click);
      this.button3.Location = new Point(360, 68);
      this.button3.Name = "button3";
      this.button3.Size = new Size(75, 23);
      this.button3.TabIndex = 14;
      this.button3.Text = "All acount";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new EventHandler(this.Button3_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.AutoSize = true;
      this.ClientSize = new Size(447, 100);
      this.Controls.Add((Control) this.button3);
      this.Controls.Add((Control) this.button2);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.numericUpDown3);
      this.Controls.Add((Control) this.numericUpDown2);
      this.Controls.Add((Control) this.numericUpDown1);
      this.Controls.Add((Control) this.cbVang);
      this.Controls.Add((Control) this.cbXanh);
      this.Controls.Add((Control) this.cbDo);
      this.Controls.Add((Control) this.cbbVang);
      this.Controls.Add((Control) this.cbbXanh);
      this.Controls.Add((Control) this.cbbDo);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (BomMau);
      this.StartPosition = FormStartPosition.Manual;
      this.Text = nameof (BomMau);
      this.numericUpDown1.EndInit();
      this.numericUpDown2.EndInit();
      this.numericUpDown3.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
