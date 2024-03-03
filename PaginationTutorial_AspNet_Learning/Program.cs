using Core;
using Microsoft.EntityFrameworkCore;
using PaginationTutorial_AspNet_Learning.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly("PaginationTutorial_AspNet_Learning")));

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IUriService>((serviceProvider) =>
{
    var accessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
    var request = accessor.HttpContext.Request;
    var URI = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
    return new UriServices(URI);
});

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
