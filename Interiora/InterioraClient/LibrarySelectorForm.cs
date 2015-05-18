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

          private void button2_Click(object sender, System.EventArgs e)
          {
              FormsHelper.GoToBackwardForm(this, Owner);
          }
     }
}
