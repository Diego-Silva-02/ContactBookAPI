using Microsoft.AspNetCore.Mvc;

namespace LearningAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetDateHour()
        {
            var obj = new 
            {
                Date = DateTime.Now.ToLongDateString(),
                Hour = DateTime.Now.ToShortTimeString()
            };

            return Ok(obj);
        }

        [HttpGet("Introduce/{name}")]
        public IActionResult Introduce(string name)
        {
            string msg = $"Hi {name}, welcome :)";
            return Ok(new {msg});
        }

    }
}