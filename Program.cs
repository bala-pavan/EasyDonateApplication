using DonateEasy.Data;
using DonateEasy.Data.Base;
using DonateEasy.Data.Services.IRepositories;
using DonateEasy.Data.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("connect")));

builder.Services.AddScoped<IDonationRepository, DonationRepository>();
builder.Services.AddScoped<IOrphanageRepository, OrphanageRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{*/
    app.UseSwagger();
    app.UseSwaggerUI();
//}
app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod();
});
app.UseHttpsRedirection();
app.UseDeveloperExceptionPage();

app.UseAuthorization();

app.MapControllers();

app.Run();
