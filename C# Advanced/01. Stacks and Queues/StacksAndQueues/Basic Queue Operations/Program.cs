int[] firstLine = Console.ReadLine().Split().Select(int.Parse).ToArray();
int n = firstLine[0];
int s = firstLine[1];
int x = firstLine[2];

int[] sequenceArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
Queue<int> sequenceQueue = new Queue<int>(sequenceArray);

for (int i = 0; i < s; i++)
    sequenceQueue.Dequeue();

if (sequenceQueue.Count() == 0)
{
    Console.WriteLine(0);
    return;
}

if (sequenceQueue.Contains(x))
{
    Console.WriteLine(true);
}
else
{
    Console.WriteLine(sequenceQueue.Min());
}