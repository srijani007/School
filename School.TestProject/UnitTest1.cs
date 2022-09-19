using Moq;
using NUnit.Framework;
using School.Business;
using School.Model.SchoolModel;
using School.Repository;
using UserEnrollment.Controllers;
using Assert = NUnit.Framework.Assert;

namespace School.TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetUser_WithUserId_ReturnsUserlist()
        {
            GetUserDetailsbyId id = new GetUserDetailsbyId();
            id.Id = 1008;
            List<User> lst = new List<User>
            {new User(){
                UserName = "Jack",
                Password = "123",
                FirstName = "Jack",
                LastName = "son",
                Email = "son@gmail.com",
                GradeLevel = 2,
                Address = "#345 2nd cross,1st building",
                StateCode = "AP",
                Country = "India",
                Zipcode = "567890",
                PhoneNumber = "87654321098",
                IdRole = "Student" }
            };
            
            var authD = new Mock<IAuthenticationDirectory>();
            var adminD = new Mock<IAdminDirectory>();

            adminD.Setup(x => x.GetDetailsbyUserId(id))
           .Returns(lst);
            AdminController obj = new AdminController(adminD.Object, authD.Object);
            var result = obj.FetchUserContent(id);

            Assert.True(lst.Equals(result.Value));            
        }

        [TestMethod]
        public void GetAllUsers()
        {
            List<User> lst = new List<User>() {
              new User() {
               UserName="Mike",Password="123456",FirstName="Mike",
               LastName="Rosewell",Email="Mike@gmail.com",GradeLevel=1,Address="#231 first cross",StateCode="KA",Country="India",
               Zipcode="567654",PhoneNumber="9876543210",IdRole="Admin"},
           new User(){UserName="Jack",Password="123",FirstName="Jack",
               LastName="son",Email="son@gmail.com",GradeLevel=2,Address="#345 2nd cross,1st building",               StateCode="AP",Country="India",
               Zipcode="567890",PhoneNumber="87654321098",IdRole="Student"
           },
           new User(){UserName="John",Password="123",FirstName="John",
               LastName="Sena",Email="Sena@gmail.com",GradeLevel=1,Address="Sri maruthi nilaya bellary road 2nd cross challakere Chitradurga District",StateCode="KA",Country="India"
               ,Zipcode="6577522",PhoneNumber="7896543219",IdRole="Teacher"}};

            var authD = new Mock<IAuthenticationDirectory>();

            var adminD = new Mock<IAdminDirectory>();

            adminD.Setup(x => x.FetchUsers()).Returns(lst);
            AdminController obj = new AdminController(adminD.Object,authD.Object);
            var result = obj.GetAllUsers();          
           
            Assert.True(lst.Equals(result.Value));

        }


        [TestMethod]
        public void AddingUsers()
        {
            var user = new UserDetails()
            {
                Id=0,
                UserName = "Surya",
                Password = "123",
                FirstName = "Surya",
                LastName = "Jyothika",
                Email = "surya@gmail.com",
                GradeLevel = 1,
                Address = "#234 flat 1",
                StateCode = "TN",
                Country = "India",
                Zipcode = "577566",
                PhoneNumber = "9876543210",
                IdRole = "Admin"
            };
            var adminD = new Mock<IAdminDirectory>();

            var authD = new Mock<IAuthenticationDirectory>();
            string TestResult = "Signed up successfully!!";
            adminD.Setup(p => p.AddUsers(user)).Returns("Signed up successfully!!");
            AdminController emp = new AdminController(adminD.Object, authD.Object);
            var result = emp.CreateUsers(user);
            //result.GetType().Should().Be(typeof(OkObjectResult));    
            //(result as OkObjectResult).StatusCode.Should().Be(200); 

            //Assert.IsNotNull(result.Value);
            Assert.AreEqual(TestResult,result.Value);
        }

        [TestMethod]
        public void FetchUserContentbyName()
        {
            GetUserDetailsbyName name = new GetUserDetailsbyName();
            name.userName = "Jack";
            List<User> lst = new List<User>
            {new User(){
                UserName = "Jack",
                Password = "123",
                FirstName = "Jack",
                LastName = "son",
                Email = "son@gmail.com",
                GradeLevel = 2,
                Address = "#345 2nd cross,1st building",
                StateCode = "AP",
                Country = "India",
                Zipcode = "567890",
                PhoneNumber = "87654321098",
                IdRole = "Student" }
            };

            var authD = new Mock<IAuthenticationDirectory>();
            var adminD = new Mock<IAdminDirectory>();

            adminD.Setup(x => x.GetDetailsbyUserName(name)).Returns(lst);
            AdminController obj = new AdminController(adminD.Object, authD.Object);
            var result = obj.FetchUserContentbyname(name);

            Assert.True(lst.Equals(result.Value));
        }


    }
}