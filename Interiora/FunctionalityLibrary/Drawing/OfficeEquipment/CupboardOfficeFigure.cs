﻿using System.Drawing;
using FunctionalityLibrary.Calculation;
using Models;

namespace FunctionalityLibrary.Drawing.OfficeEquipment
{
    public class CupboardOfficeFigure : OfficeFigure
    {
        private Furniture _f;

        public CupboardOfficeFigure(Furniture f)
        {
            _f = f;

            var splited = f.Params.Split('*');
            SizeW = float.Parse(splited[0]);
            SizeH = float.Parse(splited[1]);
        }

        public override void Draw(ref Bitmap bmp, PointF start, float factor)
        {
            Gr = Graphics.FromImage(bmp);
            var pn = new Pen(Color.Black, 1 * factor);

            var sizeW = SizeW;
            var sizeH = SizeH;

            Factor.CountFactor(ref start, factor);
            Factor.CountFactor(ref sizeW, factor);
            Factor.CountFactor(ref sizeH, factor);

            Gr.DrawRectangle(pn, start.X, start.Y, sizeW, sizeH);


        }
        public override string ToString()
        {
            return "Шкаф";
        }

        public override string GetToolTipInfo()
        {
            return "Размеры: " + _f.Params;
        }
        public override bool IsCrosses(PointF start, float sizeW, float sizeH)
        {
            var SecondLocationPoint = Distance.GetPointFromSize(FirstLocationPoint, SizeW, SizeH);
            Gr.Clip = new Region(new RectangleF(FirstLocationPoint, new SizeF(SizeW, SizeH)));
            var p2 = Distance.GetPointFromSize(start, sizeW, 0);
            var p3 = Distance.GetPointFromSize(start, 0, sizeW);
            var p4 = Distance.GetPointFromSize(start, sizeW, sizeH);
            return Gr.IsVisible(start) || Gr.IsVisible(p2) || Gr.IsVisible(p3) || Gr.IsVisible(p4);
        }
    }
}