using School.Model.SchoolModel;

namespace School.Repository
{
    public interface IAdminRepository
    {
        List<User> FetchDetailsbyUserId(GetUserDetailsbyId detailsbyId);
       
        string InsertUsers(User details);
        string Updateusers(User user);
        List<User> FetchUsers();
        List<User> FetchDetailsbyUserName(GetUserDetailsbyName detailsbyname);
        List<User> Login(string username, string password);
    }
}