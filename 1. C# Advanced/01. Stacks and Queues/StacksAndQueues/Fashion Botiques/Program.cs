int[] clothes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray(); // in box
int capacity = int.Parse(Console.ReadLine());

int requiredRacks = (int)(clothes.Length / capacity) + 1;

Console.WriteLine(requiredRacks);