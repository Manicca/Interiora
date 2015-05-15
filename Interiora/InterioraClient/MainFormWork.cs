using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using InterioraClient.Properties;
using Modals;

namespace InterioraClient
{
    public partial class MainFormWork : Form
    {
        public MainFormWork()
        {
            _sizeH = 0;
            _sizeW = 0;
            InitializeComponent();
        }

        private int _sizeH = 0;
        private int _sizeW = 0;
        private Bitmap bmBitmap;
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new EditPicture { InitialBmp = bmBitmap };
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
            button3.Enabled = true;
        }

        private void MainFormWork_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            var sizeInfoForm = new SizeInfoForm();
            sizeInfoForm.Show(this);
            this.Enabled = false;
        }

        public void SetNewProjectSize(int heightCount, int widthCount)
        {
            var ppm = Settings.Default.PixelsPerMeter;
            _sizeH = heightCount;
            _sizeW = widthCount;
            bmBitmap = new Bitmap(_sizeW*ppm, _sizeH*ppm);
            var gr = Graphics.FromImage(bmBitmap);
            gr.Clear(Color.White);
            gr.Dispose();
            
            button3.Enabled = true;
        }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            //pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
            button3.Enabled = true;
        }

       
    }
}
