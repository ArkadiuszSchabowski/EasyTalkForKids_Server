using EasyTalkForKids.Exceptions;
using EasyTalkForKids.Interfaces;
using System.Text.RegularExpressions;

namespace EasyTalkForKids.Validators
{
    public class NameValidator : INameValidator
    {
        public void ValidateName(string name)
        {
            if(name.Length < 3)
            {
                throw new BadRequestException("Nazwa nie może być krótsza niż 3 litery!");
            }

            if (name.Length > 25)
            {
                throw new BadRequestException("Nazwa nie może być dłuższa niż 25 liter!");
            }

            string pattern = "^[^0-9\\W_]+$";

            if (!Regex.IsMatch(name, pattern))
            {
                throw new BadRequestException("Nazwa nie może zawierać cyfr oraz znaków specjalnych!");
            } 
        }
        public void ValidateNameAllowingSpaces(string name)
        {
            if (name.Length < 3)
            {
                throw new BadRequestException("Nazwa nie może być krótsza niż 3 znaki!");
            }

            if (name.Length > 50)
            {
                throw new BadRequestException("Nazwa nie może być dłuższa niż 50 znaków!");
            }
        }
    }
}
