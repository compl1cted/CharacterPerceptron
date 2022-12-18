using System.Diagnostics;

namespace LetterPerceptron
{
    internal static class FileService
    {
        public static List<Character> ReadFrom(string Filepath)
        {
            using var Reader = new StreamReader(Filepath);
            {
                List<Character> characters = new();
                while (!Reader.EndOfStream)
                {
                    var line = Reader.ReadLine();
                    if (line == null) break;
                    var DatasetColumns = line.Split(',');
                    char Value = char.Parse(DatasetColumns[0]);

                    int[] Signature = new int[DatasetColumns[1].Length];
                    for (int i = 0; i < Signature.Length; i++)
                        Signature[i] = DatasetColumns[1][i];
                    characters.Add(new(Value, Signature));
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
