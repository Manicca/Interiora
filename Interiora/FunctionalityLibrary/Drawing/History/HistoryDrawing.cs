using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace FunctionalityLibrary.Drawing.History
{
    public class HistoryDrawing
    {
        readonly List<KeyValuePair<Bitmap, Figure>> _history;
        public HistoryDrawing(Bitmap startItem)
        {
            _history = new List<KeyValuePair<Bitmap, Figure>> {new KeyValuePair<Bitmap, Figure>(startItem, null)};
        }

        public List<KeyValuePair<Bitmap, Figure>> AllRecords()
        {
            return _history;
        }

        public void Add(Bitmap bp, Figure f)
        {
            _history.Add(new KeyValuePair<Bitmap, Figure>(bp, f));
        }

        public void RemoveLast()
        {
            _history.Remove(_history.Last());
        }

        public KeyValuePair<Bitmap, Figure> GetLast()
        {
            return _history.Last();
        }

        public void RemoveAfterByIndex(int index)
        {
            if (_history.Count - index != 0)
                _history.RemoveRange(index, _history.Count - index);
        }

        public KeyValuePair<Bitmap, Figure> GetByIndex(int i)
        {
            return _history[i];
        }

        public int Count()
        {
            return _history.Count;
        }
        public void Clear()
        {
            RemoveAfterByIndex(1);
        }
    }

}
