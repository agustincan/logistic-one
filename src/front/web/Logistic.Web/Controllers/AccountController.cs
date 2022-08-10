using Logistic.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace Logistic.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly string _authenticationUrl;

        public AccountController(IConfiguration configuration)
        {
            _authenticationUrl = configuration.GetValue<string>("AuthenticationUrl");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return Redirect(_authenticationUrl + $"?ReturnBaseUrl={this.Request.Scheme}://{this.Request.Host}/");
        }

        [HttpGet]
        public async Task<IActionResult> Connect(string access_token)
        {
            var tokenArr = access_token.Split('.');
            
            // to validate from64 payload - get from stackoverflow - better is webencoders
            //var tokenPayload = tokenArr[1].Replace('_', '/').Replace('-', '+');
            //switch (tokenPayload.Length % 4)
            //{
            //    case 2: tokenPayload += "=="; break;
            //    case 3: tokenPayload += "="; break;
            //}


            //System.IdentityModel.Tokens.Base64UrlEncoder.DecodeBytes(someBase64Url);
            var tokenPayload = WebEncoders.Base64UrlDecode(tokenArr[1]);
            var payloadWebEncoder = Encoding.UTF8.GetString(tokenPayload);
            //var payload = Convert.FromBase64String(tokenPayload);
            //var user = JsonSerializer.Deserialize<AccessTokenUserInformation>(payload);
            var user = JsonSerializer.Deserialize<AccessTokenUserInformation>(payloadWebEncoder);
            //var user = JsonSerializer.Deserialize<AccessTokenUserInformation>(Encoding.UTF8.GetBytes(token[1]));

            //var userId = int.Parse(access_token.Claims.First(x => x.Type == "id").Value);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user!.nameid),
                new Claim(ClaimTypes.Name, user.unique_name),
                new Claim(ClaimTypes.Email, user.email),
                new Claim("access_token", access_token)
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                IssuedUtc = DateTime.UtcNow.AddHours(10)
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            return Redirect("~/");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("~/");
        }
    }
}
