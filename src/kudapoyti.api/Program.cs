using kudapoyti.api.Configurations;
using kudapoyti.api.MiddleWares;
using kudapoyti.Service.Common.Security;
using kudapoyti.Service.Interfaces;
using kudapoyti.Service.Interfaces.Common;
using kudapoyti.Service.Services.Common;
using kudapoyti.Service.Services;
using kudapoyti.Service.Services.Common;
using kudapoyti.Service.Services.KudaPaytiService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IAuthManager, AUthManager>();

builder.Services.AddScoped<IAdminAccountService, AdminAccountService>();
builder.Services.AddScoped<IPaginationService, PaginatonService>();
builder.Services.AddScoped<IPlaceService, PlaceService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.ConfigureSwaggerAuthorize();

//Mapper
builder.Services.AddAutoMapper(typeof(MapperConfiguration));


//database
builder.ConfigureDataAccess();

//Middleware
var app = builder.Build();
app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseStaticFiles();

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
