using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using Owin;

namespace OwinKatanaSecurity
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var configuration = new HttpConfiguration();
            configuration.Routes.MapHttpRoute("default", "api/{controller}");

            appBuilder.UseBasicAuthentication("MyApp", ValidateUser);
            appBuilder.UseWebApi(configuration);
        }

        private Task<IEnumerable<Claim>> ValidateUser(string username, string password)
        {
            if (username == password)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, username),
                    new Claim(ClaimTypes.Country , "USA")
                };
                return Task.FromResult<IEnumerable<Claim>>(claims);
            }
            return null;
        }
    }
}