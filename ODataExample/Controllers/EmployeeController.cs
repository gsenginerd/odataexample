using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODataExample.Data;
using ODataExample.Data.Entities;

namespace ODataExample.Controllers;

[Route("v1/employees")]
public class EmployeeController : ODataController
{
    private readonly ODataExampleContext _oDataExampleContext;

    public EmployeeController(ODataExampleContext oDataExampleContext)
    {
        _oDataExampleContext = oDataExampleContext;
    }

    [HttpGet(Name = "Get")]
    [EnableQuery]
    public IActionResult Get() => Ok(_oDataExampleContext.Employees.AsQueryable());

    [HttpGet("{id}", Name = "GetById")]
    [EnableQuery]
    public async Task<ActionResult<Employee>> GetById(int id) => Ok(await _oDataExampleContext.Employees.FindAsync(id));
}