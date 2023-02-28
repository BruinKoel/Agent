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
        
        public double[] weights;
        public double bias;

        public SimpleNeuron DeepCopy()
        {
            var temp = new SimpleNeuron()
            {
                weights = new double[weights.Length],
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
            weights = new double[inputSize];
            for (int i = 0; i < inputSize; i++)
            {
                weights[i] = (double)random.NextDouble()-0.5d;
            }
            bias = (double)random.NextDouble()-0.5d;
        }


        public static double Sigmoid(double x)
        {
            
            return (double)Math.Tanh(x);
        }
    }
}
