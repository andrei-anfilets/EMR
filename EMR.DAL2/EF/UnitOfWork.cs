using EMR.DAL.Models;
using EMR.DAL2.Interfaces;
using EMR.DAL2.Models.Common;
using EMR.DAL2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMR.DAL2.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private EMRContext db;
        public UnitOfWork()
        {
            db = new EMRContext();
        }
        private KlassRepository klassRepository;
        private PersonRepository personRepository;
        private CrmPersonRepository crmPersonRepository;

        public IKlassRepository<Klass> Klass
        {
            get {
                if (klassRepository==null)
                {
                    klassRepository = new KlassRepository(db);
                }
                return klassRepository;
            }
        }

        public IPersonRepository<Person> Persons
        {
            get {
                if (personRepository==null)
                {
                    personRepository = new PersonRepository(db);
                }
                return personRepository;
            }
        }

        public ICrmPersonRepository<CrmPerson> CrmPersons
        {
            get {
                if (crmPersonRepository == null)
                {
                    crmPersonRepository = new CrmPersonRepository(db);
                }
                return crmPersonRepository;
            }
        }
    }
}
