using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace DAL.Repos
{
    public class RDVRepos
    {
        private MyDbContext db = new MyDbContext();
        public void Create(RDV entite)
        {
            db.RDV.Add(entite);
            db.SaveChanges();
        }

        public RDV Read(int id)
        {

            var entite = db.RDV.Find(id);
            return entite;
        }

        public List<RDV> All()
        {

            return db.RDV.ToList();
        }

        public void Delete(int id)
        {
 
            var obj = db.RDV.Find(id);
            db.RDV.Remove(obj);
        }

        public void Update(RDV entite)
        {
            db.RDV.Update(entite);
        }
        public RDV findrdv(int id)
        {
            RDV r = this.All().Where(p => p.Id == id).FirstOrDefault();
            return r;
        }
    }
}
