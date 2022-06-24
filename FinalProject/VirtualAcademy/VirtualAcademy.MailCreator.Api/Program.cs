var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/createMail", (string firstName, string lastName) => firstName + "." + lastName + "@virtualacademy.edu.com").WithName("GetNewMailAccount");

app.Run();