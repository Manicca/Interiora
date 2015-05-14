using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FunctionalityLibrary.Drawing;
using FunctionalityLibrary.Drawing.History;
using Modals;

namespace InterioraClient
{
    public partial class WorkForm : Form
    {
        public WorkForm()
        {
            InitializeComponent();
        }

        public Bitmap SaveBitmap { private get; set; }
        public HistoryDrawing History { private get; set; }

        private void button3_Click(object sender, EventArgs e)
        {
            var doneform = new DoneForm();
            doneform.Show();
            Hide();
        }
        private void WorkForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormsHelper.FormCloser(this, ref e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var drfun = new DrawFunctions();

            //drfun.Table(ref pictureBox1);
            //drfun.Chair(ref pictureBox1);
            drfun.ForClothes(ref pictureBox1);
        }



        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {

            Point screenPosition = MousePosition;
            Point listBoxClientAreaPosition = listBox1.PointToClient(screenPosition);

            listBox1.SelectedIndex = listBox1.IndexFromPoint(listBoxClientAreaPosition);
        }
        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point screenPosition = MousePosition;
                Point listBoxClientAreaPosition = listBox1.PointToClient(screenPosition);

                listBox1.SelectedIndex = listBox1.IndexFromPoint(listBoxClientAreaPosition);
                //MessageBox.Show("Перейти к определению параметров");
                var dbform = new DataBaseForm();
                dbform.Show();
               // dbform.f = this;
                var dbView = (DataGridView)dbform.Controls.Find("dataGridView1", false).First();
                var db= new AllModelsContext();
                dbView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                if (listBox1.SelectedIndex == 0)
                {

                    dbView.DataSource = db.FurnituresDb.ToList();

                    
                    //BindingSource.Filter = "[Type] = 'chair'";               
                    
                }
                if (listBox1.SelectedIndex == 1)
                {
                    dbView.DataSource = db.FurnituresDb.ToList();
                }
                if (listBox1.SelectedIndex == 2)
                {
                    dbView.DataSource = db.FurnituresDb.ToList();
                }
                if (listBox1.SelectedIndex == 3)
                {
                    dbView.DataSource = db.FurnituresDb.ToList();
                }
                if (listBox1.SelectedIndex == 4)
                {
                    dbView.DataSource = db.FurnituresDb.ToList();
                }
                if (listBox1.SelectedIndex == 5)
                {
                    dbView.DataSource = db.WebEquipmentsDb.ToList();
                }
                if (listBox1.SelectedIndex == 6)
                {
                    dbView.DataSource = db.WebEquipmentsDb.ToList();
                }
                if (listBox1.SelectedIndex == 7)
                {
                    dbView.DataSource = db.WebEquipmentsDb.ToList();
                }
                
                //this.Hide();

            }
        }


        private void WorkForm_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            FormsHelper.FormCloser(this, ref e);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == 0)
            {
                toolTip1.SetToolTip(listBox1, listBox1.SelectedItem.ToString());
            }
            if (listBox1.SelectedIndex == 1)
            {
                toolTip1.SetToolTip(listBox1, listBox1.SelectedItem.ToString());
            }
            if (listBox1.SelectedIndex == 2)
            {
                toolTip1.SetToolTip(listBox1, listBox1.SelectedItem.ToString());
            }
            if (listBox1.SelectedIndex == 3)
            {
                toolTip1.SetToolTip(listBox1, listBox1.SelectedItem.ToString());
            }
            if (listBox1.SelectedIndex == 4)
            {
                toolTip1.SetToolTip(listBox1, listBox1.SelectedItem.ToString());
            }
            if (listBox1.SelectedIndex == 5)
            {
                toolTip1.SetToolTip(listBox1, listBox1.SelectedItem.ToString());
            }
            if (listBox1.SelectedIndex == 6)
            {
                toolTip1.SetToolTip(listBox1, listBox1.SelectedItem.ToString());
            }
            if (listBox1.SelectedIndex == 7)
            {
                toolTip1.SetToolTip(listBox1, listBox1.SelectedItem.ToString());
            }
            //toolTip1.SetToolTip(listBox1, "Тут происходит получение данных о конкретном объекте");
        }

        private void WorkForm_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = SaveBitmap;
        }
    }
}
