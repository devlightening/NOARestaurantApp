using Domain.Entities;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Categories.Queries.GetList;

public class GetListCategoryListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public Guid MenuId { get; set; }
    public Menu Menu { get; set; }
}