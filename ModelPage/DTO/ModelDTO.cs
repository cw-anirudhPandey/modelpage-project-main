using Newtonsoft.Json;

namespace ModelPage.DTO
{
  public class ModelDTO
  {
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("modelName")]
    public string ModelName { get; set; }
  }
}