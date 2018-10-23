using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;


namespace FI.PoC.LogicAppsConnector.Controllers
{
    public class UserController : ApiController
    {
        // POST: api/User
        // Code needs to written - AAD
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }

        // Notify: api/User/5
        [HttpPost]
        [Route("api/notify")]
        public void Notify()
        {
            
        }
    }
}
