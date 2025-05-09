using Application.Features.Restaurants.Commands.Create;
using Application.Features.Restaurants.Commands.Delete;
using Application.Features.Restaurants.Commands.Update;
using Application.Features.Restaurants.Queries.GetById;
using Application.Features.Restaurants.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RestaurantsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateRestaurantCommand createRestaurantCommand)
    {
        CreatedRestaurantResponse response = await Mediator.Send(createRestaurantCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateRestaurantCommand updateRestaurantCommand)
    {
        UpdatedRestaurantResponse response = await Mediator.Send(updateRestaurantCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedRestaurantResponse response = await Mediator.Send(new DeleteRestaurantCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdRestaurantResponse response = await Mediator.Send(new GetByIdRestaurantQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListRestaurantQuery getListRestaurantQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListRestaurantListItemDto> response = await Mediator.Send(getListRestaurantQuery);
        return Ok(response);
    }
}