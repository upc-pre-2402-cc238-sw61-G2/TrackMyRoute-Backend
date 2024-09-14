using System.Runtime.InteropServices.Marshalling;
using backend.Promos.Domain.Model.Commands;
using backend.Promos.Domain.Model.Aggregates;
using backend.Promos.Domain.Repositories;
using backend.Promos.Domain.Services;
using backend.Shared.Domain.Repositories;

namespace backend.Promos.Application.Internal.CommandServices;

public class PromoCommandService(IPromoRepository promoRepository, IUnitOfWork unitOfWork) :IPromoCommandService
{
    public async Task<Promo> Handle(CreatePromoCommand command)
    {
        var promo = new Promo(command);
        try
        {
            await promoRepository.AddAsync(promo);
            await unitOfWork.CompleteAsync();
            return promo;
        }
        catch (Exception e)
        {
            throw new Exception("An error ocurred while trying to add the new Promo, ", e);
        }
    }
}