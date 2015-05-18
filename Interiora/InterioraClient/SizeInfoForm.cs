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
    public partial class SizeInfoForm : Form
    {
        public SizeInfoForm()
        {
            InitializeComponent();
        }

        private void SizeInfoForm_Load(object sender, EventArgs e)
        {
            for (var i = 1; i <= 10; i++)
            {
                comboBox1.Items.Add(i);
                comboBox2.Items.Add(i);
            }
            comboBox1.SelectedIndex = 1;
            comboBox2.SelectedIndex = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var work = Owner as MainFormWork;
            if (work != null)
            {
                
                work.SetNewProjectSize((int)comboBox1.SelectedItem,
                    (int)comboBox2.SelectedItem);
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
    }
}
