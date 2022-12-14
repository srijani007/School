using School.Model.SchoolModel;

namespace School.Business
{
    public interface IEnrollmentDirectory
    {
        bool AddEnrollment(EnrollmentDetails enrollment);
        List<Enrollment> GetEnrollments();
        string GetEnrollmentsbyCourseId(GetCourseDetailsbyId enrollmentDetailsbyId);
        string GetEnrollmentsbyUserId(GetUserDetailsbyId userDetailsbyId);
    }
}