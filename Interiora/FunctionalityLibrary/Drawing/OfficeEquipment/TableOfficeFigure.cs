using System;
using System.Drawing;
using FunctionalityLibrary.Calculation;
using FunctionalityLibrary.Properties;
using Models;

namespace FunctionalityLibrary.Drawing.OfficeEquipment
{
    public class TableOfficeFigure : OfficeFigure
    {
        private readonly Furniture _f;
        private float _sizeH;
        private float _sizeW;

        public TableOfficeFigure(Furniture f)
        {
            _f = f;

            if (f.Type != "Table") throw new Exception("Нельзя использовать тип : " + f.Type);
            var splited = f.Params.Split('*');

            _sizeW = float.Parse(splited[0]);
            _sizeH = float.Parse(splited[1]);
        }

        public override void Draw(ref Bitmap bmp, PointF start, float factor)
        {
            Gr = Graphics.FromImage(bmp);
            var pn = new Pen(Color.Black, 1*factor);

            Factor.CountFactor(ref start, factor);
            Factor.CountFactor(ref _sizeW, factor);
            Factor.CountFactor(ref _sizeH, factor);

            Gr.DrawRectangle(pn, start.X, start.Y, _sizeW, _sizeH);
        }

        public override string ToString()
        {
            return "Стол";
        }

        public override string GetToolTipInfo()
        {
            return "Размеры: " + _f.Params;
        }
    }
}