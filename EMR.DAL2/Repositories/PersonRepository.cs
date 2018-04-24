using EMR.DAL2.EF;
using EMR.DAL2.Interfaces;
using EMR.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMR.DAL2.Repositories
{
   public class PersonRepository : IPersonRepository<Person>
    {
        private EMRContext db;
        public PersonRepository(EMRContext context)
        {
            db = context;
        }
        
        public (IEnumerable<Person> persons, Double count) GetPage(int page, int size)
        {
           var query = db.Persons.Skip((page - 1) * size)
                           .Take(size)
                           .ToList();
           var rez =  (query, Math.Round((double)(db.Persons.Count() / size), 0));
           return rez;
        }

        public void Create(Person item)
        {
            db.Persons.Add(item);
            db.SaveChanges();
        }
        public void Delete(Int64 id)
        {
            Person p = db.Persons.Find(id);
            p.Deleted = true;
            db.Entry(p).State = System.Data.Entity.EntityState.Modified;

            db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();
            db.SaveChanges();
        }
        public IEnumerable<Person> Find(Func<Person, bool> predicate)
        {
            return db.Persons.Include("Rank").Include("Department").Where(predicate).AsEnumerable();
        }
        public Person Get(Int64 id)
        {
            return db.Persons.Include("Rank").Include("Department").Where(p => p.Id == id).FirstOrDefault();
        }
        public IEnumerable<Person> GetAll()
        {
            return this.Find(p => !p.Deleted).AsEnumerable();
        }        

        public void Update(Person item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
