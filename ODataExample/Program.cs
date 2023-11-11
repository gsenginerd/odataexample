using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using ODataExample.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ODataExampleContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ODataExampleConnection")));
builder.Services.AddControllers().AddOData(options => options.Select().Filter().Count().OrderBy().Expand());

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