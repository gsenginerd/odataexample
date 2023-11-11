using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODataExample.Data;

namespace ODataExample.Controllers;

[ODataRoutePrefix("employees")]
public class EmployeeODataController : ODataController
{
    private readonly ODataExampleContext _oDataExampleContext;

    public EmployeeODataController(ODataExampleContext oDataExampleContext)
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