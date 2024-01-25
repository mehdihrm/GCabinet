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
        public User Read2(int id)
        {
            List<User> users = dbContext.Users.ToList();
            User user = null;
            foreach (User u in users)
            {
                if (u.Id == id)
                {
                    user = u;
                    break;
                }
            }
            return user;
        }

        public void Create(User entite)
        {

            dbContext.Users.Add(entite);
            dbContext.SaveChanges();
        }
        public User findUser(string name)
        {
            User us = this.All().Where(u=> u.Username == name).FirstOrDefault();
            return us;
        }

        public List<User> All()
        {
            return dbContext.Users.ToList();
        }

        public void Delete(int id)
        {

            User u = this.Read2(id);
            dbContext.Users.Remove(u);
            dbContext.SaveChanges();
        }

        public void Update(User entite)
        {
            dbContext.Users.Update(entite);
            dbContext.SaveChanges();
        }

    }
}
