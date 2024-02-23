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
    public class RdvService
    {
        private RDVRepos rdvRepos = new RDVRepos();
        private PatientRepos patientRepos = new PatientRepos();

        public bool addRdv(RdvVM rdvVm)
        {
            List<RDV> allRdvs = rdvRepos.All();
            bool found = false;
            foreach(RDV r in allRdvs)
            {
                if(r.PatientId == rdvVm.PatientId && r.DateRDV == rdvVm.DateRDV)
                {
                    found = true;
                    break;
                }
            }

            if (found == false && rdvVm.DateRDV >= DateTime.Now)
            {
                RDV rdv = new RDV()
                {
                    PatientId = rdvVm.PatientId,
                    DateRDV = rdvVm.DateRDV,
                    etatRDV = rdvVm.etatRDV
                };
                rdvRepos.Create(rdv);
                return true;
            }
            else
                return false;
                

                



        }

        public List<RdvVM> getAllRDV()
        {
            List<RDV> listerdv = rdvRepos.All();
            List<RdvVM> listeRdVM = new List<RdvVM>();
            foreach (RDV rd in listerdv)
            { 
                RdvVM r = new RdvVM()
                {
                    Id = rd.Id,
                    patient = patientRepos.Read(rd.PatientId),
                    PatientId = rd.PatientId,
                    DateRDV=rd.DateRDV,
                    etatRDV =rd.etatRDV,
                };
                listeRdVM.Add(r);
            }
            return listeRdVM;
        }

        public RdvVM getrdv(int id)
        {
            RDV r = rdvRepos.findrdv(id);

            RdvVM rd = new RdvVM()
            {
                Id = r.Id,
                PatientId = r.PatientId,
                patient =patientRepos.Read(r.PatientId),
                DateRDV = r.DateRDV,
                etatRDV = r.etatRDV,
            };
            return rd;
        }

        public bool updateRDV(RdvVM rdVm)
        {
            RDV modifiedRdv = rdvRepos.Read(rdVm.Id);
            if (modifiedRdv != null)
            {
                modifiedRdv.PatientId = rdVm.PatientId;
                modifiedRdv.DateRDV = rdVm.DateRDV;
                modifiedRdv.etatRDV = rdVm.etatRDV;
                rdvRepos.Update(modifiedRdv);
                return true;
            }else
            {
                return false;
            }
        }

        public void deleteRDV(RdvVM rdVm)
        {
            rdvRepos.Delete(rdVm.Id);
        }
        public int rdvsDuJour()
        {
            int cnt = 0;
            foreach(RDV r in rdvRepos.All())
            {
                if (r.DateRDV.Date == DateTime.Now.Date) cnt++;
            }
            return cnt;
        }
        public int rdvAConf()
        {
            int cnt = 0;
            foreach (RDV r in rdvRepos.All())
            {
                if (r.etatRDV == false) cnt++;
            }
            return cnt;
        }
    }
}
