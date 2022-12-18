namespace LetterPerceptron
{
    internal class Neuron
    {
        public readonly float[] Weights;

        public Neuron(int _ConnectionsAmount)
        {
            Weights = new float[_ConnectionsAmount];
            for (int i = 0; i < Weights.Length; i++)
                Weights[i] = 0.0f;
        }

        public float ActivationFunction(int[] Value)
        {
            return Sigmoid(WeightedSum(Value));
        }

        public static float Sigmoid(float Value) {
            return 1 / (1 + (float)Math.Exp(-Value));
        }

        public float WeightedSum(int[] Input)
        {
            float WeightedSum = 0;
            for (int i = 0; i < Input.Length; i++)
                WeightedSum += Input[i] * Weights[i];
            return WeightedSum;
        }
        public void CorrectWeights(int[] Inputs, float Editor)
        {
            for (int i = 0; i < Weights.Length; i++)
                Weights[i] += Editor * Inputs[i];
        }
    }
}
