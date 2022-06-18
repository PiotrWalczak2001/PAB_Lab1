using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VirtualAcademy.Application.Features.Academies.Commands.CreateAcademy;
using VirtualAcademy.Application.Features.Academies.Commands.DeleteAcademy;
using VirtualAcademy.Application.Features.Academies.Commands.UpdateAcademy;
using VirtualAcademy.Application.Features.Academies.Queries.GetAcademyById;
using VirtualAcademy.Application.Features.Academies.Queries.GetAllAcademyList;

namespace VirtualAcademy.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AcademyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AcademyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all academies
        /// </summary>
        /// <returns>List of all academies</returns>
        [HttpGet("all")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAcademies()
        {
            var academies = await _mediator.Send(new GetAllAcademyListQuery());
            return Ok(academies);
        }

        /// <summary>
        /// Get academy by id
        /// </summary>
        /// <param name="academyId">Id of academy</param>
        /// <returns>Academy info model</returns>
        [HttpGet("{academyId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAcademyById(Guid academyId)
        {
            var academy = await _mediator.Send(new GetAcademyByIdQuery() { AcademyId = academyId });
            return Ok(academy);
        }

        /// <summary>
        /// Create new academy
        /// </summary>
        /// <param name="createAcademyCommand">Academy params</param>
        /// <returns>Guid of new created academy</returns>
        [HttpPost]
        [AllowAnonymous] // for tests
        public async Task<IActionResult> CreateAcademy([FromBody] CreateAcademyCommand createAcademyCommand)
        {
            var id = await _mediator.Send(createAcademyCommand);
            return Ok(id);
        }

        /// <summary>
        /// Update academy
        /// </summary>
        /// <param name="updateAcademyCommand">Academy params</param>
        /// <returns>Guid of updated academy</returns>
        [HttpPut]
        [AllowAnonymous] // for tests
        public async Task<IActionResult> UpdateAcademy([FromBody] UpdateAcademyCommand updateAcademyCommand)
        {
            await _mediator.Send(updateAcademyCommand);
            return Ok();
        }

        /// <summary>
        /// Delete academy by Id
        /// </summary>
        /// <param name="deleteAcademyCommand">Id of academy to delete</param>
        [HttpDelete]
        [AllowAnonymous] // for tests
        public async Task<IActionResult> DeleteAcademyById([FromBody] DeleteAcademyCommand deleteAcademyCommand)
        {
            await _mediator.Send(deleteAcademyCommand);
            return Ok();
        }
    }
}
