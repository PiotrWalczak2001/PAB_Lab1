using MediatR;

namespace VirtualAcademy.Application.Features.AcademyMails.Queries.CreateAcademyMail
{
    public class CreateAcademyMailQuery : IRequest<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
