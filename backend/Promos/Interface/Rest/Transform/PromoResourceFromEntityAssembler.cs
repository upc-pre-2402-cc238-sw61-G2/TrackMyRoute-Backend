using backend.Promos.Domain.Model.Aggregates;
using backend.Promos.Interface.Rest.Resources;

namespace backend.Promos.Interface.Rest.Transform;

public static class PromoResourceFromEntityAssembler
{
    public static PromoResource ToResourceFromEntity(Promo promo)
    {
        return new PromoResource(promo.Id, promo.Title, promo.Description);
    }
}