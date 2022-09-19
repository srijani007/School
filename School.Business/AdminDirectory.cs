using School.Model.SchoolModel;
using School.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business
{
    public class AdminDirectory : IAdminDirectory
    {
        public IAdminRepository _adminRepository;
        public SchoolContext _schoolContext { get; set; }

        public AdminDirectory(SchoolContext schoolContext, IAdminRepository adminRepository)
        {
            _schoolContext = schoolContext;
            _adminRepository = adminRepository;
        }
        /// <summary>
        /// Adding or registering the users
        /// </summary>
        /// <param name="details"></param>
        /// <returns>success message from repository layer</returns>
        /// <exception cref="Exception"></exception>
        public string AddUsers(UserDetails details)
        {
            try
            {
                var mailId = _schoolContext.Users.Where(x => x.Email == details.Email).Select(x => x.Email).FirstOrDefault();
                if (mailId == details.Email)
                {
                    return "EmailId already exists";
                }
                else
                {
                    var userdetails = new User();
                    userdetails.UserName = details.UserName;
                    userdetails.FirstName = details.FirstName;
                    userdetails.LastName = details.LastName;
                    userdetails.GradeLevel = details.GradeLevel;
                    userdetails.Email = details.Email;
                    userdetails.Address = details.Address;
                    userdetails.StateCode = details.StateCode;
                    userdetails.Zipcode = details.Zipcode;
                    userdetails.PhoneNumber = details.PhoneNumber;
                    userdetails.Password = details.Password;
                    userdetails.Country = details.Country;
                    userdetails.IdRole = details.IdRole;
                    return _adminRepository.InsertUsers(userdetails);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Login creds to validate in repository
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>success message</returns>
        public List<User> UserLogin(string username, string password)
        {
            return _adminRepository.Login(username,  password);
            
        }
        /// <summary>
        /// Update user details in repository
        /// </summary>
        /// <param name="user"></param>
        /// <returns>success message</returns>
        /// <exception cref="Exception"></exception>
        public string PutUsers(UserDetails user)
        {
            try
            {
                var userlst = _schoolContext.Users.ToList();
                int index = userlst.FindIndex(s => s.Id == user.Id);
                userlst[index].UserName = user.UserName;
                userlst[index].FirstName = user.FirstName;
                userlst[index].LastName = user.LastName;
                userlst[index].Password = user.Password;
                userlst[index].Address = user.Address;
                userlst[index].StateCode = user.StateCode;
                userlst[index].Country = user.Country;
                userlst[index].Zipcode = user.Zipcode;
                userlst[index].PhoneNumber = user.PhoneNumber;
                userlst[index].GradeLevel = user.GradeLevel;
                userlst[index].Email = user.Email;
                userlst[index].IdRole = user.IdRole;
                return _adminRepository.Updateusers(userlst[index]);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Fetching the userdetails by Userid        /// </summary>
        /// <param name="detailsbyId">userId</param>
        /// <returns>user list</returns>
        public List<User> GetDetailsbyUserId(GetUserDetailsbyId detailsbyId)
        {
            return _adminRepository.FetchDetailsbyUserId(detailsbyId);
        }

        /// <summary>
        /// get all the users from repository
        /// </summary>
        /// <returns>all the users in list form</returns>
        public List<User> FetchUsers()
        {
                return _adminRepository.FetchUsers();

        }

        /// <summary>
        /// Fetching the username from repository
        /// </summary>
        /// <param name="detailsbyname">username</param>
        /// <returns>user list</returns>
        public List<User> GetDetailsbyUserName(GetUserDetailsbyName detailsbyname)
        {
            return _adminRepository.FetchDetailsbyUserName(detailsbyname);
        }
    }
}
