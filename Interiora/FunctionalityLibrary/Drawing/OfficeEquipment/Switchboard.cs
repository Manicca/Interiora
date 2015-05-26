using Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalityLibrary.Drawing.OfficeEquipment
{
    public class Switchboard : OfficeFigure
    {
        public WebEquipment Equipment { get; set; }


        public Switchboard(WebEquipment equipment)
        {
            Equipment = equipment;
            SizeW = 10;
            SizeH = 5;
        }

        public override void Draw(ref Bitmap bmp, PointF start, float factor)
        {
            Gr = Graphics.FromImage(bmp);
            DrawingHelpers.RectangleHelper.DrawRectangle(start, SizeW, SizeH, ref bmp, factor);
        }

        public override bool IsCrossesFigure(PointF start, float sizeW, float sizeH)
        {
            return false;
        }

        public override string ToString()
        {
            return "Коммутатор";
        }
    }
}
