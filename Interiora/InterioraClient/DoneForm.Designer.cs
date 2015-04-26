namespace InterioraClient
{
     partial class DoneForm
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
               this.button2 = new System.Windows.Forms.Button();
               this.button3 = new System.Windows.Forms.Button();
               this.button4 = new System.Windows.Forms.Button();
               this.textBox1 = new System.Windows.Forms.TextBox();
               this.label1 = new System.Windows.Forms.Label();
               ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
               this.SuspendLayout();
               // 
               // pictureBox1
               // 
               this.pictureBox1.Location = new System.Drawing.Point(12, 18);
               this.pictureBox1.Name = "pictureBox1";
               this.pictureBox1.Size = new System.Drawing.Size(327, 404);
               this.pictureBox1.TabIndex = 0;
               this.pictureBox1.TabStop = false;
               // 
               // button1
               // 
               this.button1.Location = new System.Drawing.Point(359, 31);
               this.button1.Name = "button1";
               this.button1.Size = new System.Drawing.Size(137, 53);
               this.button1.TabIndex = 1;
               this.button1.Text = "Назад";
               this.button1.UseVisualStyleBackColor = true;
               // 
               // button2
               // 
               this.button2.Location = new System.Drawing.Point(370, 276);
               this.button2.Name = "button2";
               this.button2.Size = new System.Drawing.Size(138, 50);
               this.button2.TabIndex = 2;
               this.button2.Text = "Отправить отчет";
               this.button2.UseVisualStyleBackColor = true;
               this.button2.Click += new System.EventHandler(this.button2_Click);
               // 
               // button3
               // 
               this.button3.Location = new System.Drawing.Point(370, 356);
               this.button3.Name = "button3";
               this.button3.Size = new System.Drawing.Size(138, 47);
               this.button3.TabIndex = 3;
               this.button3.Text = "Отправить бланки";
               this.button3.UseVisualStyleBackColor = true;
               // 
               // button4
               // 
               this.button4.Location = new System.Drawing.Point(358, 109);
               this.button4.Name = "button4";
               this.button4.Size = new System.Drawing.Size(149, 50);
               this.button4.TabIndex = 4;
               this.button4.Text = "Документация ( просмотр отчетов и бланков)";
               this.button4.UseVisualStyleBackColor = true;
               // 
               // textBox1
               // 
               this.textBox1.Location = new System.Drawing.Point(369, 235);
               this.textBox1.Name = "textBox1";
               this.textBox1.Size = new System.Drawing.Size(144, 20);
               this.textBox1.TabIndex = 5;
               // 
               // label1
               // 
               this.label1.AutoSize = true;
               this.label1.Location = new System.Drawing.Point(367, 219);
               this.label1.Name = "label1";
               this.label1.Size = new System.Drawing.Size(70, 13);
               this.label1.TabIndex = 6;
               this.label1.Text = "Введите mail";
               // 
               // DoneForm
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(520, 436);
               this.Controls.Add(this.label1);
               this.Controls.Add(this.textBox1);
               this.Controls.Add(this.button4);
               this.Controls.Add(this.button3);
               this.Controls.Add(this.button2);
               this.Controls.Add(this.button1);
               this.Controls.Add(this.pictureBox1);
               this.Name = "DoneForm";
               this.Text = "Done";
               ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
               this.ResumeLayout(false);
               this.PerformLayout();
          }

          #endregion

          private System.Windows.Forms.PictureBox pictureBox1;
          private System.Windows.Forms.Button button1;
          private System.Windows.Forms.Button button2;
          private System.Windows.Forms.Button button3;
          private System.Windows.Forms.Button button4;
          private System.Windows.Forms.TextBox textBox1;
          private System.Windows.Forms.Label label1;
     }
}