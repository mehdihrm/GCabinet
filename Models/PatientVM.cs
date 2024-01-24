using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PatientVM
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Cin { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public string Ville { get; set; }
        public string Adresse { get; set; }
        public bool Mutuelle { get; set; }
    }
}
