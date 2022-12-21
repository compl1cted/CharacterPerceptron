namespace LetterPerceptron
{
    internal static class FileService
    {
        public static List<Character> ReadFrom(string Filepath)
        {
            using var reader = new StreamReader(Filepath);
            {
                List<Character> characters = new();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line == null) break;
                    var datasetColumns = line.Split(',');
                    char value = char.Parse(datasetColumns[0]);

                    int[] Signature = new int[datasetColumns[1].Length];
                    for (int i = 0; i < Signature.Length; i++)
                        Signature[i] = datasetColumns[1][i] - '0';
                    characters.Add(new(value, Signature));
                }
                return characters;
            }
        }

        //This method was used to create Dataset
        //public static void WriteTo(string Filepath, Character Char)
        //{
        //    var FileString = new StringBuilder();
        //    string StringSignature = String.Empty;
        //    foreach(int Number in Char.Signature)
        //    {
        //        StringSignature += Number;
        //    }
        //    var newLine = string.Format("{0},{1}{2}", Char.Value, StringSignature, Environment.NewLine);
        //    FileString.Append(newLine);

        //    File.AppendAllText(Filepath, FileString.ToString());
        //}
    }
}
