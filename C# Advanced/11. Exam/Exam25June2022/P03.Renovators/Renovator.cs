using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Renovators
{
    public class Renovator
    {
        public Renovator(string name, string type, double rate, int days)
        {
            Name = name;
            Type = type;
            Rate = rate;
            Days = days;
            Hired = false;
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public double Rate { get; set; }

        public int Days { get; set; }

        public bool Hired { get; set; }


        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"-Renovator: {Name}");
            output.AppendLine($"--Specialty: {Type}");
            output.AppendLine($"--Rate per day: {Rate} BGN");

            return output.ToString();
        }
    }
}
