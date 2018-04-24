using EMR.DAL.Models;
using EMR.DAL2.EF;
using EMR.DAL2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMR.DAL2.Repositories
{
    class CrmPersonRepository : ICrmPersonRepository<CrmPerson>
    {
        private EMRContext db;
        public CrmPersonRepository(EMRContext context)
        {
            db = context;
        }

        public (IEnumerable<CrmPerson> persons, Double count) GetPage(int page, int size)
        {
            var query = db.CrmPersons.Include("Person").Skip((page - 1) * size)
                            .Take(size)
                            .ToList();
            var rez = (query, Math.Round((double)(db.Persons.Count() / size), 0));
            return rez;
        }

        public void Create(CrmPerson item)
        {
            db.CrmPersons.Add(item);
            db.SaveChanges();
        }
        public void Delete(Int64 id)
        {
            CrmPerson p = db.CrmPersons.Find(id);
            p.Deleted = true;
            db.Entry(p).State = System.Data.Entity.EntityState.Modified;

            db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();
            db.SaveChanges();
        }
        public IEnumerable<CrmPerson> Find(Func<CrmPerson, bool> predicate)
        {
            return db.CrmPersons.Include("Person").Where(predicate).AsEnumerable();
        }
        public CrmPerson Get(Int64 id)
        {
            return db.CrmPersons.Include("Person").Where(p => p.id == id).FirstOrDefault();
        }
        public IEnumerable<CrmPerson> GetAll()
        {
            return this.Find(p => !p.Deleted).AsEnumerable();
        }

        public void Update(CrmPerson item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
