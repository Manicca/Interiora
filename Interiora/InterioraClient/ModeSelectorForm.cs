using System;
using System.Windows.Forms;
using FunctionalityLibrary.Modes;
using InterioraClient.Properties;

namespace InterioraClient
{
    public partial class ModeSelectorForm : Form
    {
        public ModeSelectorForm()
        {
            InitializeComponent();
            comboBox1.Items.Add(new WorkMode(EnumOfModes.Auto));
            comboBox1.Items.Add(new WorkMode(EnumOfModes.Semi));
            comboBox1.Items.Add(new WorkMode(EnumOfModes.Manual));
            comboBox1.SelectedIndex = 2;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = comboBox1.SelectedItem as WorkMode;
            if (item != null)
                textBox1.Enabled = item.Mode != EnumOfModes.Manual;
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
            var own = Owner as WorkForm;
            var selectedItem = comboBox1.SelectedItem as WorkMode;
            if (own == null) return;
            own.SetMode(selectedItem);
            if (selectedItem != null && selectedItem.Mode != EnumOfModes.Manual)
                if (textBox1.Text != "")
                    own.SetPreferredNumberOfWorkSpaces(int.Parse(textBox1.Text));
                else
                    MessageBox.Show(Resources.ModeSelectorForm_button1_Click_WrongTBData,
                        Resources.ModeSelectorForm_button1_Click_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            Dispose();
        }

        private void ModeSelectorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormsHelper.FormCloserOnlyWindow(this, ref e);
        }
    }
}