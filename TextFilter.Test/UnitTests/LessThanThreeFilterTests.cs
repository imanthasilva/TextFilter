using TextFilter.Models.Filters;
using Xunit;

namespace TextFilter.Test.UnitTests
{
    public class LessThanThreeFilterTests
    {
        [Fact]
        public void ShouldFilterWordWhenLessThanThreeLetter()
        {
            var filer = new LessThanThreeFilter();
            var result = filer.FilterWord("at");
            Assert.Equal(string.Empty, result);
        }
        [Fact]
        public void ShouldNotFilterWordWhenLessThanThreeLetter()
        {
            var october = "october";
            var filer = new LessThanThreeFilter();
            var result = filer.FilterWord(october);
            Assert.Equal(october, result);
        }
    }
}