using Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalityLibrary.Drawing.OfficeEquipment
{
    class Switchboard : OfficeFigure
    {
        public WebEquipment Equipment { get; set; }


        public Switchboard(WebEquipment equipment)
        {
            Equipment = equipment;
        }

        public override void Draw(ref Bitmap bmp, PointF start, float factor)
        {
            DrawingHelpers.RectangleHelper.DrawRectangle(start, 5, 10, ref bmp, factor);
        }

        public override bool IsCrosses(PointF start, float sizeW, float sizeH)
        {
            return false;
        }
    }
}
