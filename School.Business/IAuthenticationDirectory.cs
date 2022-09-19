using School.Model.SchoolModel;

namespace School.Business
{
    public interface IAuthenticationDirectory
    {
        SchoolContext _schoolContext { get; set; }

        string BuildToken(string key, string issuer, IEnumerable<string> audience, string userName, string userrole);
        List<User> validateuser(string username, string password);
        // List<User> validateuser(UserLogin usersdetails);
    }
}