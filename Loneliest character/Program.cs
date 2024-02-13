namespace Loneliest_character
{
    internal class Program
    {
        public static char[] Loneliest(string result)
        {
            result = result.Trim(); // Remove leading and trailing spaces

            Dictionary<char, int> spacesCount = new Dictionary<char, int>();

            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] != ' ')
                {
                    int left = 0, right = 0;

                    int j = i - 1;
                    while (j >= 0 && result[j] == ' ')
                    {
                        left++;
                        j--;
                    }

                    j = i + 1;
                    while (j < result.Length && result[j] == ' ')
                    {
                        right++;
                        j++;
                    }

                    spacesCount[result[i]] = left + right;
                }
            }

            int maxSpaces = spacesCount.Values.Max();

            return spacesCount.Where(pair => pair.Value == maxSpaces).Select(pair => pair.Key).ToArray();
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Loneliest("a b  c"));
        }
    }
}