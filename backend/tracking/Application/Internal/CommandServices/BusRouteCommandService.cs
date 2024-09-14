using backend.Shared.Domain.Repositories;

namespace backend.tracking;

public class BusRouteCommandService(IBusRouteRepository busRouteRepository, IUnitOfWork unitOfWork) : IBusRouteCommandService
{
    public async Task<BusRoute?> Handle(CreateBusRouteCommand command)
    {
        var busRoute = new BusRoute(command);
        try
        {
            await busRouteRepository.AddAsync(busRoute);
            await unitOfWork.CompleteAsync();
            return busRoute;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error ocurred while creating the bus route: {e.Message}");
            return null;
        }
    }
}