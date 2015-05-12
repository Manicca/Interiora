using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Modals;

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
            var form = new EditPicture { SaveBmp = (Bitmap)pictureBox1.Image };
            form.Show();
            Hide();
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
            var db = new AllModelsContext();
            db.SaveChanges();
            db.Dispose();
            button3.Enabled = true;
        }

        private void MainFormWork_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            var gr = Graphics.FromImage(bm);
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
