using System;
using System.Windows.Forms;

namespace InterioraClient
{
    internal static class FormsHelper
     {
          public static void FormCloser(Form f, ref FormClosingEventArgs e)
          {
               switch (e.CloseReason)
               {
                    case CloseReason.UserClosing:
                         var dialogRes = MessageBox.Show("Закрыть приложение?", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                         if (dialogRes == DialogResult.Cancel)
                              e.Cancel = true; // отмена закрытия формы
                         else
                         {
                              f.Dispose();
                              Environment.Exit(0);
                         }
                         break;
                    default:
                         f.Close();
                         break;
               }
          }

        public static void GoToBackwardForm(Form f, Form ownerForm)
        {
           f.Dispose();
           ownerForm.Show();
        }

    }
}
