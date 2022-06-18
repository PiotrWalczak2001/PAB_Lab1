using MediatR;
using VirtualAcademy.Application.Features.Courses.Models;

namespace VirtualAcademy.Application.Features.Courses.Queries.GetCoursesByAcademyId
{
    public class GetCoursesByAcademyIdQuery : IRequest<IEnumerable<CourseListModel>>
    {
        public Guid AcademyId { get; set; }
    }
}
