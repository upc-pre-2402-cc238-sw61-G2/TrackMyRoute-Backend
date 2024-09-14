using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Swashbuckle.AspNetCore.Annotations;

namespace backend.tracking.Interface.REST;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class BusRouteController(
    IBusRouteCommandService busRouteCommandService,
    IBusRouteQueryService busRouteQueryService
    ) : ControllerBase
{
    
    [HttpGet("{busName}")]
    [SwaggerOperation(
        Summary = "Get a bus route id by name",
        Description = "Gets a bus route name for a given identifier",
        OperationId = "GetBusRouteIdByName")]
    [SwaggerResponse(200, "The Bus Route Id was found", typeof(BusRouteResource))]
    public async Task<ActionResult<int?>> GetBusRouteIdByName(string busName)
    {
        var query = new GetBusRouteIdByBusName(busName);
        var busRoute = await busRouteQueryService.Handle(query);
        
        if (busRoute == null)
        {
            return NotFound();
        }
        return Ok(busRoute.Id);
    }
    
    [HttpGet("{busRouteId:int}")]
    [SwaggerOperation(
        Summary = "Get a bus route by id",
        Description = "Gets a bus route for a given identifier",
        OperationId = "GetBusRouteById")]
    [SwaggerResponse(200, "The Bus Route was found", typeof(BusRouteResource))]
    public async Task<IActionResult> GetBusRouteById(int busRouteId)
    {
        var getBusRouteByIdQuery = new GetBusRouteByIdQuery(busRouteId);
        var busRoute = await busRouteQueryService.Handle(getBusRouteByIdQuery);
        var resource = BusRouteResourceFromEntityAssembler.ToResourceFromEntity(busRoute);
        return Ok(resource);
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Gets all bus routes",
        Description = "Gets all bus routes",
        OperationId = "GetAllBusRoutes")]
    [SwaggerResponse(200, "Bus Routes were found", typeof(IEnumerable<BusRouteResource>))]
    public async Task<IActionResult> GetAllBusRoutes()
    {
        var getAllBusRoutes = new GetAllBusRoutesQuery();
        var busRoutes = await busRouteQueryService.Handle(getAllBusRoutes);
        var resources = busRoutes.Select(BusRouteResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    

    [HttpPost]
    [SwaggerOperation(
        Summary = "Post bus routes",
        Description = "Post a bus route",
        OperationId = "PostBusRoute")]
    public async Task<IActionResult> CreateBusRoute([FromBody] CreateBusRouteResource createBusRouteResource)
    {
        var createBusRouteCommand = CreateBusRouteCommandFromResourceAssembler.ToCommandFromResource(createBusRouteResource);
        var busRoute = await busRouteCommandService.Handle(createBusRouteCommand);
        if (busRoute is null) return BadRequest();
        var busRouteResource = BusRouteResourceFromEntityAssembler.ToResourceFromEntity(busRoute);
        return Ok(busRouteResource);
    }

}