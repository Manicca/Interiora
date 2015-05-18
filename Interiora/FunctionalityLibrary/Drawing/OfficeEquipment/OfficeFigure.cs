using System;
using System.Drawing;

namespace FunctionalityLibrary.Drawing.OfficeEquipment
{
    public class OfficeFigure : ICloneable
    {
        public PointF FirstLocationPoint;
        protected Graphics Gr;
        /// <summary>
        /// Функция отрисовки фигуры
        /// </summary>
        /// <param name="bmp">Объект Bitmap для проведения отрисовки.</param>
        /// <param name="start">Начальная точка оборудования. Как правило левый верхний угол.</param>
        /// <param name="factor">Коэффициент увеличения.</param>
        public virtual void Draw(ref Bitmap bmp, PointF start, float factor) { }

        public virtual string GetToolTipInfo()
        {
            return "Офисное оборудование";
        }


        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}