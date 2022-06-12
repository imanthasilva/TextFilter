using System.Text.RegularExpressions;

namespace TextFilter.ExtensionMethods
{
    public static class IsCharExtension
    {
        public static bool IsEnglishLetter(this char c)
        {
            return Regex.IsMatch(c.ToString(), "[a-z]", RegexOptions.IgnoreCase);
        }
    }
}