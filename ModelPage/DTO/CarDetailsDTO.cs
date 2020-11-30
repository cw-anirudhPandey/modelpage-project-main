using System.Collections.Generic;
using Newtonsoft.Json;

namespace ModelPage.DTO
{
  public class CarDetailsDTO
  {
    [JsonProperty("makeDetail")]
    public MakeDTO CarMake { get; set; }

    [JsonProperty("modelDetail")]
    public ModelDTO CarModel { get; set; }

    [JsonProperty("imageDetail")]
    public ImageDTO CarImage { get; set; }

    [JsonProperty("reviewDetail")]
    public ReviewDTO CarReview { get; set; }
    
    [JsonProperty("priceDetailList")]
    public IEnumerable<CarCityDTO> CitySet { get; set; }

    [JsonProperty("priceDetailList")]
    public IEnumerable<CarVersionDTO> VersionSet { get; set; }

    [JsonProperty("priceDetailList")]
    public List<PriceDetailsDTO> CarPriceDetails { get; set; }
  }
}
