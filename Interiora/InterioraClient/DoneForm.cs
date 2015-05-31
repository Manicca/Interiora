using System;
using System.Windows.Forms;
using FunctionalityLibrary;
using System.Collections.Generic;
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
                new List<string> { "Blank.odt" });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormsHelper.GoToBackwardForm(this, Owner);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var aboutcustoms = new AboutCustoms();
            aboutcustoms.ShowDialog(this);

        }
    }
}
