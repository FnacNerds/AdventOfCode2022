var inputFileContent = File.ReadAllLines("input.txt");

var letterToScore = new Dictionary<string, int>()
{
    { "A", 1 },
    { "B", 2 },
    { "C", 3 },
};

var letterToWinCondition = new Dictionary<string, string>()
{
    {"A", "B"},
    {"B", "C"},
    {"C", "A"},
};

var letterToLooseCondition = letterToWinCondition.ToDictionary(x => x.Value, x => x.Key);

var score = 0;

foreach (var inputRow in inputFileContent)
{
    if (inputRow == string.Empty)
    {
        continue;
    }

    var splitted = inputRow.Split(" ");

    var whatToDo = splitted[1];
    var opponent = splitted[0];

    switch (whatToDo)
    {
        case "X":
            score += letterToScore[letterToLooseCondition[opponent]];
            break;
        case "Y":
            score += 3;
            score += letterToScore[opponent];
            break;
        case "Z":
            score += 6;
            score += letterToScore[letterToWinCondition[opponent]];
            break;
    }
}

Console.WriteLine(score);
