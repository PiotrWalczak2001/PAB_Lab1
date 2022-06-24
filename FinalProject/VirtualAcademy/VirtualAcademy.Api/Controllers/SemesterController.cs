using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VirtualAcademy.Application.Features.Semesters.Commands.EndSemester;
using VirtualAcademy.Application.Features.Semesters.Commands.StartSemester;
using VirtualAcademy.Application.Features.Semesters.Queries.GetActiveSemesterByStudentId;

namespace VirtualAcademy.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SemesterController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SemesterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get active semester by student id
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns>Semester info model</returns>
        [HttpGet("active/{studentId}")]
        [Authorize]
        public async Task<IActionResult> GetActiveSemesterByStudentId(Guid studentId)
        {
            var semester = await _mediator.Send(new GetActiveSemesterByStudentIdQuery() { StudentId = studentId });
            return Ok(semester);
        }

        /// <summary>
        /// Start new semester
        /// </summary>
        /// <param name="startSemesterCommand">Semester params</param>
        /// <returns>Guid of started semester</returns>
        [HttpPost]
        [Route("start")]
        [Authorize]
        public async Task<IActionResult> StartSemester([FromBody] StartSemesterCommand startSemesterCommand)
        {
            var id = await _mediator.Send(startSemesterCommand);
            return Ok(id);
        }

        /// <summary>
        /// End semester by Id
        /// </summary>
        /// <param name="endSemesterCommand">Id of semester to end</param>
        [HttpPost]
        [Route("end")]
        [Authorize]
        public async Task<IActionResult> EndSemesterById([FromBody] EndSemesterCommand endSemesterCommand)
        {
            await _mediator.Send(endSemesterCommand);
            return Ok();
        }
    }
}
