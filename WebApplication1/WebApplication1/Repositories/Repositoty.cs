namespace WebApplication1.Repositories;

public interface IRepository
{
    Task<bool> CheckClientWithPeselExists(object pesel);
    Task<bool> CheckTripExists(int idTrip);
    Task<bool> CheckClientWithPeselInTrip(object pesel, int idTrip);
    Task<bool> ValidateTripDate(int idTrip);
    Task<int> GetLastIDClient();
    Task<int> AddClientToTrip(Client client, int idTrip, object paymentDate);
    Task<int> DeleteClient(int idClient);
    Task<int> GetClientTrips(int idClient);
}

public class Repositoty : IRepository
{
    public Task<bool> CheckClientWithPeselExists(object pesel)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CheckTripExists(int idTrip)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CheckClientWithPeselInTrip(object pesel, int idTrip)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ValidateTripDate(int idTrip)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetLastIDClient()
    {
        throw new NotImplementedException();
    }

    public Task<int> AddClientToTrip(Client client, int idTrip, object paymentDate)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteClient(int idClient)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetClientTrips(int idClient)
    {
        throw new NotImplementedException();
    }
}