using Przykład2.Models;

namespace Przykład2.RequestModels;

public class CreateMuzykRequestModel
{
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public string? Pseudonim { get; set; }
    public  Utwor Utwor { get; set; }
}

public class CreateUtworRequestModel
{
    public int IdUtwor { get; set; }
    public string Tytul { get; set; }
    public float CzasTrwania { get; set; }
    public int IdAlbum { get; set; }
}