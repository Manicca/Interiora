using System;
using System.Windows.Forms;
using FunctionalityLibrary;

namespace InterioraClient
{
     public partial class DoneForm : Form
     {
          public DoneForm()
          {
               InitializeComponent();
          }

          private void button2_Click(object sender, EventArgs e)
          {
               EMailSender.SendMessage("smtp.mail.ru", "isebd@mail.ru", "qwe123rty456", textBox1.Text, "expirience", "hjhkhjk");
          }

          private void DoneForm_FormClosing(object sender, FormClosingEventArgs e)
          {
               FormsHelper.FormCloser(this, ref e);
          }

          private void DoneForm_FormClosing_1(object sender, FormClosingEventArgs e)
          {
               FormsHelper.FormCloser(this, ref e);
          }
     }
}
