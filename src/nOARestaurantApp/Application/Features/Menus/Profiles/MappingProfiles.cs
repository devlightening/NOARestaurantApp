using Application.Features.Menus.Commands.Create;
using Application.Features.Menus.Commands.Delete;
using Application.Features.Menus.Commands.Update;
using Application.Features.Menus.Queries.GetById;
using Application.Features.Menus.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Menus.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Menu, CreateMenuCommand>().ReverseMap();
        CreateMap<Menu, CreatedMenuResponse>().ReverseMap();
        CreateMap<Menu, UpdateMenuCommand>().ReverseMap();
        CreateMap<Menu, UpdatedMenuResponse>().ReverseMap();
        CreateMap<Menu, DeleteMenuCommand>().ReverseMap();
        CreateMap<Menu, DeletedMenuResponse>().ReverseMap();
        CreateMap<Menu, GetByIdMenuResponse>().ReverseMap();
        CreateMap<Menu, GetListMenuListItemDto>().ReverseMap();
        CreateMap<IPaginate<Menu>, GetListResponse<GetListMenuListItemDto>>().ReverseMap();
    }
}