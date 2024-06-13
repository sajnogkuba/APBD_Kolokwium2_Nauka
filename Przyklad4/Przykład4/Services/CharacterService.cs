using Microsoft.EntityFrameworkCore;
using Przykład4.Contexts;
using Przykład4.Exceptions;
using Przykład4.Models;
using Przykład4.RequestModels;
using Przykład4.ResponseModels;

namespace Przykład4.Services;

public interface ICharacterService
{
    Task<GetCharacterResponseModel> GetCharacterByIdAsync(int id);
    Task<List<AddItemsResponseModel>> AddItemsAsync(int id, AddItemsRequestModel data);
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
                }).ToList(),
                titles = character.Titles.Select(title => new TitleResponseModel()
                {
                    title = title.Title.TitleName,
                    aquiredAt = title.AcquiredAt
                }).ToList()
            }).FirstOrDefaultAsync();

        if (result is null)
        {
            throw new NotFoundException($"Character with id: {id} not found");
        }

        return result;
    }

    public async Task<List<AddItemsResponseModel>> AddItemsAsync(int id, AddItemsRequestModel data)
    {
        var newItemsWeight = 0;
        foreach (var dataItem in data.items)
        {
            var item = context.Items.Where(i => i.ItemId == dataItem).FirstOrDefaultAsync();
            if (item.Result is null)
            {
                throw new NotFoundException($"Item with id: {dataItem} not found");
            }
            newItemsWeight += item.Result.ItemWeight;
        }
        
        var character = context.Characters
            .Where(c => c.CharacterId == id)
            .FirstOrDefaultAsync();

        if(character.Result is null)
        {
            throw new NotFoundException($"Character with id: {id} not found");
        }

        if (character.Result.CharacterCurrentWeight + newItemsWeight > character.Result.CharacterMaxWeight)
        {
            throw new BadRequestException("Character can't carry that much weight");
        }
        character.Result.CharacterCurrentWeight += newItemsWeight;

        var result = new List<AddItemsResponseModel>();
        foreach (var dataItem in data.items)
        {
            var bacpack = await context.Backpacks
                .Where(b => b.BackpackCharacterId == id && b.BackpackItemId == dataItem)
                .FirstOrDefaultAsync();

            if (bacpack is null)
            {
                await context.Backpacks.AddAsync(new Backpack()
                {
                    BackpackCharacterId = id,
                    BackpackItemId = dataItem,
                    BackpackAmount = 1
                });
                result.Add(new AddItemsResponseModel()
                {
                    amount = 1,
                    itemId = dataItem,
                    characterId = id
                });
            }
            else
            {
                bacpack.BackpackAmount++;
                result.Add(new AddItemsResponseModel()
                {
                    amount = bacpack.BackpackAmount,
                    itemId = dataItem,
                    characterId = id
                });
            }
            await context.SaveChangesAsync();
        }
        await context.SaveChangesAsync();
        return result;
    }
}