// Decompiled with JetBrains decompiler
// Type: dorajx2.xdame
// Assembly: T2Auto, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3D2B1643-7C06-428B-9BDA-29369F42091D
// Assembly location: C:\Users\itoutsource06\Desktop\AutoT2\Auto Jx2\T2Auto.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace dorajx2
{
  public class xdame : Form
  {
    private List<Player.Item> listItem = new List<Player.Item>();
    private List<Player.Item> listItemOld = new List<Player.Item>();
    private Player.Item oldKX = new Player.Item();
    private IContainer components = (IContainer) null;
    private List<Player.Item> _listItem = new List<Player.Item>();
    private Player player;
    private Label label1;
    private Label label2;
    private TextBox textBox1;
    private Label label3;
    private TextBox textBox2;
    private Label label4;
    private TextBox textBox3;
    private Button button1;
    private Button button2;
    private Label label5;
    private ComboBox cbphimbo1;

    public xdame(Client client)
    {
      this.InitializeComponent();
      this.player = client.player;
      if (!client.IsChecked)
        return;
      this.cbphimbo1.SelectedItem = (object) this.player.cobophimxdame;
      TextBox textBox1 = this.textBox1;
      int num = this.player.phatdongxdame;
      string str1 = num.ToString();
      textBox1.Text = str1;
      TextBox textBox2 = this.textBox2;
      num = this.player.xdame;
      string str2 = num.ToString();
      textBox2.Text = str2;
      TextBox textBox3 = this.textBox3;
      num = this.player.txdame;
      string str3 = num.ToString();
      textBox3.Text = str3;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (xdame));
      this.label1 = new Label();
      this.cbphimbo1 = new ComboBox();
      this.label2 = new Label();
      this.textBox1 = new TextBox();
      this.label3 = new Label();
      this.textBox2 = new TextBox();
      this.label4 = new Label();
      this.textBox3 = new TextBox();
      this.button1 = new Button();
      this.button2 = new Button();
      this.label5 = new Label();
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.Location = new Point(12, 20);
      this.label1.Name = "label1";
      this.label1.Size = new Size(62, 13);
      this.label1.TabIndex = 29;
      this.label1.Text = "Phím tắt 01";
      this.cbphimbo1.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbphimbo1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbphimbo1.FormattingEnabled = true;
      this.cbphimbo1.Items.AddRange(new object[45]
      {
        (object) "F1, Control",
        (object) "F2, Control",
        (object) "F3, Control",
        (object) "F4, Control",
        (object) "F5, Control",
        (object) "F6, Control",
        (object) "F7, Control",
        (object) "F8, Control",
        (object) "F9, Control",
        (object) "F10, Control",
        (object) "F1, Shift",
        (object) "F2, Shift",
        (object) "F3, Shift",
        (object) "F4, Shift",
        (object) "F5, Shift",
        (object) "F6, Shift",
        (object) "F7, Shift",
        (object) "F8, Shift",
        (object) "F9, Shift",
        (object) "F10, Shift",
        (object) "F1",
        (object) "F2",
        (object) "F3",
        (object) "F4",
        (object) "F5",
        (object) "F6",
        (object) "F7",
        (object) "F8",
        (object) "F9",
        (object) "F10",
        (object) "A",
        (object) "B",
        (object) "C",
        (object) "D",
        (object) "E",
        (object) "F",
        (object) "G",
        (object) "H",
        (object) "Q",
        (object) "W",
        (object) "E",
        (object) "R",
        (object) "Z",
        (object) "X",
        (object) "C"
      });
      this.cbphimbo1.Location = new Point(12, 36);
      this.cbphimbo1.Name = "cbphimbo1";
      this.cbphimbo1.Size = new Size(141, 23);
      this.cbphimbo1.TabIndex = 33;
      this.cbphimbo1.SelectedIndexChanged += new EventHandler(this.Cbphimbo1_SelectedIndexChanged);
      this.label2.AutoSize = true;
      this.label2.Location = new Point(163, 20);
      this.label2.Name = "label2";
      this.label2.Size = new Size(86, 13);
      this.label2.TabIndex = 34;
      this.label2.Text = "Chiêu phát động";
      this.textBox1.Location = new Point(166, 39);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(83, 20);
      this.textBox1.TabIndex = 35;
      this.textBox1.KeyPress += new KeyPressEventHandler(this.TextBox1_KeyPress);
      this.label3.AutoSize = true;
      this.label3.Location = new Point(265, 20);
      this.label3.Name = "label3";
      this.label3.Size = new Size(79, 13);
      this.label3.TabIndex = 36;
      this.label3.Text = "Chiêu tấn công";
      this.textBox2.Location = new Point(268, 39);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new Size(76, 20);
      this.textBox2.TabIndex = 37;
      this.textBox2.KeyPress += new KeyPressEventHandler(this.TextBox2_KeyPress);
      this.label4.AutoSize = true;
      this.label4.Location = new Point(350, 20);
      this.label4.Name = "label4";
      this.label4.Size = new Size(75, 13);
      this.label4.TabIndex = 38;
      this.label4.Text = "Thời gian ngắt";
      this.textBox3.Location = new Point(353, 39);
      this.textBox3.Name = "textBox3";
      this.textBox3.Size = new Size(72, 20);
      this.textBox3.TabIndex = 39;
      this.textBox3.TextChanged += new EventHandler(this.TextBox3_TextChanged);
      this.textBox3.KeyPress += new KeyPressEventHandler(this.TextBox3_KeyPress);
      this.button1.Location = new Point(166, 65);
      this.button1.Name = "button1";
      this.button1.Size = new Size(83, 23);
      this.button1.TabIndex = 40;
      this.button1.Text = "Add";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.Button1_Click);
      this.button2.Location = new Point(268, 65);
      this.button2.Name = "button2";
      this.button2.Size = new Size(76, 23);
      this.button2.TabIndex = 41;
      this.button2.Text = "Add";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new EventHandler(this.Button2_Click);
      this.label5.AutoSize = true;
      this.label5.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label5.Location = new Point(363, 65);
      this.label5.Name = "label5";
      this.label5.Size = new Size(37, 16);
      this.label5.TabIndex = 42;
      this.label5.Text = "t(ms)";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(431, 95);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.button2);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.textBox3);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.textBox2);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.textBox1);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.cbphimbo1);
      this.Controls.Add((Control) this.label1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (xdame);
      this.Text = "Xdame";
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private void Cbphimbo1_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.player.cobophimxdame = this.cbphimbo1.Text;
    }

    private void TextBox3_KeyPress(object sender, KeyPressEventArgs e)
    {
      if ("0123456789".IndexOf(e.KeyChar) != -1)
        e.Handled = false;
      else if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
        e.Handled = true;
    }

    private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
    {
      if ("0123456789".IndexOf(e.KeyChar) != -1)
        e.Handled = false;
      else if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
        e.Handled = true;
    }

    private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
      if ("0123456789".IndexOf(e.KeyChar) != -1)
        e.Handled = false;
      else if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
        e.Handled = true;
    }

    private void Button1_Click(object sender, EventArgs e)
    {
      if (ReadMem.Idskill(this.player.HProcess) == 0U)
      {
        int num = (int) MessageBox.Show("Bạn phải chọn skill trước!!", "Thông báo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      if (ReadMem.Idskill(this.player.HProcess) < 100U && ReadMem.Idskill(this.player.HProcess) > 0U)
      {
        this.textBox1.Text = int.Parse(Convert.ToString((long) ReadMem.Lvskill(this.player.HProcess), 16) + "00" + Convert.ToString((long) ReadMem.Idskill(this.player.HProcess), 16), NumberStyles.HexNumber).ToString();
        this.player.phatdongxdame = int.Parse(this.textBox1.Text);
      }
      if (ReadMem.Idskill(this.player.HProcess) >= 100U && ReadMem.Idskill(this.player.HProcess) < 256U)
      {
        this.textBox1.Text = int.Parse(Convert.ToString((long) ReadMem.Lvskill(this.player.HProcess), 16) + "00" + Convert.ToString((long) ReadMem.Idskill(this.player.HProcess), 16), NumberStyles.HexNumber).ToString();
        this.player.phatdongxdame = int.Parse(this.textBox1.Text);
      }
      if (ReadMem.Idskill(this.player.HProcess) < 256U)
        return;
      this.textBox1.Text = int.Parse(Convert.ToString((long) ReadMem.Lvskill(this.player.HProcess), 16) + "0" + Convert.ToString((long) ReadMem.Idskill(this.player.HProcess), 16), NumberStyles.HexNumber).ToString();
      this.player.phatdongxdame = int.Parse(this.textBox1.Text);
    }

    private void Button2_Click(object sender, EventArgs e)
    {
      if (ReadMem.Idskill(this.player.HProcess) == 0U)
      {
        int num = (int) MessageBox.Show("Bạn phải chọn skill trước!!", "Thông báo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      if (ReadMem.Idskill(this.player.HProcess) < 100U && ReadMem.Idskill(this.player.HProcess) > 0U)
      {
        this.textBox2.Text = int.Parse(Convert.ToString((long) ReadMem.Lvskill(this.player.HProcess), 16) + "00" + Convert.ToString((long) ReadMem.Idskill(this.player.HProcess), 16), NumberStyles.HexNumber).ToString();
        this.player.xdame = int.Parse(this.textBox2.Text);
      }
      if (ReadMem.Idskill(this.player.HProcess) >= 100U && ReadMem.Idskill(this.player.HProcess) < 256U)
      {
        this.textBox2.Text = int.Parse(Convert.ToString((long) ReadMem.Lvskill(this.player.HProcess), 16) + "00" + Convert.ToString((long) ReadMem.Idskill(this.player.HProcess), 16), NumberStyles.HexNumber).ToString();
        this.player.xdame = int.Parse(this.textBox2.Text);
      }
      if (ReadMem.Idskill(this.player.HProcess) < 256U)
        return;
      this.textBox2.Text = int.Parse(Convert.ToString((long) ReadMem.Lvskill(this.player.HProcess), 16) + "0" + Convert.ToString((long) ReadMem.Idskill(this.player.HProcess), 16), NumberStyles.HexNumber).ToString();
      this.player.xdame = int.Parse(this.textBox2.Text);
    }

    private void TextBox3_TextChanged(object sender, EventArgs e)
    {
      this.player.txdame = int.Parse(this.textBox3.Text);
    }
  }
}
