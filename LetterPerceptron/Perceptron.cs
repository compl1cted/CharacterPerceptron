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
            
            var dataset = FileService.ReadFrom("../../../Dataset.txt");
            CorrespondingValues = new char[NeuronsAmount];
            for (int i = 0; i < CorrespondingValues.Length; i++)
                CorrespondingValues[i] = dataset[i].Value;
        }
        public void AutoTest()
        {
            var dataset = FileService.ReadFrom("../../../Dataset.txt");
            bool[] results = new bool[Neurons.Length];
            for (int i = 0; i < Neurons.Length; i++)
            {
                var answer = Test(dataset[i].Signature);
                results[i] = answer == dataset[i].Value;
                Debug.WriteLine(dataset[i].Value + ":" + dataset[i].Signature[8]);
            }
        }
        public void AutoTrain(int TrainingIteratinos)
        {
            var dataset = FileService.ReadFrom("../../../Dataset.txt");
            for (int iteration = 0; iteration < TrainingIteratinos; iteration++)
                foreach(Character datasetItem in dataset) Train(datasetItem);
        }

        public void Train(Character TrainCharacter)
        {
            for (int i = 0; i < Neurons.Length; i++)
            {
                float result = Neurons[i].ActivationFunction(TrainCharacter.Signature);
                if (result == 1 ^ CorrespondingValues[i] == TrainCharacter.Value)
                {
                    float expectedResult = CorrespondingValues[i] == TrainCharacter.Value ? 1.0f : 0.0f;
                    float delta = expectedResult - result;
                    float editor = delta * LearningRate;
                    Neurons[i].CorrectWeights(TrainCharacter.Signature, editor);
                }
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
            return CorrespondingValues[neuronId];
        }
    }
}
