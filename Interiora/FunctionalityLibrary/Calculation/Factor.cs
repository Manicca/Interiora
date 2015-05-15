using System.Drawing;

namespace FunctionalityLibrary.Calculation
{
    public static class Factor
    {
        public static void UnCountFactor(ref PointF dotPointF, float factor)
        {
            dotPointF.X /= factor;
            dotPointF.Y /= factor;
        }

        public static void CountFactor(ref PointF dotPointF, float factor)
        {
            dotPointF.X *= factor;
            dotPointF.Y *= factor;
        }
    }
}