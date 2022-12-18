using System.Diagnostics;

namespace LetterPerceptron
{
    internal class Perceptron
    {
        private readonly Neuron[] Neurons;
        private readonly float LearningRate;
        private readonly char[] CorrespondingValues; //Array that represents each neuron's answer
        public Perceptron(int NeuronsAmount, int ConnectionsPerNeuron, float _LearningRate)
        {
            Neurons = new Neuron[NeuronsAmount];
            LearningRate = _LearningRate;
            for (int i = 0; i < Neurons.Length; i++)
                Neurons[i] = new(ConnectionsPerNeuron);
            
            var Dataset = FileService.ReadFrom("../../../Dataset.txt");
            CorrespondingValues= new char[NeuronsAmount];
            for (int i = 0; i < CorrespondingValues.Length; i++)
                CorrespondingValues[i] = Dataset[i].Value;
        }
        public void AutoTrain(int TrainingIteratinos)
        {
            var Dataset = FileService.ReadFrom("../../../Dataset.txt");
            for (int Iteration = 0; Iteration < TrainingIteratinos; Iteration++)
            {
                foreach(Character DatasetItem in Dataset) Train(DatasetItem);
            }
        }

        public void Train(Character TrainCharacter)
        {
            for (int i = 0; i < Neurons.Length; i++)
            {
                while (true)
                {
                    float Result = Neurons[i].ActivationFunction(TrainCharacter.Signature);
                    float ExpectedResult = CorrespondingValues[i] == TrainCharacter.Value ? 1.0f : 0.0f;
                    float Delta = ExpectedResult - Result;
                    if (Delta < 0.1f && Delta > -0.1f) break;
                    float Editor = Delta * LearningRate;
                    Neurons[i].CorrectWeights(TrainCharacter.Signature, Editor);
                }
            }
        }

        public char Test(int[] TestData)
        {
            float MaxValue = 0.0f;
            int NeuronId = -1;
            for (int i = 0; i < Neurons.Length; i++)
            {
                float Result = Neurons[i].ActivationFunction(TestData);
                if (Result > MaxValue)
                {
                    NeuronId = i;
                    MaxValue = Result;
                }
            }
            if (NeuronId == -1) return '-';
            return CorrespondingValues[NeuronId];
        }
    }
}
