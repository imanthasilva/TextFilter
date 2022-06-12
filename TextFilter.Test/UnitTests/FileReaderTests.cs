using System.IO;
using Moq;
using TextFilter.Models;
using Xunit;

namespace TextFilter.Test.UnitTests
{
    public class FileReaderTests
    {
        [Fact]
        public void ShouldThrowExceptionWhenFileNotFound()
        {
            var fileReaderMock = new Mock<FileReader>();
            fileReaderMock.CallBase = true;
            fileReaderMock.Setup(x => x.GetFilePath())
                .Throws(new FileNotFoundException());

            Assert.Throws<FileNotFoundException>(() => fileReaderMock.Object.ReadLines());
        }
    }
}
