using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;

var inputFileContent = File.ReadAllLines("input.txt");

var noop = new Regex("noop", RegexOptions.Compiled);
var addx = new Regex(@"addx (-?\d+)", RegexOptions.Compiled);

var instructions = new Queue<Instruction>();

foreach (var input in inputFileContent)
{
    switch (input)
    {
        case not null when noop.IsMatch(input):
            instructions.Enqueue(new NoopInstruction());
            break;
        case not null when addx.Match(input) is { Success: true } match:
            var value = int.Parse(match.Groups[1].Value);
            instructions.Enqueue(new AddXInstruction(value));
            break;
    }
}

var cycle = 1;
var regx = 1;
Instruction currentInstruction = null;
var signalStrength = 0;
var cyclesToMonitor = new HashSet<int>() { 20, 60, 100, 140, 180, 220 };

var crtBuffer = new StringBuilder();

var crtOutput = new StringBuilder();

void crtDraw(int cycle)
{
    var posInCycle = (cycle % 40) - 1;
    Console.WriteLine($"During cycle  {cycle}: CRT draws pixel in position {posInCycle}");
    if (posInCycle == 0)
    {
        if (crtBuffer.Length > 0)
        {
            crtOutput.AppendLine(crtBuffer.ToString());
        }
        crtBuffer = new StringBuilder();
    }

    if (posInCycle >= (regx - 1) % 40 && posInCycle <= (regx + 1) % 40)
    {
        crtBuffer.Append("#");
    }
    else
    {
        crtBuffer.Append(".");
    }
    Console.WriteLine($"Current CRT row: {crtBuffer.ToString()}");


    if (posInCycle == 39)
    {
        Console.WriteLine(crtBuffer.ToString());
    }
}

while (instructions.Any())
{
    if (currentInstruction == null)
    {
        currentInstruction = instructions.Dequeue();
    }

    if (!currentInstruction.Started)
    {
        Console.WriteLine($"Start cycle\t{cycle}: begin executing {currentInstruction}");
    }

    crtDraw(cycle);

    if (cyclesToMonitor.Contains(cycle))
    {
        var addedStrength = cycle * regx;
        //Console.WriteLine($"Cycle : {cycle} Strength : {addedStrength}");
        signalStrength += (addedStrength);
    }

    currentInstruction.DecreaseLifetime();

    if (currentInstruction.Lifetime == 0)
    {
        switch (currentInstruction)
        {
            case NoopInstruction noopInstruction:
                Console.WriteLine($"End of cycle \t{cycle}: finish executing {currentInstruction}");
                break;
            case AddXInstruction addXInstruction:
                regx += addXInstruction.Value;
                Console.WriteLine($"End of cycle \t{cycle}: finish executing {currentInstruction} (Register X is now {regx})");
                break;
        }

        currentInstruction = null;
    }



    cycle++;
}

if (crtBuffer.Length > 0)
{
    crtOutput.AppendLine(crtBuffer.ToString());
}

Console.WriteLine(crtOutput.ToString());

abstract class Instruction
{
    public int Lifetime { get; protected set; }
    public bool Started { get; set; } = false;

    public void DecreaseLifetime()
    {
        Lifetime--;
        Started = true;
    }
}

class NoopInstruction : Instruction
{
    public NoopInstruction()
    {
        Lifetime = 1;
    }

    public override string ToString()
    {
        return "noop";
    }
}

class AddXInstruction : Instruction
{
    public int Value { get; }

    public AddXInstruction(int value)
    {
        Value = value;
        Lifetime = 2;
    }

    public override string ToString()
    {
        return $"addx {Value}";
    }
}