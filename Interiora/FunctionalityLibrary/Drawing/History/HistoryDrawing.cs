using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace FunctionalityLibrary.Drawing.History
{
    public class HistoryDrawing
    {
        private readonly List<Figure> _history;
        private readonly int _initialHeight;
        private readonly int _initialWidht;
        private readonly Bitmap _clearBmp;

        public HistoryDrawing(Image bpBitmap)
        {
            
            _initialWidht = bpBitmap.Width;
            _initialHeight = bpBitmap.Height;
            _clearBmp = new Bitmap(_initialWidht, _initialHeight);
            var gr = Graphics.FromImage(_clearBmp);
            gr.Clear(Color.White);
            gr.Dispose();
            _history = new List<Figure>();
        }

        public List<Figure> AllRecords()
        {
            return _history;
        }

        public void Add(Figure f)
        {
            _history.Add(f);
        }

        public void RemoveLast()
        {
            _history.Remove(_history.Last());
        }

        public Figure GetLast()
        {
            return _history.Last();
        }

        public void RemoveAfterByIndex(int index)
        {
            if (_history.Count - index > 0)
                _history.RemoveRange(index, _history.Count - index);
        }

        public Bitmap GetByIndex(int index, float factor)
        {
            var realWidth = (int)(_initialWidht * factor);
            var realHeight = (int)(_initialHeight * factor);
            var bp = new Bitmap(_clearBmp, realWidth, realHeight);
            if (_history == null) return bp;
            if (_history.Count == 0) return bp;
            if (index == 0) return bp; // Крайний случай, чтобы фигурки не отрисовывались
            for (var i = 0; i < index; i++)
            {
                var figure = _history[i];
                figure.Draw(ref bp, figure.FirstLocationPoint, figure.SecondLocationPoint, factor);
            }
            return bp;
        }

        public int Count()
        {
            return _history.Count;
        }

        public void Clear()
        {
            RemoveAfterByIndex(0);
        }

        public Bitmap GetLastBitmapOrDefalut(float factor)
        {
            var realWidth = (int) (_initialWidht*factor);
            var realHeight = (int) (_initialHeight*factor);
            var bp = new Bitmap(_clearBmp, realWidth, realHeight);
            if (_history != null)
                foreach (var figure in _history)
                {
                    figure.Draw(ref bp, figure.FirstLocationPoint, figure.SecondLocationPoint, factor);
                }
            return bp;
        }
    }
}