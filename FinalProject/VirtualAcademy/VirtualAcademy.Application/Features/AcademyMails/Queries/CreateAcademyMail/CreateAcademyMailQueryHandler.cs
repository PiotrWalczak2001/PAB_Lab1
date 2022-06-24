using MediatR;

namespace VirtualAcademy.Application.Features.AcademyMails.Queries.CreateAcademyMail
{
    public class CreateAcademyMailQueryHandler : IRequestHandler<CreateAcademyMailQuery, string>
    {
        public async Task<string> Handle(CreateAcademyMailQuery request, CancellationToken cancellationToken)
        {
            using var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7058/createMail/")
            };
            var response = await client.GetAsync($"?firstName={request.FirstName}&lastName={request.LastName}");
            return await response.Content.ReadAsStringAsync();
        }
    }
}
