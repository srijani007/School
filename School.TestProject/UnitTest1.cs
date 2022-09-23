using Moq;
using Newtonsoft.Json;
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
            var adminD = new Mock<IAdminDirectory>();

            adminD.Setup(x => x.GetDetailsbyUserId(id))
           .Returns(lst);
            AdminController obj = new AdminController(adminD.Object);
            var result = obj.FetchUserContent(id);

            Assert.True(lst.Equals(result.Value));
        }

        [TestMethod]
        public void GetAllUsers_ReturnsallUsers()
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

           var adminD = new Mock<IAdminDirectory>();

            adminD.Setup(x => x.FetchUsers()).Returns(lst);
            AdminController obj = new AdminController(adminD.Object);
            var result = obj.GetAllUsers();

            Assert.True(lst.Equals(result.Value));

        }


        [TestMethod]
        public void AddUsers_ReturnsSuccessmessage()
        {
            var user = new UserDetails()
            {
                Id = 0,
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
            string TestResult = "Created user successfully!!";
            adminD.Setup(p => p.AddUsers(user)).Returns("Created user successfully!!");
            AdminController emp = new AdminController(adminD.Object);
            var result = emp.CreateUsers(user);
          
            Assert.AreEqual(TestResult, result.Value);
        }

        [TestMethod]
        public void FetchUserContentbyName_ByUsernmae_ReturnsUserDetails()
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

           
            var adminD = new Mock<IAdminDirectory>();

            adminD.Setup(x => x.GetDetailsbyUserName(name)).Returns(lst);
            AdminController obj = new AdminController(adminD.Object);
            var result = obj.FetchUserContentbyname(name);

            Assert.True(lst.Equals(result.Value));
        }

        [TestMethod]
        public void GetCourse_WithCourseId_ReturnsCoursedetails()
        {
            GetCourseDetailsbyId id = new GetCourseDetailsbyId();
            id.Id = 6;
            List<Course> lst = new List<Course>
            {new Course(){
               Title="Angular",
               Description = "Angular Basics",
               Subject ="L2",
               SubjectArea="Basics of Angular and its functionalities",
               GradeLevel=1
                }
            };

            var courseD = new Mock<ICourseDirectory>();

            courseD.Setup(x => x.GetDetailsbyCourseId(id))
           .Returns(lst);
            CourseController obj = new CourseController(courseD.Object);
            var result = obj.FetchCourseContent(id);

            Assert.True(lst.Equals(result.Value));
        }
       
        [TestMethod]
        public void GetAllCourses_ReturnsallCourses()
        {
            List<Course> lst = new List<Course>
            {new Course(){
               Title="Angular",Description = "Angular Basics",Subject ="L2",
                SubjectArea="Basics of Angular and its functionalities",GradeLevel=1
                },
            new Course(){
               Title="Java",Description = "About Java",Subject ="L1",
                SubjectArea="Basics of Java",GradeLevel=1
                },
            new Course(){
               Title="Angular-2",Description = "Basics of Angular part 2",Subject ="L2",
                SubjectArea="Basics of Angular-2",GradeLevel=2
                },
            new Course(){
               Title=".Net",Description = "About .net framework",Subject ="L1",
                SubjectArea="Framework details basics",GradeLevel=1
                },
            new Course(){
               Title="ASP .net core -2",Description = "about ASP .net core -2",Subject ="L2",
                SubjectArea="ASP .net core basics part 2",GradeLevel=2
                }
            };
            

            var courseD = new Mock<ICourseDirectory>();
            courseD.Setup(x => x.GetCourses()).Returns(lst);
            CourseController obj = new CourseController(courseD.Object);
            var result = obj.GetAllCourses();

            Assert.False(lst.Equals(result.Value));
        }

        [TestMethod]
        public void AddCourses_Returnsboolvalue()
        {
            var course = new CourseDetails()
            {
               Id = 0,
               Title="Docker",
               Description="About docker",
               Subject="L1",
               SubjectArea="Docker Basics",
               GradeLevel=1
            };
            var courseD = new Mock<ICourseDirectory>();
            bool TestResult = true;
            courseD.Setup(p => p.AddCourses(course)).Returns(true);
            CourseController coursedetails = new CourseController(courseD.Object);
            var result = coursedetails.Createcourses(course);
            
            Assert.AreEqual(TestResult, result.Value);
        }


        [TestMethod]
        public void AddEnrollmentes_Returnsboolvalue()
        {
            var enrollments = new EnrollmentDetails()
            {
                IdCourse = 2007,
                IdUser = 1007,
                Startdate = DateTime.Today,
                Enddate = DateTime.Today ,
                RoleId=2
            };
            var enrollmentD = new Mock<IEnrollmentDirectory>();
            bool TestResult = true;
            enrollmentD.Setup(p => p.AddEnrollment(enrollments)).Returns(true);
            EnrollmentController enroll = new EnrollmentController(enrollmentD.Object);
            var result = enroll.AddEnrollments(enrollments);

            Assert.AreEqual(TestResult, result.Value);
        }

        [TestMethod]
        public void GetAllEnrollments_ReturnsallEnrollments()
        {
            List<Enrollment> enrollLst = new List<Enrollment>
            {new Enrollment(){
               IdCourse=1007,IdUser = 2007,Startdate =DateTime.Today,
                Enddate=DateTime.MaxValue,RoleId=1
                }
            };
            var enrollmentD = new Mock<IEnrollmentDirectory>();

            enrollmentD.Setup(x => x.GetEnrollments()).Returns(enrollLst);
            EnrollmentController obj = new EnrollmentController(enrollmentD.Object);
            var result = obj.GetAllEnrollments();

            Assert.False(enrollLst.Equals(result.Value));
        }

        [TestMethod]
        public void GetEnrollments_WithUserId_ReturnsEnrollmentlist()
        {
            GetUserDetailsbyId userid = new GetUserDetailsbyId();
            userid.Id = 1008;
            List<Enrollment> enrolllst = new List<Enrollment>
            {new Enrollment(){
                IdCourse = 2007,
                IdUser = 1007,
                Startdate = DateTime.Today,
                Enddate = DateTime.Today ,
                RoleId=2 }
            };
            var enrollD = new Mock<IEnrollmentDirectory>();

            enrollD.Setup(x => x.GetEnrollmentsbyUserId(userid))
           .Returns(JsonConvert.SerializeObject(enrolllst));
            EnrollmentController obj = new EnrollmentController(enrollD.Object);
            var result = obj.GetEnrollmentsbyUserId(userid);

            Assert.False(enrolllst.Equals(result.Value));
        }

        [TestMethod]
        public void GetEnrollments_WithCourseId_ReturnsEnrollmentlist()
        {
            GetCourseDetailsbyId courseid = new GetCourseDetailsbyId();
            courseid.Id = 1008;
            List<Enrollment> enrolllst = new List<Enrollment>
            {new Enrollment(){
                IdCourse = 2007,
                IdUser = 1007,
                Startdate = DateTime.Today,
                Enddate = DateTime.Today ,
                RoleId=2 }
            };
            var enrollD = new Mock<IEnrollmentDirectory>();

            enrollD.Setup(x => x.GetEnrollmentsbyCourseId(courseid))
           .Returns(JsonConvert.SerializeObject(enrolllst));
            EnrollmentController obj = new EnrollmentController(enrollD.Object);
            var result = obj.GetEnrollmentsbyCourseId(courseid);

            Assert.False(enrolllst.Equals(result.Value));
        }
    }
}