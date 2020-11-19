using Microsoft.IdentityModel.Tokens;
using Owin;
using System.Text;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security;
using System.Web.Configuration;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(TesteSoftDesign.Authentication.Startup))]

namespace TesteSoftDesign.Authentication
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active,
                    TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "SoftIssuer",
                        ValidAudience = "SoftAudience",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("JwtKeySecret00181048465628"))
                    }
                });
        }
    }
}