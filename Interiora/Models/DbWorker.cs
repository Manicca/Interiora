using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Models
{
    public class DbWorker
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
    }
}