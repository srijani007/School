using System;
using System.Collections.Generic;

namespace School.Model.SchoolModel
{
    public partial class User
    {
        public User()
        {
            Enrollments = new HashSet<Enrollment>();
        }

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

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
