using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FunctionalityLibrary;
using Models;

namespace InterioraClient
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            log.NewEventHandler(SetTextSafe);
            log.AppendString("Components initialized...");
            backgroundWorker1.RunWorkerAsync();
            button1.Enabled = false;
        }
        int start = 233;
        int end = 259;
        
        public void AppentToLoggerTb(string s)
        {
                
        }

        private void SetTextSafe(string text)
        {
            if (InvokeRequired)
                this.BeginInvoke(new Action<string>((s) => {
                    SetText(s);
                }), text);
            else SetText(text);
        }

        private void SetText(string text)
        {
            textBox2.AppendText(text);
        }

        private Logger log = new Logger();
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() != "Пользователь")
            {
                if (button1.Top != end)
                    for (int i = start; i < end+1; i++)
                    {
                        Thread.Sleep(10);
                        button1.Top = i;
                    }
            }
            else
            {
                if (button1.Top != start)
                    for (int i = end; i >= start; i--)
                    {
                        Thread.Sleep(10);
                        button1.Top = i;
                    }

            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = new List<string>
            {
                "Администратор",
                "Пользователь"
            };
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() != "Пользователь")
            {
                if (textBox1.Text != "123")
                {
                    var savedColor = textBox1.BackColor;
                    textBox1.BackColor = Color.Red;
                    textBox1.Refresh();
                    Thread.Sleep(50);
                    textBox1.BackColor = savedColor;
                }
                else
                {
                    AdminForms.MainAdminForm f = new AdminForms.MainAdminForm();
                    f.Show(this);
                    Hide();
                }
            }
            else
            {
                MainFormWork f = new MainFormWork();
                f.Show();
                Hide();
            }
        }

     

        private void label1_Click(object sender, EventArgs e)
        {

        }

       

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            log.AppendString("Test connection to database...");
            DbWorker db = new DbWorker();
            log.AppendString("DbWorker created...");
            log.AppendString("Connection established...");
            log.AppendString("DbWorker trying to select all furnitures...");
            db.SelectFromBd<Furniture>(f => true);
            log.AppendString("Selection successfull...");
            log.AppendString("Trying dispose DbWorker...");
            db.Dispose();
            log.AppendString("Disposed...");
            log.AppendString("All right...");
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button1.Enabled = true;
        }
    }
}
