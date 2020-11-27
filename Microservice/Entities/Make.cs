using System;
using System.Collections.Generic;

namespace Microservice.Entities
{
  [Serializable]
  public class Make
  {
    public int Id { get; set;}
    public string MakeName { get; set; }
  }
}