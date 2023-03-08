using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Agent.models.Cells
{
    [Serializable]
    public class SimpleNeuron
    {
        
        public float[] weights;
        public float bias;

        public SimpleNeuron DeepCopy()
        {
            var temp = new SimpleNeuron()
            {
                weights = new float[weights.Length],
                bias= bias,
            };
            weights.CopyTo(temp.weights, 0);

            return temp;
        }
        public SimpleNeuron()
        {
        }

        public SimpleNeuron(int inputSize)
        {
            Random random = new Random();
            weights = new float[inputSize];
            for (int i = 0; i < inputSize; i++)
            {
                weights[i] = (float)random.NextDouble()-0.5f;
            }
            bias = (float)random.NextDouble()-0.5f;
        }


        public static float Sigmoid(float x)
        {
            
            return (float)Math.Tanh(x);
        }
    }
}
