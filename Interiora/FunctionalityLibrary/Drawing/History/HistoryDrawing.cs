using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using FunctionalityLibrary.Drawing.Figures;
using FunctionalityLibrary.Drawing.OfficeEquipment;
using System;

namespace FunctionalityLibrary.Drawing.History
{
    public class HistoryDrawing : IDisposable
    {
        private readonly List<Figure> _historyFigures;
        private readonly List<OfficeFigure> _historyOfficeFigures; 
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
            _historyFigures = new List<Figure>();
            _historyOfficeFigures = new List<OfficeFigure>();
        }

        public List<Figure> AllFiguresRecords()
        {
            return _historyFigures;
        }

        public List<OfficeFigure> AllOfficeFiguresRecords()
        {
            return _historyOfficeFigures;
        }

        public void AddFigure(Figure f)
        {
            _historyFigures.Add(f);
        }

        public void AddOfficeFigure(OfficeFigure f)
        {
            _historyOfficeFigures.Add(f);
        }

        public void RemoveFigureAfterByIndex(int index)
        {
            if (_historyFigures.Count - index > 0)
                _historyFigures.RemoveRange(index, _historyFigures.Count - index);
        }

        public void RemoveOfficeFigureAfterByIndex(int index)
        {
            if (_historyOfficeFigures.Count - index > 0)
                _historyOfficeFigures.RemoveRange(index, _historyOfficeFigures.Count - index);
        }


        public Bitmap GetFigureByIndex(int index, float factor)
        {
            if (index < 1)
                index = 1;
            var realWidth = (int)(_initialWidht * factor);
            var realHeight = (int)(_initialHeight * factor);
            var bp = new Bitmap(_clearBmp, realWidth, realHeight);
            if (_historyFigures == null) return bp;
            if (_historyFigures.Count == 0) return bp;
            if (index == 0) return bp; // Крайний случай, чтобы фигурки не отрисовывались
            for (var i = 0; i < index; i++)
            {
                var figure = _historyFigures[i];
                figure.Draw(ref bp, figure.FirstLocationPoint, figure.SecondLocationPoint, factor);
            }
            return bp;
        }

        public Bitmap GetOfficeFigureByIndex(int index, float factor)
        {
            var bp = GetLastBitmapOrDefalutOnlyFigures(factor);

            if (_historyOfficeFigures == null) return bp;
            if (_historyOfficeFigures.Count == 0) return bp;
            if (index == 0) return bp; // Крайний случай, чтобы фигурки не отрисовывались
            for (var i = 0; i < index; i++)
            {
                var figure = _historyOfficeFigures[i];
                figure.Draw(ref bp, figure.FirstLocationPoint, factor);
            }
            return bp;
        }

        public int CountFigures()
        {
            return _historyFigures.Count;
        }

        public int CountOfficeFigures()
        {
            return _historyOfficeFigures.Count;
        }


        public void ClearFigures()
        {
            RemoveFigureAfterByIndex(1);
        }

        public void ClearOfficeFigures()
        {
            RemoveOfficeFigureAfterByIndex(0);
        }

        public Bitmap GetLastBitmapOrDefalutOnlyFigures(float factor)
        {
            var realWidth = (int) (_initialWidht*factor);
            var realHeight = (int) (_initialHeight*factor);
            var bp = new Bitmap(_clearBmp, realWidth, realHeight);
            if (_historyFigures != null)
                foreach (var figure in _historyFigures)
                {
                    figure.Draw(ref bp, figure.FirstLocationPoint, figure.SecondLocationPoint, factor);
                }
            return bp;
        }

        public Bitmap GetLastBitmapOrDefalutOfficeFigures(float factor)
        {
            var bp = GetLastBitmapOrDefalutOnlyFigures(factor);
            if (_historyOfficeFigures != null)
                foreach (var figure in _historyOfficeFigures)
                {
                    figure.Draw(ref bp, figure.FirstLocationPoint, factor);
                }
            return bp;
        }

        #region IDisposable Support
        private bool disposedValue = false; // Для определения избыточных вызовов

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _clearBmp.Dispose();
                }

                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить ниже метод завершения.
                // TODO: задать большие поля как null.

                disposedValue = true;
            }
        }

        // TODO: переопределить метод завершения, только если Dispose(bool disposing) выше включает код для освобождения неуправляемых ресурсов.
        // ~HistoryDrawing() {
        //   // Не изменяйте этот код. Разместите код очистки выше в методе Dispose(bool disposing).
        //   Dispose(false);
        // }

        // Этот код добавлен для правильной реализации шаблона высвобождаемого класса.
        public void Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки выше в методе Dispose(bool disposing).
            Dispose(true);
            // TODO: раскомментировать следующую строку, если метод завершения переопределен выше.
            // GC.SuppressFinalize(this);
        }
        #endregion


    }
}