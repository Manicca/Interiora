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
               Bitmap targetImage = new Bitmap(openFileDialog1.FileName);
               pictureBox1.Image = targetImage;
          }

          private void button3_Click(object sender, EventArgs e)
          {
               var form = new InterioraClient.EditPicture();
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
          }
     }
}
