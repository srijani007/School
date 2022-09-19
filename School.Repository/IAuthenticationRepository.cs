using School.Model.SchoolModel;

namespace School.Repository
{
    public interface IAuthenticationRepository
    {
        SchoolContext _schoolContext { get; set; }

        List<User> validateuser(string username, string password);

        // List<User> validateuser(UserLogin usersdetails);
    }
}