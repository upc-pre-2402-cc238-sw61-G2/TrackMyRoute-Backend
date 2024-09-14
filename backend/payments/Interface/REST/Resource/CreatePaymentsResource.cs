namespace backend.payments.Interface.REST.Resource;

public record CreatePaymentsResource(
    string BusName,
    string OriginName,
    string DestinationName,
    string TicketPrice
    );