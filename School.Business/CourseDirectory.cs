using School.Model.SchoolModel;
using School.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business
{
    public class CourseDirectory : ICourseDirectory
    {
        public  ICourseRepository _courseRepository;

        private readonly SchoolContext _schoolContext;
        public CourseDirectory(ICourseRepository courseRepository, SchoolContext schoolContext)
        {

            _courseRepository = courseRepository;
            _schoolContext = schoolContext;
        }
        /// <summary>
        /// Adding course details from repository
        /// </summary>
        /// <param name="course">course details</param>
        /// <returns>success message</returns>
        /// <exception cref="Exception"></exception>
        public bool AddCourses(CourseDetails course)
        {
            try
            {
                var courseDetails = new Course();
                courseDetails.Title = course.Title;
                courseDetails.Description = course.Description;
                courseDetails.Subject = course.Subject;
                courseDetails.SubjectArea = course.SubjectArea;
                courseDetails.GradeLevel = course.GradeLevel;
                return _courseRepository.InsertCourses(courseDetails);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Fetch all the courses from repository
        /// </summary>
        /// <returns>all the courses from repository</returns>

        public List<Course> GetCourses()
        {
            return _courseRepository.FetchCourses();
        }
        /// <summary>
        /// Update the course details from repository
        /// </summary>
        /// <param name="course">course details</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string PutCourses(CourseDetails course)
        {
            try
            {
                var courselst = _schoolContext.Courses.ToList();
                int index = courselst.FindIndex(s => s.Id == course.Id);
                courselst[index].Title = course.Title;
                courselst[index].Description = course.Description;
                courselst[index].Subject = course.Subject;
                courselst[index].SubjectArea = course.SubjectArea;
                courselst[index].GradeLevel = course.GradeLevel;
                return _courseRepository.UpdateCourses(courselst[index]);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Fetching course details by course id
        /// </summary>
        /// <param name="detailsbyId">course id</param>
        /// <returns>course details list</returns>
        public List<Course> GetDetailsbyCourseId(GetCourseDetailsbyId detailsbyId)
        {
            return _courseRepository.FetchCoursesbyCourseId(detailsbyId);
        }

    }
}
