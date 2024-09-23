using DataAccess.MyDbContext; // Referencia a tu DbContext.
using FluentValidation; // Para validadores.
using Microsoft.EntityFrameworkCore; // Entity Framework Core.
using Services.Commands.Ideas; // Comandos de Ideas.
using Services.Validations; // Validadores.
using MediatR;
using Services.Commands.Votes; 
using Domain.Interfaces; 
using Infrastructure.Repositories;
using ExamenPR.Hubs;
using ExamenPR.Middlewares;
using FluentValidation.AspNetCore; 

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        policy => policy
            .WithOrigins("http://localhost:5173") 
            .AllowAnyMethod() 
            .AllowAnyHeader() 
            .AllowCredentials()); 
});


builder.Services.AddControllers();


builder.Services.AddDbContext<MyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateIdeaCommand).Assembly));


builder.Services.AddValidatorsFromAssemblyContaining<CreateIdeaCommandValidator>();

builder.Services.AddSignalR();

builder.Services.AddFluentValidation();
// Configurar Swagger/OpenAPI.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IIdeaRepository, IdeaRepository>();
builder.Services.AddScoped<IVoteRepository, VoteRepository>();

var app = builder.Build();

app.UseMiddleware<RequestLoggingMiddleware>();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("AllowSpecificOrigin");

app.MapHub<IdeasHub>("/ideashub");

app.MapControllers();

app.Run();
