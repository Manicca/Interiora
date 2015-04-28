using System.Drawing;

namespace FunctionalityLibrary.Drawing
{
    public class RoomFigure : Figure
    {
        public override void Draw(ref Bitmap bmp, Point start, Point end)
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
}
