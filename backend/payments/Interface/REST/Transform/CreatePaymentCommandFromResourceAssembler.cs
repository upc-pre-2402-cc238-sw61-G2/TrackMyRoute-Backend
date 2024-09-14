using backend.payments.Domain.Model.Commands;
using backend.payments.Interface.REST.Resource;

namespace backend.payments.Interface.REST.Transform;

public class CreatePaymentCommandFromResourceAssembler
{
    public static CreatePaymentCommand ToCommandFromResource(CreatePaymentsResource resource)
    {
        return new CreatePaymentCommand(
                resource.BusName,
                resource.OriginName,
                resource.DestinationName,
                resource.TicketPrice
            );
    }
}