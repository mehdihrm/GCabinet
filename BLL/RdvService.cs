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

        public bool addRdv(RdvVM rdvVm)
        {

            if (rdvRepos.findrdv(rdvVm.Id) == null && rdvVm.DateRDV < DateTime.Now)
            {

                RDV rd = new RDV()
                {
                    Patient=rdvVm.Patient,
                    etatRDV=rdvVm.etatRDV,
                    DateRDV=rdvVm.DateRDV,

                };
                rdvRepos.Create(rd);
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<RdvVM> getAllRDV()
        {
            List<RDV> listerd = rdvRepos.All();
            List<RdvVM> listeRdVM = new List<RdvVM>();
            foreach (RDV rd in listerd)
            {
                RdvVM r = new RdvVM()
                {
                    Id = rd.Id,
                    Patient=rd.Patient,
                    DateRDV=rd.DateRDV,
                    etatRDV =rd.etatRDV,
                };
                listeRdVM.Add(r);
            }
            return listeRdVM;
        }

        public RdvVM getrd(int id)
        {
            RDV r = rdvRepos.Read(id);
            RdvVM rd = new RdvVM()
            {
                Id = r.Id,
                Patient = r.Patient,
                DateRDV = r.DateRDV,
                etatRDV = r.etatRDV,
            };
            return rd;
        }

        public bool updateRDV(RdvVM rdVm)
        {
            RDV r = rdvRepos.Read(rdVm.Id);
            
            if (rdvRepos.findrdv(rdVm.Id) == null)
            {
                r.Patient=rdVm.Patient;
                r.etatRDV= rdVm.etatRDV;
                r.DateRDV= rdVm.DateRDV;

                rdvRepos.Update(r);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void deleteRDV(RdvVM rdVm)
        {
            rdvRepos.Delete(rdVm.Id);
        }
    }
}
