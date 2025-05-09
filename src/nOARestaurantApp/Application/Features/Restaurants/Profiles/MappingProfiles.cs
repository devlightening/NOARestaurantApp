using Application.Features.Restaurants.Commands.Create;
using Application.Features.Restaurants.Commands.Delete;
using Application.Features.Restaurants.Commands.Update;
using Application.Features.Restaurants.Queries.GetById;
using Application.Features.Restaurants.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Restaurants.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Restaurant, CreateRestaurantCommand>().ReverseMap();
        CreateMap<Restaurant, CreatedRestaurantResponse>().ReverseMap();
        CreateMap<Restaurant, UpdateRestaurantCommand>().ReverseMap();
        CreateMap<Restaurant, UpdatedRestaurantResponse>().ReverseMap();
        CreateMap<Restaurant, DeleteRestaurantCommand>().ReverseMap();
        CreateMap<Restaurant, DeletedRestaurantResponse>().ReverseMap();
        CreateMap<Restaurant, GetByIdRestaurantResponse>().ReverseMap();
        CreateMap<Restaurant, GetListRestaurantListItemDto>().ReverseMap();
        CreateMap<IPaginate<Restaurant>, GetListResponse<GetListRestaurantListItemDto>>().ReverseMap();
    }
}