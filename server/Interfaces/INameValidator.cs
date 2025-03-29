namespace EasyTalkForKids.Interfaces
{
    public interface INameValidator
    {
        public void ThrowIfNumbersOrSpecialCharacters(string name);
        public void ValidateNameLength(string name);
    }
}
