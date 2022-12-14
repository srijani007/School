using Microsoft.AspNetCore.Mvc;
using School.Business;
using School.Model.SchoolModel;

namespace UserEnrollment.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class EnrollmentController : Controller
    {
        private readonly IEnrollmentDirectory _enrollmentDirectory;
        public EnrollmentController(IEnrollmentDirectory enrollmentDirectory)
        {
            _enrollmentDirectory = enrollmentDirectory;
        }



        [Route("[Controller]/GetAllEnrollments")]
        [HttpGet]
        public ActionResult<List<Enrollment>> GetAllEnrollments()
        {
            try
            {
                var enrollments = _enrollmentDirectory.GetEnrollments();
                if (enrollments == null)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok(enrollments);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("[Controller]/CreateEnrollment")]
        [HttpPost]
        public ActionResult<bool> AddEnrollments([FromBody] EnrollmentDetails enrollment)
        {
            try
            {
                var enrolldata = _enrollmentDirectory.AddEnrollment(enrollment);
                if (enrolldata == false)
                {
                    var result = "Already enrolled to this course";
                    return Ok(new { result });
                }
                else
                {
                    return enrolldata;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("[Controller]/enrolled")]
        [HttpPost]
        public ActionResult<List<string>> GetEnrollmentsbyUserId([FromBody] GetUserDetailsbyId getUserDetailsby)
        {
            try
            {
                var idDetails = _enrollmentDirectory.GetEnrollmentsbyUserId(getUserDetailsby);
                if (idDetails == null)
                {
                    return new List<string>();
                }
                else
                {
                    return Ok(idDetails);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("[Controller]/enrolleditemsbyCourseId")]
        [HttpPost]
        public ActionResult<List<string>> GetEnrollmentsbyCourseId([FromBody] GetCourseDetailsbyId enrollmentDetailsbyId)
        {
            try
            {
                var idDetails = _enrollmentDirectory.GetEnrollmentsbyCourseId(enrollmentDetailsbyId);
                if (idDetails == null)
                {
                    return new List<string>();
                }
                else
                {
                    return Ok( idDetails );
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
