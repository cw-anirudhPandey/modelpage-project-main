using System;
using System.Collections.Generic;

namespace ModelPage.Entities
{
  [Serializable]
  public class CarPrice
  {
    public int Id { get; set; }
    public int VersionId { get; set; }
    public int CityId { get; set; }
    public string Value { get; set; }
  }
}