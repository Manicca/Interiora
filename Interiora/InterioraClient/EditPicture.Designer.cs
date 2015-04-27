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
               this.button3 = new System.Windows.Forms.Button();
               this.button4 = new System.Windows.Forms.Button();
               this.button5 = new System.Windows.Forms.Button();
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
               this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
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
               this.panel1.MaximumSize = new System.Drawing.Size(714, 386);
               this.panel1.MinimumSize = new System.Drawing.Size(514, 186);
               this.panel1.Name = "panel1";
               this.panel1.Size = new System.Drawing.Size(714, 386);
               this.panel1.TabIndex = 11;
               // 
               // trackBar1
               // 
               this.trackBar1.Location = new System.Drawing.Point(12, 453);
               this.trackBar1.Maximum = 3;
               this.trackBar1.Name = "trackBar1";
               this.trackBar1.Size = new System.Drawing.Size(160, 45);
               this.trackBar1.TabIndex = 12;
               this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
               // 
               // button3
               // 
               this.button3.Location = new System.Drawing.Point(12, 12);
               this.button3.Name = "button3";
               this.button3.Size = new System.Drawing.Size(68, 43);
               this.button3.TabIndex = 14;
               this.button3.Text = "Назад";
               this.button3.UseVisualStyleBackColor = true;
               this.button3.Click += new System.EventHandler(this.button3_Click);
               // 
               // button4
               // 
               this.button4.Location = new System.Drawing.Point(86, 12);
               this.button4.Name = "button4";
               this.button4.Size = new System.Drawing.Size(68, 43);
               this.button4.TabIndex = 15;
               this.button4.Text = "Вперёд";
               this.button4.UseVisualStyleBackColor = true;
               this.button4.Click += new System.EventHandler(this.button4_Click);
               // 
               // button5
               // 
               this.button5.Location = new System.Drawing.Point(160, 12);
               this.button5.Name = "button5";
               this.button5.Size = new System.Drawing.Size(132, 43);
               this.button5.TabIndex = 16;
               this.button5.Text = "Очистить Всё";
               this.button5.UseVisualStyleBackColor = true;
               this.button5.Click += new System.EventHandler(this.button5_Click);
               // 
               // EditPicture
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(933, 497);
               this.Controls.Add(this.button5);
               this.Controls.Add(this.button4);
               this.Controls.Add(this.button3);
               this.Controls.Add(this.trackBar1);
               this.Controls.Add(this.panel1);
               this.Controls.Add(this.button1);
               this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
               this.MaximizeBox = false;
               this.MinimizeBox = false;
               this.Name = "EditPicture";
               this.Text = "Edit";
               this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditPicture_FormClosing);
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
          private System.Windows.Forms.Button button3;
          private System.Windows.Forms.Button button4;
          private System.Windows.Forms.Button button5;
     }
}