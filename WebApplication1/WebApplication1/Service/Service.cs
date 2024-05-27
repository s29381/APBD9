using WebApplication1.Repositories;

namespace WebApplication1.Service;

public interface IService
{
    Task<int> Delete(int idClient);
    Task<PagedTripsDTO> GetAll();
    Task<TripsListDTO> GetByDate(DateTime dateTime);
    Task<int> AddToTrip(ClientDTO clientDto, int idTrip);
}

public class Service : IService
{
    private readonly IRepository _repository;

    public Service(IRepository repository)
    {
        _repository = repository;
    }

    public Task<TripsListDTO> GetByDate(DateTime dateTime)
    {
        throw new NotImplementedException();
    }

    public async Task<int> AddToTrip(ClientDTO clientToAdd, int idTrip)
    {
        var clientWithPeselExists = await _repository.CheckClientWithPeselExists(clientToAdd.Pesel);
        if (clientWithPeselExists) return -1;
        var tripExists = await _repository.CheckTripExists(idTrip);
        if (!tripExists) return -3;
        var clientWithPeselInTrip = await _repository.CheckClientWithPeselInTrip(clientToAdd.Pesel, idTrip);
        if (clientWithPeselInTrip) return -2;
        var validateTripDate = await _repository.ValidateTripDate(idTrip);
        if (!validateTripDate) return -4;
        int idClient = await _repository.GetLastIDClient() + 1;
        Client client = new Client
        {
            IdClient = idClient,
            FirstName = clientToAdd.FirstName,
            LastName = clientToAdd.LastName,
            Email = clientToAdd.Email,
            Telephone = clientToAdd.Telephone,
            Pesel = clientToAdd.Pesel
        };
        return await _repository.AddClientToTrip(client, idTrip, clientToAdd.PaymentDate);
    }

    public async Task<int> Delete(int idClient)
    {
        var clientTrips = await _repository.GetClientTrips(idClient);
        if (clientTrips > 0)
        {
            return -1;
        }
        return await _repository.DeleteClient(idClient);
    }

    public async Task<TripsListDTO> GetAll()
    {
    }
}