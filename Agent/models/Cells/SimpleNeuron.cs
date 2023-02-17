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
            return JsonConvert.DeserializeObject<SimpleNeuron>(JsonConvert.SerializeObject(this));
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
            
            return (double)(1 / (1 + Math.Exp(-x)));
        }
    }
}
