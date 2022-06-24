using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VirtualAcademy.Application.Features.Students.Commands.AddStudent;
using VirtualAcademy.Application.Features.Students.Commands.DeleteStudent;
using VirtualAcademy.Application.Features.Students.Commands.UpdateStudent;
using VirtualAcademy.Application.Features.Students.Queries.GetStudentById;

namespace VirtualAcademy.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get student by id
        /// </summary>S
        /// <param name="studentId">Id of student</param>
        /// <returns>Student info model</returns>
        [HttpGet("{studentId}")]
        [Authorize]
        public async Task<IActionResult> GetStudentById(Guid studentId)
        {
            var student = await _mediator.Send(new GetStudentByIdQuery() { Id = studentId });
            return Ok(student);
        }

        /// <summary>
        /// Add new student
        /// </summary>
        /// <param name="addStudentCommand">Student params</param>
        /// <returns>Guid of new added student</returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddStudent([FromBody] AddStudentCommand addStudentCommand)
        {
            var id = await _mediator.Send(addStudentCommand);
            return Ok(id);
        }

        /// <summary>
        /// Update student
        /// </summary>
        /// <param name="updateStudentCommand">student params</param>
        /// <returns>Guid of updated student</returns>
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateStudent([FromBody] UpdateStudentCommand updateStudentCommand)
        {
            var id = await _mediator.Send(updateStudentCommand);
            return Ok(id);
        }

        /// <summary>
        /// Delete student by Id
        /// </summary>
        /// <param name="deleteStudentCommand">Id of student to delete</param>
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteStudentById([FromBody] DeleteStudentCommand deleteStudentCommand)
        {
            await _mediator.Send(deleteStudentCommand);
            return Ok();
        }
    }
}
