using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FunctionalityLibrary;

namespace InterioraClient
{
    public partial class WorkForm : Form
    {
        public WorkForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var doneform = new InterioraClient.DoneForm();
            doneform.Show();
            this.Hide();
        }
        private void WorkForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormsHelper.FormCloser(this, ref e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrawFunctions drfun = new DrawFunctions();
            
            //drfun.Table(ref pictureBox1);
            //drfun.Chair(ref pictureBox1);
            drfun.ForClothes(ref pictureBox1);
        }
    }
}
