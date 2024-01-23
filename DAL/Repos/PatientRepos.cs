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
        private MyDbContext db = new MyDbContext();
        public void Create(Patient entite)
        {

            db.patient.Add(entite);
            db.SaveChanges();
        }

        public Patient Read(int id)
        {

            var entite = db.patient.Find(id);
            return entite;
        }

        public List<Patient> All()
        {

            return db.patient.ToList();
        }

        public void Delete(int id)
        {

            var obj = db.patient.Find(id);
            db.patient.Remove(obj);
        }

        public void Update(Patient entite)
        {

            db.patient.Update(entite);
        }

    }
}
