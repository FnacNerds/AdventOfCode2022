var inputFileContent = File.ReadAllLines("input.txt");

var knotsCount = 10;

var visitedPositions = new HashSet<Position>();

var knots = new Position[knotsCount];

for (var i = 0; i < knotsCount; i++)
{
    knots[i] = new Position(0, 0);
}

foreach (var row in inputFileContent)
{
    var inputs = row.Split(' ');

    Func<Position, Position> positionModifier = null;

    switch (inputs[0])
    {
        case "U":
            positionModifier = position => new Position(position.row - 1, position.col);
            break;
        case "D":
            positionModifier = position => new Position(position.row + 1, position.col);
            break;
        case "L":
            positionModifier = position => new Position(position.row, position.col - 1);
            break;
        case "R":
            positionModifier = position => new Position(position.row, position.col + 1);
            break;
    }

    var count = int.Parse(inputs[1]);

    for (var iMove = 0; iMove < count; iMove++)
    {
        knots[0] = positionModifier(knots[0]);

        for (var iKnot = 1; iKnot < knots.Length; iKnot++)
        {
            if (Math.Abs(knots[iKnot - 1].col - knots[iKnot].col) <= 1
                && Math.Abs(knots[iKnot - 1].row - knots[iKnot].row) <= 1)
            {
                continue;
            }

            if (knots[iKnot - 1].row == knots[iKnot].row)
            {
                knots[iKnot] = new Position(
                    knots[iKnot].row,
                    knots[iKnot - 1].col > knots[iKnot].col ? knots[iKnot - 1].col - 1 : knots[iKnot - 1].col + 1
                );
            }
            else if (knots[iKnot - 1].col == knots[iKnot].col)
            {
                knots[iKnot] = new Position(
                    knots[iKnot - 1].row > knots[iKnot].row ? knots[iKnot - 1].row - 1 : knots[iKnot - 1].row + 1,
                    knots[iKnot].col
                );
            }
            else
            {
                knots[iKnot] = new Position(
                    knots[iKnot - 1].row > knots[iKnot].row ? knots[iKnot].row + 1 : knots[iKnot].row - 1,
                    knots[iKnot - 1].col > knots[iKnot].col ? knots[iKnot].col + 1 : knots[iKnot].col - 1
                );
            }
        }
        visitedPositions.Add(knots[knots.Length - 1]);
    }
}

Console.WriteLine(visitedPositions.Count);

record struct Position(int row, int col);
