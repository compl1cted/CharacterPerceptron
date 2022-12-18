namespace LetterPerceptron
{
    internal class Character
    {
        public readonly char Value;
        public readonly int[] Signature = new int[35];

        public Character(char _Value, int[] _Signature)
        {
            Value = _Value;
            Signature = _Signature;
        }
    }
}
