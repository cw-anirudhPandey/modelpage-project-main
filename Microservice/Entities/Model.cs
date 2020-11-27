using System;
using System.Collections.Generic;

namespace Microservice.Entities
{
  [Serializable]
  public class Model
  {
    public int Id { get; set; }
    public string ModelName { get; set; }
  }
}