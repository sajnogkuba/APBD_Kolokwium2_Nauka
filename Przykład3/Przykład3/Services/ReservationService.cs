using Microsoft.EntityFrameworkCore;
using Przykład3.Contexts;
using Przykład3.Exceptions;
using Przykład3.Models;
using Przykład3.RequestModels;

namespace Przykład3.Services;

public interface IReservationService
{
    Task<int> CreateReservation(CreateReservationRequestModel request);
}

public class ReservationService(DatabaseContext context) : IReservationService
{
    public async Task<int> CreateReservation(CreateReservationRequestModel request)
    {
        var client = await context.Clients.Where(client => client.ClientId == request.IdClient).FirstOrDefaultAsync();
        if (client is null)
        {
            throw new NotFoundException($"Client with id {request.IdClient} not found");
        }
        var clientReservations = await context.Reservations
            .Where(reservation => reservation.ReservationClientId == request.IdClient)
            .Where(reservation => reservation.ReservationFulfilled == false && reservation.ReservationCancelReason == null)
            .ToListAsync();
        
        if (clientReservations.Count > 0)
        {
            throw new BadRequestException($"Client with id:{request.IdClient} has unfulfilled reservations");
        }
        
        var newReservation = new Reservation()
        {
            ReservationClientId = request.IdClient,
            ReservationBoatStandardId = request.IdBoatStandard,
            ReservationDateFrom = request.DateFrom,
            ReservationDateTo = request.DateTo,
            ReservationCapacity = 1,
            ReservationFulfilled = true,
            ReservationPrice = 0,
            ReservationCancelReason = null
        };

        var boats = await context.Sailboats
            .Where(sailboat => sailboat.SailboatBoatStandardId >= request.IdBoatStandard)
            .ToListAsync();

        if (boats.Count < request.NumOfBoats)
        {
            newReservation.ReservationFulfilled = false;
            newReservation.ReservationCancelReason = "Not enough boats available";
            await context.Reservations.AddAsync(newReservation);
            await context.SaveChangesAsync();
        }
        else
        {
            var newId = await context.Reservations.MaxAsync(reservation => reservation.ReservationId) + 1;
            foreach (var sailboat in boats)
            {
                newReservation.ReservationPrice += (decimal)sailboat.SailboatPrice;
                await context.SailboatsReservations.AddAsync(new SailboatReservation()
                {
                    SailboatReservationSailboatId = sailboat.SailboatId,
                    SailboatReservationReservationId = newId
                });
            }
            await context.Reservations.AddAsync(newReservation);
            await context.SaveChangesAsync();
        }
        var result = await context.Reservations.MaxAsync(reservation => reservation.ReservationId);
        return result;

    }
}