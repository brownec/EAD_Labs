using System;

/* The car should be a model class. 
 * A car has a make, model, engine size, and engine type (petrol, diesel, or hybrid).  */

namespace Task1.Models
{
    public enum CarEngineType { Petrol, Diesel, Hybrid }
    public class Car
    {
       //  public int ID { get; set; }
        public String Make { get; set; }
        public String Model { get; set; }
        public int EngineSize { get; set; }
        public CarEngineType CarEngineType { get; set; }
    }
}

