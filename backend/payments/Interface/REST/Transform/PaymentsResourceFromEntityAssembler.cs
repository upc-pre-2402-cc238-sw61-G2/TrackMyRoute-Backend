using backend.payments.Domain.Model.Aggregates;
using backend.payments.Interface.REST.Resource;

namespace backend.payments.Interface.REST.Transform;

public class PaymentsResourceFromEntityAssembler
{
    public static PaymentsResource ToResourceFromEntity(Payment entity)
    {
        return new PaymentsResource(
            entity.Id,
            entity.BusName,
            entity.OriginName,
            entity.DestinationName,
            entity.TicketPrice
            );
    }
}