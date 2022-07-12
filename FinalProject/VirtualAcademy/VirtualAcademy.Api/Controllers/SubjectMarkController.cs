using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VirtualAcademy.Application.Features.SubjectMarks.Commands.AddMark;
using VirtualAcademy.Application.Features.SubjectMarks.Commands.DeleteMark;
using VirtualAcademy.Application.Features.SubjectMarks.Commands.UpdateMark;

namespace VirtualAcademy.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectMarkController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SubjectMarkController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Add mark to student
        /// </summary>
        /// <param name="addMarkCommand">Mark params</param>
        [HttpPost]
        [Authorize(Roles = "Lecturer, Admin")]
        public async Task<IActionResult> CreateMark([FromBody] AddMarkCommand addMarkCommand)
        {
            await _mediator.Send(addMarkCommand);
            return Ok();
        }

        /// <summary>
        /// Update student mark
        /// </summary>
        /// <param name="updateMarkCommand">Mark params</param>
        [HttpPut]
        [Authorize(Roles = "Lecturer, Admin")]
        public async Task<IActionResult> UpdateMark([FromBody] UpdateMarkCommand updateMarkCommand)
        {
            await _mediator.Send(updateMarkCommand);
            return Ok();
        }

        /// <summary>
        /// Delete mark by Id
        /// </summary>
        /// <param name="deleteMarkCommand">Id of mark to delete</param>
        [HttpDelete]
        [Authorize(Roles = "Lecturer, Admin")]
        public async Task<IActionResult> DeleteMarkById([FromBody] DeleteMarkCommand deleteMarkCommand)
        {
            await _mediator.Send(deleteMarkCommand);
            return Ok();
        }
    }
}
