using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using InterioraClient.Properties;
using Models;

namespace InterioraClient
{
    public partial class MainFormWork : Form
    {
        private int _sizeH;
        private int _sizeW;
        private Bitmap _bmBitmap;

        public MainFormWork()
        {
            InitializeComponent();
            _sizeH = 0;
            _sizeW = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        public void NextForm()
        {
            var form = new EditPicture {InitialBmp = _bmBitmap};
            form.Show(this);
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
        }

        private void MainFormWork_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var sizeInfoForm = new SizeInfoForm();
            sizeInfoForm.ShowDialog(this);
            NextForm();
        }

        public void SetNewProjectSize(int heightCount, int widthCount)
        {
            var ppm = Settings.Default.PixelsPerMeter;
            _sizeH = heightCount;
            _sizeW = widthCount;
            _bmBitmap = new Bitmap(_sizeW*ppm, _sizeH*ppm);
            var gr = Graphics.FromImage(_bmBitmap);
            gr.Clear(Color.White);
            gr.Dispose();

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            //pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
        }
    }
}