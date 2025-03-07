using BusinessLayer.IServices;
using BusinessLayer.Services;
using Data_Layer.DbContextF;
using Data_Layer.Interface;
using Data_Layer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;



var builder = WebApplication.CreateBuilder(args);

// Add EF Core In-Memory Database
builder.Services.AddDbContext<NotesDbContext>(options =>
    options.UseInMemoryDatabase("NotesDb"));

// Register Dependencies
builder.Services.AddScoped<INoteRepository, NoteRepository>();
builder.Services.AddScoped<INoteService, NoteService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// Apply CORS before Authorization
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();
app.Run();