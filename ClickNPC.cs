// Decompiled with JetBrains decompiler
// Type: dorajx2.ClickNPC
// Assembly: T2Auto, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3D2B1643-7C06-428B-9BDA-29369F42091D
// Assembly location: C:\Users\itoutsource06\Desktop\AutoT2\Auto Jx2\T2Auto.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace dorajx2
{
  public class ClickNPC : Form
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
    private Label label1;
    private Label label2;
    private ComboBox comboBox2;
    private Button button1;
    private Label label3;
    private ComboBox comboBox3;
    private Label label4;
    private ComboBox comboBox4;
    private Label label5;
    private ComboBox comboBox5;
    private Label label6;
    private ComboBox comboBox6;
    private Label label7;
    private ComboBox comboBox7;
    private NumericUpDown numericUpDown1;
    private Label label8;
    private Button button2;

    public ClickNPC(Client client)
    {
      this.InitializeComponent();
      this.player = client.player;
      this.Module = client.Module;
      this.comboBox2.Items.AddRange((object[]) ClickNPC.NameDong);
      this.comboBox3.Items.AddRange((object[]) ClickNPC.NameDong);
      this.comboBox4.Items.AddRange((object[]) ClickNPC.NameDong);
      this.comboBox5.Items.AddRange((object[]) ClickNPC.NameDong);
      this.comboBox6.Items.AddRange((object[]) ClickNPC.NameDong);
      this.comboBox7.Items.AddRange((object[]) ClickNPC.NameDong);
      this.comboBox2.SelectedIndex = 0;
      this.comboBox3.SelectedIndex = 0;
      this.comboBox4.SelectedIndex = 0;
      this.comboBox5.SelectedIndex = 0;
      this.comboBox6.SelectedIndex = 0;
      this.comboBox7.SelectedIndex = 0;
    }

    private void Button1_Click(object sender, EventArgs e)
    {
      this.comboBox1.Items.Clear();
      this.listItem.Clear();
      foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
      {
        if (npc.type == 6U)
          this.comboBox1.Items.Add((object) npc.Name);
      }
    }

    private void UseGmItem_Load(object sender, EventArgs e)
    {
    }

    private void Button2_Click(object sender, EventArgs e)
    {
      for (int index = 0; index < (int) this.numericUpDown1.Value; ++index)
      {
        foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
        {
          if (npc.Name == this.comboBox1.Text)
            HookCall.ClickNPC96(this.player.hWnd, npc.id, this.player.Address);
        }
        Thread.Sleep(300);
        if (this.comboBox2.Text != "Không Sử Dụng")
        {
          HookCall.SelectMenu96(this.player.hWnd, (uint) (int.Parse(this.comboBox2.Text.Split(' ')[1]) - 1), ReadMem.GetMenu96(this.player.HProcess));
          Thread.Sleep(200);
        }
        if (this.comboBox3.Text != "Không Sử Dụng")
        {
          HookCall.SelectMenu96(this.player.hWnd, (uint) (int.Parse(this.comboBox3.Text.Split(' ')[1]) - 1), ReadMem.GetMenu96(this.player.HProcess));
          Thread.Sleep(200);
        }
        if (this.comboBox4.Text != "Không Sử Dụng")
        {
          HookCall.SelectMenu96(this.player.hWnd, (uint) (int.Parse(this.comboBox4.Text.Split(' ')[1]) - 1), ReadMem.GetMenu96(this.player.HProcess));
          Thread.Sleep(100);
        }
        if (this.comboBox5.Text != "Không Sử Dụng")
        {
          HookCall.SelectMenu96(this.player.hWnd, (uint) (int.Parse(this.comboBox5.Text.Split(' ')[1]) - 1), ReadMem.GetMenu96(this.player.HProcess));
          Thread.Sleep(100);
        }
        if (this.comboBox6.Text != "Không Sử Dụng")
        {
          HookCall.SelectMenu96(this.player.hWnd, (uint) (int.Parse(this.comboBox6.Text.Split(' ')[1]) - 1), ReadMem.GetMenu96(this.player.HProcess));
          Thread.Sleep(100);
        }
        if (this.comboBox7.Text != "Không Sử Dụng")
        {
          HookCall.SelectMenu96(this.player.hWnd, (uint) (int.Parse(this.comboBox7.Text.Split(' ')[1]) - 1), ReadMem.GetMenu96(this.player.HProcess));
          Thread.Sleep(100);
        }
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (ClickNPC));
      this.comboBox1 = new ComboBox();
      this.label1 = new Label();
      this.label2 = new Label();
      this.comboBox2 = new ComboBox();
      this.button1 = new Button();
      this.label3 = new Label();
      this.comboBox3 = new ComboBox();
      this.label4 = new Label();
      this.comboBox4 = new ComboBox();
      this.label5 = new Label();
      this.comboBox5 = new ComboBox();
      this.label6 = new Label();
      this.comboBox6 = new ComboBox();
      this.label7 = new Label();
      this.comboBox7 = new ComboBox();
      this.numericUpDown1 = new NumericUpDown();
      this.label8 = new Label();
      this.button2 = new Button();
      this.numericUpDown1.BeginInit();
      this.SuspendLayout();
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Location = new Point(78, 9);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(149, 21);
      this.comboBox1.TabIndex = 0;
      this.label1.AutoSize = true;
      this.label1.Location = new Point(12, 39);
      this.label1.Name = "label1";
      this.label1.Size = new Size(34, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Lần 1";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(12, 12);
      this.label2.Name = "label2";
      this.label2.Size = new Size(27, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "Item";
      this.comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox2.FormattingEnabled = true;
      this.comboBox2.Location = new Point(78, 36);
      this.comboBox2.Name = "comboBox2";
      this.comboBox2.Size = new Size(149, 21);
      this.comboBox2.TabIndex = 2;
      this.button1.Location = new Point(245, 7);
      this.button1.Name = "button1";
      this.button1.Size = new Size(75, 23);
      this.button1.TabIndex = 4;
      this.button1.Text = "Get";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.Button1_Click);
      this.label3.AutoSize = true;
      this.label3.Location = new Point(12, 66);
      this.label3.Name = "label3";
      this.label3.Size = new Size(34, 13);
      this.label3.TabIndex = 6;
      this.label3.Text = "Lần 2";
      this.comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox3.FormattingEnabled = true;
      this.comboBox3.Location = new Point(78, 63);
      this.comboBox3.Name = "comboBox3";
      this.comboBox3.Size = new Size(149, 21);
      this.comboBox3.TabIndex = 5;
      this.label4.AutoSize = true;
      this.label4.Location = new Point(12, 93);
      this.label4.Name = "label4";
      this.label4.Size = new Size(34, 13);
      this.label4.TabIndex = 8;
      this.label4.Text = "Lần 3";
      this.comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox4.FormattingEnabled = true;
      this.comboBox4.Location = new Point(78, 90);
      this.comboBox4.Name = "comboBox4";
      this.comboBox4.Size = new Size(149, 21);
      this.comboBox4.TabIndex = 7;
      this.label5.AutoSize = true;
      this.label5.Location = new Point(12, 120);
      this.label5.Name = "label5";
      this.label5.Size = new Size(34, 13);
      this.label5.TabIndex = 10;
      this.label5.Text = "Lần 4";
      this.comboBox5.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox5.FormattingEnabled = true;
      this.comboBox5.Location = new Point(78, 117);
      this.comboBox5.Name = "comboBox5";
      this.comboBox5.Size = new Size(149, 21);
      this.comboBox5.TabIndex = 9;
      this.label6.AutoSize = true;
      this.label6.Location = new Point(12, 147);
      this.label6.Name = "label6";
      this.label6.Size = new Size(34, 13);
      this.label6.TabIndex = 12;
      this.label6.Text = "Lần 5";
      this.comboBox6.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox6.FormattingEnabled = true;
      this.comboBox6.Location = new Point(78, 144);
      this.comboBox6.Name = "comboBox6";
      this.comboBox6.Size = new Size(149, 21);
      this.comboBox6.TabIndex = 11;
      this.label7.AutoSize = true;
      this.label7.Location = new Point(12, 174);
      this.label7.Name = "label7";
      this.label7.Size = new Size(34, 13);
      this.label7.TabIndex = 14;
      this.label7.Text = "Lần 6";
      this.comboBox7.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox7.FormattingEnabled = true;
      this.comboBox7.Location = new Point(78, 171);
      this.comboBox7.Name = "comboBox7";
      this.comboBox7.Size = new Size(149, 21);
      this.comboBox7.TabIndex = 13;
      this.numericUpDown1.Location = new Point(242, 59);
      this.numericUpDown1.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericUpDown1.Name = "numericUpDown1";
      this.numericUpDown1.Size = new Size(75, 20);
      this.numericUpDown1.TabIndex = 15;
      this.numericUpDown1.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.label8.AutoSize = true;
      this.label8.Location = new Point(247, 36);
      this.label8.Name = "label8";
      this.label8.Size = new Size(70, 13);
      this.label8.TabIndex = 16;
      this.label8.Text = "Lần Sử Dụng";
      this.button2.Location = new Point(242, 93);
      this.button2.Name = "button2";
      this.button2.Size = new Size(75, 23);
      this.button2.TabIndex = 17;
      this.button2.Text = "Start";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new EventHandler(this.Button2_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(329, 201);
      this.Controls.Add((Control) this.button2);
      this.Controls.Add((Control) this.label8);
      this.Controls.Add((Control) this.numericUpDown1);
      this.Controls.Add((Control) this.label7);
      this.Controls.Add((Control) this.comboBox7);
      this.Controls.Add((Control) this.label6);
      this.Controls.Add((Control) this.comboBox6);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.comboBox5);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.comboBox4);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.comboBox3);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.comboBox2);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.comboBox1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (ClickNPC);
      this.Text = "UseGmItem";
      this.Load += new EventHandler(this.UseGmItem_Load);
      this.numericUpDown1.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
