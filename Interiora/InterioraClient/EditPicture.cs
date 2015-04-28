using System;
using System.Drawing;
using System.Windows.Forms;
using FunctionalityLibrary.Drawing;
using FunctionalityLibrary.Drawing.History;

namespace InterioraClient
{


    public partial class EditPicture : Form
    {
        public EditPicture()
        {
            InitializeComponent();
        }

        public Bitmap saveBMP;
        Bitmap bmpBeforeDrawing;
        HistoryDrawing history;
        int historyIterator;
        Point start = new Point();
        Point end = new Point();
        bool isDrawing = false;
        Bitmap drawing;
        Figure f;
        StartPoint stp = new StartPoint();
        int buttonClicks = 0;

        private void Edit_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = saveBMP;
            pictureBox1.Top = 5;
            pictureBox1.Left = 5;
            history = new HistoryDrawing(saveBMP);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var workform = new InterioraClient.WorkForm();
            workform.Show();
            this.Hide();
        }

        private void EditPicture_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormsHelper.FormCloser(this, ref e);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            float dScroll = trackBar1.Value;
            Size newSize = new Size((int)(saveBMP.Width + (saveBMP.Width / 10.0 * dScroll)),
                                    (int)(saveBMP.Height + (saveBMP.Height / 10.0 * dScroll)));
            pictureBox1.Image = new Bitmap(saveBMP, newSize);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (--historyIterator < 0)
                historyIterator = 0;
            var lastHistory = history.GetByIndex(historyIterator);

            pictureBox1.Image = lastHistory.Key;
            drawing = lastHistory.Key;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            historyIterator++;
            if (historyIterator >= history.Count())
                historyIterator = history.Count() - 1;

            var historyLast = history.GetByIndex(historyIterator);
            Bitmap bp = historyLast.Key;
            historyLast.Value.Draw(ref bp, historyLast.Value.FirstLocationPoint, historyLast.Value.SecondLocationPoint);
            pictureBox1.Image = historyLast.Key;

            drawing = historyLast.Key;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var dialogRes = MessageBox.Show("Это удалит все ваши изменения!\nЭто действие необратимо!\nВы Уверены?", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogRes == DialogResult.OK)
            {
                history.Clear();
                historyIterator = history.Count() - 1;
                var historyLast = history.GetLast();

                Bitmap bp = historyLast.Key;
                if (historyLast.Value != null)
                    historyLast.Value.Draw(ref bp, historyLast.Value.FirstLocationPoint, historyLast.Value.SecondLocationPoint);

                pictureBox1.Image = bp;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            f = new DoorFigure();
            button7.Enabled = true;
            button6.Enabled = true;
            button2.Enabled = false;
            isDrawing = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            f = new RoomFigure();
            button7.Enabled = false;
            button6.Enabled = true;
            button2.Enabled = true;
            isDrawing = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            f = new WindowFigure();
            button7.Enabled = true;
            button6.Enabled = false;
            button2.Enabled = true;
            isDrawing = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (isDrawing)
            {
                buttonClicks++;
                if (buttonClicks == 1)
                {
                    bmpBeforeDrawing = (Bitmap)pictureBox1.Image;
                    drawing = (Bitmap)bmpBeforeDrawing.Clone();
                    isDrawing = true;
                    start = pictureBox1.PointToClient(Cursor.Position);
                    FunctionalityLibrary.Calculation.Distance.CalculateBonders(ref start, ref end, pictureBox1, history.AllRecords());
                    stp.DrawPoint(ref drawing, start);
                    pictureBox1.Image = drawing;
                    drawing = (Bitmap)bmpBeforeDrawing.Clone();
                }
                else
                {
                    buttonClicks = 0;

                    end = pictureBox1.PointToClient(Cursor.Position);
                    history.RemoveAfterByIndex(++historyIterator);

                    FunctionalityLibrary.Calculation.Distance.CalculateBonders(ref start, ref end, pictureBox1, history.AllRecords());

                    drawing = (Bitmap)bmpBeforeDrawing.Clone();
                    history.Add(drawing, (Figure)f.Clone());
                    f.FirstLocationPoint = start;
                    f.SecondLocationPoint = end;
                    f.Draw(ref drawing, start, end);

                    pictureBox1.Image = drawing;
                    drawing = (Bitmap)bmpBeforeDrawing.Clone();

                    drawing = null;
                }
            }

        }
    }
}
