using Agent.models.Layers;

namespace Agent.models.Nodes
{
    public class SimpleNode
    {
        public string name;
        public float LastCost;
        private List<SimpleLayer> layers;

        private readonly int[] shape;

        public SimpleNode DeepCopy()
        {
            SimpleNode temp = new SimpleNode()
            {
                layers = layers.Select(x => x.DeepCopy()).ToList(),
            };

            return temp;
        }
        public SimpleNode ShapeCopy()
        {
            return new SimpleNode(shape.First(), shape[1..]);
        }

        public SimpleNode()
        {
            LastCost = float.MaxValue;
        }
        public SimpleNode(int inputSize, int[] layerSizes)
        {
            shape = new int[layerSizes.Length + 1];
            shape[0] = inputSize;
            for (int i = 0; i < layerSizes.Length; i++)
            {
                shape[i + 1] = layerSizes[i];
            }


            layers = new List<SimpleLayer>();
            for (int i = 0; i < layerSizes.Length; i++)
            {
                if (i == 0)
                {
                    layers.Add(new SimpleLayer(inputSize, layerSizes[i]));
                }
                else
                {
                    layers.Add(new SimpleLayer(layerSizes[i - 1], layerSizes[i]));
                }
            }
            LastCost = float.MaxValue;
        }

        public float[] Compute(float[] inputs)
        {
            float[] outputs = inputs;
            for (int i = 0; i < layers.Count; i++)
            {
                outputs = layers[i].ForwardProp(outputs);
            }
            return outputs;
        }

        public void UpdateWeights(float factor, float odds)
        {
           foreach(var layer in layers)
            {
                layer.UpdateWeights(factor, odds);
            }
        }
        public void CalculateCost(float[][] input, float[][] desiredOutput)
        {
            List<float> cost = new List<float>();
            float[][] results = new float[input.GetLength(0)][];

            for (int i = 0; i < desiredOutput.GetLength(0); i++)
            {
                results[i] = Compute(input[i]);
                float temp = 0;
                for (int j = 0; j < results[0].Length; j++)
                {
                    temp += (float)Math.Pow(results[i][j] - desiredOutput[i][j], 2);
                }

                cost.Add(temp / results[0].Length);
            }
            LastCost = cost.Average();
        }


    }
}
