using System;
using System.Collections.Generic;

namespace Microservice.Entities
{
  [Serializable]
  public class CarModelDetails
  {
    public Make MakeDetail {get; set;}
    public Model ModelDetail {get; set;}
    public Review ReviewDetail {get; set;}
    public HashSet<string> CitySet { get; set; }
    public HashSet<string> VersionSet { get; set; }
    public List<PriceDetails> PriceDetailsList { get; set; }
    public Emi EmiDetail { get; set; }
  }
}