using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using ODataExample.Data;
using ODataExample.Data.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ODataExampleContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ODataExampleConnection")));
builder.Services.AddControllers().AddOData(options => options.Select().Filter().Count().OrderBy().Expand().AddRouteComponents("v1", GetEdmModel()));

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

app.UseODataRouteDebug();

app.Run();
return;


static IEdmModel GetEdmModel()
{
    ODataConventionModelBuilder modelBuilder = new();
    modelBuilder.EntitySet<Employee>("Employees");
    return modelBuilder.GetEdmModel();
}