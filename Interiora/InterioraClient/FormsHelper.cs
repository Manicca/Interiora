using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using InterioraClient.Properties;

namespace InterioraClient
{
    internal static class FormsHelper
    {
        public static void FormCloser(Form f, ref FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.UserClosing:
                    var dialogRes = MessageBox.Show(Resources.FormsHelper_FormCloser_CloseAppQuestion,
                        Resources.FormsHelper_FormCloser_Warning, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
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

        public static void RemoveNotDigitsFromTb(ref TextBox tbBox)
        {
            var pattern = new Regex(@"[^\d]");
            tbBox.Text = pattern.Replace(tbBox.Text, "");
        }

        public static void FormCloserOnlyWindow(Form f, ref FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.UserClosing:
                    var dialogRes = MessageBox.Show(Resources.FormsHelper_FormCloser_CloseWindowQuestion,
                        Resources.FormsHelper_FormCloser_Warning, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (dialogRes == DialogResult.Cancel)
                        e.Cancel = true; // отмена закрытия формы
                    else
                    {
                        f.Dispose();
                    }
                    break;
                default:
                    f.Close();
                    break;
            }
        }

        public static float GetFactor(ref TrackBar tbBar, float maxZoom)
        {
            var scrolled = tbBar.Value;
            var maxScrolled = tbBar.Maximum;
            return maxZoom * scrolled / maxScrolled;
        }
    }
}