using FunctionalityLibrary.Calculation;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterioraClient.AdminForms
{
    public partial class MainAdminForm : Form
    {
        public MainAdminForm()
        {
            InitializeComponent();
        }
        DbWorker db = new DbWorker();
        private object _saveList;
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormsHelper.GoToBackwardForm(this, Owner);
        }

        private void MainAdminForm_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = db.getAllDbNames();

        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _saveList = db.SelectFromBdByTableName(comboBox1.SelectedItem.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var containString = textBox1.Text;
            var ff = _saveList as IEnumerable<object>;
            ff = ff.Where(f => ObjectContains.String(f, containString)).ToList();
            dataGridView1.DataSource = ff;
        }
    }
}
