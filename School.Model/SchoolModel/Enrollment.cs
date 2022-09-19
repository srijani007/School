using System;
using System.Collections.Generic;

namespace School.Model.SchoolModel
{
    public partial class Enrollment
    {
        public int IdCourse { get; set; }
        public int? IdUser { get; set; }
        public int? RoleId { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public int Id { get; set; }

        public virtual Course IdCourseNavigation { get; set; } = null!;
        public virtual User? IdUserNavigation { get; set; }
    }
}
