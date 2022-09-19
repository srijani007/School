using Microsoft.AspNetCore.Mvc;
using School.Business;
using School.Model.SchoolModel;

namespace UserEnrollment.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationDirectory _authenticationDirectory;
        private readonly IConfiguration _configuration;
        //  private readonly IAuthorServices _authorServices;
        public AuthenticationController(IConfiguration configuration, IAuthenticationDirectory authenticationDirectory)//, IAuthorServices authorServices)
        {
            this._configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _authenticationDirectory = authenticationDirectory;//?? throw new ArgumentNullException(nameof(authenticationServices));
                                                             //  _authorServices = authorServices;
        }

        private class RequestedUserInfo
        {
            public int UserId { get; set; }
            public string UserName { get; set; }
            public string UserRole { get; set; }
            public string Email { get; set; }
            public string UserPass { get; set; }
            public RequestedUserInfo(int userId, string userName, string userrole, string email, string userpass)
            {
                UserId = userId;
                UserName = userName;
                UserRole = userrole;
                Email = email;
                UserPass = userpass;
            }
        }

        [HttpPost("SignIn")]
        public ActionResult<string> Validate(UserLogin usercreds)
        {
            try
            {
                var userdata = ValidateUserCrendentials(usercreds);

                if (userdata != null)
                {
                    var Token = _authenticationDirectory.BuildToken(_configuration["Jwt:Key"],
                                                    _configuration["Jwt:Issuer"],
                                                    new[]
                                                    {
                                                    _configuration["Jwt:Audience"]
                                                    },
                                                    userdata.UserName,
                                                    userdata.UserRole
                                                    );
                    return Ok(new
                    {
                        Token = Token,
                        IsAuthenticated = true,
                    });
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch
            {
                return Unauthorized();
            }
        }

        private RequestedUserInfo ValidateUserCrendentials(UserLogin userLogin)
        {
            try
            {
                List<User> list = _authenticationDirectory.validateuser(userLogin.UserName,userLogin.Password);
                foreach (var item in list)
                {
                    //Userid = item.User_Id
                    return new RequestedUserInfo(item.Id, item.UserName, item.IdRole, item.Email, item.Password);

                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
