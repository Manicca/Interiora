using System;
using System.Drawing;

namespace FunctionalityLibrary.Drawing.Figures
{
    public abstract class Figure : ICloneable 
    {
        public PointF FirstLocationPoint;
        public PointF SecondLocationPoint;
        protected Graphics Gr;
        /// <summary>
        /// Функция отрисовки фигуры
        /// </summary>
        /// <param name="bmp">Объект Bitmap для проведения отрисовки.</param>
        /// <param name="start">Начальная точка фигуры. Как правило левый верхний угол.</param>
        /// <param name="end">Конечная точка отрисовки.</param>
        /// <param name="factor">Коэффициент увеличения.</param>
        public virtual void Draw(ref Bitmap bmp, PointF start, PointF end, float factor) { }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
