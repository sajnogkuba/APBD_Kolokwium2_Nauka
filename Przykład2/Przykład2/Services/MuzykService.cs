using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Przykład2.Contexts;
using Przykład2.Exceptions;
using Przykład2.ResponseModels;

namespace Przykład2.Services;

public interface IMuzykService
{
    Task<GetMuzykResponseModel> GetMuzykByIdAsync(int id);
}

public class MuzykService(DatabaseContext context) : IMuzykService
{
    [HttpGet("{id}")]
    public async Task<GetMuzykResponseModel> GetMuzykByIdAsync(int id)
    {
        var result = await context.Muzycy.Where(e => e.IdMuzyk == id)
            .Select(e => new GetMuzykResponseModel()
            {
                IdMuzyk = e.IdMuzyk,
                Imie = e.Imie,
                Nazwisko = e.Nazwisko,
                Pseudonim = e.Pseudonim,
                Utwory = e.WykonawcyUtwor.Select(e2 => new GetMuzykUtworResponseModel()
                {
                    IdUtwor = e2.IdUtwor,
                    Tytul = context.Utwory.Where(e3 => e3.IdUtwor == e2.IdUtwor).Select(e3 => e3.NazwaUtworu).FirstOrDefault(),
                    CzasTrwania = context.Utwory.Where(e3 => e3.IdUtwor == e2.IdUtwor).Select(e3 => e3.CzasTrwania).FirstOrDefault()
                }).ToList()
            }).FirstOrDefaultAsync();
        
        if (result is null)
        {
            throw new NotFoundException($"Account with id:{id} does not exist");
        }

        return result;
    }
}