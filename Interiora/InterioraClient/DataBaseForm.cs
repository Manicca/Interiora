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

                var ff = SaveList as IEnumerable<object>;
                ff = ff.Where(f => ObjectContains.String(f, containString)).ToList();
                dataGridView1.DataSource = ff;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormsHelper.GoToBackwardForm(this, Owner);
        }
    }
}