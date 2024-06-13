using Microsoft.EntityFrameworkCore;
using Przykład4.Contexts;
using Przykład4.Exceptions;
using Przykład4.ResponseModels;

namespace Przykład4.Services;

public interface ICharacterService
{
    Task<GetCharacterResponseModel> GetCharacterByIdAsync(int id);
}

public class CharacterService(DatabaseContext context) : ICharacterService
{
    public async Task<GetCharacterResponseModel> GetCharacterByIdAsync(int id)
    {
        var result = await context.Characters
            .Where(character => character.CharacterId == id)
            .Select(character => new GetCharacterResponseModel()
            {
                firstName = character.CharacterFirstName,
                lastName = character.CharacterLastName,
                currentWeight = character.CharacterCurrentWeight,
                maxWeight = character.CharacterMaxWeight,
                backpackItems = character.Backpacks.Select(backpack => new BackpackItemResponseModel()
                {
                    itemName = backpack.Item.ItemName,
                    itemWeight = backpack.Item.ItemWeight,
                    amount = backpack.BackpackAmount
                }).ToList()
            }).FirstOrDefaultAsync();

        if (result is null)
        {
            throw new NotFoundException($"Character with id: {id} not found");
        }

        return result;
    }
}