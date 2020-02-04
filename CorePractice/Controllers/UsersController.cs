using CorePractice.BusinessLogic;
using CorePractice.Models;
using CorePractice.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CorePractice.Controllers
{
    public class UsersController : ApiController
    {
        // GET api/<controller>
        public List<User> Get()
        {
            IUserRepository userRepository = new EFUserRepository();
            var userBusinessLogic = new UserBusinessLogic(userRepository);
            var users = userBusinessLogic.List();
            return users;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}