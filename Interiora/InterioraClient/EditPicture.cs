using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterioraClient
{
    public partial class EditPicture : Form
    {
        public EditPicture()
        {
            InitializeComponent();
        }
       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Edit_Load(object sender, EventArgs e)
        {
            
        }

        private void Edit_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var workform = new InterioraClient.WorkForm();
            workform.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           button2.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button4.Enabled = true;
        }

    }
}
