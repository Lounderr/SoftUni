using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        private List<Drone> drones;
        
        public string Name { get; set; }

        public int Capacity { get; set; }

        public double LandingStrip { get; set; }

        public int Count { get => drones.Count; }

        public Airfield(string name, int capacity, double landingStrip)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.LandingStrip = landingStrip;
            this.drones = new List<Drone>();
        }

        public string AddDrone(Drone drone)
        {
            if (this.Count < this.Capacity)
            {
                if (drone.Name != null && drone.Name != "" && drone.Brand != null && drone.Brand != "" && drone.Range > 5 && drone.Range < 15)
                {
                    drones.Add(drone);
                    return $"Successfully added {drone.Name} to the airfield.";
                }
                else
                {
                    return "Invalid drone.";
                }
            }
            else
            {
                return "Airfield is full.";
            }
        }

        public bool RemoveDrone(string name)
        {
            if (drones.Select(x => x.Name).Contains(name))
            {
                drones.Remove(drones.Where(drone => drone.Name == name).First());
                return true;
            }

            return false;
        }

        public int RemoveDroneByBrand(string brand)
        {
            int removed = 0;
            for (int i = drones.Count - 1; i >= 0; i--)
            {
                Drone drone = drones[i];
                if (drone.Brand == brand)
                {
                    drones.Remove(drone);
                    removed++;
                }
            }

            return removed;
        }

        public Drone FlyDrone(string name)
        {
            for (int index = 0; index < drones.Count; index++)
            {
                if (drones[index].Name == name)
                {
                    drones[index].Available = false;
                    return drones[index];
                }
            }

            return null;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> flownDrones = new List<Drone>();

            foreach (var drone in drones)
            {
                if (drone.Range >= range)
                {
                    FlyDrone(drone.Name);
                    flownDrones.Add(drone);
                }
            }

            return flownDrones;
        }

        public string Report()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"Drones available at {this.Name}:");

            foreach (var drone in drones)
            {
                if (drone.Available == true)
                {
                    output.Append(drone.ToString());
                }
            }

            return output.ToString();
        }
    }
}
