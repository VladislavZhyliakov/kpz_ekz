using Microsoft.EntityFrameworkCore;
using DAL;
using Domain.RepositoryInterfaces;
using DAL.Repositories;
using Services.Interfaces;
using Services;
using Services.Mappers;
using AutoMapper;
using InProduct.Middlewares;
using DateOnlyTimeOnly.AspNet.Converters;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("MSSQLDBConnectionString");
builder.Services.AddDbContext<ApplicationContext>(x => x.UseLazyLoadingProxies().UseSqlServer(connection));
builder.Services.AddCors(x =>
{
    x.AddDefaultPolicy(s =>
    {
        s.AllowAnyMethod();
        s.AllowAnyOrigin();
        s.AllowAnyHeader();
    });
});


builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IStudentService, StudentService>();

builder.Services.AddControllers(options =>
{
    options.UseDateOnlyTimeOnlyStringConverters();
})
    .AddJsonOptions(options =>
    {
        options.UseDateOnlyTimeOnlyStringConverters();
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(provider => new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new MapperProfile());
    cfg.AllowNullCollections = true;
}).CreateMapper());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseSwagger(c =>
{
    c.SerializeAsV2 = true;
});
app.UseMiddleware<ExceptionMiddleware>();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
