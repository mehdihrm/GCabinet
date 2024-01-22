using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;


namespace DAL.Repos
{
    public class PatientRepos
    {
        public void Create(Patient entite)
        {
            MyDbContext db = new MyDbContext();
            db.patient.Add(entite);
            db.SaveChanges();
        }

        public Patient Read(int id)
        {
            MyDbContext db = new MyDbContext();
            var entite = db.patient.Find(id);
            return entite;
        }

        public List<Patient> All()
        {
            MyDbContext db = new MyDbContext();
            return db.patient.ToList();
        }

        public void Delete(int id)
        {
            MyDbContext dbContext = new MyDbContext();
            var obj = dbContext.patient.Find(id);
            dbContext.patient.Remove(obj);
        }

        public void Update(Patient entite)
        {
            MyDbContext dbContext = new MyDbContext();
            dbContext.patient.Update(entite);
        }

    }
}
