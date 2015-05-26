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

namespace InterioraClient
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() != "Пользователь")
            {
                for (int i = 162; i < 189; i++)
                {
                    Thread.Sleep(10);
                    button1.Top = i;
                }
                textBox1.Show();
            }
            else
            {
                textBox1.Hide();
                for (int i = 188; i >= 162; i--)
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
              
            }
            else
            {
                MainFormWork f = new MainFormWork();
                f.Show();
                Hide();
            }
        }
    }
}
