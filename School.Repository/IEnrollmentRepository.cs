using School.Model.SchoolModel;

namespace School.Repository
{
    public interface IEnrollmentRepository
    {
        string EnrollmentsbyCourseId(GetCourseDetailsbyId enrollmentDetailsbyId);
        string EnrollmentsbyUserId(GetUserDetailsbyId userDetailsbyId);
        List<Enrollment> FetchEnrollments();
        bool InsertEnrollments(Enrollment details);
    }
}