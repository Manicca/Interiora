using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FunctionalityLibrary;
using FunctionalityLibrary.Drawing;
using FunctionalityLibrary.Drawing.History;
using FunctionalityLibrary.Drawing.OfficeEquipment;
using FunctionalityLibrary.Modes;
using Models;

namespace InterioraClient
{
    public partial class WorkForm : Form
    {
        public WorkForm()
        {
            InitializeComponent();
        }

        private WorkMode _mode = new WorkMode(EnumOfModes.Manual);
        private int _preferredNumberOfWorkSpaces = -1;
        public void SetMode(WorkMode newMode)
        {
            _mode = newMode;
        }

        public void SetPreferredNumberOfWorkSpaces(int number)
        {
            _preferredNumberOfWorkSpaces = number;
        }

        public Bitmap SaveBitmap { private get; set; }
        public HistoryDrawing History { get; set; }

        private void button3_Click(object sender, EventArgs e)
        {
            var doneform = new DoneForm();
            doneform.Show();
            Hide();
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            var screenPosition = MousePosition;
            var listBoxClientAreaPosition = listBox1.PointToClient(screenPosition);

            listBox1.SelectedIndex = listBox1.IndexFromPoint(listBoxClientAreaPosition);
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var screenPosition = MousePosition;
                var listBoxClientAreaPosition = listBox1.PointToClient(screenPosition);

                listBox1.SelectedIndex = listBox1.IndexFromPoint(listBoxClientAreaPosition);
                //MessageBox.Show("Перейти к определению параметров");
                var dbform = new DataBaseForm();
                dbform.Show(this);
                // dbform.f = this;
                var dbView = dbform.dataGridView1;
                var db = new AllModelsContext();
                dbView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                switch (listBox1.SelectedIndex)
                {
                    case 0:
                        dbView.DataSource = db.FurnituresDb.Where(elem => elem.Type == "Table").ToList();
                        dbform.SaveList = dbView.DataSource;
                        break;
                    case 1:
                        dbView.DataSource = db.FurnituresDb.Where(elem => elem.Type == "chair").ToList();
                        dbform.SaveList = dbView.DataSource;
                        break;
                    case 2:
                        dbView.DataSource = db.FurnituresDb.Where(elem => elem.Type == "CupBoard").ToList();
                        dbform.SaveList = dbView.DataSource;
                        break;
                    case 3:
                        dbView.DataSource = db.FurnituresDb.Where(elem => elem.Type == "ForClothes").ToList();
                        dbform.SaveList = dbView.DataSource;
                        break;
                    case 4:
                        dbView.DataSource = db.FurnituresDb.Where(elem => elem.Type == "ARM").ToList();
                        dbform.SaveList = dbView.DataSource;
                        break;
                    case 5:
                        dbView.DataSource = db.WebEquipmentsDb.Where(elem => elem.TypeOfWebEquipmentId == 1).ToList();
                        dbform.SaveList = dbView.DataSource;
                        break;
                    case 6:
                        dbView.DataSource = db.WebEquipmentsDb.Where(elem => elem.TypeOfWebEquipmentId == 2).ToList();
                        dbform.SaveList = dbView.DataSource;
                        break;
                    case 7:
                        dbView.DataSource = db.WebEquipmentsDb.Where(elem => elem.TypeOfWebEquipmentId == 3).ToList();
                        dbform.SaveList = dbView.DataSource;
                        break;
                }


                //this.Hide();
            }
        }

        private void WorkForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormsHelper.FormCloser(this, ref e);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var f = listBox1.SelectedItem as MainOfficeClass;
            if (f != null)
                toolTip1.SetToolTip(listBox1, f.GetToolTipInfo());
        }

        private void WorkForm_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = SaveBitmap;
        }

        private void WorkForm_Shown(object sender, EventArgs e)
        {
            var modeSelectorForm = new ModeSelectorForm();
            modeSelectorForm.ShowDialog(this);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var pos = pictureBox1.PointToClient(MousePosition);
            
        }
    }

    
}