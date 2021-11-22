
namespace VirtualSign
{
  partial class UI
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.button1 = new System.Windows.Forms.Button();
      this.fspLabel = new System.Windows.Forms.Label();
      this.fps = new System.Windows.Forms.Label();
      this.averageFps = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // pictureBox1
      // 
      this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLight;
      this.pictureBox1.Location = new System.Drawing.Point(12, 12);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(775, 502);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(361, 520);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 1;
      this.button1.Text = "Start";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.StartButtonClick);
      // 
      // fspLabel
      // 
      this.fspLabel.AutoSize = true;
      this.fspLabel.Location = new System.Drawing.Point(12, 521);
      this.fspLabel.Name = "fspLabel";
      this.fspLabel.Size = new System.Drawing.Size(27, 13);
      this.fspLabel.TabIndex = 2;
      this.fspLabel.Text = "FPS";
      // 
      // fps
      // 
      this.fps.AutoSize = true;
      this.fps.Location = new System.Drawing.Point(45, 521);
      this.fps.Name = "fps";
      this.fps.Size = new System.Drawing.Size(13, 13);
      this.fps.TabIndex = 3;
      this.fps.Text = "0";
      // 
      // averageFps
      // 
      this.averageFps.AutoSize = true;
      this.averageFps.Location = new System.Drawing.Point(72, 521);
      this.averageFps.Name = "averageFps";
      this.averageFps.Size = new System.Drawing.Size(13, 13);
      this.averageFps.TabIndex = 4;
      this.averageFps.Text = "0";
      // 
      // UI
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 668);
      this.Controls.Add(this.averageFps);
      this.Controls.Add(this.fps);
      this.Controls.Add(this.fspLabel);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.pictureBox1);
      this.Name = "UI";
      this.Text = "Camera";
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label fspLabel;
    private System.Windows.Forms.Label fps;
    private System.Windows.Forms.Label averageFps;
  }
}