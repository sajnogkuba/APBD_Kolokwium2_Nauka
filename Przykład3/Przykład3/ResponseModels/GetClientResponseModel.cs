namespace Przykład3.ResponseModels;

public class GetClientResponseModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public DateTime Birthday { get; set; }
    public string Pesel { get; set; }
    public string Email { get; set; }
    public string ClientCategory { get; set; }
    public List<GetClientReservationsResponseModel> Reservations { get; set; }
}

public class GetClientReservationsResponseModel
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string BoatStandard { get; set; }
    public int Capacity { get; set; }
    public bool Fulfilled { get; set; }
    public decimal Price { get; set; }
    public string? CanceledReason { get; set; }
}