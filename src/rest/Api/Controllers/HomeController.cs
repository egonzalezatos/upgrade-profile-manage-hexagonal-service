using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Hello()
        {
            return Ok(await Task.Run(() => "Hello"));
        } 
    }
}