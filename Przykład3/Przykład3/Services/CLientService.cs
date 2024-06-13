using Microsoft.EntityFrameworkCore;
using Przykład3.Contexts;
using Przykład3.Exceptions;
using Przykład3.ResponseModels;

namespace Przykład3.Services;

public interface IClientService
{
    Task<GetClientResponseModel> GetClientByIdAsync(int id);
}

public class ClientService(DatabaseContext context) : IClientService
{
    public async Task<GetClientResponseModel> GetClientByIdAsync(int id)
    {
        var result = await context.Clients
            .Where(client => client.ClientId == id)
            .Select(client => new GetClientResponseModel()
            {
                Id = client.ClientId,
                Name = client.ClientName,
                LastName = client.ClientLastName,
                Birthday = client.ClientBirthday,
                Pesel = client.ClientPesel,
                Email = client.ClientEmail,
                ClientCategory = client.ClientCategory.ClientCategoryName,
                Reservations = client.Reservations.Select(reservation => new GetClientReservationsResponseModel()
                {
                    Id = reservation.ReservationId,
                    StartDate = reservation.ReservationDateFrom,
                    EndDate = reservation.ReservationDateTo,
                    BoatStandard = reservation.BoatStandard.BoatStandardName,
                    Capacity = reservation.ReservationCapacity,
                    Fulfilled = reservation.ReservationFulfilled,
                    Price = reservation.ReservationPrice,
                    CanceledReason = reservation.ReservationCancelReason
                }).OrderBy(reservation => reservation.StartDate)
                    .ToList()
            }).FirstOrDefaultAsync();

        if (result is null)
        {
            throw new NotFoundException("Client not found");
        }
        
        return result;    
    }
}