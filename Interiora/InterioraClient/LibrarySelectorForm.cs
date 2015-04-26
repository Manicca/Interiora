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
    public partial class LibrarySelectorForm : Form
    {
        public LibrarySelectorForm()
        {
            InitializeComponent();
        }

          private void LibrarySelectorForm_FormClosing(object sender, FormClosingEventArgs e)
          {
               FormsHelper.FormCloser(this, ref e);
          }
     }
}
