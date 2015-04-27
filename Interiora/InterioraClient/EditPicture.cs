using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FunctionalityLibrary;

namespace InterioraClient
{


     public partial class EditPicture : Form
     {
          public EditPicture()
          {
               InitializeComponent();
          }
          public Bitmap saveBMP;
          Bitmap bmpBeforeDrawing;
          HistoryDrawing history;
          int historyIterator;
          Point start = new Point();
          Point end = new Point();
          bool isDrawing = false;
          Bitmap drawing;




          private void Edit_Load(object sender, EventArgs e)
          {
               pictureBox1.Image = saveBMP;
               pictureBox1.Top = 0;
               pictureBox1.Left = 0;
               history = new HistoryDrawing(saveBMP);

          }

 

          private void button1_Click(object sender, EventArgs e)
          {
               var workform = new InterioraClient.WorkForm();
               workform.Show();
               this.Hide();
          }


          private void EditPicture_FormClosing(object sender, FormClosingEventArgs e)
          {
               FormsHelper.FormCloser(this, ref e);
          }

          private void trackBar1_Scroll(object sender, EventArgs e)
          {
               float dScroll = trackBar1.Value;
               Size newSize = new Size((int)(saveBMP.Width + (saveBMP.Width / 10.0 * dScroll)), (int)(saveBMP.Height + (saveBMP.Height / 10.0 * dScroll)));
               pictureBox1.Image = new Bitmap(saveBMP, newSize);

               if (panel1.HorizontalScroll.Enabled)
                    panel1.HorizontalScroll.Value = panel1.HorizontalScroll.Maximum / 2;
               if (panel1.VerticalScroll.Enabled)
                    panel1.VerticalScroll.Value = panel1.VerticalScroll.Maximum / 2;
          }

          private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
          {
               end = e.Location;
               if (isDrawing)
               {
                    RectangleD.Draw(ref drawing, start, end);
                    pictureBox1.Image = drawing;
                    drawing = (Bitmap)bmpBeforeDrawing.Clone();
               }
          }
          
         
          private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
          {
               bmpBeforeDrawing = (Bitmap)pictureBox1.Image;
               drawing = bmpBeforeDrawing;
               isDrawing=true;
               start = e.Location;
               
          }

          private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
          {
               history.RemoveAfterByIndex(++historyIterator);
               isDrawing = false;
               history.Add((Bitmap)pictureBox1.Image);
               drawing = null;
          }

          private void button3_Click(object sender, EventArgs e)
          {
               if (--historyIterator < 0)
                    historyIterator = 0;
               var lastHistory = history.GetByIndex(historyIterator);
               pictureBox1.Image = lastHistory;
               drawing = lastHistory;
          }

          private void button4_Click(object sender, EventArgs e)
          {
               historyIterator++;
               if (historyIterator >= history.Count())
                    historyIterator = history.Count() - 1;
               var lastHistory = history.GetByIndex(historyIterator);
               pictureBox1.Image = lastHistory;
               drawing = lastHistory;
          }

          private void button5_Click(object sender, EventArgs e)
          {
               var dialogRes = MessageBox.Show("Это удалит все ваши изменения!\nЭто действие необратимо!\nВы Уверены?", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
               if(dialogRes == DialogResult.OK)
               {
                    history.Clear();
                    historyIterator = history.Count()-1;
                    pictureBox1.Image = history.GetLast();
               }
          }
     }
}
