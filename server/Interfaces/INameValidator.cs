namespace EasyTalkForKids.Interfaces
{
    public interface INameValidator
    {
        public void ValidateName(string name);
        public void ValidateNameAllowingSpaces(string name);
    }
}
