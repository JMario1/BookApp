using Microsoft.AspNetCore.Mvc;

namespace BookApp.Controllers
{[
    
    ApiController]
    [Route("[controller]")]
    public class IndexController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;

        public IndexController(ILogger<BookController> logger){
            _logger = logger;
        
        }

        public ActionResult Index(){
            var message = new {
                Login = "api/login",
                Register = "api/register",
                Books = "api/book",
                Author = "api/author"
            };

           return  Ok(message);
        }
    }
}