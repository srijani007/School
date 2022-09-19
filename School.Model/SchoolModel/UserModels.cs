using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Model.SchoolModel
{
    public class UserModels
    {
    }
    public class UserLogin
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }


    public class GetUserDetailsbyId
    {
        public int? Id { get; set; }
    }

    public class GetUserDetailsbyName
    {
        public string? userName { get; set; }
    }

    public class UserDetails
    {

        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public int? GradeLevel { get; set; }
        public string? Address { get; set; }
        public string? StateCode { get; set; }
        public string? Country { get; set; }
        public string? Zipcode { get; set; }
        public string? PhoneNumber { get; set; }
        public string? IdRole { get; set; }
    }
}
