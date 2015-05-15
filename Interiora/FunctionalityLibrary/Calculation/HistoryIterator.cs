using System;
using System.Collections.Generic;

namespace FunctionalityLibrary.Calculation
{
    public class HistoryIterator
    {
        public HistoryIterator(int count, int current)
        {
            _count = count;
            _current = current;
        }

        private int _count;
        private int _current;

        public int Current
        {
            get { return _current; }
        }

        public int Count
        {
            get { return _count; }
        }

        public int NextOrLast()
        {
            if (++_current > _count)
                _current = _count ;
            return _current;
        }

        public int PreviousOrFirst()
        {
            if (--_current < 0)
                _current = 0;
            return _current;
        }

        public void Clear()
        {
            _current = 0;
            _count = 0;
        }

        public void HistoryUpdate(int newCount, int current)
        {
            _count = newCount;
            if(_current > _count)
                throw new Exception("Текущий не может быть больше количества");
            _current = current;
        }

    }
}