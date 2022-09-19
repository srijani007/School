using School.Model.SchoolModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly SchoolContext _schoolContext;
        public AdminRepository(SchoolContext context)
        {
            _schoolContext = context;
        }

        public string InsertUsers(User details)
        {
            _schoolContext.Users.Add(details);
            _schoolContext.SaveChanges();
            return "Signed up successfully!!";
        }
        public List<User> Login(string username, string password)
        {
            try
            {
                var userData = _schoolContext.Users.Where(u => u.UserName == username && u.Password == password).Select(u => u).ToList();
                if (userData != null)
                {
                    return userData;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string Updateusers(User user)
        {
            _schoolContext.Users.Update(user);
            _schoolContext.SaveChanges();
            return "User details updated successfully";

        }
        public List<User> FetchDetailsbyUserId(GetUserDetailsbyId detailsbyId)
        {
            try
            {
                var coursecontent = _schoolContext.Users.Where(c => c.Id == detailsbyId.Id).Select(c => c);
                return coursecontent.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<User> FetchUsers()
        {
            try
            {
                return _schoolContext.Users.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<User> FetchDetailsbyUserName(GetUserDetailsbyName detailsbyname)
        {
            try
            {
                var coursecontent = _schoolContext.Users.Where(c => c.UserName == detailsbyname.userName).Select(c => c);
                return coursecontent.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
