var inputFileContent = File.ReadAllLines("input.txt");

var allNodes = new List<Node>();
var rootNode = new Node()
{
    Id = "/"
};
allNodes.Add(rootNode);
var currentNode = rootNode;

// 1. Build graph

foreach (var row in inputFileContent)
{
    if (row == "$ cd ..")
    {
        currentNode = currentNode.Parent;
    }
    else if (row == "$ cd /")
    {
        currentNode = rootNode;
    }
    else if (row.StartsWith("$ cd"))
    {
        var id = row.Substring("$ cd ".Length);
        currentNode = currentNode.ChildNodes[id];
    }
    else if (row == "$ ls")
    {
        // ignore
    }
    else if (row.StartsWith("dir "))
    {
        var id = row.Substring("dir ".Length);
        if (!currentNode.ChildNodes.ContainsKey(id))
        {
            var newNode = new Node()
            {
                Id = id,
                Parent = currentNode,
                IsDirectory = true
            };
            currentNode.ChildNodes.Add(id, newNode);
            allNodes.Add(newNode);
        }
    }
    else
    {
        var columns = row.Split(' ');
        var size = int.Parse(columns[0]);
        var id = columns[1];
        if (!currentNode.ChildNodes.ContainsKey(id))
        {
            var newNode = new Node()
            {
                Id = id,
                Parent = currentNode,
                Size = size
            };
            currentNode.ChildNodes.Add(id, newNode);
            allNodes.Add(newNode);
        }
    }
}

// 2. dfs to compute sizes

Action<Node> explore = null;
explore = (Node node) =>
{
    foreach (var (id, childNode) in node.ChildNodes)
    {
        if (childNode.IsDirectory)
        {
            explore(childNode);
        }
    }

    node.Size = node.ChildNodes.Sum(x => x.Value.Size.GetValueOrDefault());
};
explore(rootNode);

// 3 . result

const int totalSpace = 70000000;
const int neededSpace = 30000000;
var unused = totalSpace - rootNode.Size.GetValueOrDefault();
var missingSpace = neededSpace - unused;

var goodCandidateSize = int.MaxValue;

foreach (var node in allNodes)
{
    if (node.IsDirectory 
        && node.Size.GetValueOrDefault() >= missingSpace 
        && node.Size.GetValueOrDefault() < goodCandidateSize)
    {
        goodCandidateSize = node.Size.GetValueOrDefault();
    }
}

Console.WriteLine(goodCandidateSize);

class Node
{
    public string Id { get; set; }
    public Node Parent { get; set; }
    public int? Size { get; set; }
    public bool IsDirectory { get; set; }
    public Dictionary<string, Node> ChildNodes { get; set; } = new();

    public override string ToString()
    {
        return $"Id: {Id} - Size: {Size.GetValueOrDefault()}";
    }
}