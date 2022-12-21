using System.Diagnostics;

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

        public static float Sigmoid(float Value)
        {
            return (float)(1.0 / (1.0 + Math.Pow(Math.E, -Value)));
        }

        public float WeightedSum(int[] Input)
        {
            float weightedSum = 0.0f;
            for (int i = 0; i < Input.Length; i++)
                weightedSum += Input[i] * Weights[i];
            return weightedSum;
        }
        public void CorrectWeights(int[] Inputs, float Editor)
        {
            for (int i = 0; i < Weights.Length; i++)
                Weights[i] += Editor * Inputs[i];
        }
    }
}
