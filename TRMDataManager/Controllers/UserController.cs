using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TRMDataManager.Library.DataAccess;
using TRMDataManager.Library.Models;

namespace TRMDataManager.Controllers
{
    [Authorize]
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        public List<UserEntity> GetById()
        {
            // Get user from token auth
            string userId = RequestContext.Principal.Identity.GetUserId();

            UserRepository userRepository = new UserRepository();

            List<UserEntity> user = userRepository.GetUserById(userId);

            return user;
        }
    }
}
