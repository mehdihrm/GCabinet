using DAL.Entity;
using DAL.Repos;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PatientService
    {
        private PatientRepos patientRepos = new PatientRepos();

        public bool addPatient(PatientVM patientVm)
        {
            
            if(patientRepos.findPatient(patientVm.Cin) == null && patientVm.DateNaissance < DateTime.Now)
            {

                Patient patient = new Patient()
                {
                    Nom = patientVm.Nom,
                    Prenom = patientVm.Prenom,
                    Adresse = patientVm.Adresse,
                    Ville = patientVm.Ville,
                    Mutuelle = patientVm.Mutuelle,
                    DateNaissance = patientVm.DateNaissance,
                    Cin = patientVm.Cin
                    
                };
                patientRepos.Create(patient);
                return true;
            }
            else
            {
                return false;
            }
           
        }
        public List<PatientVM> getAllPatients() {
            List<Patient> listePatients = patientRepos.All();
            List<PatientVM> listePatVM = new List<PatientVM>();
            foreach(Patient patient in listePatients)
            {
                PatientVM p = new PatientVM()
                {
                    Id = patient.Id,
                    Nom = patient.Nom,
                    Prenom = patient.Prenom,
                    Ville = patient.Ville,
                    DateNaissance = patient.DateNaissance,
                    Adresse = patient.Adresse,
                    Cin = patient.Cin,
                    Mutuelle = patient.Mutuelle
                };
                listePatVM.Add(p);
            }
            return listePatVM;
        }
    }
}
