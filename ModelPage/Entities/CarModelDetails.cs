using System;
using System.Collections.Generic;

namespace ModelPage.Entities
{
  [Serializable]
  public class CarModelDetails
  {
    public Make MakeDetail {get; set;}
    public Model ModelDetail {get; set;}
    public CarImage ImageDetail {get; set;}
    public Review ReviewDetail {get; set;}
    public IEnumerable<CarCity> CitySet { get; set; }
    public IEnumerable<CarVersion> VersionSet { get; set; }
    public IEnumerable<CarPrice> PriceDetailList { get; set; }
  }
}