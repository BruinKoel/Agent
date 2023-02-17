namespace Agent.models.Nodes
{
    public class RNN : Node
    {
        private int inputSize;
        private int outputSize;
        private int recurrences;
        private float learning_rate;

        public override float[] Compute(float[] inputs)
        {
            throw new NotImplementedException();
        }

        public RNN(int inputSize, int outputSize, int recurrences, float learning_rate)
        {
            this.inputSize = inputSize;
            this.outputSize = outputSize;
            this.recurrences = recurrences;
            this.learning_rate = learning_rate;
        }
        private float activationFunction(float x)
        {
            return (float)Math.Tanh(x);
        }

        private float deactivationFunction(float x)
        {
            return (float)Math.Asinh(x); ;
        }

         
    }

}
