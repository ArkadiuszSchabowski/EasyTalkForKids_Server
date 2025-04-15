using EasyTalkForKids.Interfaces;

namespace EasyTalkForKids.Formatters
{
    public class TextFormatter : ITextFormatter
    {
        public string NormalizeText(string text)
        {
            return text.Trim().ToLower();
        }
    }
}
