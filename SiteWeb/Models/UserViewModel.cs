using Models;

namespace SiteWeb.Models
{
    public class UserViewModel
    {
        public UserAuthVM newUser { get; set; }
        public List<UserAuthVM> ListeUser { get; set; }
    }
}
