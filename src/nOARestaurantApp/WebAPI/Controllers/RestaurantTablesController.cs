using Application.Features.RestaurantTables.Commands.Create;
using Application.Features.RestaurantTables.Commands.Delete;
using Application.Features.RestaurantTables.Commands.Update;
using Application.Features.RestaurantTables.Queries.GetById;
using Application.Features.RestaurantTables.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RestaurantTablesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateRestaurantTableCommand createRestaurantTableCommand)
    {
        CreatedRestaurantTableResponse response = await Mediator.Send(createRestaurantTableCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateRestaurantTableCommand updateRestaurantTableCommand)
    {
        UpdatedRestaurantTableResponse response = await Mediator.Send(updateRestaurantTableCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedRestaurantTableResponse response = await Mediator.Send(new DeleteRestaurantTableCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdRestaurantTableResponse response = await Mediator.Send(new GetByIdRestaurantTableQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListRestaurantTableQuery getListRestaurantTableQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListRestaurantTableListItemDto> response = await Mediator.Send(getListRestaurantTableQuery);
        return Ok(response);
    }
}