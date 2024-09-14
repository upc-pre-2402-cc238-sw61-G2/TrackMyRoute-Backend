namespace backend.payments.Interface.ACL;

public interface IPaymentsContextFacade
{
    Task<int> CreatePayment(
        string busName,
        string originName, 
        string destinationName,
        string ticketPrice
    );
}