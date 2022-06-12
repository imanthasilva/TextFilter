using TextFilter.Interfaces;

namespace TextFilter.Models.Filters
{
    public class ContainsLetterTFilter :  IFilter
    {
        public string FilterWord(string word)
        {
            return word.ToLower().Contains("t") ? string.Empty : word;
        }
    }
}