using MultipleChoiceTool.API.Extensions;
using MultipleChoiceTool.Infrastructure.Extensions;
using MultipleChoiceTool.Service.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMultipleChoiceToolInfrastructure();
builder.Services.AddMultipleChoiceToolService();
builder.Services.AddMultipleChoiceToolApi();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddSqliteDbInfrastructure(builder.Configuration, "MultipleChoiceToolDb");
}
else
{
    builder.Services.AddSqlServerDbInfrastructure(builder.Configuration, "MultipleChoiceToolDb");
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseDbInfrastructure();

app.Run();
