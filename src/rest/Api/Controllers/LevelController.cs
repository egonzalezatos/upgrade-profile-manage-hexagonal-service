using System.Threading.Tasks;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LevelController : ControllerBase
    {
        private readonly ILevelService _levelService;

        public LevelController(ILevelService levelService)
        {
            _levelService = levelService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _levelService.GetAll());
        }
        
        [HttpGet("user/{userId}/position/{positionId}")]
        public async Task<IActionResult> Get(int userId, int positionId)
        {
            return Ok(await _levelService.GetByUserIdPositionId(userId, positionId));
        }
    }
}