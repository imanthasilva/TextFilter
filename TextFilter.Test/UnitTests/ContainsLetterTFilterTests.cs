using TextFilter.Models.Filters;
using Xunit;

namespace TextFilter.Test.UnitTests
{
    public class ContainsLetterTFilterTests
    {
        [Fact]
        public void ShouldFilterWhenWordContainsLetterT()
        {
            var filer = new ContainsLetterTFilter();
            var result = filer.FilterWord("at");
            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void ShouldNotFilterWhenWordDoesNotContainsLetterT()
        {
            var word = "as";
            var filer = new ContainsLetterTFilter();
            var result = filer.FilterWord(word);
            Assert.Equal(word, result);
        }
    }
}