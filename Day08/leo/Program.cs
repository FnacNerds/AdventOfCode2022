var inputFileContent = File.ReadAllLines("input.txt");

var numRows = inputFileContent.Length;
var numCols = inputFileContent.First().Length;

var map = new int[numRows, numCols];

for (var iRow = 0; iRow < numRows; iRow++)
{
    var row = inputFileContent[iRow];
    for (var iCol = 0; iCol < numCols; iCol++)
    {
        var col = row[iCol].ToString();
        var height = int.Parse(col);
        map[iRow, iCol] = height;
    }
}

bool isEdge(int row, int col)
{
    if (row == 0)
        return true;
    if (col == 0)
        return true;
    if (row == numRows - 1)
        return true;
    if (col == numCols - 1)
        return true;
    return false;
}

bool inMap(int row, int col)
{
    return row >= 0 && col >= 0 && row < numRows && col < numCols;
}

int browseNeighboors(int rowindex, int colindex, Func<int, int> rowindexModifier, Func<int, int> colindexModifier)
{
    var currentHeight = map[rowindex, colindex];
    var count = 1;

    rowindex = rowindexModifier(rowindex);
    colindex = colindexModifier(colindex);

    while (inMap(rowindex, colindex))
    {
        var neighboorHeight = map[rowindex, colindex];

        if (isEdge(rowindex, colindex))
        {
            break;
        }

        if (neighboorHeight >= currentHeight)
        {
            break;
        }

        rowindex = rowindexModifier(rowindex);
        colindex = colindexModifier(colindex);

        count++;
    }

    return count;
}


var bestScenicScore = 0;

for (var rowindex = 0; rowindex < numRows; rowindex++)
{
    for (var colindex = 0; colindex < numCols; colindex++)
    {
        var left = browseNeighboors(rowindex, colindex, i => i, i => i - 1);
        var right = browseNeighboors(rowindex, colindex, i => i, i => i + 1);
        var top = browseNeighboors(rowindex, colindex, i => i - 1, i => i);
        var bottom = browseNeighboors(rowindex, colindex, i => i + 1, i => i);

        var scenicScore = left * right * top * bottom;

        if (scenicScore > bestScenicScore)
        {
            bestScenicScore = scenicScore;
        }
    }
}

Console.WriteLine(bestScenicScore);
