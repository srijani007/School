using School.Model.SchoolModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        public SchoolContext _schoolContext { get; set; }

        public AuthenticationRepository(SchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
        }

        public List<User> validateuser(string username, string password)
        {
            var userObj = _schoolContext.Users.Where(u => u.UserName == username && u.Password == password).ToList();
            if (userObj != null)
            {
                return userObj;
            }
            else
            {
                return null;
            }
        }
    }
}
