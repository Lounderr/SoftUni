using System;

namespace P05.DateModifier
{
    public class DateModifier
    {
        public static double GetDifference(DateTime d1, DateTime d2) 
            => Math.Abs((d2 - d1).TotalDays);
        }
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime firstDate = Convert.ToDateTime(Console.ReadLine()).Date;
            DateTime secondDate = Convert.ToDateTime(Console.ReadLine()).Date;
            Console.WriteLine(DateModifier.GetDifference(firstDate, secondDate));
        }
    }
}
