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
    public class UserService
    {
        private UserRepos UserRepos = new UserRepos();

        public string HashPassword(string password)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password) ;
            return hashedPassword;
        }


        public bool ajouterUser(UserAuthVM userModel)
        {
            if (UserRepos.findUser(userModel.Username) == null && UserRepos.findUser(userModel.Password) == null)
            {

                User user = new User()
                {
                    Username = userModel.Username,
                    Password = HashPassword(userModel.Password),
                    email = userModel.email

                };
                UserRepos.Create(user);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<UserAuthVM> getAllUsers()
        {
            List<User> liste = UserRepos.All();
            List<UserAuthVM> listeUserVM = new List<UserAuthVM>();
            foreach (User us in liste)
            {
                UserAuthVM user = new UserAuthVM()
                {
                    Id = us.Id,
                    Username = us.Username,
                    Password = us.Password,
                    email = us.email
                };
                listeUserVM.Add(user);
            }
            return listeUserVM;
        }
        public UserAuthVM getUser(int id)
        {
            User u = UserRepos.ReadById(id);

            if (u != null)
            {
                UserAuthVM user = new UserAuthVM()
                {
                    Id = u.Id,
                    Username = u.Username,
                    Password = u.Password,
                    email = u.email
                };

                return user;
            }
            else
            {
                throw new Exception("Null");

            }
        }
        public User getUserByUsername(string username)
        {
            return UserRepos.findUser(username);
        }
        public void deleteUser(UserAuthVM user)
        {
            UserRepos.Delete(user.Id);
        }
        public bool updateUser(UserAuthVM user)
        {
            User u = UserRepos.ReadById(user.Id);

            if (UserRepos.findUser(user.Username) == null || UserRepos.findUser(user.Username).Id == user.Id)
            {
                u.Username = user.Username;
                u.email = user.email;
                if(!string.IsNullOrEmpty(user.Password))
                {
                        u.Password = HashPassword(user.Password);                     
                }
                              
                UserRepos.Update(u);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
