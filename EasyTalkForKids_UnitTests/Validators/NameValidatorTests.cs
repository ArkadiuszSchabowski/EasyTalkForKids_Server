using EasyTalkForKids.Exceptions;
using EasyTalkForKids.Validators;

namespace EasyTalkForKids_UnitTests.Validators
{
    [Trait("Category", "Unit")]
    public class NameValidatorTests
    {

        [Theory]
        [InlineData("house99")]
        [InlineData("11house")]
        [InlineData("7HO1USE9")]
        [InlineData("12345")]
        public void ValidateName_WithNumber_ShouldThrowBadRequestException(string name)
        {
            var validator = new NameValidator();

            Action action = () => validator.ValidateName(name);

            var exception = Assert.Throws<BadRequestException>(action);

            Assert.Equal("Nazwa nie może zawierać cyfr oraz znaków specjalnych!", exception.Message);
        }

        [Theory]
        [InlineData("small house")]
        [InlineData("@house")]
        [InlineData(" HOUSE ")]
        [InlineData("@X@^&A")]
        public void ValidateName_WithSpecialCharacter_ShouldThrowBadRequestException(string name)
        {
            var validator = new NameValidator();

            Action action = () => validator.ValidateName(name);

            var exception = Assert.Throws<BadRequestException>(action);

            Assert.Equal("Nazwa nie może zawierać cyfr oraz znaków specjalnych!", exception.Message);
        }
        [Theory]
        [InlineData("house")]
        [InlineData("APARTMENT")]
        [InlineData("Aeroplane")]
        [InlineData("Samochód")]
        public void ValidateName_WhenInputIsValid_ShouldNotThrowException(string name)
        {
            var validator = new NameValidator();

            var exception = Record.Exception(() => validator.ValidateName(name));

            Assert.Null(exception);
        }

        [Theory]
        [InlineData("")]
        [InlineData("a")]
        [InlineData("ab")]
        public void ValidateName_WhenNameIsTooShort_ShouldThrowBadRequestException(string name)
        {
            var validator = new NameValidator();

            var action = () => validator.ValidateName(name);

            var exception = Assert.Throws<BadRequestException>(action);

            Assert.Equal("Nazwa nie może być krótsza niż 3 litery!", exception.Message);
        }

        [Theory]
        [InlineData("VeryLongNameVeryLongNameVeryLongName")]
        [InlineData("ThisNameIsLongerThan25CharactersThisNameIsLongerThan25Characters")]

        public void ValidateName_WhenNameIsTooLong_ShouldThrowBadRequestException(string name)
        {
            var validator = new NameValidator();

            var action = () => validator.ValidateName(name);

            var exception = Assert.Throws<BadRequestException>(action);

            Assert.Equal("Nazwa nie może być dłuższa niż 25 liter!", exception.Message);
        }
        [Theory]
        [InlineData("Name with spaces")]
        [InlineData("NameWithoutSpaces")]
        [InlineData("TEST")]
        public void ValidateNameAllowingSpaces_WhenValidData_ShouldPass(string name)
        {
            var validator = new NameValidator();

            var exception = Record.Exception(() => validator.ValidateNameAllowingSpaces(name));

            Assert.Null(exception);
        }
    }
}
