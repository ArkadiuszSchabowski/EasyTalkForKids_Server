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
        private readonly Mock<IRepositoryCategory> _mockRepositoryCategory;
        public CategoryValidatorTests()
        {
            _mockRepositoryCategory = new Mock<IRepositoryCategory>();
        }
        [Fact]
        public void ThrowIfPolishNameIsNull_WhenIsNotNull_ShouldNotThrowException()
        {
            var categoryValidator = new CategoryValidator(_mockRepositoryCategory.Object);

            string name = "samochody";

            var exception = Record.Exception(() => categoryValidator.ThrowIfPolishNameIsNull(name));

            Assert.Null(exception);
        }

        [Fact]
        public void ThrowIfPolishNameIsNull_WhenIsNull_ShouldThrowBadRequestException()
        {
            var categoryValidator = new CategoryValidator(_mockRepositoryCategory.Object);

            string name = null;

            Action action = () => categoryValidator.ThrowIfPolishNameIsNull(name);

            var exception = Assert.Throws<BadRequestException>(action);

            Assert.Equal("Polska nazwa kategorii jest wymagana!", exception.Message);
        }

        [Fact]
        public void ThrowIfEnglishNameIsNull_WhenIsNotNull_ShouldNotThrowException()
        {
            var categoryValidator = new CategoryValidator(_mockRepositoryCategory.Object);

            string name = "cars";

            var exception = Record.Exception(() => categoryValidator.ThrowIfEnglishNameIsNull(name));

            Assert.Null(exception);
        }

        [Fact]
        public void ThrowIfEnglishNameIsNull_WhenIsNull_ShouldThrowBadRequestException()
        {
            var categoryValidator = new CategoryValidator(_mockRepositoryCategory.Object);

            string name = null;

            Action action = () => categoryValidator.ThrowIfEnglishNameIsNull(name);

            var exception = Assert.Throws<BadRequestException>(action);

            Assert.Equal("Angielska nazwa kategorii jest wymagana!", exception.Message);
        }

        [Fact]
        public void ThrowIfPolishNameExists_WhenNameDoesNotExist_ShouldNotThrowException()
        {
            var categoryValidator = new CategoryValidator(_mockRepositoryCategory.Object);

            string name = "samochody";

            _mockRepositoryCategory.Setup(x => x.GetByPolishName(name)).Returns((Category)null);

            var exception = Record.Exception(() => categoryValidator.ThrowIfPolishNameExists(name));

            Assert.Null(exception);
        }

        [Fact]
        public void ThrowIfEnglishNameExists_WhenNameDoesNotExist_ShouldNotThrowException()
        {
            var categoryValidator = new CategoryValidator(_mockRepositoryCategory.Object);

            string name = "cars";

            _mockRepositoryCategory.Setup(x => x.GetByEnglishName(name)).Returns((Category)null);

            var exception = Record.Exception(() => categoryValidator.ThrowIfEnglishNameExists(name));

            Assert.Null(exception);
        }

        [Fact]
        public void ThrowIfPolishNameExists_WhenPolishNameExistsInDb_ShouldThrowConflictException()
        {
            var categoryValidator = new CategoryValidator(_mockRepositoryCategory.Object);

            string name = "samochody";

            var category = new Category
            {
                Id = 1,
                PolishName = "samochody",
                EnglishName = "cars"
            };

            _mockRepositoryCategory.Setup(x => x.GetByPolishName(name)).Returns(category);

            Action action = () => categoryValidator.ThrowIfPolishNameExists(name);

            var exception = Assert.Throws<ConflictException>(action);

            Assert.Equal("Polska nazwa kategorii isnieje już w bazie danych!", exception.Message);
        }

        [Fact]
        public void ThrowIfEnglishNameExists_WhenEnglishNameExistsInDb_ShouldThrowConflictException()
        {
            var categoryValidator = new CategoryValidator(_mockRepositoryCategory.Object);

            string name = "ubrania";

            var category = new Category
            {
                Id = 1,
                PolishName = "ubrania",
                EnglishName = "clothes"
            };

            _mockRepositoryCategory.Setup(x => x.GetByEnglishName(name)).Returns(category);

            Action action = () => categoryValidator.ThrowIfEnglishNameExists(name);

            var exception = Assert.Throws<ConflictException>(action);

            Assert.Equal("Angielska nazwa kategorii isnieje już w bazie danych!", exception.Message);
        }
    }
}