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

        public PatientVM getPatient(int id)
        {
            Patient p = patientRepos.Read(id);
            PatientVM patient = new PatientVM()
            {
                Id = p.Id,
                Nom = p.Nom,
                Ville = p.Ville,
                Adresse = p.Adresse,
                Cin = p.Cin,
                Mutuelle = p.Mutuelle,
                DateNaissance = p.DateNaissance,
                Prenom = p.Prenom
            };
            return patient;
        }
        public bool updatePatient(PatientVM patientVm)
        {
            Patient p = patientRepos.Read(patientVm.Id);
            // Modifier si cin = cin du mêmme patient ou modifier si on mmet un new cin
            if(patientRepos.findPatient(patientVm.Cin) == null || patientRepos.findPatient(patientVm.Cin).Id == patientVm.Id)
            {
                p.Nom = patientVm.Nom;
                p.Prenom = patientVm.Prenom;
                p.Ville = patientVm.Ville;  
                p.Mutuelle = patientVm.Mutuelle;
                p.Cin = patientVm.Cin;
                p.DateNaissance = patientVm.DateNaissance;
                patientRepos.Update(p);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void deletePatient(PatientVM patientVm)
        {
            patientRepos.Delete(patientVm.Id);
        }

        
    }
}
