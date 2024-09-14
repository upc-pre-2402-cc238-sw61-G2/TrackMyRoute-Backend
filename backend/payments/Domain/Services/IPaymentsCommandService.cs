using backend.payments.Domain.Model.Aggregates;
using backend.payments.Domain.Model.Commands;

namespace backend.payments.Domain.Services;

public interface IPaymentsCommandService
{
   Task<Payment?> Handle(CreatePaymentCommand command);
}