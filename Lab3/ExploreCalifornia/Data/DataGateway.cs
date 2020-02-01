using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExploreCalifornia.Models;
using Microsoft.EntityFrameworkCore;

namespace ExploreCalifornia.Data
{
    public class DataGateway<T> : IDataGateway<T> where T : class
    {
        internal ExploreCaliforniaContext db;
        internal DbSet<T> data = null;

        public DataGateway(ExploreCaliforniaContext context)
        {
            this.db = context;
            this.data = db.Set<T>();
        }
        public T Delete(int? id)
        {
            T obj = data.Find(id);
            data.Remove(obj);
            Save();
            return obj;
        }

        public void Insert(T obj)
        {
            data.Add(obj);
            Save();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public IEnumerable<T> SelectAll()
        {
            return data.ToList();
        }

        public T SelectById(int? id)
        {
            return data.Find(id);
        }

        public void Update(T obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            Save();
        }

    }
}
