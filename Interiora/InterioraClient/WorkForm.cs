﻿using System;
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

          private void WorkForm_FormClosing(object sender, FormClosingEventArgs e)
          {
               FormsHelper.FormCloser(this, ref e);
          }
     }
}
