using Newtonsoft.Json;

namespace ModelPage.DTO
{
  public class MakeDTO
  {
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("makeName")]
    public string MakeName { get; set; }
  }
}
