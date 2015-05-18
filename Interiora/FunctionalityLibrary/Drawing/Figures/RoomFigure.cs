using System.Drawing;
using FunctionalityLibrary.Calculation;

namespace FunctionalityLibrary.Drawing.Figures
{
    public class RoomFigure : Figure
    {
        public override void Draw(ref Bitmap bmp, PointF start, PointF end, float factor)
        {
            Factor.CountFactor(ref start, factor);
            Factor.CountFactor(ref end, factor);
            if (start.X > end.X)
            {
                var x = start.X;
                start.X = end.X;
                end.X = x;
            }
            if (start.Y > end.Y)
            {
                var y = start.Y;
                start.Y = end.Y;
                end.Y = y;
            }
            Gr = Graphics.FromImage(bmp);
            var blackPen = new Pen(Color.Black, 1*factor);
            Gr.DrawRectangle(blackPen, start.X, start.Y, end.X - start.X, end.Y - start.Y);
            Gr.Dispose();
        }
    }
}