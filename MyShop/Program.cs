using Repositories;
using Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// Add services to the container.


builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IUserServices, UserServices>();                                                                                                                                                         ;
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

app.Run();
