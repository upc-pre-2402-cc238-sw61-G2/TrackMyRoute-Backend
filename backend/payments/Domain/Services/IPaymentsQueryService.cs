using backend.payments.Domain.Model.Aggregates;
using backend.payments.Domain.Model.Queries;

namespace backend.payments.Domain.Services;

public interface IPaymentsQueryService
{
    Task<IEnumerable<Payment>> Handle(GetAllPaymentsQuery query);
}