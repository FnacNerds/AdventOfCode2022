var inputFileContent = File.ReadAllLines("input.txt");

var capacity = 3;

var priorityQueue = new PriorityQueue<int, int>(capacity);
var sum = 0;

foreach (var inputRow in inputFileContent)
{
    if (inputRow == string.Empty)
    {
        if (priorityQueue.Count == capacity)
        {
            priorityQueue.EnqueueDequeue(sum, sum);
        }
        else
        {
            priorityQueue.Enqueue(sum, sum);
        }
        sum = 0;
    }
    else
    {
        sum += int.Parse(inputRow);
    }
}

Console.WriteLine(priorityQueue.UnorderedItems.Select(x => x.Element).Sum());