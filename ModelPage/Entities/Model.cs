using System;
using System.Collections.Generic;

namespace ModelPage.Entities
{
  [Serializable]
  public class Model
  {
    public int Id { get; set; }
    public int MakeId { get; set; }
    public string ModelName { get; set; }
  }
}