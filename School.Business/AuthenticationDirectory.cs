using Microsoft.IdentityModel.Tokens;
using School.Model.SchoolModel;
using School.Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace School.Business
{
    public class AuthenticationDirectory : IAuthenticationDirectory
    {
        public SchoolContext _schoolContext { get; set; }

        private readonly IAuthenticationRepository _authenticationRepoistory;
        public AuthenticationDirectory(SchoolContext schoolContext, IAuthenticationRepository authenticationRepository)
        {
            _schoolContext = schoolContext;
            _authenticationRepoistory = authenticationRepository;
        }
        /// <summary>
        /// Validating the username and password from repository
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>success message</returns>
        public List<User> validateuser(string username , string password)
        {
            return _authenticationRepoistory.validateuser(username, password);

        }

        private TimeSpan ExpiryDuration = new TimeSpan(20, 30, 0);
        public string BuildToken(string key, string issuer, IEnumerable<string> audience, string userName, string userrole)
        {
            var claims = new List<Claim>
        {
            new Claim("UserName", userName),
            new Claim("IdRole",userrole)


        };

            claims.AddRange(audience.Select(aud => new Claim(JwtRegisteredClaimNames.Aud, aud)));

            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256Signature);
            var tokendescriptor = new JwtSecurityToken(issuer, issuer, claims,
                expires: DateTime.Now.Add(ExpiryDuration), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(tokendescriptor);
        }

    }
}
