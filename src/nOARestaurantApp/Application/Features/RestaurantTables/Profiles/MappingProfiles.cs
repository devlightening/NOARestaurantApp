using Application.Features.RestaurantTables.Commands.Create;
using Application.Features.RestaurantTables.Commands.Delete;
using Application.Features.RestaurantTables.Commands.Update;
using Application.Features.RestaurantTables.Queries.GetById;
using Application.Features.RestaurantTables.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.RestaurantTables.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<RestaurantTable, CreateRestaurantTableCommand>().ReverseMap();
        CreateMap<RestaurantTable, CreatedRestaurantTableResponse>().ReverseMap();
        CreateMap<RestaurantTable, UpdateRestaurantTableCommand>().ReverseMap();
        CreateMap<RestaurantTable, UpdatedRestaurantTableResponse>().ReverseMap();
        CreateMap<RestaurantTable, DeleteRestaurantTableCommand>().ReverseMap();
        CreateMap<RestaurantTable, DeletedRestaurantTableResponse>().ReverseMap();
        CreateMap<RestaurantTable, GetByIdRestaurantTableResponse>().ReverseMap();
        CreateMap<RestaurantTable, GetListRestaurantTableListItemDto>().ReverseMap();
        CreateMap<IPaginate<RestaurantTable>, GetListResponse<GetListRestaurantTableListItemDto>>().ReverseMap();
    }
}