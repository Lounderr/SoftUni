using System;
using System.Text;

namespace Drones
{
    public class Drone
    {
        public string Name { get; set; }
        
        public string Brand { get; set; }
        
        public int Range { get; set; }
        
        public bool Available { get; set; }

        public Drone(string name, string brand, int range)
        {
            this.Name = name;
            this.Brand = brand;
            this.Range = range;
            this.Available = true;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Drone: {this.Name}");
            output.AppendLine($"Manufactured by: {this.Brand}");
            output.AppendLine($"Range: {this.Range} kilometers");

            return output.ToString();
        }
    }
}
