using System;

namespace ModelPage.Entities
{
  [Serializable]
  public class CarVersion
  {
    public int Id {get; set;}
    public int ModelId {get; set;}
    public string Name { get; set; }
  }
}