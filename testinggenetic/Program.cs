// See https://aka.ms/new-console-template for more information

using Agent.models.Nodes;

Console.WriteLine("Hello, World!");



//x and y trainingset , 100 bits re[resnted by boudbles
var (x, y) = (new double[100][], new double[100][]);
Random random = new Random();
List<SimpleNode> nodes = new List<SimpleNode>();

for (int i = 0; i < 50; i++)
{
    nodes.Add(new Agent.models.Nodes.SimpleNode(2, new int[] { 2,2,2, 1 }));

}

// a node is a WHOLE network
var temp = nodes.FirstOrDefault();

// fill XOR set
for (int i = 0; i < y.Length; i++)
{
    x[i] = new double[2];
    y[i] = new double[1];

    x[i][0] = (double)Math.Round(random.NextDouble());
    x[i][1] = (double)Math.Round(random.NextDouble());
    y[i][0] = (x[i][0] > 0) ^ (x[i][1] > 0) ? 1f : 0f;
}


List<string> costs = new List<string>();
int generationCounter = 0;
while (temp.LastCost > 0.0000001 && costs.Count < 20000)
{
    costs.Add(temp.LastCost.ToString());


    Parallel.ForEach<SimpleNode>(nodes, p => p.CalculateCost(x, y));
    nodes = nodes.OrderBy(x => x.LastCost).ToList();
    temp = nodes.FirstOrDefault();
    int half = (int)Math.Round((double)nodes.Count / 2f);

    double odds = 1 / temp.LastCost;
    double factor = odds* odds;

    for (int i = half; i < nodes.Count; i++)
    {
        nodes[i] = nodes[i - half].DeepCopy();
        nodes[i].UpdateWeights(factor, odds);

    }

   
        Console.WriteLine($"Generation:{++generationCounter} current cost:{costs.Last().ToString()}");
    
}


Console.WriteLine("Finished training enter 2 bits seperated by a space to test the XOR operator Network");
while (true)
{

    string kek = Console.ReadLine();
    var (a, b) = (double.Parse(kek.Split()[0]), double.Parse(kek.Split()[1]));

    Console.WriteLine(temp.Compute(new double[] { a, b }).First());
    Console.WriteLine();
}

