using backend.payments.Domain.Model.Aggregates;
using backend.payments.Domain.Model.Commands;
using backend.payments.Domain.Model.Queries;
using backend.payments.Domain.Repositories;
using backend.payments.Domain.Services;
using backend.Shared.Domain.Repositories;
using backend.tracking;

namespace backend.payments.Application.Internal.CommandServices;

public class PaymentsCommandService(IPaymentsRepository paymentsRepository, IUnitOfWork unitOfWork) : IPaymentsCommandService
{
    public async Task<Payment?> Handle(CreatePaymentCommand command)
    {
        var payment = new Payment(command);
        try
        {
            await paymentsRepository.AddAsync(payment);
            await unitOfWork.CompleteAsync();
            return payment;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error ocurred while creating the bus route: {e.Message}");
            return null;
        }
    }
}