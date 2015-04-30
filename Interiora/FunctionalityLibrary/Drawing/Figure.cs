using System;
using System.Drawing;

namespace FunctionalityLibrary.Drawing
{
    public abstract class Figure : ICloneable
    {
        public Point FirstLocationPoint;
        public Point SecondLocationPoint;
        public Graphics gr;
        public virtual void Draw(ref Bitmap bmp, Point start, Point end) { }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
