#nullable disable

using EasyTalkForKids.Exceptions;
using EasyTalkForKids.Validators;
using EasyTalkForKids_Database.Entities;

namespace EasyTalkForKids_UnitTests.Validators
{
    [Trait("Category", "Unit")]
    public class LessonValidatorTests
    {
        [Theory]
        [InlineData("Lekcja 1: zwierzęta")]
        [InlineData("Lekcja 2: pojazdy")]
        [InlineData("Lekcja 3: rodzina")]
        [InlineData("Lekcja 99: słownictwo")]
        public void ThrowIfPolishNameIsNullOrEmpty_WhenIsCorrect_ShouldNotThrowException(string name)
        {
            var lessonValidator = new LessonValidator();

            var exception = Record.Exception(() => lessonValidator.ThrowIfPolishNameIsNullOrEmpty(name));

            Assert.Null(exception);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ThrowIfPolishNameIsNullOrEmpty_WhenIsNullOrEmpty_ShouldThrowBadRequestException(string name)
        {
            var lessonValidator = new LessonValidator();

            Action action = () => lessonValidator.ThrowIfPolishNameIsNullOrEmpty(name);

            var exception = Assert.Throws<BadRequestException>(action);

            Assert.Equal("Polska nazwa lekcji jest wymagana!", exception.Message);
        }

        [Theory]
        [InlineData("Lesson 1: animals")]
        [InlineData("Lesson 2: vehicles")]
        [InlineData("Lesson 3: family")]
        [InlineData("Lesson 109: wild animals")]
        public void ThrowIfEnglishNameIsNullOrEmpty_WhenIsCorrect_ShouldNotThrowException(string name)
        {
            var lessonValidator = new LessonValidator();

            var exception = Record.Exception(() => lessonValidator.ThrowIfEnglishNameIsNullOrEmpty(name));

            Assert.Null(exception);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ThrowIfEnglishNameIsNullOrEmpty_WhenIsNullOrEmpty_ShouldThrowBadRequestException(string name)
        {
            var lessonValidator = new LessonValidator();

            Action action = () => lessonValidator.ThrowIfEnglishNameIsNullOrEmpty(name);

            var exception = Assert.Throws<BadRequestException>(action);

            Assert.Equal("Angielska nazwa lekcji jest wymagana!", exception.Message);
        }

        [Fact]
        public void ThrowIfLessonIsNull_WhenIsNotNull_ShouldNotThrowException()
        {
            var lessonValidator = new LessonValidator();

            var lesson = new Lesson
            {
                Id = 1,
                PolishName = "Lekcja 1: Zwierzęta",
                EnglishName = "Lesson 1: Animals"
            };

            var exception = Record.Exception(() => lessonValidator.ThrowIfLessonIsNull(lesson));

            Assert.Null(exception);
        }

        [Fact]
        public void ThrowIfLessonIsNull_WhenIsNull_ShouldThrowNotFoundException()
        {
            var lessonValidator = new LessonValidator();

            Lesson? lesson = null;

            Action action = () => lessonValidator.ThrowIfLessonIsNull(lesson);

            var exception = Assert.Throws<NotFoundException>(action);

            Assert.Equal("Nie znaleziono lekcji o takim numerze Id!", exception.Message);
        }
    }
}
