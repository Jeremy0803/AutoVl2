// Decompiled with JetBrains decompiler
// Type: dorajx2.ThayDo
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
  public class ThayDo : Form
  {
    private List<Player.Item> listItem = new List<Player.Item>();
    private List<Player.Item> listItemOld = new List<Player.Item>();
    private Player.Item oldKX = new Player.Item();
    private IContainer components = (IContainer) null;
    private List<Player.Item> _listItem = new List<Player.Item>();
    private Player player;
    private ListView listView1;
    private ColumnHeader columnHeader1;
    private Button button2;
    private Button button6;
    private ListView listView2;
    private ColumnHeader columnHeader2;
    private ListView listView3;
    private ColumnHeader columnHeader3;
    private Button button7;
    private Button button8;
    private ListView listView4;
    private ColumnHeader columnHeader4;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private ComboBox cbphimbo1;
    private ComboBox cbphimbo2;
    private ComboBox cbphimbo3;
    private ComboBox cbphimbo4;

    public ThayDo(Client client)
    {
      this.InitializeComponent();
      this.player = client.player;
      if (!client.IsChecked)
        return;
      this.cbphimbo1.SelectedItem = (object) this.player.cobophim1;
      this.cbphimbo2.SelectedItem = (object) this.player.cobophim2;
      this.cbphimbo3.SelectedItem = (object) this.player.cobophim3;
      this.cbphimbo4.SelectedItem = (object) this.player.cobophim4;
      if (this.player.setthaydo != null)
      {
        foreach (Player.Item obj in this.player.setthaydo)
          this.listView1.Items.Add(new ListViewItem(new string[1]
          {
            obj.Name
          }));
      }
      else
        this.player.setthaydo = new List<Player.Item>();
      if (this.player.setthaydo2 != null)
      {
        foreach (Player.Item obj in this.player.setthaydo2)
          this.listView2.Items.Add(new ListViewItem(new string[1]
          {
            obj.Name
          }));
      }
      else
        this.player.setthaydo2 = new List<Player.Item>();
      if (this.player.setthaydo3 != null)
      {
        foreach (Player.Item obj in this.player.setthaydo3)
          this.listView3.Items.Add(new ListViewItem(new string[1]
          {
            obj.Name
          }));
      }
      else
        this.player.setthaydo3 = new List<Player.Item>();
      if (this.player.setthaydo4 != null)
      {
        foreach (Player.Item obj in this.player.setthaydo4)
          this.listView4.Items.Add(new ListViewItem(new string[1]
          {
            obj.Name
          }));
      }
      else
        this.player.setthaydo4 = new List<Player.Item>();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (ThayDo));
      this.listView1 = new ListView();
      this.columnHeader1 = new ColumnHeader();
      this.button2 = new Button();
      this.button6 = new Button();
      this.listView2 = new ListView();
      this.columnHeader2 = new ColumnHeader();
      this.listView3 = new ListView();
      this.columnHeader3 = new ColumnHeader();
      this.button7 = new Button();
      this.button8 = new Button();
      this.listView4 = new ListView();
      this.columnHeader4 = new ColumnHeader();
      this.label1 = new Label();
      this.label2 = new Label();
      this.label3 = new Label();
      this.label4 = new Label();
      this.cbphimbo1 = new ComboBox();
      this.cbphimbo2 = new ComboBox();
      this.cbphimbo3 = new ComboBox();
      this.cbphimbo4 = new ComboBox();
      this.SuspendLayout();
      this.listView1.Columns.AddRange(new ColumnHeader[1]
      {
        this.columnHeader1
      });
      this.listView1.FullRowSelect = true;
      this.listView1.GridLines = true;
      this.listView1.HideSelection = false;
      this.listView1.Location = new Point(5, 92);
      this.listView1.Name = "listView1";
      this.listView1.Size = new Size(149, 301);
      this.listView1.TabIndex = 15;
      this.listView1.UseCompatibleStateImageBehavior = false;
      this.listView1.View = View.Details;
      this.listView1.SelectedIndexChanged += new EventHandler(this.listView1_SelectedIndexChanged);
      this.columnHeader1.Text = "Set1";
      this.columnHeader1.Width = 145;
      this.button2.Location = new Point(5, 68);
      this.button2.Name = "button2";
      this.button2.Size = new Size(141, 23);
      this.button2.TabIndex = 22;
      this.button2.Text = "Add1";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new EventHandler(this.Button2_Click_1);
      this.button6.Location = new Point(152, 68);
      this.button6.Name = "button6";
      this.button6.Size = new Size(149, 23);
      this.button6.TabIndex = 23;
      this.button6.Text = "Add2";
      this.button6.UseVisualStyleBackColor = true;
      this.button6.Click += new EventHandler(this.Button6_Click);
      this.listView2.Columns.AddRange(new ColumnHeader[1]
      {
        this.columnHeader2
      });
      this.listView2.FullRowSelect = true;
      this.listView2.GridLines = true;
      this.listView2.HideSelection = false;
      this.listView2.Location = new Point(152, 92);
      this.listView2.Name = "listView2";
      this.listView2.Size = new Size(149, 301);
      this.listView2.TabIndex = 24;
      this.listView2.UseCompatibleStateImageBehavior = false;
      this.listView2.View = View.Details;
      this.columnHeader2.Text = "Set2";
      this.columnHeader2.Width = 145;
      this.listView3.Columns.AddRange(new ColumnHeader[1]
      {
        this.columnHeader3
      });
      this.listView3.FullRowSelect = true;
      this.listView3.GridLines = true;
      this.listView3.HideSelection = false;
      this.listView3.Location = new Point(298, 92);
      this.listView3.Name = "listView3";
      this.listView3.Size = new Size(149, 301);
      this.listView3.TabIndex = 28;
      this.listView3.UseCompatibleStateImageBehavior = false;
      this.listView3.View = View.Details;
      this.columnHeader3.Text = "Set3";
      this.columnHeader3.Width = 145;
      this.button7.Location = new Point(453, 68);
      this.button7.Name = "button7";
      this.button7.Size = new Size(141, 23);
      this.button7.TabIndex = 27;
      this.button7.Text = "Add4";
      this.button7.UseVisualStyleBackColor = true;
      this.button7.Click += new EventHandler(this.Button7_Click);
      this.button8.Location = new Point(306, 68);
      this.button8.Name = "button8";
      this.button8.Size = new Size(141, 23);
      this.button8.TabIndex = 26;
      this.button8.Text = "Add3";
      this.button8.UseVisualStyleBackColor = true;
      this.button8.Click += new EventHandler(this.Button8_Click);
      this.listView4.Columns.AddRange(new ColumnHeader[1]
      {
        this.columnHeader4
      });
      this.listView4.FullRowSelect = true;
      this.listView4.GridLines = true;
      this.listView4.HideSelection = false;
      this.listView4.Location = new Point(445, 92);
      this.listView4.Name = "listView4";
      this.listView4.Size = new Size(149, 301);
      this.listView4.TabIndex = 25;
      this.listView4.UseCompatibleStateImageBehavior = false;
      this.listView4.View = View.Details;
      this.columnHeader4.Text = "Set4";
      this.columnHeader4.Width = 145;
      this.label1.AutoSize = true;
      this.label1.Location = new Point(25, 20);
      this.label1.Name = "label1";
      this.label1.Size = new Size(62, 13);
      this.label1.TabIndex = 29;
      this.label1.Text = "Phím tắt 01";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(184, 20);
      this.label2.Name = "label2";
      this.label2.Size = new Size(62, 13);
      this.label2.TabIndex = 30;
      this.label2.Text = "Phím tắt 02";
      this.label3.AutoSize = true;
      this.label3.Location = new Point(346, 20);
      this.label3.Name = "label3";
      this.label3.Size = new Size(62, 13);
      this.label3.TabIndex = 31;
      this.label3.Text = "Phím tắt 03";
      this.label4.AutoSize = true;
      this.label4.Location = new Point(489, 20);
      this.label4.Name = "label4";
      this.label4.Size = new Size(62, 13);
      this.label4.TabIndex = 32;
      this.label4.Text = "Phím tắt 04";
      this.cbphimbo1.FlatStyle = FlatStyle.Popup;
      this.cbphimbo1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbphimbo1.FormattingEnabled = true;
      this.cbphimbo1.Items.AddRange(new object[69]
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
        (object) "T",
        (object) "Y",
        (object) "U",
        (object) "I"
      });
      this.cbphimbo1.Location = new Point(5, 36);
      this.cbphimbo1.Name = "cbphimbo1";
      this.cbphimbo1.Size = new Size(141, 23);
      this.cbphimbo1.TabIndex = 33;
      this.cbphimbo1.SelectedIndexChanged += new EventHandler(this.Cbphimbo1_SelectedIndexChanged);
      this.cbphimbo2.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbphimbo2.FlatStyle = FlatStyle.Popup;
      this.cbphimbo2.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbphimbo2.FormattingEnabled = true;
      this.cbphimbo2.Items.AddRange(new object[69]
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
        (object) "T",
        (object) "Y",
        (object) "U",
        (object) "I"
      });
      this.cbphimbo2.Location = new Point(152, 36);
      this.cbphimbo2.Name = "cbphimbo2";
      this.cbphimbo2.Size = new Size(148, 23);
      this.cbphimbo2.TabIndex = 34;
      this.cbphimbo2.SelectedIndexChanged += new EventHandler(this.Cbphimbo2_SelectedIndexChanged);
      this.cbphimbo3.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbphimbo3.FlatStyle = FlatStyle.Popup;
      this.cbphimbo3.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbphimbo3.FormattingEnabled = true;
      this.cbphimbo3.Items.AddRange(new object[69]
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
        (object) "T",
        (object) "Y",
        (object) "U",
        (object) "I"
      });
      this.cbphimbo3.Location = new Point(306, 36);
      this.cbphimbo3.Name = "cbphimbo3";
      this.cbphimbo3.Size = new Size(141, 23);
      this.cbphimbo3.TabIndex = 35;
      this.cbphimbo3.SelectedIndexChanged += new EventHandler(this.Cbphimbo3_SelectedIndexChanged);
      this.cbphimbo4.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbphimbo4.FlatStyle = FlatStyle.Popup;
      this.cbphimbo4.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbphimbo4.FormattingEnabled = true;
      this.cbphimbo4.Items.AddRange(new object[69]
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
        (object) "T",
        (object) "Y",
        (object) "U",
        (object) "I"
      });
      this.cbphimbo4.Location = new Point(453, 36);
      this.cbphimbo4.Name = "cbphimbo4";
      this.cbphimbo4.Size = new Size(141, 23);
      this.cbphimbo4.TabIndex = 36;
      this.cbphimbo4.SelectedIndexChanged += new EventHandler(this.Cbphimbo4_SelectedIndexChanged);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(593, 400);
      this.Controls.Add((Control) this.cbphimbo4);
      this.Controls.Add((Control) this.cbphimbo3);
      this.Controls.Add((Control) this.cbphimbo2);
      this.Controls.Add((Control) this.cbphimbo1);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.listView3);
      this.Controls.Add((Control) this.button7);
      this.Controls.Add((Control) this.button8);
      this.Controls.Add((Control) this.listView4);
      this.Controls.Add((Control) this.listView2);
      this.Controls.Add((Control) this.button6);
      this.Controls.Add((Control) this.button2);
      this.Controls.Add((Control) this.listView1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (ThayDo);
      this.Text = "Sell items";
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private void Button3_Click_1(object sender, EventArgs e)
    {
      if (this.cbphimbo2.Items.Count <= 0)
        return;
      this.listView1.Items.Add(new ListViewItem(new string[1]
      {
        this.Name = this.cbphimbo2.Text
      }));
      this.player.setthaydo.Add(new Player.Item()
      {
        Name = this.cbphimbo2.Text
      });
    }

    private void Button4_Click(object sender, EventArgs e)
    {
      if (this.listView1.SelectedItems.Count <= 0)
        return;
      this.player.setthaydo.Remove(this.player.setthaydo.FirstOrDefault<Player.Item>((Func<Player.Item, bool>) (x => x.Name == this.listView1.SelectedItems[0].SubItems[0].Text)));
      this.listView1.Items.Clear();
      foreach (Player.Item obj in this.player.setthaydo)
        this.listView1.Items.Add(new ListViewItem(new string[1]
        {
          obj.Name
        }));
    }

    private void Button1_Click(object sender, EventArgs e)
    {
      this.cbphimbo2.Items.Clear();
      foreach (Player.Item obj in ReadMem.GetItemList(this.player.HProcess))
      {
        if (obj.type == 5U)
        {
          this.cbphimbo2.Items.Add((object) obj.Name);
          this.oldKX.Name = obj.Name;
          this.oldKX.id = obj.id;
          this.cbphimbo2.SelectedIndex = 0;
        }
      }
    }

    private void Button5_Click(object sender, EventArgs e)
    {
      this.listView1.Items.Clear();
      this.player.setthaydo.Clear();
    }

    private void Button2_Click_1(object sender, EventArgs e)
    {
      this.listView1.Items.Clear();
      this.player.setthaydo.Clear();
      foreach (Player.Item obj in ReadMem.GetItemList(this.player.HProcess))
      {
        if (obj.type == 1U && obj.hang == 0U || obj.type == 1U && obj.hang == 1U || (obj.type == 1U && obj.hang == 2U || obj.type == 1U && obj.hang == 3U) || (obj.type == 1U && obj.hang == 4U || obj.type == 1U && obj.hang == 5U || (obj.type == 1U && obj.hang == 11U || obj.type == 1U && obj.hang == 17U)) || obj.type == 1U && obj.hang == 18U || obj.type == 1U && obj.hang == 19U)
        {
          this.listView1.Items.Add(new ListViewItem(new string[1]
          {
            obj.Name + obj.chisoitem
          }));
          this.player.setthaydo.Add(new Player.Item()
          {
            Name = obj.Name + obj.chisoitem
          });
        }
      }
    }

    private void Button6_Click(object sender, EventArgs e)
    {
      this.listView2.Items.Clear();
      this.player.setthaydo2.Clear();
      foreach (Player.Item obj in ReadMem.GetItemList(this.player.HProcess))
      {
        if (obj.type == 1U && obj.hang == 0U || obj.type == 1U && obj.hang == 1U || (obj.type == 1U && obj.hang == 2U || obj.type == 1U && obj.hang == 3U) || (obj.type == 1U && obj.hang == 4U || obj.type == 1U && obj.hang == 5U || (obj.type == 1U && obj.hang == 11U || obj.type == 1U && obj.hang == 17U)) || obj.type == 1U && obj.hang == 18U || obj.type == 1U && obj.hang == 19U)
        {
          this.listView2.Items.Add(new ListViewItem(new string[1]
          {
            obj.Name + obj.chisoitem
          }));
          this.player.setthaydo2.Add(new Player.Item()
          {
            Name = obj.Name + obj.chisoitem
          });
        }
      }
    }

    private void Button8_Click(object sender, EventArgs e)
    {
      this.listView3.Items.Clear();
      this.player.setthaydo3.Clear();
      foreach (Player.Item obj in ReadMem.GetItemList(this.player.HProcess))
      {
        if (obj.type == 1U && obj.hang == 0U || obj.type == 1U && obj.hang == 1U || (obj.type == 1U && obj.hang == 2U || obj.type == 1U && obj.hang == 3U) || (obj.type == 1U && obj.hang == 4U || obj.type == 1U && obj.hang == 5U || (obj.type == 1U && obj.hang == 11U || obj.type == 1U && obj.hang == 17U)) || obj.type == 1U && obj.hang == 18U || obj.type == 1U && obj.hang == 19U)
        {
          this.listView3.Items.Add(new ListViewItem(new string[1]
          {
            obj.Name + obj.chisoitem
          }));
          this.player.setthaydo3.Add(new Player.Item()
          {
            Name = obj.Name + obj.chisoitem
          });
        }
      }
    }

    private void Button7_Click(object sender, EventArgs e)
    {
      this.listView4.Items.Clear();
      this.player.setthaydo4.Clear();
      foreach (Player.Item obj in ReadMem.GetItemList(this.player.HProcess))
      {
        if (obj.type == 1U && obj.hang == 0U || obj.type == 1U && obj.hang == 1U || (obj.type == 1U && obj.hang == 2U || obj.type == 1U && obj.hang == 3U) || (obj.type == 1U && obj.hang == 4U || obj.type == 1U && obj.hang == 5U || (obj.type == 1U && obj.hang == 11U || obj.type == 1U && obj.hang == 17U)) || obj.type == 1U && obj.hang == 18U || obj.type == 1U && obj.hang == 19U)
        {
          this.listView4.Items.Add(new ListViewItem(new string[1]
          {
            obj.Name + obj.chisoitem + obj?.ToString()
          }));
          this.player.setthaydo4.Add(new Player.Item()
          {
            Name = obj.Name + obj.chisoitem
          });
        }
      }
    }

    private void Cbphimbo1_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.player.cobophim1 = this.cbphimbo1.Text;
    }

    private void Cbphimbo2_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.player.cobophim2 = this.cbphimbo2.Text;
    }

    private void Cbphimbo3_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.player.cobophim3 = this.cbphimbo3.Text;
    }

    private void Cbphimbo4_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.player.cobophim4 = this.cbphimbo4.Text;
    }

    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
  }
}
