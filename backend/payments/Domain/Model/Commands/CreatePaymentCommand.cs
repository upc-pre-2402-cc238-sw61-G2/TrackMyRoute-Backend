namespace backend.payments.Domain.Model.Commands;

public record CreatePaymentCommand(
        string busName,
        string originName,
        string destinationName,
        string ticketPrice
    );