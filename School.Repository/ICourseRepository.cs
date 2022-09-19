using School.Model.SchoolModel;

namespace School.Repository
{
    public interface ICourseRepository
    {
        List<Course> FetchCourses();
        List<Course> FetchCoursesbyCourseId(GetCourseDetailsbyId detailsbyId);
        bool InsertCourses(Course details);
        string UpdateCourses(Course course);
    }
}