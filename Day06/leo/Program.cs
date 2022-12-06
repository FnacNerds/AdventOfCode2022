var inputFileContent = File.ReadAllLines("input.txt");

const int markerSize = 14;

var markerBuffer = new Queue<char>();
var markerBufferCharFrequencies = new Dictionary<char, int>();
var duplicatedCount = 0;

var input = inputFileContent.First();

for (var i = 0; i < input.Length; i++)
{
    if (markerBuffer.Count > markerSize)
    {
        var dequeuedC = markerBuffer.Dequeue();
        if (markerBufferCharFrequencies[dequeuedC] > 1)
        {
            duplicatedCount--;
        }
        markerBufferCharFrequencies[dequeuedC]--;

        if (duplicatedCount == 0)
        {
            Console.WriteLine(i);
            return;
        }
    }

    var c = input[i];

    markerBuffer.Enqueue(c);

    if (!markerBufferCharFrequencies.ContainsKey(c))
    {
        markerBufferCharFrequencies.Add(c, 1);
    }
    else
    {
        markerBufferCharFrequencies[c]++;
        if (markerBufferCharFrequencies[c] > 1)
        {
            duplicatedCount++;
        }
    }
 }

Console.WriteLine("oops");