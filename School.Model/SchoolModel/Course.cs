using System;
using System.Collections.Generic;

namespace School.Model.SchoolModel
{
    public partial class Course
    {
        public Course()
        {
            Enrollments = new HashSet<Enrollment>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Subject { get; set; }
        public string? SubjectArea { get; set; }
        public int? GradeLevel { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
