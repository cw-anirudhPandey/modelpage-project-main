using Newtonsoft.Json;

namespace ModelPage.DTO
{
  public class ReviewDTO
  {
    [JsonProperty("modelId")]
    public int ModelId { get; set; }

    [JsonProperty("rating")]
    public double Rating { get; set; }

    [JsonProperty("count")]
    public int Count { get; set; }
  }
}