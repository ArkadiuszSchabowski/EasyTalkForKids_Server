using EasyTalkForKids.Formatters;

namespace EasyTalkForKids_UnitTests.Formatters
{
    [Trait("Category", "Unit")]
    public class TextFormatterTests
    {
        [Theory]
        [InlineData("     TEXT", "text")]
        [InlineData("sIMple texT", "simple text")]
        [InlineData(" SIMPLE TEXT   ", "simple text")]
        [InlineData("This text CONTAINS UPPER letTers", "this text contains upper letters")]
        [InlineData(" x7G81 ", "x7g81")]
        [InlineData(" Zwierzę DOMOWE  ", "zwierzę domowe")]
        [InlineData("personal DaTA  ", "personal data")]
        public void NormalizeText_WhenCalled_ReturnsTextToLowerCaseAndRemoveEmptySpace(string text, string expectedText)
        {
            var textFormater = new TextFormatter();

            var result = textFormater.NormalizeText(text);

            Assert.Equal(expectedText, result);
        }
    }
}
