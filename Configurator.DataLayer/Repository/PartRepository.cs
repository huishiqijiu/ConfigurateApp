using Configurator.DataLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.DataLayer.Repository
{
    public class PartRepository : IPartRepository
    {
        ConfiguratorEntities1 db = new ConfiguratorEntities1();
        public void DeletePart(int id)
        {
            Part p = db.Parts.FirstOrDefault(x => x.Id == id);
            db.Parts.Remove(p);
            db.SaveChanges();
        }

        public IList<Part> GetAllParts(int prodID)
        {
            return db.Parts.Where(x => x.ProductId == prodID).ToList();
        }

        public Part GetPartById(int id)
        {
            return db.Parts.FirstOrDefault(x => x.Id == id);
        }

        public int SavePart(Part part)
        {
            db.Parts.Add(part);
            db.SaveChanges();
            return part.Id;
        }

        public bool UpdatePart(Part part)
        {
            throw new NotImplementedException();
        }
    }
}
