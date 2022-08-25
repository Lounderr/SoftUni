int foodQuantity = int.Parse(Console.ReadLine());
int[] secondLine = Console.ReadLine().Split().Select(int.Parse).ToArray();
Queue<int> orders = new Queue<int>(secondLine);

Console.WriteLine(orders.Max());

int initalOrdersCount = orders.Count();

for (int i = 0; i < initalOrdersCount; i++) // Is there a way to instantiate this without storing it in a variable
{
    if (foodQuantity >= orders.Peek())
    {
        foodQuantity -= orders.Dequeue();
    }
    else
    {
        Console.WriteLine($"Orders left: {string.Join(' ', orders)}");
        return;
    }
}

Console.WriteLine($"Orders complete");

