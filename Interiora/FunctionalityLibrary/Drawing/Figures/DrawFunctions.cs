using System.Drawing;
using System.Windows.Forms;

namespace FunctionalityLibrary.Drawing.Figures
{
    public class DrawFunctions
    {
        public int h;
        public int w;
        public int x;
        public int y;

        public void Table(ref PictureBox targetPictureBox)
        {
            Bitmap bmp;
            if (targetPictureBox.Image == null)
                bmp = new Bitmap(targetPictureBox.Width, targetPictureBox.Height);
            else
                bmp = (Bitmap) targetPictureBox.Image;
            var gr = Graphics.FromImage(bmp);

            var pn = new Pen(Color.Black, 1);
            gr.DrawRectangle(pn, 10, 15, 10, 10);

            targetPictureBox.Image = (Bitmap) bmp.Clone();
        }

        public void Chair(ref PictureBox targetPictureBox)
        {
            Bitmap bmp;
            if (targetPictureBox.Image == null)
                bmp = new Bitmap(targetPictureBox.Width, targetPictureBox.Height);
            else
                bmp = (Bitmap) targetPictureBox.Image;
            var gr = Graphics.FromImage(bmp);

            var pn = new Pen(Color.Black, 1);
            var gra = Graphics.FromImage(bmp);
            gra.DrawEllipse(pn, 10, 0, 10, 10);

            targetPictureBox.Image = (Bitmap) bmp.Clone();
        }

        public void Cupboard(ref PictureBox targetPictureBox)
        {
            Bitmap bmp;
            if (targetPictureBox.Image == null)
                bmp = new Bitmap(targetPictureBox.Width, targetPictureBox.Height);
            else
                bmp = (Bitmap) targetPictureBox.Image;
            var gr = Graphics.FromImage(bmp);


            var pn = new Pen(Color.Black, 1);
            gr.DrawRectangle(pn, 40, 0, 10, 20);

            targetPictureBox.Image = (Bitmap) bmp.Clone();
        }

        public void ForClothes(ref PictureBox targetPictureBox)
        {
            Bitmap bmp;
            if (targetPictureBox.Image == null)
                bmp = new Bitmap(targetPictureBox.Width, targetPictureBox.Height);
            else
                bmp = (Bitmap) targetPictureBox.Image;
            var gr = Graphics.FromImage(bmp);


            var pn = new Pen(Color.Black, 1);
            gr.DrawLine(pn, new Point(0, 0), new Point(5, 8));
            gr.DrawLine(pn, new Point(0, 8), new Point(5, 0));


            targetPictureBox.Image = (Bitmap) bmp.Clone();
        }

        public void ARM()
        {
        }
    }
}