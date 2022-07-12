using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VirtualAcademy.Application.Features.Courses.Commands.CreateCourse;
using VirtualAcademy.Application.Features.Courses.Commands.DeleteCourse;
using VirtualAcademy.Application.Features.Courses.Commands.UpdateCourse;
using VirtualAcademy.Application.Features.Courses.Queries.GetCourseById;
using VirtualAcademy.Application.Features.Courses.Queries.GetCoursesByAcademyId;

namespace VirtualAcademy.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all courses by academy id
        /// </summary>
        /// <param name="academyId"></param>
        /// <returns>List of courses with specific academy id</returns>
        [HttpGet("all/{academyId}")]
        [Authorize(Roles = "User, Student, Lecturer, Admin")]
        public async Task<IActionResult> GetAllCoursesByAcademyId(Guid academyId)
        {
            var courses = await _mediator.Send(new GetCoursesByAcademyIdQuery() {AcademyId = academyId});
            return Ok(courses);
        }

        /// <summary>
        /// Get course by id
        /// </summary>
        /// <param name="courseId">Id of course</param>
        /// <returns>Course info model</returns>
        [HttpGet("{courseId}")]
        [Authorize(Roles = "User, Student, Lecturer, Admin")]
        public async Task<IActionResult> GetCourseById(Guid courseId)
        {
            var course = await _mediator.Send(new GetCourseByIdQuery() { CourseId = courseId });
            return Ok(course);
        }

        /// <summary>
        /// Create new course
        /// </summary>
        /// <param name="createCourseCommand">Course params</param>
        /// <returns>Guid of new created course</returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCourseCommand createCourseCommand)
        {
            var id = await _mediator.Send(createCourseCommand);
            return Ok(id);
        }

        /// <summary>
        /// Update course
        /// </summary>
        /// <param name="updateCourseCommand">Course params</param>
        /// <returns>Guid of updated course</returns>
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCourse([FromBody] UpdateCourseCommand updateCourseCommand)
        {
            var id = await _mediator.Send(updateCourseCommand);
            return Ok(id);
        }

        /// <summary>
        /// Delete course by Id
        /// </summary>
        /// <param name="deleteCourseCommand">Id of course to delete</param>
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCourseById([FromBody] DeleteCourseCommand deleteCourseCommand)
        {
            await _mediator.Send(deleteCourseCommand);
            return Ok();
        }
    }
}
