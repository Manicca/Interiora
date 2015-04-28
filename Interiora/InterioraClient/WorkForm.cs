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



        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {

            Point screenPosition = ListBox.MousePosition;
            Point listBoxClientAreaPosition = listBox1.PointToClient(screenPosition);

            listBox1.SelectedIndex = listBox1.IndexFromPoint(listBoxClientAreaPosition);
        }
        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                Point screenPosition = ListBox.MousePosition;
                Point listBoxClientAreaPosition = listBox1.PointToClient(screenPosition);

                listBox1.SelectedIndex = listBox1.IndexFromPoint(listBoxClientAreaPosition);
                MessageBox.Show("Перейти к определению параметров");
            }
        }


        private void WorkForm_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            FormsHelper.FormCloser(this, ref e);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(listBox1, "Тут происходит получение данных о конкретном объекте");
        }
    }
}
