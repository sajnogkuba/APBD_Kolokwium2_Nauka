namespace Przykład4.ResponseModels;

public class GetCharacterResponseModel
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public int currentWeight { get; set; }
    public int maxWeight { get; set; }
    public List<BackpackItemResponseModel> backpackItems  { get; set; }
    public List<TitleResponseModel> titles  { get; set; }
}

public class BackpackItemResponseModel
{
    public string itemName { get; set; }
    public int itemWeight { get; set; }
    public int amount { get; set; }
}

public class TitleResponseModel
{
    public string title { get; set; }
    public DateTime aquiredAt { get; set; }
}