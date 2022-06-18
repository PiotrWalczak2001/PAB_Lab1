using MediatR;
using VirtualAcademy.Application.Features.Courses.Models;

namespace VirtualAcademy.Application.Features.Courses.Queries.GetCourseById
{
    public class GetCourseByIdQuery : IRequest<CourseInfoModel>
    {
        public Guid CourseId { get; set; }
    }
}
