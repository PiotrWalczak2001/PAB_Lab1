using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VirtualAcademy.Application.Features.Courses.Commands.DeleteCourse;
using VirtualAcademy.Application.Features.Departments.Commands.CreateDepartment;
using VirtualAcademy.Application.Features.Departments.Commands.DeleteDepartment;
using VirtualAcademy.Application.Features.Departments.Commands.UpdateDepartment;
using VirtualAcademy.Application.Features.Departments.Queries.GetDepartmentById;
using VirtualAcademy.Application.Features.Departments.Queries.GetDepartmentsByAcademyId;

namespace VirtualAcademy.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all departments by academy id
        /// </summary>
        /// <param name="academyId"></param>
        /// <returns>List of departments with specific academy id</returns>
        [HttpGet("all/{academyId}")]
        [Authorize(Roles = "Student, Lecturer, Admin")]
        public async Task<IActionResult> GetAllDepartmentsByAcademyId(Guid academyId)
        {
            var departments = await _mediator.Send(new GetDepartmentsByAcademyIdQuery() { AcademyId = academyId });
            return Ok(departments);
        }

        /// <summary>
        /// Get department by id
        /// </summary>
        /// <param name="departmentId">Id of department</param>
        /// <returns>department info model</returns>
        [HttpGet("{departmentId}")]
        [Authorize(Roles = "Student, Lecturer, Admin")]
        public async Task<IActionResult> GetDepartmentById(Guid departmentId)
        {
            var department = await _mediator.Send(new GetDepartmentByIdQuery() { Id = departmentId });
            return Ok(department);
        }

        /// <summary>
        /// Create new department
        /// </summary>
        /// <param name="createDepartmentCommand">Department params</param>
        /// <returns>Guid of new created department</returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentCommand createDepartmentCommand)
        {
            var id = await _mediator.Send(createDepartmentCommand);
            return Ok(id);
        }

        /// <summary>
        /// Update department
        /// </summary>
        /// <param name="updateDepartmentCommand">department params</param>
        /// <returns>Guid of updated department</returns>
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateDepartment([FromBody] UpdateDepartmentCommand updateDepartmentCommand)
        {
            var id = await _mediator.Send(updateDepartmentCommand);
            return Ok(id);
        }

        /// <summary>
        /// Delete department by Id
        /// </summary>
        /// <param name="deleteDepartmentCommand">Id of department to delete</param>
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteDepartmentById([FromBody] DeleteDepartmentCommand deleteDepartmentCommand)
        {
            await _mediator.Send(deleteDepartmentCommand);
            return Ok();
        }
    }
}
