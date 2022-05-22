using System.Text.RegularExpressions;

namespace RDK.Data.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Find and remove any special char, only letting numbers and letters in.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Same <see langword="string"/> without any special char.</returns>
        public static string RemoveSpecialChars(this string input) => string.IsNullOrEmpty(input) ? "No Aplica" : Regex.Replace(input, @"[^0-9a-zA-Z]", " ");

        /// <summary>
        /// Lower all other strings, except the first one on each word.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Same <see langword="string"/> all lower except the first one.</returns>
        public static string UpperOnEveryWord(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            char[] letters = input.ToLower().ToCharArray();
            int count = 0;
            bool isFirst = true;

            foreach (var str in input)// rafa el
            {
                if (!char.IsLetter(str) || !char.IsDigit(str))
                {
                    isFirst = true;
                    count++;
                    continue;
                }
                if (isFirst)
                {
                    letters[count] = char.ToUpper(letters[count]);
                    isFirst = false;
                }

                count++;
            }

            return new string(letters);
        }
    }
}
