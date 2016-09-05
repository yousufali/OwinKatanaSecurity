using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace OwinKatanaSecurity
{
    [Authorize]
    public class TestController : ApiController
    {
        public IEnumerable<ViewClaim> Get()
        {
            var principal = User as ClaimsPrincipal;
            return from c in principal.Claims
                   select new ViewClaim() { Type = c.Type, Value = c.Value };
        }
    }
    public class ViewClaim
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }
}