// Decompiled with JetBrains decompiler
// Type: dorajx2.DownloadProgress
// Assembly: T2Auto, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3D2B1643-7C06-428B-9BDA-29369F42091D
// Assembly location: C:\Users\itoutsource06\Desktop\AutoT2\Auto Jx2\T2Auto.exe

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace dorajx2
{
  public class DownloadProgress : Form
  {
    private IContainer components = (IContainer) null;
    public ProgressBar progressBar1;

    public DownloadProgress()
    {
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (DownloadProgress));
      this.progressBar1 = new ProgressBar();
      this.SuspendLayout();
      this.progressBar1.Location = new Point(39, 29);
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new Size(284, 23);
      this.progressBar1.TabIndex = 1;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(362, 81);
      this.Controls.Add((Control) this.progressBar1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (DownloadProgress);
      this.StartPosition = FormStartPosition.Manual;
      this.Text = "Update by dorajx2";
      this.ResumeLayout(false);
    }
  }
}
