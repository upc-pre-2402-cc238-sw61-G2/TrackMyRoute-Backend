namespace backend.payments.Interface.REST.Resource;

public record PaymentsResource(
        int Id,
        string BusName,
        string OriginName,
        string DestinationName,
        string TicketPrice
    );