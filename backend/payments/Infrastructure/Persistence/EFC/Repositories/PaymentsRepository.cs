using backend.payments.Domain.Model.Aggregates;
using backend.payments.Domain.Repositories;
using backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace backend.payments.Infrastructure.Persistence.EFC.Repositories;

public class PaymentsRepository(AppDbContext context) : BaseRepository<Payment>(context), IPaymentsRepository
{
    
}