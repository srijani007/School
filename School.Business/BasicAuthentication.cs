//using Microsoft.AspNetCore.Http;
//using School.Model.SchoolModel;
//using School.Repository;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Security.Claims;
//using System.Security.Principal;
//using System.Text;



//namespace School.Business
//{
//    public class BasicAuthentication : Attribute
//    {

//        //private readonly IAuthenticationDirectory _authenticationDirectory;

//        //public BasicAuthentication(IAuthenticationDirectory authenticationDirectory)
//        //{
//        //    _authenticationDirectory = authenticationDirectory;
//        //}
//      //  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
//        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
//        {
//            try
//            {
//                var authenticationToken = request.Headers.GetValues("Authorization").FirstOrDefault();
//                if (authenticationToken != null)
//                {
//                    byte[] data = Convert.FromBase64String(authenticationToken);
//                    string decodedAuthenticationToken = Encoding.UTF8.GetString(data);
//                    string[] UsernamePasswordArray = decodedAuthenticationToken.Split(':');
//                    string username = UsernamePasswordArray[0];
//                    string password = UsernamePasswordArray[1];
//                   // List<User> result = _authenticationDirectory.validateuser(username, password);
//                    //  string output = new AuthenticationRepository().validateuser(UserLogin );
//                    //var result = _authenticationDirectory.validateuser(UserLogin usersdetails);
//                    //string ObjUser = new 
//                    // UserMaster ObjUser = new ValidateUser().CheckUserCredentials(username, password);
//                    // if (result != null)
//                    //{
//                    //    var identity = new GenericIdentity(result[0].UserName);
//                    //    identity.AddClaim(new Claim("UserName", result[0].UserName));
//                    //    IPrincipal principal = new GenericPrincipal(identity, result[0].IdRole.Split(','));
//                    //    Thread.CurrentPrincipal = principal;
//                        //if (HttpContext.Current != null)
//                        //{
//                        //    HttpContext.Current.User = principal;
//                        //}
//                        // return base.SendAsync(request, cancellationToken);
//                       return null;
//                    }
//                    else
//                    {
//                        var response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
//                        var tsc = new TaskCompletionSource<HttpResponseMessage>();
//                        tsc.SetResult(response);
//                        return tsc.Task;
//                    }
//                }
//                //else
//                //{
//                //    var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
//                //    var tsc = new TaskCompletionSource<HttpResponseMessage>();
//                //    tsc.SetResult(response);
//                //    return tsc.Task;
//                //}
            
//            catch
//            {
//                var response = new HttpResponseMessage(HttpStatusCode.Forbidden);
//                var tsc = new TaskCompletionSource<HttpResponseMessage>();
//                tsc.SetResult(response);
//                return tsc.Task;
//            }
//        }
//    }
//}

