using Models;

namespace SiteWeb.Models
{
    public class RdvViewModel
    {
        public RdvVM newrd { get; set; }
        public List<RdvVM> Listerdv{ get; set; }
        public List<PatientVM> Patients { get; set; }
    }
}
