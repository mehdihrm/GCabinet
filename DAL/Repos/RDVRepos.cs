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
        public void Create(RDV entite)
        {
            MyDbContext db = new MyDbContext();
            db.RDV.Add(entite);
            db.SaveChanges();
        }

        public RDV Read(int id)
        {
            MyDbContext db = new MyDbContext();
            var entite = db.RDV.Find(id);
            return entite;
        }

        public List<RDV> All()
        {
            MyDbContext db = new MyDbContext();
            return db.RDV.ToList();
        }

        public void Delete(int id)
        {
            MyDbContext dbContext = new MyDbContext();
            var obj = dbContext.RDV.Find(id);
            dbContext.RDV.Remove(obj);
        }

        public void Update(RDV entite)
        {
            MyDbContext dbContext = new MyDbContext();
            dbContext.RDV.Update(entite);
        }
    }
}
