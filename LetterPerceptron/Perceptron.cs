using System.Diagnostics;

namespace LetterPerceptron
{
    internal class Perceptron
    {
        private readonly Neuron[] Neurons;
        private readonly float LearningRate;
        private readonly List<Character> Dataset; //Array that represents each neuron's answer
        public Perceptron(int NeuronsAmount, int ConnectionsPerNeuron, float _LearningRate, string DatasetFilepath)
        {
            Neurons = new Neuron[NeuronsAmount];
            LearningRate = _LearningRate;
            Dataset = FileService.ReadFrom(DatasetFilepath);
            for (int i = 0; i < Neurons.Length; i++)
                Neurons[i] = new(ConnectionsPerNeuron);
        }
        public void AutoTest()
        {
            bool[] results = new bool[Neurons.Length];
            for (int i = 0; i < Dataset.Count; i++)
            {
                var answer = Test(Dataset[i].Signature);
                results[i] = answer == Dataset[i].Value;
                Debug.WriteLine("Test: " + Dataset[i].Value + ";" + " Answer: " + answer + ", Result: " + results[i] + ";");
            }
        }
        public void AutoTrain(int TrainingIteratinos)
        {
            for (int iteration = 0; iteration < TrainingIteratinos; iteration++)
                foreach(Character datasetItem in Dataset) Train(datasetItem);
        }

        public void Train(Character TrainCharacter)
        {
            for (int i = 0; i < Neurons.Length; i++)
            {
                float result = Neurons[i].ActivationFunction(TrainCharacter.Signature);
                float expectedResult = Dataset[i].Value == TrainCharacter.Value ? 1.0f : 0.0f;
                float delta = expectedResult - result;
                float editor = delta * LearningRate;
                Neurons[i].CorrectWeights(TrainCharacter.Signature, editor);
            }
        }

        public char Test(int[] TestData)
        {
            float maxValue = 0.0f;
            int neuronId = -1;
            for (int i = 0; i < Neurons.Length; i++)
            {
                float result = Neurons[i].ActivationFunction(TestData);
                if (result > maxValue)
                {
                    neuronId = i;
                    maxValue = result;
                }
            }
            if (neuronId == -1) return '-';
            return Dataset[neuronId].Value;
        }
    }
}
