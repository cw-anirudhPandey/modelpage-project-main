using System;
using System.Collections.Generic;

namespace Microservice.Entities
{
  [Serializable]
    public class Price
    {
        public int Id { get; set; }
        public int VersionId { get; set; }
        public int CityId { get; set; }
        public string Value {get; set;}
  }
}
