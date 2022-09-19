using School.Model.SchoolModel;
using School.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business
{
    public class EnrollmentDirectory : IEnrollmentDirectory
    {
        private SchoolContext _schoolContext;
        public  IEnrollmentRepository _enrollmentRepository;
        public EnrollmentDirectory(IEnrollmentRepository enrollmentRepository,SchoolContext schoolContext)
        {
            _enrollmentRepository = enrollmentRepository;
            _schoolContext = schoolContext;
        }
        /// <summary>
        /// Adding enrollments from the repository
        /// </summary>
        /// <param name="enrolls">enrollment details</param>
        /// <returns>success message</returns>
        /// <exception cref="Exception"></exception>
        public bool AddEnrollments(EnrollmentDetails enrolls)
        {
            try
            {
                var enrollment = _schoolContext.Enrollments.Where(e => e.IdUser == enrolls.IdUser && e.IdCourse == enrolls.IdCourse && e.RoleId == enrolls.RoleId).Count();
                if (enrollment > 0)
                {
                    return false;
                }
                else
                {
                    var enroll = new Enrollment();
                    enroll.IdCourse = enrolls.IdCourse;
                    enroll.IdUser = enrolls.IdUser;
                    enroll.RoleId = enrolls.RoleId;
                    enroll.Startdate = enrolls.Startdate;
                    enroll.Enddate = enrolls.Enddate;
                    return _enrollmentRepository.InsertEnrollments(enroll);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Fetch all the enrollments
        /// </summary>
        /// <returns>all enrollments</returns>
        public List<Enrollment> GetEnrollments()
        {
            return _enrollmentRepository.FetchEnrollments();
        }
        /// <summary>
        /// Fetch enrollment by userId
        /// </summary>
        /// <param name="userDetailsbyId">userId</param>
        /// <returns>user enrollment details</returns>
        public string GetEnrollmentsbyUserId(GetUserDetailsbyId userDetailsbyId)
        {
           return _enrollmentRepository.EnrollmentsbyUserId(userDetailsbyId);
        }

        /// <summary>
        /// Fetch enrollment by courseId
        /// </summary>
        /// <param name="enrollmentDetailsbyId">courseId</param>
        /// <returns>enrollment details</returns>
        public string GetEnrollmentsbyCourseId(GetCourseDetailsbyId enrollmentDetailsbyId)
        {
            return _enrollmentRepository.EnrollmentsbyCourseId(enrollmentDetailsbyId);
        }
    }
}
