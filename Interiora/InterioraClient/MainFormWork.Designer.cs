﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using InterioraClient.Properties;

namespace InterioraClient
{
    partial class MainFormWork
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private IContainer components = null;

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
               this.button1 = new Button();
               this.button2 = new Button();
               this.pictureBox1 = new PictureBox();
               this.button3 = new Button();
               this.openFileDialog1 = new OpenFileDialog();
               this.button4 = new Button();
               ((ISupportInitialize)(this.pictureBox1)).BeginInit();
               this.SuspendLayout();
               // 
               // button1
               // 
               this.button1.Location = new Point(550, 12);
               this.button1.Name = "button1";
               this.button1.Size = new Size(129, 46);
               this.button1.TabIndex = 0;
               this.button1.Text = "Загрузить файл";
               this.button1.UseVisualStyleBackColor = true;
               this.button1.Click += new EventHandler(this.button1_Click);
               // 
               // button2
               // 
               this.button2.Location = new Point(550, 64);
               this.button2.Name = "button2";
               this.button2.Size = new Size(129, 50);
               this.button2.TabIndex = 1;
               this.button2.Text = "Выбрать из библиотеки";
               this.button2.UseVisualStyleBackColor = true;
               this.button2.Click += new EventHandler(this.button2_Click);
               // 
               // pictureBox1
               // 
               this.pictureBox1.BorderStyle = BorderStyle.Fixed3D;
               this.pictureBox1.Image = Resources._2dkRaUJ9ArI;
               this.pictureBox1.InitialImage = null;
               this.pictureBox1.Location = new Point(12, 12);
               this.pictureBox1.Name = "pictureBox1";
               this.pictureBox1.Size = new Size(532, 330);
               this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
               this.pictureBox1.TabIndex = 2;
               this.pictureBox1.TabStop = false;
               // 
               // button3
               // 
               this.button3.Enabled = false;
               this.button3.Location = new Point(550, 292);
               this.button3.Name = "button3";
               this.button3.Size = new Size(129, 50);
               this.button3.TabIndex = 3;
               this.button3.Text = "Далее";
               this.button3.UseVisualStyleBackColor = true;
               this.button3.Click += new EventHandler(this.button3_Click);
               // 
               // openFileDialog1
               // 
               this.openFileDialog1.FileName = "openFileDialog1";
               this.openFileDialog1.Filter = "Png-файлы|*.png";
               this.openFileDialog1.FileOk += new CancelEventHandler(this.openFileDialog1_FileOk);
               // 
               // button4
               // 
               this.button4.Location = new Point(550, 120);
               this.button4.Name = "button4";
               this.button4.Size = new Size(129, 50);
               this.button4.TabIndex = 4;
               this.button4.Text = "Новый проект";
               this.button4.UseVisualStyleBackColor = true;
               this.button4.Click += new EventHandler(this.button4_Click);
               // 
               // MainFormWork
               // 
               this.AutoScaleDimensions = new SizeF(6F, 13F);
               this.AutoScaleMode = AutoScaleMode.Font;
               this.ClientSize = new Size(691, 354);
               this.Controls.Add(this.button4);
               this.Controls.Add(this.button3);
               this.Controls.Add(this.pictureBox1);
               this.Controls.Add(this.button2);
               this.Controls.Add(this.button1);
               this.FormBorderStyle = FormBorderStyle.FixedSingle;
               this.MaximizeBox = false;
               this.MinimizeBox = false;
               this.Name = "MainFormWork";
               this.Text = "Form1";
               this.FormClosing += new FormClosingEventHandler(this.MainFormWork_FormClosing);
               this.Load += new EventHandler(this.MainFormWork_Load);
               this.Click += new EventHandler(this.MainFormWork_Click);
               ((ISupportInitialize)(this.pictureBox1)).EndInit();
               this.ResumeLayout(false);

        }

        #endregion

        private Button button1;
        private Button button2;
        private PictureBox pictureBox1;
        private Button button3;
        private OpenFileDialog openFileDialog1;
          private Button button4;
     }
}

