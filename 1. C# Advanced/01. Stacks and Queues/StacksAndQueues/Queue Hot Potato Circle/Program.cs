string[] circleMembers = Console.ReadLine().Split(' '); // A J V
int n = int.Parse(Console.ReadLine()); // 2

Queue<string> queue = new Queue<string>(circleMembers);

for (int i = 0; i < circleMembers.Length; i++)
{
    if (i % n == 0)
    {
        Console.WriteLine($"Removed {queue.Dequeue()}");
    }
    if (queue.Count() == 1)
    {
        Console.WriteLine($"Last is {queue.Peek()}");
    }
}