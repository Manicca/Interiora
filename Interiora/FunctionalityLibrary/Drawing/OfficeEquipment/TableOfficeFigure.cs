using System;
using System.Drawing;
using FunctionalityLibrary.Calculation;
using FunctionalityLibrary.Properties;
using Models;

namespace FunctionalityLibrary.Drawing.OfficeEquipment
{
    public class TableOfficeFigure : OfficeFigure
    {
        public readonly Furniture _f;

        public TableOfficeFigure(Furniture f)
        {
            _f = f;

            if (f.Type != "Table") throw new Exception("Нельзя использовать тип : " + f.Type);
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
            return "Стол";
        }

        public override string GetToolTipInfo()
        {
            return "Размеры: " + _f.Params;
        }

        public override Furniture getFurniture() { return _f; }
    }
}