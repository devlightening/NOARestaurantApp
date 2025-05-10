using NArchitecture.Core.Application.Responses;

namespace Application.Features.Menus.Commands.Delete;

public class DeletedMenuResponse : IResponse
{
    public Guid Id { get; set; }
}