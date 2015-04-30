using System;
using System.Windows.Forms;

namespace InterioraClient
{
     public class FormsHelper
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
     }
}
