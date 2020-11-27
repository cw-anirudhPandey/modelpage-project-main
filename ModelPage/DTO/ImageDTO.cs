using Newtonsoft.Json;

namespace ModelPage.DTO
{
  public class ImageDTO
  {
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("modelId")]
    public int ModelId { get; set; }

    [JsonProperty("imageUrl")]
    public string ImageUrl { get; set; }
  }
}