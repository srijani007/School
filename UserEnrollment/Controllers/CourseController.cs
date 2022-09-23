using Microsoft.AspNetCore.Mvc;
using School.Business;
using School.Model.SchoolModel;

namespace UserEnrollment.Controllers
{
    [Produces("application/json")]
    [ApiController]   

    public class CourseController : Controller
    {
        private readonly ICourseDirectory _courseDirectory;

        public CourseController(ICourseDirectory courseDirectory)
        {
            _courseDirectory = courseDirectory;
        }

        [Route("[Controller]/CreateCourse")]
        [HttpPost]
        public ActionResult<bool> Createcourses(CourseDetails course)
        {
            try
            {
                var courseData = _courseDirectory.AddCourses(course);
                if (courseData == false)
                {
                    var result = new List<string>();
                    return Ok(new  { result });
                }
                else
                {
                    return  courseData ;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("[Controller]/GetAllCourses")]
        [HttpGet]
        public ActionResult<List<Course>> GetAllCourses()
        {
            try
            {
                var courses = _courseDirectory.GetCourses();
                if (courses == null)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok(courses);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("[Controller]/UpdateCoursedetails")]
        [HttpPut]
        public ActionResult<string> EditCouserDeatils([FromBody] CourseDetails course)
        {
            try
            {
                string result = _courseDirectory.PutCourses(course);
                if (result == null)
                {
                    BadRequest();
                }
                else
                {
                    return Ok(new { result });
                }
                return Ok(null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("[Controller]/GetDetailsbyCourseId")]
        [HttpPost]
        public ActionResult<List<Course>> FetchCourseContent([FromBody] GetCourseDetailsbyId courseDetailsbyId)
        {
            try
            {
                var content = _courseDirectory.GetDetailsbyCourseId(courseDetailsbyId);
                if (content == null)
                {
                    return BadRequest();
                }
                else
                {
                    return content;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
   
    }
}
