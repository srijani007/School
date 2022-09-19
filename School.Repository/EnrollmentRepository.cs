using Microsoft.Data.SqlClient;
using School.Model.SchoolModel;
using Newtonsoft.Json;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace School.Repository
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly SchoolContext _schoolcontext;

        private readonly IConfiguration _configuration;        

        public EnrollmentRepository(SchoolContext context, IConfiguration configuration)
        {
            _schoolcontext = context;
            _configuration = configuration;
        }
        public bool InsertEnrollments(Enrollment details)
        {
            _schoolcontext.Enrollments.Add(details);
            return _schoolcontext.SaveChanges() > 0;
        }

        public string EnrollmentsbyUserId(GetUserDetailsbyId userDetailsbyId)
        {
            try

            {
                string connetionString;
                SqlConnection con;
                connetionString =_configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
                con = new SqlConnection(connetionString);
                con.Open();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("GetEnrolledCourse", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@userId", userDetailsbyId.Id);
                da.Fill(dt);
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    string JSONString = JsonConvert.SerializeObject(dt);
                    return JSONString;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Enrollment> FetchEnrollments()
        {
            try
            {
                return _schoolcontext.Enrollments.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string EnrollmentsbyCourseId(GetCourseDetailsbyId enrollmentDetailsbyId)
        {
            try

            {
                string connetionString;
                SqlConnection con;
                connetionString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
                con = new SqlConnection(connetionString);
                con.Open();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("GetEnrollmentsbyCourseId", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idcourse", enrollmentDetailsbyId.Id);
                da.Fill(dt);
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    string JSONString = JsonConvert.SerializeObject(dt);
                    return JSONString;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
