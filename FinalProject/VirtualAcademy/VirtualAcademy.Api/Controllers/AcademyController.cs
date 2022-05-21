using Microsoft.AspNetCore.Mvc;

namespace VirtualAcademy.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AcademyController : ControllerBase
    {
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllAcademies()
        {
            List<string> list = new List<string>();
            list.Add("WSEI");
            list.Add("AGH");
            return Ok(list);
        }
    }
}
