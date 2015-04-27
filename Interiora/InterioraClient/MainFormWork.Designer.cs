namespace InterioraClient
{
    partial class MainFormWork
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
               this.button1 = new System.Windows.Forms.Button();
               this.button2 = new System.Windows.Forms.Button();
               this.pictureBox1 = new System.Windows.Forms.PictureBox();
               this.button3 = new System.Windows.Forms.Button();
               this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
               ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
               this.SuspendLayout();
               // 
               // button1
               // 
               this.button1.Location = new System.Drawing.Point(550, 12);
               this.button1.Name = "button1";
               this.button1.Size = new System.Drawing.Size(129, 46);
               this.button1.TabIndex = 0;
               this.button1.Text = "Загрузить";
               this.button1.UseVisualStyleBackColor = true;
               this.button1.Click += new System.EventHandler(this.button1_Click);
               // 
               // button2
               // 
               this.button2.Location = new System.Drawing.Point(550, 64);
               this.button2.Name = "button2";
               this.button2.Size = new System.Drawing.Size(129, 50);
               this.button2.TabIndex = 1;
               this.button2.Text = "Выбрать из библиотеки";
               this.button2.UseVisualStyleBackColor = true;
               this.button2.Click += new System.EventHandler(this.button2_Click);
               // 
               // pictureBox1
               // 
               this.pictureBox1.Image = global::InterioraClient.Properties.Resources._2dkRaUJ9ArI;
               this.pictureBox1.InitialImage = null;
               this.pictureBox1.Location = new System.Drawing.Point(12, 12);
               this.pictureBox1.Name = "pictureBox1";
               this.pictureBox1.Size = new System.Drawing.Size(532, 330);
               this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
               this.pictureBox1.TabIndex = 2;
               this.pictureBox1.TabStop = false;
               // 
               // button3
               // 
               this.button3.Enabled = false;
               this.button3.Location = new System.Drawing.Point(550, 120);
               this.button3.Name = "button3";
               this.button3.Size = new System.Drawing.Size(129, 50);
               this.button3.TabIndex = 3;
               this.button3.Text = "ОК";
               this.button3.UseVisualStyleBackColor = true;
               this.button3.Click += new System.EventHandler(this.button3_Click);
               // 
               // openFileDialog1
               // 
               this.openFileDialog1.FileName = "openFileDialog1";
               // 
               // MainFormWork
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(691, 354);
               this.Controls.Add(this.button3);
               this.Controls.Add(this.pictureBox1);
               this.Controls.Add(this.button2);
               this.Controls.Add(this.button1);
               this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
               this.MaximizeBox = false;
               this.MinimizeBox = false;
               this.Name = "MainFormWork";
               this.Text = "Form1";
               this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormWork_FormClosing);
               this.Load += new System.EventHandler(this.MainFormWork_Load);
               this.Click += new System.EventHandler(this.MainFormWork_Click);
               ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
               this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

