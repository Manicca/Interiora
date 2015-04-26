using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        MailSend sendmail = new MailSend();

        private void button2_Click(object sender, EventArgs e)
        {
            sendmail.SendMail("smtp.mail.ru","isebd@mail.ru","qwe123rty456",textBox1.Text,"expirience","hjhkhjk","filele.txt");
            MessageBox.Show("Ваше сообщение отправлено!");    
        }
        
        
    }
}
