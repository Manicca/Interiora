using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FunctionalityLibrary.Drawing.History;
using FunctionalityLibrary.Drawing.OfficeEquipment;
using FunctionalityLibrary.Modes;
using Models;

namespace InterioraClient
{
    public partial class WorkForm : Form
    {
        private readonly AllModelsContext _db = new AllModelsContext();
        private WorkMode _mode = new WorkMode(EnumOfModes.Manual);
        private int _preferredNumberOfWorkSpaces = -1;

        public WorkForm()
        {
            InitializeComponent();
        }

        public Bitmap SaveBitmap { private get; set; }
        public HistoryDrawing History { get; set; }

        public void SetMode(WorkMode newMode)
        {
            _mode = newMode;
        }

        public void SetPreferredNumberOfWorkSpaces(int number)
        {
            _preferredNumberOfWorkSpaces = number;
        }

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
                // dbform.f = this;
                var dbView = dbform.dataGridView1;

                dbView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                switch (listBox1.SelectedIndex)
                {
                    case 0:
                        dbView.DataSource = _db.FurnituresDb.Where(elem => elem.Type == "Table").ToList();
                        dbform.SaveList = dbView.DataSource;
                        break;
                    case 1:
                        dbView.DataSource = _db.FurnituresDb.Where(elem => elem.Type == "chair").ToList();
                        dbform.SaveList = dbView.DataSource;
                        break;
                    case 2:
                        dbView.DataSource = _db.FurnituresDb.Where(elem => elem.Type == "CupBoard").ToList();
                        dbform.SaveList = dbView.DataSource;
                        break;
                    case 3:
                        dbView.DataSource = _db.FurnituresDb.Where(elem => elem.Type == "ForClothes").ToList();
                        dbform.SaveList = dbView.DataSource;
                        break;
                    case 4:
                        dbView.DataSource = _db.FurnituresDb.Where(elem => elem.Type == "ARM").ToList();
                        dbform.SaveList = dbView.DataSource;
                        break;
                    case 5:
                        dbView.DataSource = _db.WebEquipmentsDb.Where(elem => elem.TypeOfWebEquipmentId == 1).ToList();
                        dbform.SaveList = dbView.DataSource;
                        break;
                    case 6:
                        dbView.DataSource = _db.WebEquipmentsDb.Where(elem => elem.TypeOfWebEquipmentId == 2).ToList();
                        dbform.SaveList = dbView.DataSource;
                        break;
                    case 7:
                        dbView.DataSource = _db.WebEquipmentsDb.Where(elem => elem.TypeOfWebEquipmentId == 3).ToList();
                        dbform.SaveList = dbView.DataSource;
                        break;
                }

                dbform.ShowDialog(this);

            }

        }

        private void WorkForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormsHelper.FormCloser(this, ref e);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var f = listBox1.SelectedItem as OfficeFigure;
            if (f != null)
                toolTip1.SetToolTip(listBox1, f.GetToolTipInfo());
        }

        private void WorkForm_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = SaveBitmap;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormsHelper.GoToBackwardForm(this, Owner);
        }

        private void WorkForm_Shown(object sender, EventArgs e)
        {
            var modeSelectorForm = new ModeSelectorForm();
            modeSelectorForm.ShowDialog(this);
            backgroundWorker1.RunWorkerAsync();
        }

        /*Стол
Стул
Шкаф
Вешалка
АРМ
Хаб
Коммутатор
Протянуть витую пару*/

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var pos = pictureBox1.PointToClient(MousePosition);
            var item = listBox1.SelectedItem as OfficeFigure;
            var bmp = (Bitmap) pictureBox1.Image;
            if (item != null)
                item.Draw(ref bmp, pos, 1);
            pictureBox1.Image = bmp;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var officeFigures = new List<OfficeFigure>
            {
                new TableOfficeFigure(_db.FurnituresDb.FirstOrDefault(elem => elem.Type == "Table")),
                new ChairOfficeFigure(_db.FurnituresDb.FirstOrDefault(elem => elem.Type == "Chair"))
            };

            e.Result = officeFigures;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.DataSource = e.Result;
            listBox1.Enabled = true;
        }
    }
}