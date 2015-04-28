using System.Drawing;

namespace FunctionalityLibrary.Drawing
{
    public class StartPoint : Figure
    {
        public void DrawPoint(ref Bitmap bmp, Point p)
        {
            int distance = 5;
            gr = Graphics.FromImage(bmp);
            gr.DrawLine(Pens.Red, p.X + distance, p.Y + distance, p.X - distance, p.Y - distance);
            gr.DrawLine(Pens.Red, p.X - distance, p.Y + distance, p.X + distance, p.Y - distance);
        }
    }

}
