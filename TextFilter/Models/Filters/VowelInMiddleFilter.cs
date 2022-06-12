using System.Linq;
using TextFilter.Interfaces;

namespace TextFilter.Models.Filters
{
    public class VowelInMiddleFilter : IFilter
    {
        private  readonly char[] _vowels = { 'a', 'i', 'u', 'e', 'o', 'A', 'I', 'U', 'E', 'O' };
        public string FilterWord(string word)
        {
            int offset = 1 - word.Length % 2;
            var middle = word.Substring(word.Length / 2 - offset, 1 + offset);

            var containsVowels = middle.ToCharArray().Any(c => _vowels.Contains(c));
            if (containsVowels)
            {
                return string.Empty;
            }
            else
            {
                return word;
            }
        }

    }
}