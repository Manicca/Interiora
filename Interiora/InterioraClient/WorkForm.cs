using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterioraClient
{
    public partial class WorkForm : Form
    {
        public WorkForm()
        {
            InitializeComponent();
        }

<<<<<<< HEAD
        private void button3_Click(object sender, EventArgs e)
        {
            var doneform = new InterioraClient.DoneForm();
            doneform.Show();
            this.Hide();
        }
    }
=======
          private void WorkForm_FormClosing(object sender, FormClosingEventArgs e)
          {
               FormsHelper.FormCloser(this, ref e);
          }
     }
>>>>>>> f7491d3bc4e6ae31f1a083ba1a920ad681d028fe
}
