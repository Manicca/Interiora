using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using FunctionalityLibrary.Calculation;

namespace FunctionalityLibrary.Drawing.OfficeEquipment
{
    public class TwistedPair : OfficeFigure
    {
        public TwistedPair()
        {
            Points = new List<PointF>();
        }
        new private float SizeH = 0;
        new private float SizeW = 0;
        public TwistedPair(WebEquipment we)
        {
            Equipment = we;
            Points = new List<PointF>();
        }

        public WebEquipment Equipment { get; set; }
        public List<PointF> Points { get; set; }

        public override void Draw(ref Bitmap bmp, PointF start, float factor)
        {
            var pen = new Pen(Color.Red, 1 * factor);

            if (Points != null && Points.Count > 0)
            {
                Gr = Graphics.FromImage(bmp);
                var past = FirstLocationPoint;
                foreach (var point in Points)
                {
                    Factor.CountFactor(ref past, factor);
                    var tmp = point;
                    Factor.CountFactor(ref tmp, factor);
                    Gr.DrawLine(pen, past, tmp);
                    past = point;
                }
            }
        }

        public void DrawLine(ref Bitmap bmp, PointF start, PointF end, float factor, History.HistoryDrawing history)
        {
            var pen = new Pen(Color.Red, 1 * factor);
            var switches = history.AllOfficeFiguresRecords().Where(e => e is Switchboard).Select(e => e as Switchboard);
            foreach (var _switch in switches)
            {
                if (_switch.IsCrossesPoint(start, 5))
                {
                    start.X = _switch.FirstLocationPoint.X + _switch.SizeW / 2;
                    start.Y = _switch.FirstLocationPoint.Y + _switch.SizeH / 2;
                    break;
                }
            }
            foreach (var _switch in switches)
            {
                if (_switch.IsCrossesPoint(end, 5))
                {
                    end.X = _switch.FirstLocationPoint.X + _switch.SizeW / 2;
                    end.Y = _switch.FirstLocationPoint.Y + _switch.SizeH / 2;
                    break;
                }
            }

            FirstLocationPoint = start;
            Points.Clear();
            Points.Add(end);

            Draw(ref bmp, start, factor);

        }

        public override string ToString()
        {
            return "Витая пара";
        }

        public override string GetToolTipInfo()
        {
            return "Размеры: " + Equipment.Atributes;
        }

        public override bool IsCrossesFigure(PointF start, float sizeW, float sizeH)
        {
            return false;
        }

        public override object Clone()
        {
            var res = (TwistedPair)MemberwiseClone();
            res.Points = Points.Select(e => new PointF(e.X, e.Y)).ToList();
            return res;
        }

        public override void Rotate()
        {
            return;
        }

        public override Furniture getFurniture() { return null; }

        public override WebEquipment getWeb() { return Equipment; }

    }
}