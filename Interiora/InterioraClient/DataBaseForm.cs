using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FunctionalityLibrary.Calculation;
using Models;

namespace InterioraClient
{
    public partial class DataBaseForm : Form
    {
        public object SaveList;

        public DataBaseForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var containString = textBox1.Text;
            if (SaveList is List<Furniture>)
            {
                var ff = SaveList as List<Furniture>;
                ff = ff.Where(f => ObjectContains.String(f, containString)).ToList();
                dataGridView1.DataSource = ff;
            }
            else if (SaveList is List<WebEquipment>)
            {
                var ff = SaveList as List<WebEquipment>;
                ff = ff.Where(f => ObjectContains.String(f, containString)).ToList();
                dataGridView1.DataSource = ff;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormsHelper.GoToBackwardForm(this, Owner);
        }
    }
}