using backend.payments.Domain.Model.Commands;
using backend.payments.Domain.Services;

namespace backend.payments.Interface.ACL.Services;

public class PaymentsContextFacade(
        IPaymentsCommandService paymentsCommandService,
        IPaymentsQueryService paymentsQueryService
    ) : IPaymentsContextFacade
{
    public async Task<int> CreatePayment(
        string busName,
        string originName,
        string destinationName,
        string ticketPrice
    )
    {
        var createPaymentCommand = new CreatePaymentCommand(
            busName, 
            originName, 
            destinationName, 
            ticketPrice
            );
        var payment = await paymentsCommandService.Handle(createPaymentCommand);
        return payment?.Id ?? 0;
    }
}