// Decompiled with JetBrains decompiler
// Type: dorajx2.Sell
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
  public class Sell : Form
  {
    private Player.Item oldKX = new Player.Item();
    private IContainer components = (IContainer) null;
    private List<Player.Item> _listItem = new List<Player.Item>();
    private Player player;
    private Button button3;
    private Button button4;
    private ListView listView1;
    private ColumnHeader columnHeader1;
    private Button button1;
    private Label label1;
    private ComboBox comboBox1;
    private Button button5;
    private Timer time_1;

    public Sell(Client client)
    {
      this.InitializeComponent();
      this.player = client.player;
      if (!client.IsChecked)
        return;
      if (this.player.sellitemlist != null)
      {
        foreach (Player.Item obj in this.player.sellitemlist)
          this.listView1.Items.Add(new ListViewItem(new string[1]
          {
            obj.Name
          }));
      }
      else
        this.player.sellitemlist = new List<Player.Item>();
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Sell));
      this.time_1 = new Timer(this.components);
      this.button3 = new Button();
      this.button4 = new Button();
      this.listView1 = new ListView();
      this.columnHeader1 = new ColumnHeader();
      this.button1 = new Button();
      this.label1 = new Label();
      this.comboBox1 = new ComboBox();
      this.button5 = new Button();
      this.SuspendLayout();
      this.button3.Location = new Point(76, 12);
      this.button3.Name = "button3";
      this.button3.Size = new Size(132, 23);
      this.button3.TabIndex = 13;
      this.button3.Text = "Thêm ";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new EventHandler(this.Button3_Click_1);
      this.button4.Location = new Point(214, 12);
      this.button4.Name = "button4";
      this.button4.Size = new Size(99, 23);
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
      this.listView1.Location = new Point(3, 68);
      this.listView1.Name = "listView1";
      this.listView1.Size = new Size(317, 451);
      this.listView1.TabIndex = 15;
      this.listView1.UseCompatibleStateImageBehavior = false;
      this.listView1.View = View.Details;
      this.columnHeader1.Text = "Name";
      this.columnHeader1.Width = 311;
      this.button1.Location = new Point(254, 39);
      this.button1.Name = "button1";
      this.button1.Size = new Size(59, 23);
      this.button1.TabIndex = 20;
      this.button1.Text = "Get";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.Button1_Click);
      this.label1.AutoSize = true;
      this.label1.Location = new Point(5, 44);
      this.label1.Name = "label1";
      this.label1.Size = new Size(63, 13);
      this.label1.TabIndex = 19;
      this.label1.Text = "Hành trang:";
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Location = new Point(76, 41);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(172, 21);
      this.comboBox1.TabIndex = 18;
      this.button5.Location = new Point(3, 12);
      this.button5.Name = "button5";
      this.button5.Size = new Size(67, 23);
      this.button5.TabIndex = 21;
      this.button5.Text = "Xóa All";
      this.button5.UseVisualStyleBackColor = true;
      this.button5.Click += new EventHandler(this.Button5_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(325, 531);
      this.Controls.Add((Control) this.button5);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.comboBox1);
      this.Controls.Add((Control) this.listView1);
      this.Controls.Add((Control) this.button4);
      this.Controls.Add((Control) this.button3);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (Sell);
      this.Text = "Sell items";
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
      this.player.sellitemlist.Add(new Player.Item()
      {
        Name = this.comboBox1.Text
      });
    }

    private void Button4_Click(object sender, EventArgs e)
    {
      this.player.sellitemlist.Remove(this.player.sellitemlist.FirstOrDefault<Player.Item>((Func<Player.Item, bool>) (x => x.Name == this.listView1.SelectedItems[0].SubItems[0].Text)));
      this.listView1.Items.Clear();
      foreach (Player.Item obj in this.player.sellitemlist)
        this.listView1.Items.Add(new ListViewItem(new string[1]
        {
          obj.Name
        }));
    }

    private void Button1_Click(object sender, EventArgs e)
    {
      this.comboBox1.Items.Clear();
      foreach (Player.Item obj in (IEnumerable<Player.Item>) ReadMem.GetItemList(this.player.HProcess).OrderByDescending<Player.Item, uint>((Func<Player.Item, uint>) (x => x.id)))
      {
        if (obj.type == 2U)
        {
          this.comboBox1.Items.Add((object) obj.Name);
          this.oldKX.Name = obj.Name;
          this.oldKX.id = obj.id;
          this.comboBox1.SelectedIndex = 0;
        }
      }
    }

    private void Button5_Click(object sender, EventArgs e)
    {
      this.listView1.Items.Clear();
      this.player.sellitemlist.Clear();
    }
  }
}
