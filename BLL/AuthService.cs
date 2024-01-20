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
            if(user != null && user.Password == userModel.Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
