using EMR.DAL2.EF;
using EMR.DAL2.Interfaces;
using EMR.DAL2.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EMR.DAL2.Repositories
{
    public class KlassRepository : IKlassRepository<Klass>
    {
        private EMRContext db;
        public KlassRepository(EMRContext context)
        {
            db = context;
        }

        public Klass Get(Int64 id)
        {
            return db.Klass.Find(id);
        }

        public IEnumerable<SelectListItem> DropDownFor(Int64 selectedId, int type, int code)
        {
            List<SelectListItem> list = db.Klass.Where(c => c.Type == type && (code == 0 || c.Code == code)).
               Select(d => new SelectListItem() { Value = d.Id.ToString(), Text = d.Name }).ToList();
            if (selectedId > 0)
            {
                list.Where(d => d.Value.ToString() == selectedId.ToString()).ToList().ForEach(l => l.Selected = true);
            }
            return list;
        }
    }
}
