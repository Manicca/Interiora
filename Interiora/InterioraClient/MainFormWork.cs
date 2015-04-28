using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;

namespace InterioraClient
{
     public partial class MainFormWork : Form
     {
          public MainFormWork()
          {
               InitializeComponent();
          }

          private void button1_Click(object sender, EventArgs e)
          {
               openFileDialog1.ShowDialog();
               
          }

          private void button3_Click(object sender, EventArgs e)
          {
               var form = new InterioraClient.EditPicture();
               form.saveBMP = (Bitmap)pictureBox1.Image;
               form.Show();
               this.Hide();
          }

          private void MainFormWork_Load(object sender, EventArgs e)
          {

          }

          private void MainFormWork_FormClosing(object sender, FormClosingEventArgs e)
          {
               FormsHelper.FormCloser(this, ref e);
          }

          private void button2_Click(object sender, EventArgs e)
          {
               AllModelsContext _db = new AllModelsContext();
               _db.SaveChanges();
               _db.Dispose();
               button3.Enabled = true;
          }

          private void MainFormWork_Click(object sender, EventArgs e)
          {

          }

          private void button4_Click(object sender, EventArgs e)
          {
               Bitmap bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
               Graphics gr = Graphics.FromImage(bm);
               gr.Clear(Color.White);
               gr.Dispose();
               pictureBox1.Image = bm;
               button3.Enabled = true;
          }

          private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
          {
               pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
               button3.Enabled = true;
          }
     }
}
