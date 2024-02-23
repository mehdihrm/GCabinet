using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace Models
{
    public class RdvVM
    {
        
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Patient patient { get; set; }
        public DateTime DateRDV { get; set; }
        public bool etatRDV { get; set; }
    }
}
