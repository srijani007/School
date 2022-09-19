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

namespace UserEnrollment.Controllers
{
   // [AuthenticationFilter]
   //[BasicAuthentication]
    [ApiController]
    [Route("[Controller]")]
    [Produces("application/json")]

   
    public class AdminController : Controller 
    {


 
        private  IAdminDirectory _adminDirectory;
        private IAuthenticationDirectory _authenticationDirectory;

        public AdminController(IAdminDirectory adminDirectory, IAuthenticationDirectory authenticationDirectory)
        {
            _adminDirectory = adminDirectory;
            _authenticationDirectory = authenticationDirectory;
        }

        //protected   Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        //{
        //    try
        //    {

        //        var authenticationToken = request.Headers.GetValues("Authorization").FirstOrDefault();
        //        if (authenticationToken != null)
        //        {
        //            byte[] data = Convert.FromBase64String(authenticationToken);
        //            string decodedAuthenticationToken = Encoding.UTF8.GetString(data);
        //            string[] UsernamePasswordArray = decodedAuthenticationToken.Split(':');
        //            string username = UsernamePasswordArray[0];
        //            string password = UsernamePasswordArray[1];
                    
        //             List<User> result = _authenticationDirectory.validateuser(username ,password);
        //           // User obj=new _a
        //            //  string output = new AuthenticationRepository().validateuser(UserLogin );
        //            //var result = _authenticationDirectory.validateuser(UserLogin usersdetails);
        //            //string ObjUser = new 
        //            // UserMaster ObjUser = new ValidateUser().CheckUserCredentials(username, password);
        //            if (result != null)
        //            {
        //                var identity = new GenericIdentity(result[0].UserName);
        //                identity.AddClaim(new Claim("UserName", result[0].UserName));
        //                IPrincipal principal = new GenericPrincipal(identity, result[0].IdRole.Split(','));
        //                Thread.CurrentPrincipal = principal;
        //                //if (HttpContext.Current. != null)
        //                //{
        //                //    HttpContext.Current.User = principal;
        //                //}
        //                // return   base.SendAsync(request, cancellationToken);
        //                return null;
        //            }
        //            else
        //            {
        //                var response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
        //                var tsc = new TaskCompletionSource<HttpResponseMessage>();
        //                tsc.SetResult(response);
        //                return tsc.Task;
        //            }
        //        }
        //        else
        //        {
        //            var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
        //            var tsc = new TaskCompletionSource<HttpResponseMessage>();
        //            tsc.SetResult(response);
        //            return tsc.Task;
        //        }
        //    }
        //    catch
        //    {
        //        var response = new HttpResponseMessage(HttpStatusCode.Forbidden);
        //        var tsc = new TaskCompletionSource<HttpResponseMessage>();
        //        tsc.SetResult(response);
        //        return tsc.Task;
        //    }
        //}

        [HttpPost("SignIn")]
       
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
            }
        }


        [HttpPost("CreateUser")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        
        public ActionResult<string> CreateUsers(UserDetails user)
        {
            try
            {
               
                var userData = _adminDirectory.AddUsers(user);
                if (userData == null)
                {
                    var result = "Login Failed";// new List<string>();
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

        [HttpGet("GetUsers")]

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

        [HttpPut("UpdateUserdetails")]
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

        [HttpPost("GetDetailsbyUserId")]
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

        [HttpPost("GetDetailsbyUserName")]
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
