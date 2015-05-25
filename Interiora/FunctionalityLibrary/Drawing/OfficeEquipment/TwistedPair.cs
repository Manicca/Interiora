using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace FunctionalityLibrary.Drawing.OfficeEquipment
{
    public class TwistedPair : OfficeFigure
    {
        public TwistedPair() { }
        new private float SizeH;
        new private float SizeW;
        public TwistedPair(WebEquipment we)
        {
            Equipment = we;
        }

        public WebEquipment Equipment { get; set; }
        public List<PointF> Points { get; set; }

        public override void Draw(ref Bitmap bmp, PointF start, float factor)
        {

            var pen = new Pen(Color.Red, 1 * factor);
            if(Points != null && Points.Count > 0)
            {
                Gr = Graphics.FromImage(bmp);
                var past = FirstLocationPoint;
                foreach(var point in Points)
                {
                    Gr.DrawLine(pen, past, point);
                    past = point;
                }
            }
        }

        public override string ToString()
        {
            return "Витая пара";
        }

        public override string GetToolTipInfo()
        {
            return "Размеры: " + Equipment.Atributes;
        }

        public override bool IsCrosses(PointF start, float sizeW, float sizeH)
        {
            throw new NotImplementedException();
        }


    }
}