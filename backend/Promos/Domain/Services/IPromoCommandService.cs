using backend.Promos.Domain.Model.Commands;
using backend.Promos.Domain.Model.Aggregates;

namespace backend.Promos.Domain.Services;

public interface IPromoCommandService
{
    Task<Promo> Handle(CreatePromoCommand command);
}