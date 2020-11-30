using Newtonsoft.Json;

namespace ModelPage.DTO
{
  public class PriceDetailsDTO
  {
    [JsonProperty("id")]
    public int Id { get; set; }
    [JsonProperty("versionId")]
    public int VersionId { get; set; }
    [JsonProperty("cityId")]
    public int CityId { get; set; }
    [JsonProperty("value")]
    public string Value { get; set; }

  }
}