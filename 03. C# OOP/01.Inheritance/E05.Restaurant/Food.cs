using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Text;

namespace Restaurant
{
    public class Food : Product
    {
        public Food(string name, decimal price, double grams) : base(name, price)
        {
            Grams = grams;
        }

        public virtual double Grams { get; set; }
    }
}
