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
        foreach (var dataItem in data.Items)
        {
            var item = context.Items.Where(i => i.ItemPK == dataItem).FirstOrDefaultAsync();
            if (item.Result is null)
            {
                throw new NotFoundException($"Item with id: {dataItem} not found");
            }
            newItemsWeight += item.Result.ItemWeight;
        }

        var character = await context.Characters
            .Where(character => character.CharacterPK == id)
            .FirstOrDefaultAsync();

        if (character is null)
        {
            throw new NotFoundException($"Character with id: {id} not found");
        }
        
        if (character.CharacterCurrentWeight + newItemsWeight > character.CharacterMaxWeight)
        {
            throw new BadRequestException("Character can't carry that much weight");
        }
        
        character.CharacterCurrentWeight += newItemsWeight;
        
        var result = new List<AddItemsResponseModel>();
        
        foreach (var item in data.Items)
        {
            var newBackpackSlot = new BackpackSlot()
            {
                Character = character,
                Item = await context.Items.Where(i => i.ItemPK == item).FirstOrDefaultAsync() ??
                       throw new NotFoundException("")
            };
            await context.BackpackSlots.AddAsync(newBackpackSlot);
            result.Add(new AddItemsResponseModel()
            {
                characterId = character.CharacterPK,
                itemId = item,
                slotId = newBackpackSlot.BackpackSlotPK
            });

        }
        
        await context.SaveChangesAsync();
        return result;
    }
}