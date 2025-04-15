#nullable disable

using EasyTalkForKids.Exceptions;
using EasyTalkForKids.Validators;
using EasyTalkForKids_Database.Entities;

namespace EasyTalkForKids_UnitTests.Validators
{
    [Trait("Category", "Unit")]
    public class WordValidatorTests
    {
        [Theory]
        [InlineData("samochód")]
        [InlineData("Samochód Osobowy")]
        [InlineData("KOŁO ZAPASOWE")]
        [InlineData("Dach")]
        public void ThrowIfPolishNameIsNullOrEmpty_WhenIsCorrect_ShouldNotThrowException(string name)
        {
            var wordValidator = new WordValidator();

            var exception = Record.Exception(() => wordValidator.ThrowIfPolishNameIsNullOrEmpty(name));

            Assert.Null(exception);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ThrowIfPolishNameIsNullOrEmpty_WhenIsNullOrEmpty_ShouldThrowBadRequestException(string name)
        {
            var wordValidator = new WordValidator();

            Action action = () => wordValidator.ThrowIfPolishNameIsNullOrEmpty(name);

            var exception = Assert.Throws<BadRequestException>(action);

            Assert.Equal("Polska nazwa słowa jest wymagana!", exception.Message);
        }

        [Theory]
        [InlineData("peanut butter")]
        [InlineData("ICE CREAM")]
        [InlineData("Banana")]
        [InlineData("Swimming Pool")]
        public void ThrowIfEnglishNameIsNullOrEmpty_WhenIsCorrect_ShouldNotThrowException(string name)
        {
            var wordValidator = new WordValidator();

            var exception = Record.Exception(() => wordValidator.ThrowIfEnglishNameIsNullOrEmpty(name));

            Assert.Null(exception);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ThrowIfEnglishNameIsNullOrEmpty_WhenIsNullOrEmpty_ShouldThrowBadRequestException(string name)
        {
            var wordValidator = new WordValidator();

            Action action = () => wordValidator.ThrowIfEnglishNameIsNullOrEmpty(name);

            var exception = Assert.Throws<BadRequestException>(action);

            Assert.Equal("Angielska nazwa słowa jest wymagana!", exception.Message);
        }

        [Fact]
        public void ThrowIfWordIsNull_WhenIsNotNull_ShouldNotThrowException()
        {
            var wordValidator = new WordValidator();

            var word = new Word
            {
                Id = 1,
                PolishName = "dom",
                EnglishName = "house"
            };

            var exception = Record.Exception(() => wordValidator.ThrowIfWordIsNull(word));

            Assert.Null(exception);
        }

        [Fact]
        public void ThrowIfWordIsNull_WhenIsNull_ShouldThrowNotFoundException()
        {
            var wordValidator = new WordValidator();

            Word? word = null;

            Action action = () => wordValidator.ThrowIfWordIsNull(word);

            var exception = Assert.Throws<NotFoundException>(action);

            Assert.Equal("Nie znaleziono słowa o takim numerze Id!", exception.Message);
        }
    }
}
