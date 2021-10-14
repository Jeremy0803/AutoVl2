// Decompiled with JetBrains decompiler
// Type: dorajx2.AutoPK
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
  public class AutoPK : Form
  {
    private List<Player.NPCinfo> listItem = new List<Player.NPCinfo>();
    private List<Player.NPCinfo> listItemOld = new List<Player.NPCinfo>();
    private Player.NPCinfo oldKX = new Player.NPCinfo();
    private IContainer components = (IContainer) null;
    private List<Player.NPCinfo> _listItem = new List<Player.NPCinfo>();
    private Player player;
    private GroupBox groupBox1;
    private Label label1;
    private CheckBox checkAnCo;
    private ComboBox cbphimbo1;
    private ComboBox comboBox1;

    public AutoPK(Client client)
    {
      this.InitializeComponent();
      this.player = client.player;
      if (!client.IsChecked)
        return;
      this.checkAnCo.Checked = this.player.minhgiaoanco;
      this.cbphimbo1.Text = this.player.cobophimanco;
      this.comboBox1.Text = this.player.cobophimanco1;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (AutoPK));
      this.groupBox1 = new GroupBox();
      this.comboBox1 = new ComboBox();
      this.cbphimbo1 = new ComboBox();
      this.label1 = new Label();
      this.checkAnCo = new CheckBox();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      this.groupBox1.Controls.Add((Control) this.comboBox1);
      this.groupBox1.Controls.Add((Control) this.cbphimbo1);
      this.groupBox1.Controls.Add((Control) this.label1);
      this.groupBox1.Controls.Add((Control) this.checkAnCo);
      this.groupBox1.Location = new Point(8, 9);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(305, 91);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Minh Giáo Bút";
      this.comboBox1.FlatStyle = FlatStyle.Popup;
      this.comboBox1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Items.AddRange(new object[74]
      {
        (object) "A, Control",
        (object) "S, Control",
        (object) "F, Control",
        (object) "D, Control",
        (object) "Z, Control",
        (object) "X, Control",
        (object) "C, Control",
        (object) "Q, Control",
        (object) "W, Control",
        (object) "E, Control",
        (object) "A, Shift",
        (object) "S, Shift",
        (object) "F, Shift",
        (object) "D, Shift",
        (object) "Z, Shift",
        (object) "X, Shift",
        (object) "C, Shift",
        (object) "Q, Shift",
        (object) "W, Shift",
        (object) "E, Shift",
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
        (object) "C",
        (object) "1",
        (object) "2",
        (object) "3",
        (object) "4",
        (object) "5",
        (object) "6",
        (object) "7",
        (object) "8",
        (object) "9"
      });
      this.comboBox1.Location = new Point(134, 24);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(141, 23);
      this.comboBox1.TabIndex = 54;
      this.comboBox1.SelectedIndexChanged += new EventHandler(this.comboBox1_SelectedIndexChanged);
      this.cbphimbo1.FlatStyle = FlatStyle.Popup;
      this.cbphimbo1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbphimbo1.FormattingEnabled = true;
      this.cbphimbo1.Items.AddRange(new object[74]
      {
        (object) "A, Control",
        (object) "S, Control",
        (object) "F, Control",
        (object) "D, Control",
        (object) "Z, Control",
        (object) "X, Control",
        (object) "C, Control",
        (object) "Q, Control",
        (object) "W, Control",
        (object) "E, Control",
        (object) "A, Shift",
        (object) "S, Shift",
        (object) "F, Shift",
        (object) "D, Shift",
        (object) "Z, Shift",
        (object) "X, Shift",
        (object) "C, Shift",
        (object) "Q, Shift",
        (object) "W, Shift",
        (object) "E, Shift",
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
        (object) "C",
        (object) "1",
        (object) "2",
        (object) "3",
        (object) "4",
        (object) "5",
        (object) "6",
        (object) "7",
        (object) "8",
        (object) "9"
      });
      this.cbphimbo1.Location = new Point(134, 53);
      this.cbphimbo1.Name = "cbphimbo1";
      this.cbphimbo1.Size = new Size(141, 23);
      this.cbphimbo1.TabIndex = 53;
      this.cbphimbo1.SelectedIndexChanged += new EventHandler(this.cbphimbo1_SelectedIndexChanged);
      this.label1.AutoSize = true;
      this.label1.Location = new Point(39, 58);
      this.label1.Name = "label1";
      this.label1.Size = new Size(78, 13);
      this.label1.TabIndex = 52;
      this.label1.Text = "Phím tắt bẻ Cờ";
      this.checkAnCo.AutoSize = true;
      this.checkAnCo.Location = new Point(15, 28);
      this.checkAnCo.Name = "checkAnCo";
      this.checkAnCo.Size = new Size(113, 17);
      this.checkAnCo.TabIndex = 51;
      this.checkAnCo.Text = "Tự động thả 5 linh";
      this.checkAnCo.UseVisualStyleBackColor = true;
      this.checkAnCo.CheckedChanged += new EventHandler(this.checkBox2_CheckedChanged_1);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(320, 495);
      this.Controls.Add((Control) this.groupBox1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (AutoPK);
      this.Text = "Chém nhau";
      this.Load += new EventHandler(this.KillNPC_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
    }

    private void KillNPC_Load(object sender, EventArgs e)
    {
    }

    private void checkBox2_CheckedChanged(object sender, EventArgs e)
    {
    }

    private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
    {
      this.player.minhgiaoanco = this.checkAnCo.Checked;
    }

    private void cbphimbo1_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.player.cobophimanco = this.cbphimbo1.Text;
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.player.cobophimanco1 = this.comboBox1.Text;
    }
  }
}
