namespace EasyTalkForKids.Interfaces
{
    public interface IValidator
    {
        public void ThrowIfNumbersOrSpecialCharacters(string name);
        public void ValidateNameLength(string name);
    }
}
