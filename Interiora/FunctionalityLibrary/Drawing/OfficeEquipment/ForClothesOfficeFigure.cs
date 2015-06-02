using System.Drawing;
using FunctionalityLibrary.Calculation;
using Models;

namespace FunctionalityLibrary.Drawing.OfficeEquipment
{
    public class ForClothesOfficeFigure : OfficeFigure
    {
        private readonly Furniture _f;

        public ForClothesOfficeFigure(Furniture f)
        {
            _f = f;

            var splited = f.Params.Split('*');
            SizeW = float.Parse(splited[0]);
            SizeH = float.Parse(splited[1]);
        }

        public override void Draw(ref Bitmap bmp, PointF start, float factor)
        {
            Gr = Graphics.FromImage(bmp);
            var pn = new Pen(Color.Black, 1*factor);

            var sizeW = SizeW;
            var sizeH = SizeH;
            Factor.CountFactor(ref start, factor);
            Factor.CountFactor(ref sizeW, factor);
            Factor.CountFactor(ref sizeH, factor);

            Gr.DrawLine(pn, start.X, start.Y, start.X + sizeW, start.Y + sizeH);
            Gr.DrawLine(pn, start.X, start.Y + sizeH, start.X + sizeW, start.Y);
        }

        public override string ToString()
        {
            return "Вешалка";
        }

        public override string GetToolTipInfo()
        {
            return "Размеры: " + _f.Params;
        }

        public override Furniture getFurniture() { return _f; }
    }
}