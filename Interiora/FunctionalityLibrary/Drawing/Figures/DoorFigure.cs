using System.Drawing;
using FunctionalityLibrary.Calculation;

namespace FunctionalityLibrary.Drawing.Figures
{
    public class DoorFigure : Figure
    {
        public override void Draw(ref Bitmap bmp, PointF start, PointF end, float factor)
        {
            Gr = Graphics.FromImage(bmp);
            //Учитываем масштаб
            Factor.CountFactor(ref start, factor);
            Factor.CountFactor(ref end, factor);

            var redPen = new Pen(Color.Red, 1*factor);
            Gr.DrawLine(redPen, start, end);
            var startD = start;
            var endD = end;

            var dy = (startD.Y - endD.Y)/6;
            var dx = (startD.X - endD.X)/6;
            startD = endD;
            startD.Y += dx;
            startD.X -= dy;
            endD.Y -= dx;
            endD.X += dy;

            var bluePen = new Pen(Color.Blue, 1*factor);
            Gr.DrawLine(bluePen, startD, endD); //отрисовка на конце перпендикулярчика

            endD = end;
            startD = start;
            endD = startD;

            startD.Y -= dx;
            startD.X += dy;
            endD.Y += dx;
            endD.X -= dy;

            Gr.DrawLine(bluePen, startD, endD); //отрисовка на начале перпендикулярчика

            Gr.Dispose();
        }
    }
}