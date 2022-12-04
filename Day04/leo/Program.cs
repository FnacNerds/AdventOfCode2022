var inputFileContent = File.ReadAllLines("input.txt");

var fullyContainedCount = 0;

foreach (var row in inputFileContent)
{
    var pairs = row.Split(',');

    var pair1 = pairs[0].Split('-');
    var pair2 = pairs[1].Split('-');

    var range1 = new Range(int.Parse(pair1[0]), int.Parse(pair1[1]));
    var range2 = new Range(int.Parse(pair2[0]), int.Parse(pair2[1]));

    if (range1.Overlaps(range2)
        || range2.Overlaps(range1))
    {
        fullyContainedCount++;
    }
}

Console.WriteLine(fullyContainedCount);

record struct Range(int min, int max)
{
    public bool FullyContains(Range other)
    {
        return min <= other.min && max >= other.max;
    }

    public bool Overlaps(Range other)
    {
        return min <= other.max && max >= other.min;
    }
}
