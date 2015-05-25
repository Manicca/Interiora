using System;
using System.Collections.Generic;
using System.Drawing;
using FunctionalityLibrary.Drawing.OfficeEquipment;
using FunctionalityLibrary.Properties;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunctionalityLibrary.Drawing.History;

namespace FunctionalityLibrary.Calculation
{
    public static class CoordinateCorrector
    {
        /// <summary>
        /// Корректировка координат. В програме нельзя ставить окна под углом.
        /// </summary>
        /// <param name="start">Стартовая точка рисования</param>
        /// <param name="end">Точка для корректировки</param>
        public static void CorrectAngle(PointF start, ref PointF end)
        {
            var p1 = new PointF(end.X, start.Y);
            var p2 = new PointF(start.X, end.Y);
            var dp1 = Distance.GetDistanceFromPoints(p1, end);
            var dp2 = Distance.GetDistanceFromPoints(p2, end);
            if (dp1 < dp2)
                end = p1;
            else
                end = p2;
        }


        public static bool CorrectTableCoordinate(ref OfficeFigure tfo, Bitmap bp, float factor, HistoryDrawing history)
        {
            var indent = Settings.Default.indentFromWall * factor;
            if (tfo.FirstLocationPoint.X < indent)
                tfo.FirstLocationPoint.X = indent;

            if (tfo.FirstLocationPoint.Y < indent)
                tfo.FirstLocationPoint.Y = indent;


            if (tfo.SizeH + tfo.FirstLocationPoint.Y > bp.Height - indent)
            {
                tfo.FirstLocationPoint.Y = bp.Height - indent - tfo.SizeH;
            }
            if (tfo.SizeW + tfo.FirstLocationPoint.X > bp.Width - indent)
            {
                tfo.FirstLocationPoint.X = bp.Width - indent - tfo.SizeW;
            }

            var of = history.AllOfficeFiguresRecords().Where(e => !(e is TwistedPair));

            foreach (var t in of)
            {
                if (t.IsCrosses(tfo.FirstLocationPoint, tfo.SizeW, tfo.SizeH))
                    return false;
            }

            return true;

        }
    }
}
