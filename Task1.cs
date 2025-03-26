using System.Text;

namespace Cleverence
{
    public static class Task1
    {
        public static string Compress(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            StringBuilder result = new StringBuilder();
            int count = 1;

            for (int i = 1; i <= input.Length; i++)
            {
                if (i < input.Length && input[i] == input[i - 1])
                {
                    count++;
                }
                else
                {
                    result.Append(input[i - 1]);

                    if (count > 1)
                        result.Append(count);

                    count = 1;
                }
            }

            return result.ToString();
        }

        public static string Decompress(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                char letter = input[i];
                int count = 1;

                if (i + 1 < input.Length && char.IsDigit(input[i + 1]))
                {
                    count = int.Parse(input[i + 1].ToString());
                    i++;
                }

                result.Append(letter, count);
            }

            return result.ToString();
        }
    }
}
