using WeifenLuo.WinFormsUI.Docking;

namespace InterioraClient
{
    partial class EditPicture
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
               this.panel1 = new System.Windows.Forms.Panel();
               this.trackBar1 = new System.Windows.Forms.TrackBar();
               this.button2 = new System.Windows.Forms.Button();
               this.button3 = new System.Windows.Forms.Button();
               ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
               this.panel1.SuspendLayout();
               ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
               this.SuspendLayout();
               // 
               // pictureBox1
               // 
               this.pictureBox1.Location = new System.Drawing.Point(3, 3);
               this.pictureBox1.Name = "pictureBox1";
               this.pictureBox1.Size = new System.Drawing.Size(100, 100);
               this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
               this.pictureBox1.TabIndex = 0;
               this.pictureBox1.TabStop = false;
               this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
               this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
               this.pictureBox1.MouseHover += new System.EventHandler(this.pictureBox1_MouseHover);
               this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
               this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
               // 
               // button1
               // 
               this.button1.Location = new System.Drawing.Point(732, 442);
               this.button1.Name = "button1";
               this.button1.Size = new System.Drawing.Size(147, 43);
               this.button1.TabIndex = 5;
               this.button1.Text = "Далее";
               this.button1.UseVisualStyleBackColor = true;
               this.button1.Click += new System.EventHandler(this.button1_Click);
               // 
               // panel1
               // 
               this.panel1.AutoScroll = true;
               this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
               this.panel1.Controls.Add(this.pictureBox1);
               this.panel1.Location = new System.Drawing.Point(12, 61);
               this.panel1.Name = "panel1";
               this.panel1.Size = new System.Drawing.Size(714, 386);
               this.panel1.TabIndex = 11;
               this.panel1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panel1_Scroll);
               this.panel1.MouseHover += new System.EventHandler(this.panel1_MouseHover);
               this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
               // 
               // trackBar1
               // 
               this.trackBar1.Location = new System.Drawing.Point(12, 453);
               this.trackBar1.Maximum = 100;
               this.trackBar1.Name = "trackBar1";
               this.trackBar1.Size = new System.Drawing.Size(714, 45);
               this.trackBar1.TabIndex = 12;
               this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
               // 
               // button2
               // 
               this.button2.Location = new System.Drawing.Point(732, 61);
               this.button2.Name = "button2";
               this.button2.Size = new System.Drawing.Size(189, 43);
               this.button2.TabIndex = 13;
               this.button2.Text = "Открыть окно опций";
               this.button2.UseVisualStyleBackColor = true;
               this.button2.Click += new System.EventHandler(this.button2_Click);
               // 
               // button3
               // 
               this.button3.Location = new System.Drawing.Point(12, 12);
               this.button3.Name = "button3";
               this.button3.Size = new System.Drawing.Size(68, 43);
               this.button3.TabIndex = 14;
               this.button3.Text = "Отмена";
               this.button3.UseVisualStyleBackColor = true;
               this.button3.Click += new System.EventHandler(this.button3_Click);
               // 
               // EditPicture
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(933, 497);
               this.Controls.Add(this.button3);
               this.Controls.Add(this.button2);
               this.Controls.Add(this.trackBar1);
               this.Controls.Add(this.panel1);
               this.Controls.Add(this.button1);
               this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
               this.MaximizeBox = false;
               this.MinimizeBox = false;
               this.Name = "EditPicture";
               this.Text = "Edit";
               this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditPicture_FormClosing);
               this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Edit_FormClosed);
               this.Load += new System.EventHandler(this.Edit_Load);
               ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
               this.panel1.ResumeLayout(false);
               this.panel1.PerformLayout();
               ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
               this.ResumeLayout(false);
               this.PerformLayout();

          }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
          private System.Windows.Forms.Panel panel1;
          private System.Windows.Forms.TrackBar trackBar1;
          private System.Windows.Forms.Button button2;
          private System.Windows.Forms.Button button3;
     }
}