using backend.Promos.Domain.Model.Aggregates;
using backend.Shared.Domain.Repositories;

namespace backend.Promos.Domain.Repositories;

public interface IPromoRepository : IBaseRepository<Promo>
{
    Task<IEnumerable<Promo>> FindByTitleAsync(string title);
    
}