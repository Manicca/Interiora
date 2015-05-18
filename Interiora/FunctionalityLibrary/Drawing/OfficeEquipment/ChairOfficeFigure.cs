using System;
using System.Drawing;
using FunctionalityLibrary.Calculation;
using FunctionalityLibrary.Properties;
using Models;

namespace FunctionalityLibrary.Drawing.OfficeEquipment
{
    public class ChairOfficeFigure : OfficeFigure
    {
        

        private readonly Furniture _f;
        private float _sizeH;
        private float _sizeW;

        public ChairOfficeFigure(Furniture f)
        {
            _f = f;

            if (f.Type != "Chair") throw new Exception("Нельзя использовать тип : " + f.Type);
            var splited = f.Params.Split('*');

            _sizeW = float.Parse(splited[0]);
            _sizeH = float.Parse(splited[1]);
        }

        public override void Draw(ref Bitmap bmp, PointF start, float factor)
        {
            Gr = Graphics.FromImage(bmp);
            var pn = new Pen(Color.Black, 1 * factor);
            var sizeW = _sizeW;
            var sizeH = _sizeH;
            Factor.CountFactor(ref start, factor);
            Factor.CountFactor(ref sizeW, factor);
            Factor.CountFactor(ref sizeH, factor);

            Gr.DrawEllipse(pn, start.X, start.Y, sizeW, sizeH);
        }

        public override string ToString()
        {
            return "Стул";
        }

        public override string GetToolTipInfo()
        {
            return "Размеры: " + _f.Params;
        }
    }
}