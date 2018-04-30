using System;
namespace TextUtility
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "Hello World";
            string s2 = "Hello. How are you?";
            Console.WriteLine("Distance: {0}", LevenshteinDistance.Compute(s1, s2));

            string original = s2;
            string encoded = TextUtil.EncodeTo64(original);
            Console.WriteLine("Encoded: {0}", encoded);
            Console.WriteLine("Decoded: {0}", TextUtil.DecodeFrom64(encoded));
        }
    }
}
