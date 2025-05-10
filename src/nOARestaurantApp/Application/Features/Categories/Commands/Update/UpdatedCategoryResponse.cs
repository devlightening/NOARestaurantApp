using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Categories.Commands.Update;

public class UpdatedCategoryResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public Guid MenuId { get; set; }
    public Menu Menu { get; set; }
}