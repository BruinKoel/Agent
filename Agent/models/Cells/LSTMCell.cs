using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Agent.models.Cells
{
    public struct LSTMCell
    {
        public int historyPointer;

        public float weight;
        public float bias;

        public float[] history;
        public float[] historyWeights;
        public float[] historyBiases;

        public float[] saveWeights;
        public float[] saveBiases;






        public static float Sigmoid(float x)
        {
            return (float)(1 / (1 + Math.Exp(-x)));
        }

        public static float[] Sigmoid(float[] x)
        {
            float[] temp = new float[x.Length];
            for(int i = 0; i < x.Length; i++)
            {
                
                    temp[i] = Sigmoid(x[i]);
                
            }
            return temp;
        }

        public static float Tanh(float x)
        {
            return (float)Math.Tanh(x);
        }

        public static float Activate(float input, LSTMCell cell)
        {
            float F = 0;
            
            for (int i = cell.historyPointer+1; i != cell.historyPointer; i++)
            {
                if(i == cell.history.Length)
                {
                    i = 0;
                }
                F += Sigmoid(cell.history[i] * cell.historyWeights[i]) + cell.historyBiases[i];
            }

            float I = 0;

            for (int i = cell.historyPointer + 1; i != cell.historyPointer; i++)
            {
                if (i == cell.history.Length)
                {
                    i = 0;
                }
                I += Tanh(cell.history[i] * cell.saveWeights[i]) + cell.saveBiases[i];
            }

            float C = 0;

            for (int i = cell.historyPointer + 1; i != cell.historyPointer; i++)
            {
                if (i == cell.history.Length)
                {
                    i = 0;
                }
                C += Sigmoid(cell.history[i] * cell.saveWeights[i]) + cell.saveBiases[i];
            }

            return 0;
        }

    
    }

}
