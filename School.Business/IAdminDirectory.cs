using School.Model.SchoolModel;

namespace School.Business
{
    public interface IAdminDirectory
    {
        SchoolContext _schoolContext { get; set; }

        string AddUsers(UserDetails details);
        List<User> GetDetailsbyUserId(GetUserDetailsbyId detailsbyId);
        
        string PutUsers(UserDetails user);
        List<User> FetchUsers();
        List<User> GetDetailsbyUserName(GetUserDetailsbyName detailsbyname);
        List<User> UserLogin(string username, string password);
    }
}