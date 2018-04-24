using EMR.DAL2.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EMR.DAL2.Interfaces
{
   public interface IKlassRepository<T>  where T : class
    {
        Klass Get(Int64 id);
        IEnumerable<SelectListItem> DropDownFor(Int64 selectedId, int type, int Code);
    }
}
