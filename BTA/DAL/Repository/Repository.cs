using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{

    public interface IRepository<T> where T:class
    {
        IEnumerable<T> GetAll();
        T Get(object id);
        
        void Insert(T item);

        void Update(T item);

        void Delete(object id);

        void Save();
    }
    public class Repository<T> : IRepository<T> where T : class
    {
        private BlogContext db;

        DbSet<T> dbset;
        public Repository()
        {
            db = new BlogContext();

            dbset = db.Set<T>();    
        }
        public void Delete(object id)
        {
            T found = dbset.Find(id);
            dbset.Remove(found);

        }

        

        public T Get(object id)
        {
            T found = dbset.Find(id);

            return found;

        }

        public IEnumerable<T> GetAll()
        {
            var list = dbset.ToList();

            return list;
        }

        public void Insert(T item)
        {
            dbset.Add(item);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(T item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.db != null)
                {
                    this.db.Dispose();
                    this.db = null;
                }
            }
        }
    }
}
