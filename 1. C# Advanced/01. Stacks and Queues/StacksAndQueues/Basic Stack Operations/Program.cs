string[] firstLine = Console.ReadLine().Split();
int n = int.Parse(firstLine[0]);
int s = int.Parse(firstLine[1]);
int x = int.Parse(firstLine[2]);

int[] sequenceArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
Stack<int> sequenceStack = new Stack<int>(sequenceArray);

for (int i = 0; i < s; i++)
    sequenceStack.Pop();

if (sequenceStack.Count() == 0)
{
    Console.WriteLine(0);
    return;
}

if (sequenceStack.Contains(x))
{
    Console.WriteLine(true);
}
else
{
    Console.WriteLine(sequenceStack.Min());
}