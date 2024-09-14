using backend.Promos.Domain.Model.Aggregates;
using backend.Promos.Domain.Model.Queries;

namespace backend.Promos.Domain.Services;

public interface IPromoQueryService
{
    Task<IEnumerable<Promo>> Handle(GetPromoByTitleQuery query);
    Task<Promo> Handle(GetPromoByIdQuery query);
    
    Task<IEnumerable<Promo>> Handle(GetAllPromosQuery query);
}