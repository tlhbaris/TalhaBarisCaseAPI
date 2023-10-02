using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using TalhaBaris.Cache;
using TalhaBaris.Core.Repositories;
using TalhaBaris.Core.Services;
using TalhaBaris.Repository;
using TalhaBaris.Repository.Repositories;
using TalhaBaris.Service.Mapping;
using TalhaBaris.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IDoctorRepository>(sp =>
{
    var appDbContext = sp.GetRequiredService<AppDbContext>();
    var doctorRepository = new DoctorRepository(appDbContext);
    var redisService = sp.GetRequiredService<RedisService>();
    return new DoctorRepositoryWithCacheDecarotar(doctorRepository, redisService);

});
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IMailService, MailService>();
builder.Services.AddSingleton<RedisService>(sp=>
{
    return new RedisService(builder.Configuration["CacheOptions:Url"]);
});

builder.Services.AddDbContext<AppDbContext>();
//builder.Services.AddDbContext<AppDbContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
//});


builder.Services.AddAutoMapper(typeof(MapProfile)); //AutoMapper Eklendi

builder.Services.AddControllers();
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
