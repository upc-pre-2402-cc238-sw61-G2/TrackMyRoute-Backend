using backend.payments.Domain.Model.Commands;

namespace backend.payments.Domain.Model.Aggregates;

public partial class Payment
{

    public int Id { get; private set; }
    public string BusName { get; private set; }
    public string OriginName { get; private set; }
    public string DestinationName { get; private set; }
    public string TicketPrice { get; private set; }

    public Payment()
    {
        BusName = " ";
        OriginName = " ";
        DestinationName = " ";
        TicketPrice = " ";
    }
    
    public Payment(string busName, string originName, string destinationName, string ticketPrice)
    {
        BusName = busName;
        OriginName = originName;
        DestinationName = destinationName;
        TicketPrice = ticketPrice;
    }

    public Payment(CreatePaymentCommand command)
    {
        BusName = command.busName;
        OriginName = command.originName;
        DestinationName = command.destinationName;
        TicketPrice = command.ticketPrice;
    }
}
