using System.Collections.Generic;
using System.Linq;
using Moq;
using TextFilter.Interfaces;
using TextFilter.Models;
using Xunit;

namespace TextFilter.Test.UnitTests
{
    public class WorkerTests
    {
        [Fact]
        public void ShouldBeEmptyWhenLessThanThreeFilterApplies()
        {
            var fileReader = new Mock<IReader>();
            var word = "FakeWord";
            var lessThanThreeFilter =new Mock<IFilter>();
            lessThanThreeFilter.Setup(x => x.FilterWord(word)).Returns(string.Empty);
            var containsTFilter = new Mock<IFilter>();
            containsTFilter.Setup(x => x.FilterWord(word)).Returns(word);
            var vowelInMiddleFilter = new Mock<IFilter>();
            vowelInMiddleFilter.Setup(x => x.FilterWord(word)).Returns(word);

            IEnumerable<IFilter> filters = new List<IFilter>()
            {
                lessThanThreeFilter.Object,
                containsTFilter.Object,
                vowelInMiddleFilter.Object
            };
            var worker = new Worker(fileReader.Object, filters);
            Assert.Equal(string.Empty,worker.ApplyFilters(word));
        }

        [Fact]
        public void ShouldBeEmptyWhenContainsLetterTFilterApplies()
        {
            var fileReader = new Mock<IReader>();
            var word = "FakeWord";
            var lessThanThreeFilter = new Mock<IFilter>();
            lessThanThreeFilter.Setup(x => x.FilterWord(word)).Returns(word);
            var containsTFilter = new Mock<IFilter>();
            containsTFilter.Setup(x => x.FilterWord(word)).Returns(string.Empty);
            var vowelInMiddleFilter = new Mock<IFilter>();
            vowelInMiddleFilter.Setup(x => x.FilterWord(word)).Returns(word);

            IEnumerable<IFilter> filters = new List<IFilter>()
            {
                lessThanThreeFilter.Object,
                containsTFilter.Object,
                vowelInMiddleFilter.Object
            };
            var worker = new Worker(fileReader.Object, filters);
            Assert.Equal(string.Empty, worker.ApplyFilters(word));
        }

        [Fact]
        public void ShouldBeEmptyWhenVowelInMiddleFilterApplies()
        {
            var fileReader = new Mock<IReader>();
            var word = "FakeWord";
            var lessThanThreeFilter = new Mock<IFilter>();
            lessThanThreeFilter.Setup(x => x.FilterWord(word)).Returns(word);
            var containsTFilter = new Mock<IFilter>();
            containsTFilter.Setup(x => x.FilterWord(word)).Returns(word);
            var vowelInMiddleFilter = new Mock<IFilter>();
            vowelInMiddleFilter.Setup(x => x.FilterWord(word)).Returns(string.Empty);

            IEnumerable<IFilter> filters = new List<IFilter>()
            {
                lessThanThreeFilter.Object,
                containsTFilter.Object,
                vowelInMiddleFilter.Object
            };
            var worker = new Worker(fileReader.Object, filters);
            Assert.Equal(string.Empty, worker.ApplyFilters(word));
        }
        [Fact]
        public void ShouldReturnWordWhenNoFilterApplies()
        {
            var fileReader = new Mock<IReader>();
            var word = "FakeWord";
            var lessThanThreeFilter = new Mock<IFilter>();
            lessThanThreeFilter.Setup(x => x.FilterWord(word)).Returns(word);
            var containsTFilter = new Mock<IFilter>();
            containsTFilter.Setup(x => x.FilterWord(word)).Returns(word);
            var vowelInMiddleFilter = new Mock<IFilter>();
            vowelInMiddleFilter.Setup(x => x.FilterWord(word)).Returns(word);

            IEnumerable<IFilter> filters = new List<IFilter>()
            {
                lessThanThreeFilter.Object,
                containsTFilter.Object,
                vowelInMiddleFilter.Object
            };
            var worker = new Worker(fileReader.Object, filters);
            Assert.Equal(word, worker.ApplyFilters(word));
        }

        [Fact]
        public void ShouldGetWordsSeparatedFromLine()
        {
            var filters = new Mock<IEnumerable<IFilter>>();
            var fileReader = new Mock<IReader>();
            var worker = new Worker(fileReader.Object, filters.Object);

            var result =
                worker.GetWordsSeparated(
                    "to itself, 'Oh dear! Oh dear! I shall be late!' (when she thought it over afterwards, it");
            var expected = new List<Word>()
            {
                new Word(){Text = "to",IsWord = true},
                new Word(){Text = " ",IsWord = false},
                new Word(){Text = "itself",IsWord = true},
                new Word(){Text = ", '",IsWord = false},
                new Word(){Text = "Oh",IsWord = true},
                new Word(){Text = " ",IsWord = false},
                new Word(){Text = "dear",IsWord = true},
                new Word(){Text = "! ",IsWord = false},
                new Word(){Text = "Oh",IsWord = true},
                new Word(){Text = " ",IsWord = false},
                new Word(){Text = "dear",IsWord = true},
                new Word(){Text = "! ",IsWord = false},
                new Word(){Text = "I",IsWord = true},
                new Word(){Text = " ",IsWord = false},
                new Word(){Text = "shall",IsWord = true},
                new Word(){Text = " ",IsWord = false},
                new Word(){Text = "be",IsWord = true},
                new Word(){Text = " ",IsWord = false},
                new Word(){Text = "late",IsWord = true},
                new Word(){Text = "!' (",IsWord = false},
                new Word(){Text = "when",IsWord = true},
                new Word(){Text = " ",IsWord = false},
                new Word(){Text = "she",IsWord = true},
                new Word(){Text = " ",IsWord = false},
                new Word(){Text = "thought",IsWord = true},
                new Word(){Text = " ",IsWord = false},
                new Word(){Text = "it",IsWord = true},
                new Word(){Text = " ",IsWord = false},
                new Word(){Text = "over",IsWord = true},
                new Word(){Text = " ",IsWord = false},
                new Word(){Text = "afterwards",IsWord = true},
                new Word(){Text = ", ",IsWord = false},
                new Word(){Text = "it",IsWord = true},
            };
           Assert.Equal(expected.Select(x=>x.Text),result.Select(x=>x.Text));
           Assert.Equal(expected.Select(x => x.IsWord), result.Select(x => x.IsWord));
        }
    }
}
