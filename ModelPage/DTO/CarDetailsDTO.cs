using System.Collections.Generic;
using Newtonsoft.Json;

namespace ModelPage.DTO
{
  public class CarDetailsDTO
  {
    [JsonProperty("carMake")]
    public MakeDTO CarMake { get; set; }

    [JsonProperty("modelName")]
    public ModelDTO CarModel { get; set; }

    [JsonProperty("carImage")]
    public ImageDTO CarImage { get; set; }

    [JsonProperty("carReview")]
    public ReviewDTO CarReview { get; set; }

    [JsonProperty("carEmi")]
    public EmiDTO CarEmi { get; set; }

    [JsonProperty("carPriceDetails")]
    public IEnumerable<PriceDetailsDTO> CarPriceDetails { get; set; }
  }
}
