using System.Reflection;
using Tff.WebApi.Exceptions;
using Tff.WebApi.Repositories;
using Tff.WebApi.Services.Abstract;
using Tff.WebApi.Services.Concrete;
using Tff.WebApi.Services.Mappers;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

string ReactCors = "ReactCors";

builder.Services.AddCors(options =>
{
    options.AddPolicy(ReactCors, policy =>
    {
        policy.WithOrigins("http://localhost:5173")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddControllers();




builder.Services.AddScoped<PlayerMapper>();


builder.Services.AddScoped<ITeamService,TeamService>();
builder.Services.AddScoped<IPlayerService,PlayerService>();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();


builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddDbContext<BaseDbContext>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseMiddleware<ExceptionMiddleware>();

app.UseExceptionHandler(_ => { });
app.UseHttpsRedirection();

app.UseCors(ReactCors);
app.UseAuthorization();

app.MapControllers();

app.Run();