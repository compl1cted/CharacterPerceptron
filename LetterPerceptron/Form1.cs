namespace LetterPerceptron
{
    public partial class Form1 : Form
    {
        private const int MatrixColumns = 5;
        private const int MatrixRows = 7;
        private readonly Button[,] ButtonMatrix = new Button[MatrixColumns, MatrixRows];
        private readonly Perceptron NeuralNet = new(36, MatrixColumns * MatrixRows, 0.00001f);
        public Form1()
        {
            InitializeComponent();
            GenerateButtonMatrix();
        }

        private void TestButtonClick(object sender, EventArgs e)
        {
            char result = NeuralNet.Test(GetInput());
            OutputLabel.Text = result.ToString();
        }

        private void TrainButtonClick(object sender, EventArgs e)
        {
            try
            {
                Character chararacter = new(char.Parse(CharacterInput.Text), GetInput());
                NeuralNet.Train(chararacter);
            }
            catch (FormatException exception)
            {
                OutputLabel.Text = exception.Message;
            }
        }

        private void AutoTrainButtonClick(object sender, EventArgs e)
        {
            NeuralNet.AutoTrain(1000);
        }

        private void MatrixButtonClick(object? sender, EventArgs e)
        {
            Button? button = sender as Button;
            if (button == null) return;
            button.BackColor = button.BackColor != Color.Black ? Color.Black : Color.White;
        }

        private int[] GetInput()
        {
            int counter = 0;
            int[] matrixValues = new int[MatrixColumns * MatrixRows];
            for (int i = 0; i < MatrixRows; i++)
            {
                for (int j = 0; j < MatrixColumns; j++)
                {
                    matrixValues[counter] = ButtonMatrix[j, i].BackColor == Color.Black ? 1 : 0;
                    counter++;
                }
            }
            return matrixValues;
        }

        private void GenerateButtonMatrix()
        {
            for (int y = 0; y < MatrixColumns; y++)
            {
                for (int x = 0; x < MatrixRows; x++)
                {
                    ButtonMatrix[y, x] = new()
                    {
                        Size = new Size(50, 50),
                        Location = new Point(y * 50 + 275, x * 50 + 120),
                    };
                    ButtonMatrix[y, x].Click += MatrixButtonClick;
                    Controls.Add(ButtonMatrix[y, x]);
                }
            }
        }
    }
}