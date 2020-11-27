using Newtonsoft.Json;

namespace ModelPage.DTO
{
  public class PriceDetailsDTO
  {
    [JsonProperty("price")]
    public int Price { get; set; }

    [JsonProperty("city")]
    public int City { get; set; }

    [JsonProperty("version")]
    public string Version { get; set; }

  }
}