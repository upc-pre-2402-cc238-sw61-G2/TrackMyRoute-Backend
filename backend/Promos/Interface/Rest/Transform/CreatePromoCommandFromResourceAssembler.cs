using backend.Promos.Domain.Model.Commands;
using backend.Promos.Interface.Rest.Resources;

namespace backend.Promos.Interface.Rest.Transform;

public static class CreatePromoCommandFromResourceAssembler
{
    public static CreatePromoCommand ToCommandFromResource(CreatePromoResource resource)
    {
        return new CreatePromoCommand(resource.Title, resource.Description);
    }
}