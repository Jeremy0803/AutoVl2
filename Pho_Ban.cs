// Decompiled with JetBrains decompiler
// Type: dorajx2.Pho_Ban
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
  public class Pho_Ban : Form
  {
    private Player.PhoBan dpb = new Player.PhoBan();
    private IContainer components = (IContainer) null;
    public Pho_Ban.PassControl passControl;
    private Player player;
    private bool activeall;
    private List<Client> listClient;
    private GroupBox groupBox3;
    private CheckBox checkBox_ruongBac;
    private CheckBox checkBox_RvThuPhi;
    private CheckBox checkBox_ruongDong;
    private CheckBox checkBox_RvangFree;
    private GroupBox groupBox4;
    private RadioButton radioButton_Nhanh;
    private RadioButton radioButton_Full;
    private CheckBox checkBox_AutoPhoBan;
    private GroupBox groupBox6;
    private ComboBox comboBox_Map;
    private GroupBox groupBox1;
    private RadioButton radioButton1;
    private RadioButton radioButton2;
    private GroupBox groupBox2;
    private CheckBox checkBox1;
    private CheckBox checkBox2;
    private CheckBox checkBox3;
    private TrackBar trackBar1;
    private GroupBox groupBox5;
    private Label label1;
    private ComboBox comboBox1;
    private GroupBox groupBox7;
    private ComboBox comboBox2;
    private Button button1;

    public Pho_Ban(Client client, List<Client> _listClient)
    {
      this.InitializeComponent();
      if (client == null)
        return;
      this.listClient = _listClient;
      this.player = client.player;
      this.activeall = client.player.isPhoBan;
      if (client.IsChecked)
      {
        this.comboBox_Map.SelectedIndex = 0;
        if (this.player.DiPhoBan.KieuDiAi == 0)
        {
          this.radioButton_Full.Checked = false;
          this.radioButton_Nhanh.Checked = true;
        }
        else if (this.player.DiPhoBan.KieuDiAi == 1)
        {
          this.radioButton_Full.Checked = true;
          this.radioButton_Nhanh.Checked = false;
        }
        if (this.player.DiPhoBan.CheDo == 0)
        {
          this.radioButton2.Checked = false;
          this.radioButton1.Checked = true;
        }
        else if (this.player.DiPhoBan.CheDo == 1)
        {
          this.radioButton2.Checked = true;
          this.radioButton1.Checked = false;
        }
        this.checkBox3.Checked = this.player.DiPhoBan.isLatBaiMP;
        this.checkBox2.Checked = this.player.DiPhoBan.isLatBaiTP;
        this.dpb = this.player.DiPhoBan;
        this.comboBox_Map.SelectedItem = (object) this.player.DiPhoBan.Map;
        this.comboBox2.SelectedItem = (object) this.player.DiPhoBan.loaipb;
        this.comboBox1.SelectedItem = (object) this.player.DiPhoBan.thanhvien;
        this.checkBox1.Checked = this.player.DiPhoBan.isBanRac;
        this.checkBox_AutoPhoBan.Checked = this.player.DiPhoBan.isbatdaudi;
        this.checkBox_ruongDong.Checked = this.player.DiPhoBan.isRuongDong;
      }
    }

    private void RadioButton_Nhanh_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.radioButton_Nhanh.Checked)
        return;
      this.dpb.KieuDiAi = 0;
      this.radioButton_Full.Checked = false;
    }

    private void RadioButton_Full_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.radioButton_Full.Checked)
        return;
      this.dpb.KieuDiAi = 1;
      this.radioButton_Nhanh.Checked = false;
    }

    private void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.radioButton1.Checked)
        return;
      this.dpb.CheDo = 0;
      this.radioButton2.Checked = false;
    }

    private void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.radioButton2.Checked)
        return;
      this.dpb.CheDo = 1;
      this.radioButton1.Checked = false;
    }

    private void CheckBox_ruongDong_CheckedChanged(object sender, EventArgs e)
    {
      this.player.DiPhoBan.isRuongDong = this.checkBox_ruongDong.Checked;
    }

    private void CheckBox_RvangFree_CheckedChanged(object sender, EventArgs e)
    {
    }

    private void CheckBox_RvThuPhi_CheckedChanged(object sender, EventArgs e)
    {
    }

    private void CheckBox_ruongBac_CheckedChanged(object sender, EventArgs e)
    {
    }

    private void CheckBox_AutoPhoBan_CheckedChanged(object sender, EventArgs e)
    {
      this.player.DiPhoBan.isbatdaudi = this.checkBox_AutoPhoBan.Checked;
      if (this.checkBox_AutoPhoBan.Checked)
      {
        this.radioButton2.Enabled = false;
        this.radioButton1.Enabled = false;
        this.radioButton_Nhanh.Enabled = false;
        this.radioButton_Full.Enabled = false;
      }
      else
      {
        this.radioButton2.Enabled = true;
        this.radioButton1.Enabled = true;
        this.radioButton_Nhanh.Enabled = true;
        this.radioButton_Full.Enabled = true;
      }
    }

    private void ComboBox_Map_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.dpb.Map = this.comboBox_Map.Text;
    }

    private void Button1_Click(object sender, EventArgs e)
    {
    }

    private void Button2_Click(object sender, EventArgs e)
    {
      this.player.DiPhoBan = this.dpb;
      this.player.SaveData();
    }

    private void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
    }

    private void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {
      this.dpb.isLatBaiTP = this.checkBox2.Checked;
    }

    private void CheckBox3_CheckedChanged(object sender, EventArgs e)
    {
      this.dpb.isLatBaiMP = this.checkBox3.Checked;
    }

    private void TrackBar1_Scroll(object sender, EventArgs e)
    {
      this.dpb.Speed = this.trackBar1.Value;
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.dpb.thanhvien = this.comboBox1.Text;
    }

    private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.player.DiPhoBan.loaipb = this.comboBox2.Text;
    }

    private void button1_Click_1(object sender, EventArgs e)
    {
      foreach (Client client in this.listClient)
      {
        client.player.DiPhoBan.isLatBaiMP = this.checkBox3.Checked;
        client.player.DiPhoBan.isLatBaiTP = this.checkBox2.Checked;
        client.player.DiPhoBan.Map = this.comboBox_Map.Text;
        client.player.DiPhoBan.loaipb = this.comboBox2.Text;
        client.player.DiPhoBan.thanhvien = this.comboBox1.Text;
        client.player.DiPhoBan.isBanRac = this.checkBox1.Checked;
        client.player.DiPhoBan.isbatdaudi = this.checkBox_AutoPhoBan.Checked;
        client.player.DiPhoBan.isRuongDong = this.checkBox_ruongDong.Checked;
        client.player.SaveData();
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Pho_Ban));
      this.groupBox3 = new GroupBox();
      this.checkBox1 = new CheckBox();
      this.checkBox_ruongBac = new CheckBox();
      this.checkBox_RvThuPhi = new CheckBox();
      this.checkBox_ruongDong = new CheckBox();
      this.checkBox_RvangFree = new CheckBox();
      this.groupBox4 = new GroupBox();
      this.button1 = new Button();
      this.label1 = new Label();
      this.radioButton_Nhanh = new RadioButton();
      this.radioButton_Full = new RadioButton();
      this.comboBox1 = new ComboBox();
      this.checkBox_AutoPhoBan = new CheckBox();
      this.groupBox6 = new GroupBox();
      this.comboBox_Map = new ComboBox();
      this.groupBox1 = new GroupBox();
      this.radioButton1 = new RadioButton();
      this.radioButton2 = new RadioButton();
      this.groupBox2 = new GroupBox();
      this.checkBox2 = new CheckBox();
      this.checkBox3 = new CheckBox();
      this.trackBar1 = new TrackBar();
      this.groupBox5 = new GroupBox();
      this.groupBox7 = new GroupBox();
      this.comboBox2 = new ComboBox();
      this.groupBox3.SuspendLayout();
      this.groupBox4.SuspendLayout();
      this.groupBox6.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.trackBar1.BeginInit();
      this.groupBox5.SuspendLayout();
      this.groupBox7.SuspendLayout();
      this.SuspendLayout();
      this.groupBox3.Controls.Add((Control) this.checkBox1);
      this.groupBox3.Controls.Add((Control) this.checkBox_ruongBac);
      this.groupBox3.Controls.Add((Control) this.checkBox_RvThuPhi);
      this.groupBox3.Controls.Add((Control) this.checkBox_ruongDong);
      this.groupBox3.Controls.Add((Control) this.checkBox_RvangFree);
      this.groupBox3.Location = new Point(8, 140);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new Size(195, 118);
      this.groupBox3.TabIndex = 3;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Mở rương";
      this.checkBox1.AutoSize = true;
      this.checkBox1.Location = new Point(114, 91);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new Size(68, 17);
      this.checkBox1.TabIndex = 5;
      this.checkBox1.Text = "Bán Rác";
      this.checkBox1.UseVisualStyleBackColor = true;
      this.checkBox1.CheckedChanged += new EventHandler(this.CheckBox1_CheckedChanged);
      this.checkBox_ruongBac.AutoSize = true;
      this.checkBox_ruongBac.Location = new Point(12, 93);
      this.checkBox_ruongBac.Name = "checkBox_ruongBac";
      this.checkBox_ruongBac.Size = new Size(79, 17);
      this.checkBox_ruongBac.TabIndex = 3;
      this.checkBox_ruongBac.Text = "Rương bạc";
      this.checkBox_ruongBac.UseVisualStyleBackColor = true;
      this.checkBox_ruongBac.CheckedChanged += new EventHandler(this.CheckBox_ruongBac_CheckedChanged);
      this.checkBox_RvThuPhi.AutoSize = true;
      this.checkBox_RvThuPhi.Location = new Point(12, 68);
      this.checkBox_RvThuPhi.Name = "checkBox_RvThuPhi";
      this.checkBox_RvThuPhi.Size = new Size(122, 17);
      this.checkBox_RvThuPhi.TabIndex = 2;
      this.checkBox_RvThuPhi.Text = "Rương vàng thu phí";
      this.checkBox_RvThuPhi.UseVisualStyleBackColor = true;
      this.checkBox_RvThuPhi.CheckedChanged += new EventHandler(this.CheckBox_RvThuPhi_CheckedChanged);
      this.checkBox_ruongDong.AutoSize = true;
      this.checkBox_ruongDong.Location = new Point(12, 20);
      this.checkBox_ruongDong.Name = "checkBox_ruongDong";
      this.checkBox_ruongDong.Size = new Size(86, 17);
      this.checkBox_ruongDong.TabIndex = 1;
      this.checkBox_ruongDong.Text = "Rương đồng";
      this.checkBox_ruongDong.UseVisualStyleBackColor = true;
      this.checkBox_ruongDong.CheckedChanged += new EventHandler(this.CheckBox_ruongDong_CheckedChanged);
      this.checkBox_RvangFree.AutoSize = true;
      this.checkBox_RvangFree.Location = new Point(12, 45);
      this.checkBox_RvangFree.Name = "checkBox_RvangFree";
      this.checkBox_RvangFree.Size = new Size(129, 17);
      this.checkBox_RvangFree.TabIndex = 0;
      this.checkBox_RvangFree.Text = "Rương vàng miễn phí";
      this.checkBox_RvangFree.UseVisualStyleBackColor = true;
      this.checkBox_RvangFree.CheckedChanged += new EventHandler(this.CheckBox_RvangFree_CheckedChanged);
      this.groupBox4.Controls.Add((Control) this.button1);
      this.groupBox4.Controls.Add((Control) this.label1);
      this.groupBox4.Controls.Add((Control) this.radioButton_Nhanh);
      this.groupBox4.Controls.Add((Control) this.radioButton_Full);
      this.groupBox4.Controls.Add((Control) this.comboBox1);
      this.groupBox4.Controls.Add((Control) this.checkBox_AutoPhoBan);
      this.groupBox4.Location = new Point(9, 309);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Size = new Size(195, 118);
      this.groupBox4.TabIndex = 4;
      this.groupBox4.TabStop = false;
      this.button1.Location = new Point(93, 83);
      this.button1.Name = "button1";
      this.button1.Size = new Size(93, 28);
      this.button1.TabIndex = 17;
      this.button1.Text = "Lưu All";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click_1);
      this.label1.AutoSize = true;
      this.label1.Location = new Point(15, 54);
      this.label1.Name = "label1";
      this.label1.Size = new Size(73, 13);
      this.label1.TabIndex = 7;
      this.label1.Text = "Số thành viên";
      this.radioButton_Nhanh.AutoSize = true;
      this.radioButton_Nhanh.Location = new Point(15, 23);
      this.radioButton_Nhanh.Name = "radioButton_Nhanh";
      this.radioButton_Nhanh.Size = new Size(57, 17);
      this.radioButton_Nhanh.TabIndex = 4;
      this.radioButton_Nhanh.Text = "Nhanh";
      this.radioButton_Nhanh.UseVisualStyleBackColor = true;
      this.radioButton_Nhanh.CheckedChanged += new EventHandler(this.RadioButton_Nhanh_CheckedChanged);
      this.radioButton_Full.AutoSize = true;
      this.radioButton_Full.Location = new Point(116, 24);
      this.radioButton_Full.Name = "radioButton_Full";
      this.radioButton_Full.Size = new Size(52, 17);
      this.radioButton_Full.TabIndex = 3;
      this.radioButton_Full.Text = "Full ải";
      this.radioButton_Full.UseVisualStyleBackColor = true;
      this.radioButton_Full.CheckedChanged += new EventHandler(this.RadioButton_Full_CheckedChanged);
      this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox1.FlatStyle = FlatStyle.System;
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Items.AddRange(new object[4]
      {
        (object) "4",
        (object) "5",
        (object) "6",
        (object) "7"
      });
      this.comboBox1.Location = new Point(94, 51);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(92, 21);
      this.comboBox1.TabIndex = 6;
      this.comboBox1.SelectedIndexChanged += new EventHandler(this.comboBox1_SelectedIndexChanged);
      this.checkBox_AutoPhoBan.AutoSize = true;
      this.checkBox_AutoPhoBan.Location = new Point(14, 0);
      this.checkBox_AutoPhoBan.Name = "checkBox_AutoPhoBan";
      this.checkBox_AutoPhoBan.Size = new Size(57, 17);
      this.checkBox_AutoPhoBan.TabIndex = 0;
      this.checkBox_AutoPhoBan.Text = "Chủ pt";
      this.checkBox_AutoPhoBan.UseVisualStyleBackColor = true;
      this.checkBox_AutoPhoBan.CheckedChanged += new EventHandler(this.CheckBox_AutoPhoBan_CheckedChanged);
      this.groupBox6.Controls.Add((Control) this.comboBox_Map);
      this.groupBox6.ForeColor = Color.Black;
      this.groupBox6.Location = new Point(8, 59);
      this.groupBox6.Margin = new Padding(3, 0, 0, 0);
      this.groupBox6.Name = "groupBox6";
      this.groupBox6.Padding = new Padding(3, 3, 3, 0);
      this.groupBox6.Size = new Size(196, 42);
      this.groupBox6.TabIndex = 11;
      this.groupBox6.TabStop = false;
      this.groupBox6.Text = "Map";
      this.comboBox_Map.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox_Map.FlatStyle = FlatStyle.System;
      this.comboBox_Map.FormattingEnabled = true;
      this.comboBox_Map.Items.AddRange(new object[5]
      {
        (object) "Thành Đô",
        (object) "Tuyền Châu",
        (object) "Biện Khinh",
        (object) "Tương Dương",
        (object) "Phụng Tường"
      });
      this.comboBox_Map.Location = new Point(20, 13);
      this.comboBox_Map.Name = "comboBox_Map";
      this.comboBox_Map.Size = new Size(167, 21);
      this.comboBox_Map.TabIndex = 5;
      this.comboBox_Map.SelectedIndexChanged += new EventHandler(this.ComboBox_Map_SelectedIndexChanged);
      this.groupBox1.Controls.Add((Control) this.radioButton1);
      this.groupBox1.Controls.Add((Control) this.radioButton2);
      this.groupBox1.ForeColor = Color.Black;
      this.groupBox1.Location = new Point(8, 101);
      this.groupBox1.Margin = new Padding(3, 0, 0, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Padding = new Padding(3, 3, 3, 0);
      this.groupBox1.Size = new Size(196, 39);
      this.groupBox1.TabIndex = 12;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Chế Độ";
      this.radioButton1.AutoSize = true;
      this.radioButton1.Location = new Point(31, 15);
      this.radioButton1.Name = "radioButton1";
      this.radioButton1.Size = new Size(51, 17);
      this.radioButton1.TabIndex = 6;
      this.radioButton1.Text = "Đánh";
      this.radioButton1.UseVisualStyleBackColor = true;
      this.radioButton1.CheckedChanged += new EventHandler(this.RadioButton1_CheckedChanged);
      this.radioButton2.AutoSize = true;
      this.radioButton2.Location = new Point(116, 15);
      this.radioButton2.Name = "radioButton2";
      this.radioButton2.Size = new Size(44, 17);
      this.radioButton2.TabIndex = 5;
      this.radioButton2.Text = "Buff";
      this.radioButton2.UseVisualStyleBackColor = true;
      this.radioButton2.CheckedChanged += new EventHandler(this.RadioButton2_CheckedChanged);
      this.groupBox2.Controls.Add((Control) this.checkBox2);
      this.groupBox2.Controls.Add((Control) this.checkBox3);
      this.groupBox2.ForeColor = Color.Black;
      this.groupBox2.Location = new Point(9, 261);
      this.groupBox2.Margin = new Padding(3, 0, 0, 0);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Padding = new Padding(3, 3, 3, 0);
      this.groupBox2.Size = new Size(196, 39);
      this.groupBox2.TabIndex = 13;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Lật Bài";
      this.checkBox2.AutoSize = true;
      this.checkBox2.Location = new Point(113, 15);
      this.checkBox2.Name = "checkBox2";
      this.checkBox2.Size = new Size(65, 17);
      this.checkBox2.TabIndex = 8;
      this.checkBox2.Text = "Thu Phí";
      this.checkBox2.UseVisualStyleBackColor = true;
      this.checkBox2.CheckedChanged += new EventHandler(this.CheckBox2_CheckedChanged);
      this.checkBox3.AutoSize = true;
      this.checkBox3.Location = new Point(19, 15);
      this.checkBox3.Name = "checkBox3";
      this.checkBox3.Size = new Size(69, 17);
      this.checkBox3.TabIndex = 7;
      this.checkBox3.Text = "Miễn Phí";
      this.checkBox3.UseVisualStyleBackColor = true;
      this.checkBox3.CheckedChanged += new EventHandler(this.CheckBox3_CheckedChanged);
      this.trackBar1.Location = new Point(1, 14);
      this.trackBar1.Name = "trackBar1";
      this.trackBar1.Size = new Size(197, 45);
      this.trackBar1.TabIndex = 15;
      this.trackBar1.Scroll += new EventHandler(this.TrackBar1_Scroll);
      this.groupBox5.Controls.Add((Control) this.trackBar1);
      this.groupBox5.Location = new Point(315, 328);
      this.groupBox5.Name = "groupBox5";
      this.groupBox5.Size = new Size(197, 33);
      this.groupBox5.TabIndex = 16;
      this.groupBox5.TabStop = false;
      this.groupBox5.Text = "SPEED";
      this.groupBox7.Controls.Add((Control) this.comboBox2);
      this.groupBox7.ForeColor = Color.Black;
      this.groupBox7.Location = new Point(8, 9);
      this.groupBox7.Margin = new Padding(3, 0, 0, 0);
      this.groupBox7.Name = "groupBox7";
      this.groupBox7.Padding = new Padding(3, 3, 3, 0);
      this.groupBox7.Size = new Size(196, 42);
      this.groupBox7.TabIndex = 12;
      this.groupBox7.TabStop = false;
      this.groupBox7.Text = "Phó bản";
      this.comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox2.FlatStyle = FlatStyle.System;
      this.comboBox2.FormattingEnabled = true;
      this.comboBox2.Items.AddRange(new object[4]
      {
        (object) "Địa huyền cung",
        (object) "Lương sơn bạc",
        (object) "Vạn kiếm trủng",
        (object) "Thái nhất tháp"
      });
      this.comboBox2.Location = new Point(19, 13);
      this.comboBox2.Name = "comboBox2";
      this.comboBox2.Size = new Size(168, 21);
      this.comboBox2.TabIndex = 5;
      this.comboBox2.SelectedIndexChanged += new EventHandler(this.comboBox2_SelectedIndexChanged);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(213, 432);
      this.Controls.Add((Control) this.groupBox7);
      this.Controls.Add((Control) this.groupBox5);
      this.Controls.Add((Control) this.groupBox2);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.groupBox6);
      this.Controls.Add((Control) this.groupBox4);
      this.Controls.Add((Control) this.groupBox3);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (Pho_Ban);
      this.StartPosition = FormStartPosition.Manual;
      this.Text = "PhoBan";
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.groupBox4.ResumeLayout(false);
      this.groupBox4.PerformLayout();
      this.groupBox6.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.trackBar1.EndInit();
      this.groupBox5.ResumeLayout(false);
      this.groupBox5.PerformLayout();
      this.groupBox7.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    public delegate void PassControl(bool ischeck);
  }
}
