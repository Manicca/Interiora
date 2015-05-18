using System;
using System.Drawing;
using System.Windows.Forms;
using FunctionalityLibrary.Calculation;
using FunctionalityLibrary.Drawing;
using FunctionalityLibrary.Drawing.Figures;
using FunctionalityLibrary.Drawing.History;
using InterioraClient.Properties;

namespace InterioraClient
{
    public partial class EditPicture : Form
    {
        private readonly HistoryIterator _historyIterator;
        private readonly StartPointFigure _stp = new StartPointFigure();
        private Bitmap _bmpBeforeDrawing;
        private int _buttonClicks;
        private Bitmap _drawing;
        private PointF _end;
        private Figure _f;
        private float _factor = 1.0f;
        private HistoryDrawing _history;
        private bool _isDrawing;
        private PointF _start;
        public Bitmap InitialBmp;

        public EditPicture()
        {
            InitializeComponent();
            _historyIterator = new HistoryIterator(0, 0);
        }

        private void Edit_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = InitialBmp;
            pictureBox1.Top = 5;
            pictureBox1.Left = 5;
            _history = new HistoryDrawing(InitialBmp);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var workform = new WorkForm {SaveBitmap = (Bitmap) pictureBox1.Image, History = _history};
            workform.ShowDialog(this);
            Hide();
        }

        private void EditPicture_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormsHelper.FormCloser(this, ref e);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            _factor = 1.0f + (float) trackBar1.Value/trackBar1.Maximum;
            pictureBox1.Image = SizingImage.GetNewSizedBitmap(_history, _factor, InitialBmp);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _historyIterator.PreviousOrFirst();
            var currentHistoryRecord = _history.GetByIndex(_historyIterator.Current, _factor);

            pictureBox1.Image = currentHistoryRecord;
            _drawing = currentHistoryRecord;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _historyIterator.NextOrLast();
            var currentHistoryRecord = _history.GetByIndex(_historyIterator.Current, _factor);
            pictureBox1.Image = currentHistoryRecord;
            _drawing = currentHistoryRecord;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var dialogRes = MessageBox.Show(Resources.Delete_Message_Warning,
                Resources.Delete_Message_Warning_Title,
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning);

            if (dialogRes != DialogResult.OK) return;


            _history.Clear();
            _historyIterator.Clear();

            var historyLast = _history.GetLastBitmapOrDefalut(_factor);

            pictureBox1.Image = historyLast;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            _f = new DoorFigure();
         //  button7.Enabled = true;
            button6.Enabled = true;
            button2.Enabled = false;
            _isDrawing = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            _f = new RoomFigure();
            //button7.Enabled = false;
            button6.Enabled = true;
            button2.Enabled = true;
            _isDrawing = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            _f = new WindowFigure();
           // button7.Enabled = true;
            button6.Enabled = false;
            button2.Enabled = true;
            _isDrawing = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (_isDrawing)
            {
                _buttonClicks++;
                if (_buttonClicks == 1)
                {
                    trackBar1.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                    button5.Enabled = false;

                    _bmpBeforeDrawing = (Bitmap) pictureBox1.Image;
                    _drawing = (Bitmap) _bmpBeforeDrawing.Clone();

                    _isDrawing = true;

                    _start = pictureBox1.PointToClient(Cursor.Position);
                    _end = new Point(0, 0);
                    Factor.UnCountFactor(ref _start, _factor);

                    Distance.CalculateBonders(ref _start, ref _end, pictureBox1, _history.AllRecords());

                    _stp.DrawPoint(ref _drawing, _start, _factor);

                    pictureBox1.Image = _drawing;
                    _drawing = (Bitmap) _bmpBeforeDrawing.Clone();
                }
                else
                {
                    trackBar1.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = true;
                    button5.Enabled = true;

                    _buttonClicks = 0;

                    _end = pictureBox1.PointToClient(Cursor.Position);
                    Factor.UnCountFactor(ref _end, _factor);

                    _history.RemoveAfterByIndex(_historyIterator.Current);

                    _drawing = (Bitmap) _bmpBeforeDrawing.Clone();

                    Distance.CalculateBonders(ref _start, ref _end, pictureBox1, _history.AllRecords());

                    _f.FirstLocationPoint = _start;
                    _f.SecondLocationPoint = _end;

                    _history.Add((Figure) _f.Clone());
                    _historyIterator.HistoryUpdate(_history.Count(), _history.Count());
                    _f.Draw(ref _drawing, _start, _end, _factor);

                    pictureBox1.Image = _drawing;
                    _drawing = null;
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FormsHelper.GoToBackwardForm(this, Owner);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
