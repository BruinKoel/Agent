using Agent.models.Cells;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

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
            random= new Random();
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
        public void UpdateWeights(double factor, double odds)
        {

            for (int i = 0; i < neurons.Length; i++)
            {
                for (int z = 0; z < neurons[i].weights.Length; z++)
                {
                    if(random.NextDouble() < odds)
                    {
                        var change = (double)((random.NextDouble() - 0.5d) * factor);
                        neurons[i].weights[z] += change;
                        neurons[i].weights[z] *= 1 - change;
                    }
                }

            }
        }
        public double[] ForwardProp(double[] inputs)
        {
            double[] outputs = new double[neurons.Length];
            for (int i = 0; i < neurons.Length; i++)
            {
                for (int z = 0; z < inputs.Length; z++)
                {
                    outputs[i] += inputs[z] * neurons[i].weights[z];
                }
                outputs[i] = SimpleNeuron.Sigmoid(outputs[i]);
            }
            return outputs;
        }


    }
}
