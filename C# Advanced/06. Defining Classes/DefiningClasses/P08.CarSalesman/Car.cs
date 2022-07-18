using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P08.CarSalesman
{
    public class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; } // optional
        public string Color { get; set; } // optional

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"{Model}:");
            output.AppendLine($"  {Engine.Model}:");
            output.AppendLine($"    Power: {Engine.Power}");
            output.AppendLine($"    Displacement: {(Engine.Displacement == 0 ? "n/a" : Engine.Displacement)}");
            output.AppendLine($"    Efficiency: {(Engine.Efficiency == null ? "n/a" : Engine.Efficiency)}");
            output.AppendLine($"  Weight: {(Weight == 0 ? "n/a" : Weight)}");
            output.Append($"  Color: {(Color == null ? "n/a" : Color)}");

            return output.ToString();
        }
    }
}
