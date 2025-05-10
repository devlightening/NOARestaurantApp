using Application.Features.Menus.Commands.Create;
using Application.Features.Menus.Commands.Delete;
using Application.Features.Menus.Commands.Update;
using Application.Features.Menus.Queries.GetById;
using Application.Features.Menus.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MenusController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateMenuCommand createMenuCommand)
    {
        CreatedMenuResponse response = await Mediator.Send(createMenuCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateMenuCommand updateMenuCommand)
    {
        UpdatedMenuResponse response = await Mediator.Send(updateMenuCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedMenuResponse response = await Mediator.Send(new DeleteMenuCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdMenuResponse response = await Mediator.Send(new GetByIdMenuQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListMenuQuery getListMenuQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListMenuListItemDto> response = await Mediator.Send(getListMenuQuery);
        return Ok(response);
    }
    [HttpGet("getall")]
    public async Task<IActionResult> GetAll()
    {
        GetListMenuQuery getListMenuQuery = new() { PageRequest = new PageRequest { PageSize = 1000, PageIndex = 0 } };
        GetListResponse<GetListMenuListItemDto> response = await Mediator.Send(getListMenuQuery);
        return Ok(response);
    }

}