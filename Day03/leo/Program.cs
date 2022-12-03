var inputFileContent = File.ReadAllLines("input.txt");

int LowerCharToPriority(char c)
{
    return Convert.ToInt32(c) - Convert.ToInt32('a') + 1;
}

int UpperCharToPriority(char c)
{
    return Convert.ToInt32(c) - Convert.ToInt32('A') + 27;
}

int CharToPriority(char c)
{
    if (char.IsLower(c))
    {
        return LowerCharToPriority(c);
    }

    return UpperCharToPriority(c);
}

var sumOfPriorities = 0;

for (var groupIndex = 0; groupIndex < inputFileContent.Length; groupIndex += 3)
{
    var itemFrequencyInGroup = new Dictionary<char, int>();

    for (var rucksackIndex = 0; rucksackIndex < 3; rucksackIndex++)
    {
        var knownItemInRucksack = new HashSet<char>();
        var row = inputFileContent[groupIndex + rucksackIndex];

        foreach (var c in row)
        {
            if (knownItemInRucksack.Contains(c))
            {
                continue;
            }

            knownItemInRucksack.Add(c);

            if (itemFrequencyInGroup.ContainsKey(c))
            {
                itemFrequencyInGroup[c]++;
            }
            else
            {
                itemFrequencyInGroup.Add(c, 1);
            }
        }
    }

    foreach (var (item, frequency) in itemFrequencyInGroup)
    {
        if (frequency == 3)
        {
            sumOfPriorities += CharToPriority(item);
        }
    }
}

Console.WriteLine(sumOfPriorities);