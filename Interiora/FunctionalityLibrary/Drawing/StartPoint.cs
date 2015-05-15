using System.Drawing;
using FunctionalityLibrary.Calculation;
using FunctionalityLibrary.Properties;

namespace FunctionalityLibrary.Drawing
{
    public class StartPoint : Figure
    {
        public void DrawPoint(ref Bitmap bmp, PointF p, float factor)
        {
            Factor.CountFactor(ref p, factor);

            Gr = Graphics.FromImage(bmp);
            Gr.DrawLine(Pens.Red,
                p.X + Settings.Default.sizeOfCross,
                p.Y + Settings.Default.sizeOfCross,
                p.X - Settings.Default.sizeOfCross,
                p.Y - Settings.Default.sizeOfCross);
            Gr.DrawLine(Pens.Red,
                p.X - Settings.Default.sizeOfCross,
                p.Y + Settings.Default.sizeOfCross,
                p.X + Settings.Default.sizeOfCross,
                p.Y - Settings.Default.sizeOfCross);
        }
    }
}