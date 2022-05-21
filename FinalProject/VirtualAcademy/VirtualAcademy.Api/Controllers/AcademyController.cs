using Microsoft.AspNetCore.Mvc;

namespace VirtualAcademy.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AcademyController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllAcademies()
        {
            return Ok("Academies");
        }
    }
}
