using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace FunctionalityLibrary.Drawing.History
{
    public class HistoryDrawing
    {
        List<KeyValuePair<Bitmap, Figure>> history;
        public HistoryDrawing(Bitmap startItem)
        {
            history = new List<KeyValuePair<Bitmap, Figure>>();
            history.Add(new KeyValuePair<Bitmap, Figure>(startItem, null));
        }

        public List<KeyValuePair<Bitmap, Figure>> AllRecords()
        {
            return history;
        }

        public void Add(Bitmap bp, Figure f)
        {
            history.Add(new KeyValuePair<Bitmap, Figure>(bp, f));
        }

        public void RemoveLast()
        {
            history.Remove(history.Last());
        }

        public KeyValuePair<Bitmap, Figure> GetLast()
        {
            return history.Last();
        }

        public void RemoveAfterByIndex(int index)
        {
            if (history.Count - index != 0)
                history.RemoveRange(index, history.Count - index);
        }

        public KeyValuePair<Bitmap, Figure> GetByIndex(int i)
        {
            return history[i];
        }

        public int Count()
        {
            return history.Count;
        }
        public void Clear()
        {
            this.RemoveAfterByIndex(1);
        }
    }

}
