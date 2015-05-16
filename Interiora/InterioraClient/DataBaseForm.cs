using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using FunctionalityLibrary.Calculation;
using FunctionalityLibrary.Drawing;
using FunctionalityLibrary.Drawing.History;
using Modals;

namespace InterioraClient
{
    public partial class DataBaseForm : Form
    {
        public DataBaseForm()
        {
            InitializeComponent();
        }

        public object SaveList;
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{
        //}


    }
}
