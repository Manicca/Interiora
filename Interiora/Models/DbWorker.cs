using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Models
{
    public class DbWorker : IDisposable
    {
        private readonly AllModelsContext _db = new AllModelsContext();

        private DbSet<TT> GetDb<TT>() where TT : class
        {
            var source = _db.GetType().GetProperties().First(el => el.ToString().Contains(typeof (TT).Name + "Db"));
            var selectedDb = source.GetValue(_db) as DbSet<TT>;
            return selectedDb;
        }

        public TT AddToBd<TT>(TT tmp) where TT : class
        {
            var selectedDb = GetDb<TT>();
            if (selectedDb != null)
                selectedDb.Add(tmp);
            _db.SaveChanges();
            return tmp;
        }

        public List<TT> SelectFromBd<TT>(Func<TT, bool> f) where TT : class
        {
            var selectedDb = GetDb<TT>();
            return selectedDb != null ? selectedDb.Where(f).ToList() : null;
        }

        public void DeleteFromBd<TT>(Func<TT, bool> f) where TT : class
        {
            var selectedDb = GetDb<TT>();
            var selectedObjectToDestroy = selectedDb.FirstOrDefault(f);
            selectedDb.Remove(selectedObjectToDestroy);
            _db.SaveChanges();
        }

        public TT SelectFirstOrDefaultFromBd<TT>(Func<TT, bool> f) where TT : class
        {
            var selectedDb = GetDb<TT>();
            return selectedDb.FirstOrDefault(f);
        }

        #region IDisposable Support
        private bool disposedValue = false; // Для определения избыточных вызовов

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить ниже метод завершения.
                // TODO: задать большие поля как null.
                disposedValue = true;
            }
        }

        // TODO: переопределить метод завершения, только если Dispose(bool disposing) выше включает код для освобождения неуправляемых ресурсов.
        // ~DbWorker() {
        //   // Не изменяйте этот код. Разместите код очистки выше в методе Dispose(bool disposing).
        //   Dispose(false);
        // }
        // Этот код добавлен для правильной реализации шаблона высвобождаемого класса.
        public void Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки выше в методе Dispose(bool disposing).
            Dispose(true);
            // TODO: раскомментировать следующую строку, если метод завершения переопределен выше.
             GC.SuppressFinalize(this);
        }
        #endregion


    }
}