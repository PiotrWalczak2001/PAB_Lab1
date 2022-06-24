using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VirtualAcademy.Application.Features.Subjects.Commands.CreateSubject;
using VirtualAcademy.Application.Features.Subjects.Commands.DeleteSubject;
using VirtualAcademy.Application.Features.Subjects.Commands.UpdateSubject;
using VirtualAcademy.Application.Features.Subjects.Queries.GetSubjectById;

namespace VirtualAcademy.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SubjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get subject by id
        /// </summary>
        /// <param name="subjectId">Id of subject</param>
        /// <returns>subject info model</returns>
        [HttpGet("{subjectId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSubjectById(Guid subjectId)
        {
            var subject = await _mediator.Send(new GetSubjectByIdQuery() { SubjectId = subjectId });
            return Ok(subject);
        }

        /// <summary>
        /// Create new subject
        /// </summary>
        /// <param name="createSubjectCommand">subject params</param>
        /// <returns>Guid of new created subject</returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateSubject([FromBody] CreateSubjectCommand createSubjectCommand)
        {
            var id = await _mediator.Send(createSubjectCommand);
            return Ok(id);
        }

        /// <summary>
        /// Update subject
        /// </summary>
        /// <param name="updateSubjectCommand">subject params</param>
        /// <returns>Guid of updated subject</returns>
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateSubject([FromBody] UpdateSubjectCommand updateSubjectCommand)
        {
            var id = await _mediator.Send(updateSubjectCommand);
            return Ok(id);
        }

        /// <summary>
        /// Delete subject by Id
        /// </summary>
        /// <param name="deleteSubjectCommand">Id of subject to delete</param>
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteSubjectById([FromBody] DeleteSubjectCommand deleteSubjectCommand)
        {
            await _mediator.Send(deleteSubjectCommand);
            return Ok();
        }
    }
}
