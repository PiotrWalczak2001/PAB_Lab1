using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VirtualAcademy.Application.Features.Employees.Commands.AddEmployee;
using VirtualAcademy.Application.Features.Employees.Commands.DeleteEmployee;
using VirtualAcademy.Application.Features.Employees.Commands.UpdateEmployee;
using VirtualAcademy.Application.Features.Employees.Queries.GetAllEmployeesByAcademyId;
using VirtualAcademy.Application.Features.Employees.Queries.GetEmployeeById;

namespace VirtualAcademy.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all employees by academy id
        /// </summary>
        /// <param name="academyId"></param>
        /// <returns>List of employees with specific academy id</returns>
        [HttpGet("all/{academyId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllEmployeesByAcademyId(Guid academyId)
        {
            var employees = await _mediator.Send(new GetAllEmployeesByAcademyIdQuery() { AcademyId = academyId });
            return Ok(employees);
        }

        /// <summary>
        /// Get employee by id
        /// </summary>
        /// <param name="employeeId">Id of employee</param>
        /// <returns>Employee info model</returns>
        [HttpGet("{employeeId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetEmployeeById(Guid employeeId)
        {
            var employee = await _mediator.Send(new GetEmployeeByIdQuery() { Id = employeeId });
            return Ok(employee);
        }

        /// <summary>
        /// Add new employee
        /// </summary>
        /// <param name="addEmployeeCommand">Employee params</param>
        /// <returns>Guid of new created employee</returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddEmployee([FromBody] AddEmployeeCommand addEmployeeCommand)
        {
            var id = await _mediator.Send(addEmployeeCommand);
            return Ok(id);
        }

        /// <summary>
        /// Update employee
        /// </summary>
        /// <param name="updateEmployeeCommand">Employee params</param>
        /// <returns>Guid of updated employee</returns>
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeCommand updateEmployeeCommand)
        {
            var id = await _mediator.Send(updateEmployeeCommand);
            return Ok(id);
        }

        /// <summary>
        /// Delete employee by Id
        /// </summary>
        /// <param name="deleteEmployeeCommand">Id of employee to delete</param>
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteEmployeeById([FromBody] DeleteEmployeeCommand deleteEmployeeCommand)
        {
            await _mediator.Send(deleteEmployeeCommand);
            return Ok();
        }
    }
}
