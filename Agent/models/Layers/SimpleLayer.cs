using Agent.models.Cells;

namespace Agent.models.Layers
{
    [Serializable]
    public class SimpleLayer
    {
        private SimpleNeuron[] neurons;
        private Random random;

        public SimpleLayer DeepCopy()
        {
            //return JsonConvert.DeserializeObject<SimpleLayer>(JsonConvert.SerializeObject(this));

            var temp = new SimpleNeuron[neurons.Length];
            for (int i = 0; i < neurons.Length; i++)
            {
                temp[i] = neurons[i].DeepCopy();
            }
            return new SimpleLayer()
            {
                neurons = temp,
            };
        }

        public SimpleLayer()
        {
            random = new Random();
        }

        public SimpleLayer(int inputSize, int outputSize)
        {
            random = new Random();
            neurons = new SimpleNeuron[outputSize];
            for (int i = 0; i < outputSize; i++)
            {
                neurons[i] = new SimpleNeuron(inputSize);
            }
        }
        public void UpdateWeights(float factor, float odds)
        {
            int count = (int)(random.NextDouble()*odds*(float)neurons.Length);
            for(int i = 0; i < count; i++)
            {
                var index = random.Next(0, neurons.Length);
                var change = (float)((random.NextDouble() - 0.5d) * factor);
                neurons[index].bias += change;

                int weightCount = (int)(random.NextDouble() * odds * (float)neurons[index].weights.Length);
                for(int z = 0; z < weightCount; z++)
                {
                    var weightIndex = random.Next(0, neurons[index].weights.Length);
                    change = (float)((random.NextDouble() - 0.5d) * factor);
                    neurons[index].weights[weightIndex] += change;
                }

            }
        }
        public float[] ForwardProp(float[] inputs)
        {
            float[] outputs = new float[neurons.Length];
            for (int i = 0; i < neurons.Length; i++)
            {
                for (int z = 0; z < inputs.Length; z++)
                {
                    outputs[i] += inputs[z] * neurons[i].weights[z];
                }
                outputs[i] = SimpleNeuron.Sigmoid(outputs[i] + neurons[i].bias);
            }
            return outputs;
        }


    }
}
