using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.Business;
using School.Model.SchoolModel;
using System.Net;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using Newtonsoft.Json;
using System.Web;
using Microsoft.VisualStudio.Services.UserAccountMapping;
using Microsoft.AspNetCore.Authentication;

namespace UserEnrollment.Controllers
{
 
    [ApiController]
   // [Route("[Controller]")]
    [Produces("application/json")]

   
    public class AdminController : Controller 
    { 
        private  IAdminDirectory _adminDirectory;
        

        public AdminController(IAdminDirectory adminDirectory)
        {
            _adminDirectory = adminDirectory;
        }

        [Route("[Controller]/SignIn")]
        [HttpPost]
       
        public ActionResult<List<User>> SignIn(UserLogin userLogin)
        {
            try
            {
               
                var result = _adminDirectory.UserLogin(userLogin.UserName,userLogin.Password);
                if (result != null)
                {
                    return  result;
                }
                else
                {
                    return Ok(null);
                }

            }
            catch (Exception ex)
            {
                 throw new Exception(ex.Message);
               // _logger.LogError(ex.Message);
            }
        }

        [Route("[Controller]/CreateUser")]
        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        
        public ActionResult<string> CreateUsers(UserDetails user)
        {
            try
            {               
                var userData = _adminDirectory.AddUsers(user);
                if (userData == null)
                {
                    var result = "Adding user failed";
                    return Ok(new { result });                   
                }
                else
                {
                    return   userData ;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("[Controller]/GetUsers")]        
        [HttpGet]

        public ActionResult<List<User>> GetAllUsers()
        {
            try
            {
                var users = _adminDirectory.FetchUsers();
                if (users == null)
                {
                    return BadRequest();
                }
                else
                {
                    return users;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("[Controller]/UpdateUserdetails")]
        [HttpPut]
        public ActionResult<string> EditUserDeatils([FromBody] UserDetails user)
        {
            try
            {
                string result = _adminDirectory.PutUsers(user);
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

        [Route("[Controller]/GetDetailsbyUserId")]
        [HttpPost]
        public ActionResult<List<User>> FetchUserContent([FromBody] GetUserDetailsbyId userDetailsbyId)
        {
            try
            {
                var content = _adminDirectory.GetDetailsbyUserId(userDetailsbyId);
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

        [Route("[Controller]/GetDetailsbyUserName")]
        [HttpPost]
        public ActionResult<List<User>> FetchUserContentbyname([FromBody] GetUserDetailsbyName userDetailsbyname)
        {
            try
            {
                var content = _adminDirectory.GetDetailsbyUserName(userDetailsbyname);
                if (content == null)
                {
                    return BadRequest();
                }
                else
                {
                    return  content;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



    }
}
