using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ODataExample.Data;

namespace ODataExample.Controllers;

[ApiController]
[Route("employees")]
public class EmployeeController : ControllerBase
{
    private readonly ODataExampleContext _oDataExampleContext;

    public EmployeeController(ODataExampleContext oDataExampleContext)
    {
        _oDataExampleContext = oDataExampleContext;
    }

    // GET
    [EnableQuery]
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_oDataExampleContext.Employees.AsQueryable());
    }
}