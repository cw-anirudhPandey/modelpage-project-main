using Newtonsoft.Json;

namespace ModelPage.DTO
{
  public class EmiDTO
  {
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("modelId")]
    public int ModelId { get; set; }

    [JsonProperty("cost")]
    public string Cost { get; set; }


    [JsonProperty("duration")]
    public string Duration { get; set; }
  }
}