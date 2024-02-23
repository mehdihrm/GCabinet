using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;
using Microsoft.EntityFrameworkCore;

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

            RDV rdv = db.RDV.Find(id);
            return rdv;
        }

        public List<RDV> All()
        {

            return db.RDV.ToList();
        }

        public void Delete(int id)
        {
 
            var obj = db.RDV.Find(id);
            db.RDV.Remove(obj);
            db.SaveChanges();

        }

        public void Update(RDV entite)
        {
            db.RDV.Update(entite);
            db.SaveChanges();
        }
        public RDV findrdv(int id)
        {

            RDV rdv = this.All().Where(r => r.Id == id).FirstOrDefault();
            return rdv;
        }
    }
}
