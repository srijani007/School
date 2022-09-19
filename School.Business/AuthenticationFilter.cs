//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Runtime.CompilerServices;
//using System.Security.Principal;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web.Mvc.Filters;

//namespace School.Business
//{

//    public class AuthenticationFilter : Attribute, IAuthenticationFilter
//    {

//        private readonly IAuthenticationDirectory _authenticationDirectory;

//        public void OnAuthentication(AuthenticationContext filterContext)
//        {
//            throw new NotImplementedException();
//        }

//        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
//        {
//            throw new NotImplementedException();
//        }

//        /// <summary>
//        /// read requested header and validated
//        /// </summary>
//        /// <param name="actionContext"></param>
//        //    public void OnAuthorization(HttpActionContext actionContext)
//        //    {
//        //        var identity = FetchFromHeader(actionContext);

//        //        if (identity != null)
//        //        {
//        //            // var securityService = actionContext.ControllerContext.Configuration.DependencyResolver.GetService(typeof(ILoginService)) as ILoginService;
//        //            if (_authenticationDirectory.validateuser.TokenAutentication())
//        //            {
//        //                CurrentThread.SetPrincipal(new GenericPrincipal(new GenericIdentity(identity), null), null, null);

//        //                // CurrentThread.SetPrincipal(new GenericPrincipal(new GenericIdentity(identity), null), null, null);
//        //            }
//        //            else
//        //            {
//        //                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
//        //                return;
//        //            }
//        //        }
//        //        else
//        //        {
//        //            actionContext.Response = new HttpResponseMessage(HttpStatusCode.BadRequest);
//        //            return;
//        //        }
//        //        base.OnAuthorization(actionContext);
//        //    }

//        //    /// <summary>
//        //    /// retrive header detail from the request 
//        //    /// </summary>
//        //    /// <param name="actionContext"></param>
//        //    /// <returns></returns>
//        //    private string FetchFromHeader(HttpActionContext actionContext)
//        //    {
//        //        string requestToken = null;

//        //        var authRequest = actionContext.Request.Headers.Authorization;
//        //        if (authRequest != null && !string.IsNullOrEmpty(authRequest.Scheme) && authRequest.Scheme == "Basic")
//        //            requestToken = authRequest.Parameter;

//        //        return requestToken;
//        //    }
//        //}
//    }
 
//}

