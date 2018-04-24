using EMR.DAL.Models;
using EMR.DAL2.Models;
using EMR.DAL2.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMR.DAL2.Interfaces
{
   public interface IUnitOfWork
    {

        IPersonRepository<Person> Persons { get; }
        ICrmPersonRepository<CrmPerson> CrmPersons { get; }
        IKlassRepository<Klass> Klass { get; }
    }
}
