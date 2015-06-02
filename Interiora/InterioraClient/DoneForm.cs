using System;
using System.Windows.Forms;
using FunctionalityLibrary;
using FunctionalityLibrary.Drawing.History;
using System.Collections.Generic;
using System.Drawing;
using FunctionalityLibrary.Calculation;
using FunctionalityLibrary.Drawing.OfficeEquipment;
using FunctionalityLibrary.Modes;
using Models;
using InterioraClient.Properties;
using FunctionalityLibrary.Drawing.Figures;

namespace InterioraClient
{
    public partial class DoneForm : Form
    {
        public DoneForm()
        {
            InitializeComponent();
        }
        public CreateBlank crbl = new FunctionalityLibrary.CreateBlank();
        public CreateReports crrep = new FunctionalityLibrary.CreateReports();
        public InfoCustoms info = new FunctionalityLibrary.InfoCustoms();
        private HistoryIterator _historyIterator = new HistoryIterator(0, 0);
        private FormsHelper.ButtonClicker _buttonClicker = new FormsHelper.ButtonClicker();
        private readonly StartPointFigure _stp = new StartPointFigure();
       // public HistoryDrawing History;
        public Bitmap InitialBmp;
        private WorkMode _mode = new WorkMode(EnumOfModes.Manual);
        public HistoryDrawing History { get; set; }
        private Bitmap _saveBmp;
        private float _factor = 1.0f;
        
       
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

        public void SetInfo(InfoCustoms inf)
        {
            info = inf;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            EMailSender.SendMessage("smtp.mail.ru", "isebd@mail.ru", "qwe123rty456", textBox1.Text, "expirience", "hjhkhjk",
                new List<string> { "Document2.pdf" });
        }

        private void DoneForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormsHelper.FormCloser(this, ref e);
        }

        private void DoneForm_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            FormsHelper.FormCloser(this, ref e);
        }

        private void button4_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.ToolTipTitle = " Открыть отчеты и бланки";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EMailSender.SendMessage("smtp.mail.ru", "isebd@mail.ru", "qwe123rty456", textBox1.Text, "expirience", "hjhkhjk",
                new List<string> { "blank.odt" });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormsHelper.GoToBackwardForm(this, Owner);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var aboutcustoms = new AboutCustoms();
            aboutcustoms.History = History;
            aboutcustoms.ShowDialog(this);
            crrep.blankPDF(info,aboutcustoms.History);
            crbl.blank(info, aboutcustoms.History);

        }

        private void DoneForm_Load(object sender, EventArgs e)
        {
            var historyLast = History.GetLastBitmapOrDefalutOfficeFigures(_factor);

            pictureBox1.Image = historyLast;
        }
    }
}
