using DAL.Entity;
using DAL.Repos;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AuthService
    {
        private UserRepos UserRepos = new UserRepos();
        public bool authentifyUser(UserAuthVM userModel)
        {
            User user = UserRepos.Read(userModel.Username);
            // Enlever le commentaire si on va crypter les mdp
            //if (user != null && BCrypt.Net.BCrypt.Verify(userModel.Password, user.Password))
            //{
            //    return true;
            //}
            if (user != null && user.Password == userModel.Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ajouterUser(UserAuthVM userModel)
        {
            if (UserRepos.findUser(userModel.Username) == null && UserRepos.findUser(userModel.Password) ==null)
            {

                User user = new User()
                {
                    Username = userModel.Username,
                    Password = userModel.Password,
                    email=userModel.email

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
            User u = UserRepos.Read2(id);

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

        public void deleteUser(UserAuthVM user)
        {
            UserRepos.Delete(user.Id);
        }

        public bool updateUser(UserAuthVM user)
        {
            User u = UserRepos.Read2(user.Id);
            
            if (UserRepos.findUser(user.Username) == null || UserRepos.findUser(user.Username).Id == user.Id)
            {
                u.Username = user.Username;
                u.email=user.email; u.Password = user.Password;
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
