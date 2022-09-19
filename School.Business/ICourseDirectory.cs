using School.Model.SchoolModel;

namespace School.Business
{
    public interface ICourseDirectory
    {
        bool AddCourses(CourseDetails course);
        List<Course> GetCourses();
        List<Course> GetDetailsbyCourseId(GetCourseDetailsbyId detailsbyId);
        string PutCourses(CourseDetails course);
    }
}