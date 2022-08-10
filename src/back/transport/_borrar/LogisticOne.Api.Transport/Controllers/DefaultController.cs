using Microsoft.AspNetCore.Mvc;

namespace LogisticOne.Api.Transport.Controllers
{
    [ApiController]
    [Route("/")]
    public class DefaultController : Controller
    {
        public string Index()
        {
            return $"Running...";
        }
    }
}
