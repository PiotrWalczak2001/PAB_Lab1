using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VirtualAcademy.Application.Features.Lecturers.Queries.GetAllLecturersByAcademyId;
using VirtualAcademy.Application.Features.Lecturers.Queries.GetLecturerById;

namespace VirtualAcademy.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LecturerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LecturerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all lecturers by academy id
        /// </summary>
        /// <param name="academyId"></param>
        /// <returns>List of lecturers with specific academy id</returns>
        [HttpGet("all/{academyId}")]
        [Authorize(Roles = "User, Student, Lecturer, Admin")]
        public async Task<IActionResult> GetAllLecturersByAcademyId(Guid academyId)
        {
            var lecturers = await _mediator.Send(new GetAllLecturersByAcademyIdQuery() { AcademyId = academyId });
            return Ok(lecturers);
        }

        /// <summary>
        /// Get lecturer by id
        /// </summary>
        /// <param name="lecturerId">Id of lecturer</param>
        /// <returns>Lecturer info model</returns>
        [HttpGet("{lecturerId}")]
        [Authorize(Roles = "User, Student, Lecturer, Admin")]
        public async Task<IActionResult> GetLecturerById(Guid lecturerId)
        {
            var lecturer = await _mediator.Send(new GetLecturerByIdQuery() { Id = lecturerId });
            return Ok(lecturer);
        }
    }
}
