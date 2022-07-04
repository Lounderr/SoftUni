int n = int.Parse(Console.ReadLine());

Stack<int> stack = new Stack<int>();

for (int i = 0; i < n; i++)
{
    int[] query = Console.ReadLine().Split().Select(int.Parse).ToArray();
    int cmdIndex = query[0];


    switch (cmdIndex)
    {
        case 1:
            int element = query[1];
            stack.Push(element);
            break;
        case 2:
            if (stack.Any())
                stack.Pop();
            break;
        case 3:
            if (stack.Any())
                Console.WriteLine(stack.Max());
            break;
        case 4:
            if (stack.Any())
                Console.WriteLine(stack.Min());
            break;

    }
}

Console.WriteLine(String.Join(", ", stack));
