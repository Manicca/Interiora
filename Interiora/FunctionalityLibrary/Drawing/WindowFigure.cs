using System.Drawing;

namespace FunctionalityLibrary.Drawing
{
    public class WindowFigure : Figure
    {
        public override void Draw(ref Bitmap bmp, Point start, Point end)
        {

            gr = Graphics.FromImage(bmp);
            gr.DrawLine(Pens.Red, start, end);
            var startD = start;
            var endD = end;

            int dy = (startD.Y - endD.Y) / 6;
            int dx = (startD.X - endD.X) / 6;
            startD = endD;
            startD.Y += dx;
            startD.X -= dy;


            gr.DrawLine(Pens.Blue, startD, endD);//отрисовка на конце перпендикулярчика

            endD = end;
            startD = start;
            endD = startD;


            endD.Y += dx;
            endD.X -= dy;

            gr.DrawLine(Pens.Blue, startD, endD);//отрисовка на начале перпендикулярчика

            gr.Dispose();
        }
    }
}
