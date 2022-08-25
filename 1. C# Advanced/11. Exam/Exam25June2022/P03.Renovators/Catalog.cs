using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        public List<Renovator> Renovators;

        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;

            Renovators = new List<Renovator>();
        }

        private string Name { get; set; }

        private int NeededRenovators { get; set; }

        private string Project { get; set; }

        public int Count { get => Renovators.Count; }


        public string AddRenovator(Renovator renovator)
        {
            if (NeededRenovators > Renovators.Count)
                if (renovator.Name != null && renovator.Name != "")
                    if (renovator.Rate <= 350)
                    {
                        Renovators.Add(renovator);
                        return $"Successfully added {renovator.Name} to the catalog.";
                    }
                    else
                        return "Invalid renovator's rate.";
                else
                    return $"Invalid renovator's information.";
            else
                return $"Renovators are no more needed.";
        }

        public bool RemoveRenovator(string name)
        {
            if (Renovators.Any(r => r.Name == name))
            {
                Renovator renovator = Renovators.Where(r => r.Name == name).First();
                Renovators.Remove(renovator);
                return true;
            }

            return false;
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            int removedCount = 0;
            foreach (var renovator in Renovators.ToList())
            {
                if (renovator.Type == type)
                {
                    Renovators.Remove(renovator);
                    removedCount++;
                }
            }

            return removedCount;
        }

        public Renovator HireRenovator(string name)
        {
            for (int i = 0; i < Renovators.Count; i++)
            {
                if (Renovators[i].Name == name)
                {
                    Renovators[i].Hired = true;
                    return Renovators[i];
                }
            }

            return null;
        }

        public List<Renovator> PayRenovators(int days)
        {
            return Renovators.Where(r => r.Days >= days).ToList();
        }

        public string Report()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Renovators available for Project {Project}:");
            foreach (var renovator in Renovators.Where(r => r.Hired == false))
            {
                output.AppendLine(renovator.ToString());
            }

            return output.ToString();
        }

    }
}
