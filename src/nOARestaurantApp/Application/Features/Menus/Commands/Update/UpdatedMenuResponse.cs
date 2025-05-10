using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Menus.Commands.Update;

public class UpdatedMenuResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public Guid RestaurantId { get; set; }
    public string? Photo { get; set; }
    public bool IsActive { get; set; }
    public Restaurant Restaurant { get; set; }
}