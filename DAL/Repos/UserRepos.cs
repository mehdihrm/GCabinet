using DAL.Entity;

namespace DAL.Repos
{
    public class UserRepos
    {
        private MyDbContext dbContext = new MyDbContext();
        public User Read(string username)
        {
            List<User> users = dbContext.Users.ToList();
            User user = null;
            foreach(User u in users)
            {
                if (u.Username == username)
                {
                   user = u;
                    break;
                }
            }
            return user;
        }
    }
}
