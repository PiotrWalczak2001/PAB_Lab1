using MediatR;
using VirtualAcademy.Application.Features.Students.Models;

namespace VirtualAcademy.Application.Features.Students.Queries.GetStudentById
{
    public class GetStudentByIdQuery : IRequest<StudentInfoModel>
    {
        public Guid Id { get; set; }
    }
}
