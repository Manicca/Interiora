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
using InterioraClient.Properties;
using FunctionalityLibrary.Drawing.Figures;

namespace InterioraClient
{
    public partial class WorkForm : Form
    {
        private readonly DbWorker _db = new DbWorker();
        private readonly int maxZoom = 3;
        private float _factor = 1.0f;
        private WorkMode _mode = new WorkMode(EnumOfModes.Manual);
        private int _preferredNumberOfWorkSpaces = -1;
        private List<PointF> PointsForTwistedPair = new List<PointF>();
        public Bitmap InitialBmp;
        private HistoryIterator _historyIterator = new HistoryIterator(0, 0);
        private PointF _start;
        private PointF _end;
        private FormsHelper.ButtonClicker _buttonClicker = new FormsHelper.ButtonClicker();
        private readonly StartPointFigure _stp = new StartPointFigure();
        private Bitmap _saveBmp;

        public WorkForm()
        {
            InitializeComponent();
            backgroundWorker1.RunWorkerAsync();
            button4.Enabled = false;
            trackBar1.Value = trackBar1.Maximum / maxZoom;
        }

        public void BlockInstruments()
        {
            listBox1.Enabled = false;
        }

        public void UnBlockInstruments()
        {
            listBox1.Enabled = true;
        }

        public HistoryDrawing History { get; set; }

        private void RestoreBmp(ref Bitmap bmp)
        {
            bmp = (Bitmap)_saveBmp.Clone();
        }

        private void SaveBmp(Bitmap bmp)
        {
            _saveBmp = (Bitmap)bmp.Clone();
        }

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
            doneform.History = History;
            doneform.Show(this);
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
                    dbView.DataSource = _db.SelectFromBd<Furniture>(elem => elem.Type == "Chair");
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
                //case 4:
                //    dbView.DataSource = _db.SelectFromBd<Furniture>(elem => elem.Type == "ARM");
                //    dbform.SaveList = dbView.DataSource;
                //    break;
                case 5:
                    dbView.DataSource = _db.SelectFromBd<WebEquipment>(elem => elem.TypeOfWebEquipmentId == 1);
                    dbform.SaveList = dbView.DataSource;
                    break;
                case 6:
                    dbView.DataSource = _db.SelectFromBd<WebEquipment>(elem => elem.TypeOfWebEquipmentId == 2);
                    dbform.SaveList = dbView.DataSource;
                    break;
                case 4:
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


            //if (selectedItem != null)
            //{
            //    Factor.UnCountFactor(ref pos, _factor);
            //    History.RemoveOfficeFigureAfterByIndex(_historyIterator.Current);

            //    selectedItem.FirstLocationPoint = pos;

            //    if (!IsOptionalDrawing)
            //    {
            //        var tmpItem = selectedItem;
            //        var resCoor = CoordinateCorrector.CorrectOfficeCoordinate(ref tmpItem, bmp, _factor, History);
            //        selectedItem = tmpItem;
            //        if (resCoor)
            //        {
            //            selectedItem.Draw(ref bmp, selectedItem.FirstLocationPoint, _factor);
            //            History.AddOfficeFigure(selectedItem.Clone() as OfficeFigure);
            //            _historyIterator.HistoryUpdate(History.CountOfficeFigures(), History.CountOfficeFigures());
            //        }
            //        else
            //        {
            //            FormsHelper.FormWarningMeassage("Нельзя так разместить объект типа \"" + selectedItem.ToString() + "\"!" +
            //                Environment.NewLine + "Возможно объект пересекается с другими объектами.");
            //        }
            //    }
            //    else
            //    {
            //        if (++_buttonClicks == 1)
            //        {
            //            _start = pos;
            //        }
            //        else
            //        {
            //            _end = pos;
            //            _buttonClicks = 0;
            //            var tmp = selectedItem as TwistedPair;
            //            selectedItem.Draw(ref bmp, selectedItem.FirstLocationPoint, _factor);
            //            History.AddOfficeFigure(selectedItem.Clone() as OfficeFigure);
            //            _historyIterator.HistoryUpdate(History.CountOfficeFigures(), History.CountOfficeFigures());
            //        }
            //    }
            //}
            var currentPosition = (PointF)pictureBox1.PointToClient(MousePosition);
            var selectedItem = listBox1.SelectedItem as OfficeFigure;
            var isOptionalDrawing = selectedItem is TwistedPair;
            var isNeedMoreDrawingArea = selectedItem is Switchboard;
            var bmp = (Bitmap)pictureBox1.Image;
            _buttonClicker.Click();

            if (!_buttonClicker.IsSecondClick())
            {
                BlockInstruments();
                _start = currentPosition;
                Factor.UnCountFactor(ref _start, _factor);
                SaveBmp(bmp);
                _stp.DrawPoint(ref bmp, _start, _factor);
                selectedItem.FirstLocationPoint = currentPosition;
                if (!isOptionalDrawing)
                {
                    _buttonClicker.RemoveStatistics();
                    History.RemoveOfficeFigureAfterByIndex(_historyIterator.Current);

                    var tmpItem = selectedItem;
                    var resCoor = true;
                    if (isNeedMoreDrawingArea)
                        CoordinateCorrector.CorrectSwitchCoordinate(ref tmpItem, bmp, _factor);
                    else
                        resCoor = CoordinateCorrector.CorrectOfficeCoordinate(ref tmpItem, bmp, _factor, History); // Временный хак, сейчас можно поставить switch на стол
                    selectedItem = tmpItem;
                    if (resCoor)
                    {
                        RestoreBmp(ref bmp);
                        selectedItem.Draw(ref bmp, selectedItem.FirstLocationPoint, _factor);
                        History.AddOfficeFigure(selectedItem.Clone() as OfficeFigure);
                        _historyIterator.HistoryUpdate(History.CountOfficeFigures(), History.CountOfficeFigures());
                    }
                    else
                    {
                        selectedItem.Draw(ref bmp, selectedItem.FirstLocationPoint, _factor);
                        FormsHelper.FormWarningMeassage("Нельзя так разместить объект типа \"" + selectedItem.ToString() + "\"!" +
                            Environment.NewLine + "Возможно объект пересекается с другими объектами.");
                        RestoreBmp(ref bmp);
                    }
                    UnBlockInstruments();

                }
            }
            else
            {
                RestoreBmp(ref bmp);
                _end = currentPosition;
                Factor.UnCountFactor(ref _end, _factor);

                var twisted = selectedItem as TwistedPair;
                twisted.Points.Add(_end);
                History.RemoveOfficeFigureAfterByIndex(_historyIterator.Current);
                twisted.DrawLine(ref bmp, _start, _end, _factor, History);

                History.AddOfficeFigure(twisted);
                _historyIterator.HistoryUpdate(History.CountOfficeFigures(), History.CountOfficeFigures());

                twisted.Points.Clear();

                UnBlockInstruments();
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
                new ForClothesOfficeFigure(_db.SelectFirstOrDefaultFromBd<Furniture>(elem => elem.Type == "ForClothes")),
                new Switchboard(_db.SelectFirstOrDefaultFromBd<WebEquipment>(elem => elem.TypeOfWebEquipment.Name == "Коммутатор")),
                new TwistedPair(_db.SelectFirstOrDefaultFromBd<WebEquipment>(elem => elem.TypeOfWebEquipment.Name == "Витая пара"))
            };

            e.Result = officeFigures;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.DataSource = e.Result;
            listBox1.Enabled = true;
            button4.Enabled = true;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            _factor = FormsHelper.GetFactor(ref trackBar1, maxZoom);
            pictureBox1.Image = SizingImage.GetNewSizedBitmapFigures(History, _factor, InitialBmp);
            label2.Text = "Увеличение" + (int)(_factor * 100.0f) + "%";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var selectedtem = listBox1.SelectedItem as OfficeFigure;
            selectedtem.Rotate();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _historyIterator.PreviousOrFirst();
            var currentHistoryRecord = History.GetOfficeFigureByIndex(_historyIterator.Current, _factor);
            pictureBox1.Image = currentHistoryRecord;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            _historyIterator.NextOrLast();
            var currentHistoryRecord = History.GetOfficeFigureByIndex(_historyIterator.Current, _factor);
            pictureBox1.Image = currentHistoryRecord;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var dialogRes = MessageBox.Show(Resources.Delete_Message_Warning,
                Resources.Delete_Message_Warning_Title,
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning);

            if (dialogRes != DialogResult.OK) return;


            History.ClearOfficeFigures();
            _historyIterator.Clear();

            var historyLast = History.GetLastBitmapOrDefalutOfficeFigures(_factor);

            pictureBox1.Image = historyLast;
        }

       
        private void button8_Click(object sender, EventArgs e)
        {

        }
    }
}