using System.Drawing;
using FunctionalityLibrary.Calculation;
using FunctionalityLibrary.Properties;

namespace FunctionalityLibrary.Drawing
{
    public class WindowFigure : Figure
    {
        public override void Draw(ref Bitmap bmp, PointF start, PointF end, float factor)
        {
            Factor.CountFactor(ref start, factor);
            Factor.CountFactor(ref end, factor);

            Gr = Graphics.FromImage(bmp);
            var redPen = new Pen(Color.Red, 1*factor);
            Gr.DrawLine(redPen, start, end);
            var startD = start;
            var endD = end;

            var dy = ((startD.Y - endD.Y)/Settings.Default.sizeReductionOfLine);
            var dx = ((startD.X - endD.X)/Settings.Default.sizeReductionOfLine);
            startD = endD;
            startD.Y += dx;
            startD.X -= dy;

            var bluePen = new Pen(Color.Blue, 1*factor);
            Gr.DrawLine(bluePen, startD, endD); //отрисовка на конце перпендикулярчика

            endD = end;
            startD = start;
            endD = startD;


            endD.Y += dx;
            endD.X -= dy;

            Gr.DrawLine(bluePen, startD, endD); //отрисовка на начале перпендикулярчика

            Gr.Dispose();
        }
    }
}