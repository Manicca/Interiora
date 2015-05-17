using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using InterioraClient.Properties;

namespace InterioraClient
{
    public partial class ModeSelectorForm : Form
    {
        public ModeSelectorForm()
        {
            InitializeComponent();
            comboBox1.Items.Add(Resources.ModeSelectorForm_ModeSelectorForm_Modes_Auto);
            comboBox1.Items.Add(Resources.ModeSelectorForm_ModeSelectorForm_Semi_Automatic);
            comboBox1.Items.Add(Resources.ModeSelectorForm_ModeSelectorForm_Modes_Hands);
            comboBox1.SelectedIndex = 2;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = comboBox1.SelectedItem.ToString() ==
                               Resources.ModeSelectorForm_ModeSelectorForm_Modes_Auto ||
                               comboBox1.SelectedItem.ToString() ==
                               Resources.ModeSelectorForm_ModeSelectorForm_Semi_Automatic;
            label2.Enabled = textBox1.Enabled;
        }

        private void ModeSelectorForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FormsHelper.RemoveNotDigitsFromTb(ref textBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
