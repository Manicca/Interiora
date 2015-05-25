using FunctionalityLibrary.Calculation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalityLibrary.Drawing.DrawingHelpers
{
    class RectangleHelper
    {

        public static void DrawRectangle(PointF start, PointF end, ref Bitmap bp, float factor)
        {
            Graphics Gr = Graphics.FromImage(bp);
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
            var blackPen = new Pen(Color.Black, 1 * factor);
            Gr.DrawRectangle(blackPen, start.X, start.Y, end.X - start.X, end.Y - start.Y);
            Gr.Dispose();
        }

        public static void DrawRectangle(PointF start, float sizeW, float sizeH, ref Bitmap bp, float factor)
        {
            var end = Calculation.Distance.GetPointFromSize(start, sizeW, sizeW);
            DrawRectangle(start, end, ref bp, factor);
        }
    }
}
