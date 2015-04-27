using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Design;


namespace FunctionalityLibrary
{
     public class DrawFunctions
     {
          public int x;
          public int y;
          public int w;
          public int h;
          public void Table(ref PictureBox targetPictureBox)
          {
               Bitmap bmp;
               if (targetPictureBox.Image == null)
                    bmp = new Bitmap(targetPictureBox.Width, targetPictureBox.Height);
               else
                    bmp = (Bitmap)targetPictureBox.Image;
               Graphics gr = Graphics.FromImage(bmp);

               //gr.Clear(Color.Red);
               Pen pn = new Pen(Color.Black, 3);
               gr.DrawRectangle(pn, 10, 15, 10, 10);

               targetPictureBox.Image = (Bitmap)bmp.Clone();
          }


          public void Chair(ref PictureBox targetPictureBox)
          {
               Bitmap bmp;
               if (targetPictureBox.Image == null)
                    bmp = new Bitmap(targetPictureBox.Width, targetPictureBox.Height);
               else
                    bmp = (Bitmap)targetPictureBox.Image;
               Graphics gr = Graphics.FromImage(bmp);

               Pen pn = new Pen(Color.Black, 3);
               Graphics gra = Graphics.FromImage(bmp);
               gra.DrawEllipse(pn, 10, 0, 10, 10);

               targetPictureBox.Image = (Bitmap)bmp.Clone();

          }
          public void Cupboard(ref PictureBox targetPictureBox)
          {
               Bitmap bmp;
               if (targetPictureBox.Image == null)
                    bmp = new Bitmap(targetPictureBox.Width, targetPictureBox.Height);
               else
                    bmp = (Bitmap)targetPictureBox.Image;
               Graphics gr = Graphics.FromImage(bmp);


               Pen pn = new Pen(Color.Black, 6);
               gr.DrawRectangle(pn, 40, 0, 10, 20);

               targetPictureBox.Image = (Bitmap)bmp.Clone();
          }
          public void ForClothes()
          {

          }
          public void ARM()
          { }

     }

     public class RectangleD
     {
          static Graphics gr;

          public static void Draw(ref Bitmap bmp, Point start, Point end)
          {
               if (start.X > end.X)
               {
                    int x = start.X;
                    start.X = end.X;
                    end.X = x;
               }
               if (start.Y > end.Y)
               {
                    int y = start.Y;
                    start.Y = end.Y;
                    end.Y = y;
               }
               gr = Graphics.FromImage(bmp);
               gr.DrawRectangle(Pens.Black, new Rectangle(start.X, start.Y, end.X - start.X, end.Y - start.Y));
               gr.Dispose();
          }
     }

     public class HistoryDrawing
     {
          List<Bitmap> history;
          public HistoryDrawing(Bitmap startItem)
          {
               history = new List<Bitmap>();
               history.Add(startItem);
          }

          public void Add(Bitmap bp)
          {
               history.Add(bp);
          }

          public void RemoveLast()
          {
               history.Remove(history.Last());
          }

          public Bitmap GetLast()
          {
               return history.Last();
          }

          public void RemoveAfterByIndex(int index)
          {
               if (history.Count - index != 0)
                    history.RemoveRange(index , history.Count - index);
          }

          public Bitmap GetByIndex(int i)
          {
               return history[i];
          }

          public int Count()
          {
               return history.Count;
          }
          public void Clear()
          {
               this.RemoveAfterByIndex(1);
          }
     }
}
