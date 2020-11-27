using System;
using System.Collections.Generic;

namespace Microservice.Entities
{
  [Serializable]
    public class PriceDetails
    {
        public string Version {get; set;}
        public string City {get; set;}
        public string Price {get; set;}
  }
}
