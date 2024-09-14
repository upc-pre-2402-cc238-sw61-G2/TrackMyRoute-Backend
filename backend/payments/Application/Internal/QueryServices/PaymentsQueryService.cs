using backend.payments.Domain.Model.Aggregates;
using backend.payments.Domain.Model.Queries;
using backend.payments.Domain.Repositories;
using backend.payments.Domain.Services;

namespace backend.payments.Application.Internal.QueryServices;

public class PaymentsQueryService(IPaymentsRepository paymentsRepository) : IPaymentsQueryService
{
    public async Task<IEnumerable<Payment>> Handle(GetAllPaymentsQuery query)
    {
        return await paymentsRepository.ListAsync();
    }
}