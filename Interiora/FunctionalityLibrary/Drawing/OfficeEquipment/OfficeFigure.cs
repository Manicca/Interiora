using FunctionalityLibrary.Calculation;
using System;
using System.Drawing;
using Models;

namespace FunctionalityLibrary.Drawing.OfficeEquipment
{
    public abstract class OfficeFigure : ICloneable
    {
        public PointF FirstLocationPoint;
        public float SizeH;
        public float SizeW;
        protected Graphics Gr;
        /// <summary>
        /// Функция отрисовки фигуры
        /// </summary>
        /// <param name="bmp">Объект Bitmap для проведения отрисовки.</param>
        /// <param name="start">Начальная точка оборудования. Как правило левый верхний угол.</param>
        /// <param name="factor">Коэффициент увеличения.</param>
        public abstract void Draw(ref Bitmap bmp, PointF start, float factor);

        public virtual string GetToolTipInfo()
        {
            return "Офисное оборудование";
        }

        public virtual void Rotate ()
        {
            var tmp = SizeW;
            SizeW = SizeH;
            SizeH = tmp;
        }

        public virtual object Clone()
        {
            return MemberwiseClone();
        }

        public virtual bool IsCrossesFigure(PointF start, float sizeW, float sizeH)
        {
            var SecondLocationPoint = Distance.GetPointFromSize(FirstLocationPoint, SizeW, SizeH);
            Gr.Clip = new Region(new RectangleF(FirstLocationPoint, new SizeF(SizeW, SizeH)));
            var p2 = Distance.GetPointFromSize(start, sizeW, 0);
            var p3 = Distance.GetPointFromSize(start, 0, sizeH);
            var p4 = Distance.GetPointFromSize(start, sizeW, sizeH);
            return Gr.IsVisible(start) || Gr.IsVisible(p2) || Gr.IsVisible(p3) || Gr.IsVisible(p4) || Gr.IsVisible(new RectangleF(start, new SizeF(sizeW, sizeH)));
        }

        public virtual bool IsCrossesPoint(PointF start, float offsetError = 0)
        {
            var p1 = FirstLocationPoint;
            p1.X -= offsetError;
            p1.Y -= offsetError;
            var SecondLocationPoint = Distance.GetPointFromSize(FirstLocationPoint, SizeW + offsetError, SizeH + offsetError);
            Gr.Clip = new Region(new RectangleF(p1, new SizeF(SizeW + 2*offsetError, SizeH + 2*offsetError)));
            return Gr.IsVisible(start);
        }

        public abstract Furniture getFurniture();

        public abstract WebEquipment getWeb();

    }
}