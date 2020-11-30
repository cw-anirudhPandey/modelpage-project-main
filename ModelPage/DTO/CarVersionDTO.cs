using System;
using Newtonsoft.Json;

namespace ModelPage.DTO
{
  public class CarVersionDTO
  {
    [JsonProperty("id")]
    public int Id {get; set;}
    [JsonProperty("modelId")]
    public int ModelId {get; set;}
    [JsonProperty("name")]
    public string Name { get; set; }
  }
}