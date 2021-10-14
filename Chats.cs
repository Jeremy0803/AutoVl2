// Decompiled with JetBrains decompiler
// Type: dorajx2.Chats
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
  public class Chats : Form
  {
    private List<Player.Item> listItem = new List<Player.Item>();
    private List<Player.Item> listItemOld = new List<Player.Item>();
    private Player.Item oldKX = new Player.Item();
    private IContainer components = (IContainer) null;
    private List<Player.Item> _listItem = new List<Player.Item>();
    private Player player;
    private IntPtr Module;
    private Button button3;
    private Button button4;
    private ListView listView1;
    private Label label1;
    private Button button5;
    private TextBox textBox1;
    private ColumnHeader columnHeader1;
    private Label label2;
    private NumericUpDown numericUpDown1;
    private Timer time_1;

    public Chats(Client client)
    {
      this.InitializeComponent();
      this.player = client.player;
      this.Module = client.Module;
      if (client.IsChecked)
      {
        if (this.player.chatlist != null)
        {
          foreach (Player.Item obj in this.player.chatlist)
            this.listView1.Items.Add(new ListViewItem(new string[1]
            {
              obj.Name
            }));
        }
        else
          this.player.chatlist = new List<Player.Item>();
      }
      this.numericUpDown1.Value = (Decimal) this.player.TimeDelayChat;
      this.textBox1.Text = this.player.loichat;
    }

    private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
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
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Chats));
      this.time_1 = new Timer(this.components);
      this.button3 = new Button();
      this.button4 = new Button();
      this.listView1 = new ListView();
      this.columnHeader1 = new ColumnHeader();
      this.label1 = new Label();
      this.button5 = new Button();
      this.textBox1 = new TextBox();
      this.label2 = new Label();
      this.numericUpDown1 = new NumericUpDown();
      this.numericUpDown1.BeginInit();
      this.SuspendLayout();
      this.time_1.Enabled = true;
      this.time_1.Interval = 1500;
      this.time_1.Tick += new EventHandler(this.Time_1_Tick);
      this.button3.Location = new Point(76, 12);
      this.button3.Name = "button3";
      this.button3.Size = new Size(132, 23);
      this.button3.TabIndex = 13;
      this.button3.Text = "Thêm ";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new EventHandler(this.Button3_Click_1);
      this.button4.Location = new Point(214, 12);
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
      this.listView1.Enabled = false;
      this.listView1.FullRowSelect = true;
      this.listView1.GridLines = true;
      this.listView1.HideSelection = false;
      this.listView1.Location = new Point(3, 68);
      this.listView1.Name = "listView1";
      this.listView1.Size = new Size(317, 189);
      this.listView1.TabIndex = 15;
      this.listView1.UseCompatibleStateImageBehavior = false;
      this.listView1.View = View.Details;
      this.columnHeader1.Text = "T2Auto Chat";
      this.columnHeader1.Width = 313;
      this.label1.AutoSize = true;
      this.label1.Location = new Point(5, 44);
      this.label1.Name = "label1";
      this.label1.Size = new Size(42, 13);
      this.label1.TabIndex = 19;
      this.label1.Text = "Lời rao:";
      this.button5.Location = new Point(3, 12);
      this.button5.Name = "button5";
      this.button5.Size = new Size(67, 23);
      this.button5.TabIndex = 21;
      this.button5.Text = "Xóa All";
      this.button5.UseVisualStyleBackColor = true;
      this.button5.Click += new EventHandler(this.Button5_Click);
      this.textBox1.Location = new Point(53, 41);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(184, 20);
      this.textBox1.TabIndex = 1;
      this.textBox1.TextChanged += new EventHandler(this.textBox1_TextChanged);
      this.label2.AutoSize = true;
      this.label2.Location = new Point(243, 44);
      this.label2.Name = "label2";
      this.label2.Size = new Size(35, 13);
      this.label2.TabIndex = 22;
      this.label2.Text = "deley:";
      this.numericUpDown1.Location = new Point(280, 42);
      this.numericUpDown1.Maximum = new Decimal(new int[4]
      {
        100000,
        0,
        0,
        0
      });
      this.numericUpDown1.Name = "numericUpDown1";
      this.numericUpDown1.Size = new Size(40, 20);
      this.numericUpDown1.TabIndex = 23;
      this.numericUpDown1.ValueChanged += new EventHandler(this.numericUpDown1_ValueChanged);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(325, 269);
      this.Controls.Add((Control) this.numericUpDown1);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.textBox1);
      this.Controls.Add((Control) this.button5);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.listView1);
      this.Controls.Add((Control) this.button4);
      this.Controls.Add((Control) this.button3);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (Chats);
      this.Text = "Chát";
      this.numericUpDown1.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private void Time_1_Tick(object sender, EventArgs e)
    {
    }

    private void Button3_Click_1(object sender, EventArgs e)
    {
      this.listView1.Items.Add(new ListViewItem(new string[1]
      {
        this.Name = this.textBox1.Text
      }));
      this.player.chatlist.Add(new Player.Item()
      {
        Name = this.textBox1.Text
      });
    }

    private void Button4_Click(object sender, EventArgs e)
    {
      if (this.listView1.SelectedItems.Count <= 0)
        return;
      this.player.chatlist.Remove(this.player.chatlist.FirstOrDefault<Player.Item>((Func<Player.Item, bool>) (x => x.Name == this.listView1.SelectedItems[0].SubItems[0].Text)));
      this.listView1.Items.Clear();
      foreach (Player.Item obj in this.player.chatlist)
        this.listView1.Items.Add(new ListViewItem(new string[1]
        {
          obj.Name
        }));
    }

    private void Button1_Click_1(object sender, EventArgs e)
    {
    }

    private void Button1_Click(object sender, EventArgs e)
    {
    }

    private void Button5_Click(object sender, EventArgs e)
    {
      this.listView1.Items.Clear();
      this.player.chatlist.Clear();
    }

    private void numericUpDown1_ValueChanged(object sender, EventArgs e)
    {
      this.player.TimeDelayChat = (int) this.numericUpDown1.Value;
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
      this.player.loichat = this.textBox1.Text;
    }
  }
}
