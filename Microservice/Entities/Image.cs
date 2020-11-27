using System;
using System.Collections.Generic;

namespace Microservice.Entities
{
  [Serializable]
  public class Image
  {
    public int Id { get; set; }
    public int ModelId { get; set; }
    public string ImageUrl { get; set; }
  }
}