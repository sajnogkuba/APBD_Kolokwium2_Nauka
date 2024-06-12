namespace Przykład2.ResponseModels;

public class GetMuzykResponseModel
{
    public int IdMuzyk { get; set; }
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public string Pseudonim { get; set; }
    public List<GetMuzykUtworResponseModel> Utwory { get; set; }
}

public class GetMuzykUtworResponseModel
{
    public int IdUtwor { get; set; }
    public string Tytul { get; set; }
    public float CzasTrwania { get; set; }
}