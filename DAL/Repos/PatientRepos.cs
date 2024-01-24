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
        public Patient findPatient(string cin)
        {
            //List<Patient> liste = this.All();
            //Patient patient = null;   
            //foreach(Patient p in liste)
            //{
            //    if(p.Cin == cin)
            //    {
            //        patient = p;
            //        break;
            //    }

            //}
            Patient pat = this.All().Where(p => p.Cin == cin).FirstOrDefault();
            return pat;
        }

        public List<Patient> All()
        {
            return db.patient.ToList();
        }

        public void Delete(int id)
        {

            Patient p = this.Read(id);
            db.patient.Remove(p);
            db.SaveChanges();
        }

        public void Update(Patient entite)
        {
            db.patient.Update(entite);
            db.SaveChanges();
        }

    }
}
