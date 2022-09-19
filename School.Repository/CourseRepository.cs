using School.Model.SchoolModel;

namespace School.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly SchoolContext _schoolcontext;
        public CourseRepository(SchoolContext context)
        {
            _schoolcontext = context;
        }
        public bool InsertCourses(Course details)
        {
            _schoolcontext.Courses.Add(details);
            return _schoolcontext.SaveChanges() > 0;
        }

        public List<Course> FetchCourses()
        {
            try
            {
                return _schoolcontext.Courses.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string UpdateCourses(Course course)
        {
            try
            {
                _schoolcontext.Courses.Update(course);
                _schoolcontext.SaveChanges();
                return "Course details updated succesfully";

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Course> FetchCoursesbyCourseId(GetCourseDetailsbyId detailsbyId)
        {
            try
            {
                var coursecontent = _schoolcontext.Courses.Where(c => c.Id == detailsbyId.Id).Select(c => c);
                return coursecontent.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
