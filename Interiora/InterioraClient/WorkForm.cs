using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using FunctionalityLibrary.Calculation;
using FunctionalityLibrary.Drawing.History;
using FunctionalityLibrary.Drawing.OfficeEquipment;
using FunctionalityLibrary.Modes;
using Models;

namespace InterioraClient
{
    public partial class WorkForm : Form
    {
        private readonly DbWorker _db = new DbWorker();
        private readonly int maxZoom = 3;
        private float _factor = 1.0f;
        private WorkMode _mode = new WorkMode(EnumOfModes.Manual);
        private int _preferredNumberOfWorkSpaces = -1;
        public Bitmap InitialBmp;

        public WorkForm()
        {
            InitializeComponent();
            backgroundWorker1.RunWorkerAsync();
            trackBar1.Value = trackBar1.Maximum/maxZoom;
        }

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
            if (e.Button != MouseButtons.Right) return;
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
                    dbView.DataSource = _db.SelectFromBd<Furniture>(elem => elem.Type == "Table");
                    dbform.SaveList = dbView.DataSource;
                    break;
                case 1:
                    dbView.DataSource = _db.SelectFromBd<Furniture>(elem => elem.Type == "chair");
                    dbform.SaveList = dbView.DataSource;
                    break;
                case 2:
                    dbView.DataSource = _db.SelectFromBd<Furniture>(elem => elem.Type == "CupBoard");
                    dbform.SaveList = dbView.DataSource;
                    break;
                case 3:
                    dbView.DataSource = _db.SelectFromBd<Furniture>(elem => elem.Type == "ForClothes");
                    dbform.SaveList = dbView.DataSource;
                    break;
                case 4:
                    dbView.DataSource = _db.SelectFromBd<Furniture>(elem => elem.Type == "ARM");
                    dbform.SaveList = dbView.DataSource;
                    break;
                case 5:
                    dbView.DataSource = _db.SelectFromBd<WebEquipment>(elem => elem.TypeOfWebEquipmentId == 1);
                    dbform.SaveList = dbView.DataSource;
                    break;
                case 6:
                    dbView.DataSource = _db.SelectFromBd<WebEquipment>(elem => elem.TypeOfWebEquipmentId == 2);
                    dbform.SaveList = dbView.DataSource;
                    break;
                case 7:
                    dbView.DataSource = _db.SelectFromBd<WebEquipment>(elem => elem.TypeOfWebEquipmentId == 3);
                    dbform.SaveList = dbView.DataSource;
                    break;
            }

            dbform.ShowDialog(this);
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
            pictureBox1.Image = InitialBmp;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormsHelper.GoToBackwardForm(this, Owner);
        }

        private void WorkForm_Shown(object sender, EventArgs e)
        {
            var modeSelectorForm = new ModeSelectorForm();
            modeSelectorForm.ShowDialog(this);
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
            {
                item.Draw(ref bmp, pos, 1);
                item.FirstLocationPoint = pos;
                History.AddOfficeFigure(item.Clone() as OfficeFigure);
            }
            pictureBox1.Image = bmp;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var officeFigures = new List<OfficeFigure>
            {
                new TableOfficeFigure(_db.SelectFirstOrDefaultFromBd<Furniture>(elem => elem.Type == "Table")),
                new ChairOfficeFigure(_db.SelectFirstOrDefaultFromBd<Furniture>(elem => elem.Type == "Chair")),
                new CupboardOfficeFigure(_db.SelectFirstOrDefaultFromBd<Furniture>(elem => elem.Type == "CupBoard")),
                new ForClothesOfficeFigure(_db.SelectFirstOrDefaultFromBd<Furniture>(elem => elem.Type == "ForClothes"))
            };

            e.Result = officeFigures;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.DataSource = e.Result;
            listBox1.Enabled = true;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            _factor = FormsHelper.GetFactor(ref trackBar1, maxZoom);
            pictureBox1.Image = SizingImage.GetNewSizedBitmapFigures(History, _factor, InitialBmp);
            label2.Text = $"Зум {(int) (_factor*100.0f)}%";
        }
    }
}