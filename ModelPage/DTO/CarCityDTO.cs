using System;
using Newtonsoft.Json;

namespace ModelPage.DTO
{
  public class CarCityDTO
  {
    [JsonProperty("id")]
    public int Id {get; set;}
    [JsonProperty("name")]
    public string Name { get; set; }
  }
}