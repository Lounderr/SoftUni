using System;

namespace InAndOutTesting
{
    internal class Program
    {
        public static void MyMethod(int a, in int b, ref int c, out int d)
        {
            a = 1; // Standard

            int z = b;
            //b = 2; -> НЕВЪЗМОЖНО, защото е read only

            c = 4; // Can assign a value or not
            // Може да върне (или не), защото е двупосочен параметър <->

            d = 4; // Must assign a value
            // int y = d; -> НЕВЪЗМОЖНО, защото е еднопосочен параметър само навън, който няма стойност в метода, дори и да е зададена извън метода ->
            // Действието е възможно само ако преди това е зададена стойност на d в метода
        }
        static void Main(string[] args)
        {
            int a = 1; // трябва да има стойност
            int b = 2; // трябва да има стойност
            int c = 3; // трябва да има стойност
            int d; // може да няма стойност, но ако има, ще се презапише

            MyMethod(a, b, ref c, out d); // b може да се напише без in
        }
    }
}
