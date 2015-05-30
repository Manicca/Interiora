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
    public partial class AboutCustoms : Form
    {
        public AboutCustoms()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InfoCustoms info = new InfoCustoms();
            CreateReports CrRep = new CreateReports();
          var form=  Owner as DoneForm;
          if (form != null)
          {
             
              info.inn = textBox1.Text;
              info.adress = textBox2.Text;
              info.bankinfo = textBox3.Text;
              info.direct = textBox4.Text;
              info.buch = textBox5.Text;
              info.number = textBox6.Text;
              info.mail = textBox7.Text;

              

              form.SetInfo(info);
          }
          CrRep.blankPDF(info);
            this.Close();
        }

        
    }
}
