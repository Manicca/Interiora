using System;
using System.Windows.Forms;

namespace InterioraClient
{
    public partial class SizeInfoForm : Form
    {
        public SizeInfoForm()
        {
            InitializeComponent();
        }

        private void SizeInfoForm_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var work = Owner as MainFormWork;
            if (work != null)
            {
                var w = int.Parse(textBox1.Text);
                var h = int.Parse(textBox2.Text);

                work.SetNewProjectSize(w, h);
            }
            Close();
        }

        private void SizeInfoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            var work = Owner as MainFormWork;
            if (work != null)
                work.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormsHelper.GoToBackwardForm(this, Owner);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FormsHelper.RemoveNotDigitsFromTb(ref textBox1);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            FormsHelper.RemoveNotDigitsFromTb(ref textBox2);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}