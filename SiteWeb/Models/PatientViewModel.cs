using Models;

namespace SiteWeb.Models
{
    public class PatientViewModel
    {
        public PatientVM NewPatient { get; set; }
        public List<PatientVM> Patients { get; set; }
    }
}
