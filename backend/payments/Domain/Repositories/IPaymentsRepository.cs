using backend.payments.Domain.Model.Aggregates;
using backend.Shared.Domain.Repositories;

namespace backend.payments.Domain.Repositories;

public interface IPaymentsRepository : IBaseRepository<Payment>
{
    
}