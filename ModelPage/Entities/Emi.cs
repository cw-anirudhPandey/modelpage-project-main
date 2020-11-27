using System;

namespace ModelPage.Entities
{
  [Serializable]
  public class Emi 
  {
    public int Id { get; set; }
    public int ModelId { get; set; }
    public string Cost { get; set; }
    public string Duration { get; set; }
  }
}