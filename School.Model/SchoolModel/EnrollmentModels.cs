using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Model.SchoolModel
{
    public class EnrollmentModels
    {
    }
    public class EnrollmentDetails
    {
        public int IdCourse { get; set; }
        public int? IdUser { get; set; }
        public int? RoleId { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
    }
}
