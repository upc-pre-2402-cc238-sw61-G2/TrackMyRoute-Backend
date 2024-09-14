using backend.Promos.Domain.Model.Aggregates;
using backend.Promos.Domain.Repositories;
using backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend.Promos.Infrastructure.Persistence.EFC.Repositories;

public class PromoRepository:BaseRepository<Promo>, IPromoRepository
{

    public PromoRepository(AppDbContext context) : base(context)
    {
        
    }
    
    public async Task<IEnumerable<Promo>> FindByTitleAsync(string title)
    {
        return await Context.Set<Promo>().Where(f => f.Title == title).ToListAsync();
    }
    public new async Task<IEnumerable<Promo>> ListAsync()
    {
        return await Context.Set<Promo>().ToListAsync();
    }
}