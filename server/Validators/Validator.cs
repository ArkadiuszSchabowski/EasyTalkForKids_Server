﻿using EasyTalkForKids.Exceptions;
using EasyTalkForKids.Interfaces;
using System.Text.RegularExpressions;

namespace EasyTalkForKids.Validators
{
    public class Validator : IValidator
    {
        public void ThrowIfNumbersOrSpecialCharacters(string name)
        {
            string pattern = "^[^0-9\\W_]+$";

            if (!Regex.IsMatch(name, pattern))
            {
                throw new BadRequestException("Nazwa nie może zawierać cyfr oraz znaków specjalnych!");
            } 
        }

        public void ValidateNameLength(string name)
        {
            if(name.Length < 3)
            {
                throw new BadRequestException("Nazwa nie może być krótsza niż 3 litery!");
            }

            if (name.Length > 25)
            {
                throw new BadRequestException("Nazwa nie może być dłuższa niż 25 liter!");
            }
        }
    }
}
