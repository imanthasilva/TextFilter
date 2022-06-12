using TextFilter.Interfaces;

namespace TextFilter.Models.Filters
{
    public class LessThanThreeFilter :  IFilter
    {
        public string FilterWord(string word)
        {
            return word.Length < 3 ? string.Empty : word;
        }
    }
}