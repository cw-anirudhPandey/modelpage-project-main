using System;

namespace UserReview.Entities
{
  [Serializable]
  public class CarReview
  {
    public int ModelId {get; set;}
    public double Rating { get; set; }
    public int Count { get; set; }
  }
}