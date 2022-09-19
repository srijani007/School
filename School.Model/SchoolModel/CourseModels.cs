using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Model.SchoolModel
{
    public class CourseModels
    {
    }
    public class CourseDetails
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Subject { get; set; }
        public string? SubjectArea { get; set; }
        public int? GradeLevel { get; set; }

    }

    public class GetCourseDetailsbyId
    {
        public int? Id { get; set; }
    }
}
