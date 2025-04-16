#nullable disable

using EasyTalkForKids.Exceptions;
using EasyTalkForKids.Interfaces;
using EasyTalkForKids.Validators;
using EasyTalkForKids_Database.Entities;
using Moq;

namespace EasyTalkForKids_UnitTests.Validators
{

    [Trait("Category", "Unit")]
    public class CategoryValidatorTests
    {
        [Theory]
        [InlineData("zwierzęta")]
        [InlineData("POJAZDY")]
        [InlineData("czasowniki")]
        [InlineData("Przedmioty domowe")]
        public void ThrowIfPolishNameIsNullOrEmpty_WhenIsCorrect_ShouldNotThrowException(string name)
        {
            var categoryValidator = new CategoryValidator();

            var exception = Record.Exception(() => categoryValidator.ThrowIfPolishNameIsNullOrEmpty(name));

            Assert.Null(exception);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ThrowIfPolishNameIsNullOrEmpty_WhenIsNullOrEmpty_ShouldThrowBadRequestException(string? name)
        {
            var categoryValidator = new CategoryValidator();

            Action action = () => categoryValidator.ThrowIfPolishNameIsNullOrEmpty(name);

            var exception = Assert.Throws<BadRequestException>(action);

            Assert.Equal("Polska nazwa kategorii jest wymagana!", exception.Message);
        }

        [Theory]
        [InlineData("pets")]
        [InlineData("FAMILY")]
        [InlineData("Clothes")]
        [InlineData("Wild animals")]
        public void ThrowIfEnglishNameIsNullOrEmpty_WhenIsCorrect_ShouldNotThrowException(string name)
        {
            var categoryValidator = new CategoryValidator();

            var exception = Record.Exception(() => categoryValidator.ThrowIfEnglishNameIsNullOrEmpty(name));

            Assert.Null(exception);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ThrowIfEnglishNameIsNullOrEmpty_WhenIsNullOrEmpty_ShouldThrowBadRequestException(string? name)
        {
            var categoryValidator = new CategoryValidator();

            Action action = () => categoryValidator.ThrowIfEnglishNameIsNullOrEmpty(name);

            var exception = Assert.Throws<BadRequestException>(action);

            Assert.Equal("Angielska nazwa kategorii jest wymagana!", exception.Message);
        }

        [Fact]
        public void ThrowIfPolishNameExists_WhenNameDoesNotExist_ShouldNotThrowException()
        {
            var categoryValidator = new CategoryValidator();

            Category? category = null;

            var exception = Record.Exception(() => categoryValidator.ThrowIfPolishNameExists(category));

            Assert.Null(exception);
        }

        [Fact]
        public void ThrowIfEnglishNameExists_WhenNameDoesNotExist_ShouldNotThrowException()
        {
            var categoryValidator = new CategoryValidator();

            Category? category = null;

            var exception = Record.Exception(() => categoryValidator.ThrowIfEnglishNameExists(category));

            Assert.Null(exception);
        }

        [Fact]
        public void ThrowIfPolishNameExists_WhenPolishNameExistsInDb_ShouldThrowConflictException()
        {
            var categoryValidator = new CategoryValidator();

            var category = new Category
            {
                Id = 1,
                PolishName = "samochody",
                EnglishName = "cars"
            };

            Action action = () => categoryValidator.ThrowIfPolishNameExists(category);

            var exception = Assert.Throws<ConflictException>(action);

            Assert.Equal("Polska nazwa kategorii istnieje już w bazie danych!", exception.Message);
        }

        [Fact]
        public void ThrowIfEnglishNameExists_WhenEnglishNameExistsInDb_ShouldThrowConflictException()
        {
            var categoryValidator = new CategoryValidator();

            var category = new Category
            {
                Id = 1,
                PolishName = "ubrania",
                EnglishName = "clothes"
            };

            Action action = () => categoryValidator.ThrowIfEnglishNameExists(category);

            var exception = Assert.Throws<ConflictException>(action);

            Assert.Equal("Angielska nazwa kategorii istnieje już w bazie danych!", exception.Message);
        }
    }
}