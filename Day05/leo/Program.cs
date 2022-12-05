using System.Text;
using System.Text.RegularExpressions;

var inputFileContent = File.ReadAllLines("input.txt");

var cratesRegex = new Regex(@"(?:\[(\w{1})\]\s?)|(?:\s(\s)\s\s?)", RegexOptions.Compiled);
var stacksRegex = new Regex(@"(?:\s(\d+)\s)", RegexOptions.Compiled);

var rowIndex = 0;
var parsingInitialState = true;

var invertedStacksByIndex = new Dictionary<int, Stack<string>>();
var stacksById = new Dictionary<string, Stack<string>>();

while (parsingInitialState)
{
    var row = inputFileContent[rowIndex];

    if (row == string.Empty)
    {
        parsingInitialState = false;
    }
    else
    {
        var stacksRegexMatches = stacksRegex.Matches(row);

        if (stacksRegexMatches.Count > 0)
        {
            for (var stackIndex = 0; stackIndex < stacksRegexMatches.Count; stackIndex++)
            {
                var id = stacksRegexMatches[stackIndex].Groups[1].Value;
                var stack = new Stack<string>();
                var invertedStack = invertedStacksByIndex[stackIndex];
                while (invertedStack.Count > 0)
                {
                    stack.Push(invertedStack.Pop());
                }
                stacksById.Add(id, stack);
            }
        }
        else
        {
            var cratesRegexMatches = cratesRegex.Matches(row);

            if (cratesRegexMatches.Count > 0)
            {
                for (var stackIndex = 0; stackIndex < cratesRegexMatches.Count; stackIndex++)
                {
                    var value = cratesRegexMatches[stackIndex].Groups[1].Value;

                    if (!invertedStacksByIndex.ContainsKey(stackIndex))
                    {
                        invertedStacksByIndex.Add(stackIndex, new Stack<string>());
                    }

                    if (value != string.Empty)
                    {
                        invertedStacksByIndex[stackIndex].Push(value);
                    }
                }
            }
        }
    }

    rowIndex++;
}

var instructionRegex = new Regex(@"move (\d+) from (\d+) to (\d+)", RegexOptions.Compiled);

for (; rowIndex < inputFileContent.Length; rowIndex++)
{
    var row = inputFileContent[rowIndex];
    var match = instructionRegex.Match(row);
    if (match.Success)
    {
        var count = int.Parse(match.Groups[1].Value);
        var from = match.Groups[2].Value;
        var to = match.Groups[3].Value;

        var tempStack = new Stack<string>();

        for (var i = 0; i < count; i++)
        {
            var crate = stacksById[from].Pop();
            tempStack.Push(crate);
        }

        while (tempStack.Count > 0)
        {
            stacksById[to].Push(tempStack.Pop());
        }
    }
}

var output = new StringBuilder();
foreach (var (_, stack) in stacksById)
{
    if (stack.Count > 0)
    {
        output.Append(stack.Peek());
    }
}

Console.WriteLine(output);