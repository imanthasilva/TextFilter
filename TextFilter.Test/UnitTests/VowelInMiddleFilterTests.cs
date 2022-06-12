using TextFilter.Models.Filters;
using Xunit;

namespace TextFilter.Test.UnitTests
{
    public class VowelInMiddleFilterTests
    {
        [Fact]
        public void ShouldFilterWordWhenVowelInMiddle()
        {
            var filer = new VowelInMiddleFilter();

            var result = filer.FilterWord("what");
            Assert.Equal(string.Empty, result);

            var result2 = filer.FilterWord("clean");
            Assert.Equal(string.Empty, result2);

            var result3 = filer.FilterWord("currently");
            Assert.Equal(string.Empty, result3);
        }

        [Fact]
        public void ShouldNotFilterWordWhenVowelInMiddle()
        {
            var filer = new VowelInMiddleFilter();
            var result = filer.FilterWord("the");
            Assert.Equal("the", result);

            var result2 = filer.FilterWord("rather");
            Assert.Equal("rather", result2);

            var result3 = filer.FilterWord("middle");
            Assert.Equal("middle", result3);
        }
    }
}