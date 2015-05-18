using System.Drawing;
using FunctionalityLibrary.Drawing.History;

namespace FunctionalityLibrary.Calculation
{
    public static class SizingImage
    {
        public static Bitmap GetNewSizedBitmap(HistoryDrawing history, float factor, Bitmap initialBmp)
        {
            
            var newSize = new Size((int)(initialBmp.Width * factor),
                (int)(initialBmp.Height * factor));

            return new Bitmap(history.GetLastBitmapOrDefalut(factor), newSize);
        }  
    }
}