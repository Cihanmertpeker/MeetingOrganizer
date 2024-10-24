using MeetingOrganizer.BusinessLayer.Abstract;
using MeetingOrganizer.BusinessLayer.Concrete;
using MeetingOrganizer.DataAccessLayer.Abstract;
using MeetingOrganizer.DataAccessLayer.Concrete;
using MeetingOrganizer.DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));

builder.Services.AddDbContext<MeetingOrganizerContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
