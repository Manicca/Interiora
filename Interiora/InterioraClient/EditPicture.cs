using System;
using System.Drawing;
using System.Windows.Forms;
using FunctionalityLibrary.Calculation;
using FunctionalityLibrary.Drawing;
using FunctionalityLibrary.Drawing.History;
using InterioraClient.Properties;

namespace InterioraClient
{


    public partial class EditPicture : Form
    {
        public EditPicture()
        {
            InitializeComponent();
        }

        public Bitmap SaveBmp;
        Bitmap _bmpBeforeDrawing;
        HistoryDrawing _history;
        int _historyIterator;
        Point _start;
        Point _end;
        bool _isDrawing;
        Bitmap _drawing;
        Figure _f;
        readonly StartPoint _stp = new StartPoint();
        int _buttonClicks;

        private void Edit_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = SaveBmp;
            pictureBox1.Top = 5;
            pictureBox1.Left = 5;
            _history = new HistoryDrawing(SaveBmp);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var workform = new WorkForm { SaveBitmap = (Bitmap)pictureBox1.Image, History = this._history};
            workform.Show();
            Hide();
        }

        private void EditPicture_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormsHelper.FormCloser(this, ref e);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            float dScroll = trackBar1.Value;
            Size newSize = new Size((int)(SaveBmp.Width + (SaveBmp.Width / 10.0 * dScroll)),
                                    (int)(SaveBmp.Height + (SaveBmp.Height / 10.0 * dScroll)));
            pictureBox1.Image = new Bitmap(SaveBmp, newSize);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (--_historyIterator < 0)
                _historyIterator = 0;
            var lastHistory = _history.GetByIndex(_historyIterator);

            pictureBox1.Image = lastHistory.Key;
            _drawing = lastHistory.Key;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _historyIterator++;
            if (_historyIterator >= _history.Count())
                _historyIterator = _history.Count() - 1;

            var historyLast = _history.GetByIndex(_historyIterator);
            var bp = historyLast.Key;
            historyLast.Value.Draw(ref bp, historyLast.Value.FirstLocationPoint, historyLast.Value.SecondLocationPoint);
            pictureBox1.Image = historyLast.Key;

            _drawing = historyLast.Key;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var dialogRes = MessageBox.Show(Resources.Delete_Message_Warning, Resources.Delete_Message_Warning_Title, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogRes == DialogResult.OK)
            {
                _history.Clear();
                _historyIterator = _history.Count() - 1;
                var historyLast = _history.GetLast();

                var bp = historyLast.Key;
                historyLast.Value.Draw(ref bp, historyLast.Value.FirstLocationPoint, historyLast.Value.SecondLocationPoint);

                pictureBox1.Image = bp;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            _f = new DoorFigure();
            button7.Enabled = true;
            button6.Enabled = true;
            button2.Enabled = false;
            _isDrawing = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            _f = new RoomFigure();
            button7.Enabled = false;
            button6.Enabled = true;
            button2.Enabled = true;
            _isDrawing = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            _f = new WindowFigure();
            button7.Enabled = true;
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
                    _bmpBeforeDrawing = (Bitmap)pictureBox1.Image;
                    _drawing = (Bitmap)_bmpBeforeDrawing.Clone();
                    _isDrawing = true;
                    _start = pictureBox1.PointToClient(Cursor.Position);
                    _end = new Point(0, 0);
                    Distance.CalculateBonders(ref _start, ref _end, pictureBox1, _history.AllRecords());
                    _stp.DrawPoint(ref _drawing, _start);
                    pictureBox1.Image = _drawing;
                    _drawing = (Bitmap)_bmpBeforeDrawing.Clone();
                }
                else
                {
                    _buttonClicks = 0;

                    _end = pictureBox1.PointToClient(Cursor.Position);
                    _history.RemoveAfterByIndex(++_historyIterator);


                    _drawing = (Bitmap)_bmpBeforeDrawing.Clone();
                    
                    Distance.CalculateBonders(ref _start, ref _end, pictureBox1, _history.AllRecords());

                    _f.FirstLocationPoint = _start;
                    _f.SecondLocationPoint = _end;

                    _history.Add(_drawing, (Figure)_f.Clone());
                    _f.Draw(ref _drawing, _start, _end);

                    pictureBox1.Image = _drawing;
                    _drawing = (Bitmap)_bmpBeforeDrawing.Clone();

                    _drawing = null;
                }
            }

        }
    }
}
