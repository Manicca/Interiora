﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                              Environment.Exit(0);
                         break;
                    default:
                         f.Close();
                         break;
               }
          }
     }
}
