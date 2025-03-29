﻿using EasyTalkForKids.Exceptions;
using EasyTalkForKids.Interfaces;
using EasyTalkForKids_Database.Entities;

namespace EasyTalkForKids.Validators
{
    public class LessonValidator : ILessonValidator
    {
        private readonly IRepository<Category> _categoryRepository;

        public LessonValidator(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void ThrowIfPolishNameIsNull(string name)
        {
            if (name == null)
            {
                throw new BadRequestException("Polska nazwa lekcji jest wymagana!");
            }
        }

        public void ThrowIfEnglishNameIsNull(string name)
        {
            if (name == null)
            {
                throw new BadRequestException("Angielska nazwa lekcji jest wymagana!");
            }
        }
        public void ThrowIfCategoryIdDoesNotExists(int id)
        {
            var category = _categoryRepository.Get(id);

            if (category != null)
            {
                throw new ConflictException("Kategoria o podanym id nie została znaleziona!");
            }
        }
    }
}
