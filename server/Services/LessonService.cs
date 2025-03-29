using AutoMapper;
using EasyTalkForKids.Exceptions;
using EasyTalkForKids.Interfaces;
using EasyTalkForKids.Models;
using EasyTalkForKids.Repositories;
using EasyTalkForKids_Database.Entities;

namespace EasyTalkForKids.Services
{
    public class LessonService : IAddService<AddLessonDto>, IGetService<GetLessonDto>, IRemoveService<RemoveLessonDto>
    {
        private readonly IRepository<Lesson> _repository;
        private readonly INameValidator _nameValidator;
        private readonly ILessonValidator _lessonValidator;
        private readonly IMapper _mapper;
        

        public LessonService(IRepository<Lesson> repository, INameValidator nameValidator, ILessonValidator lessonValidator, IMapper mapper)
        {
            _repository = repository;
            _lessonValidator = lessonValidator;
            _mapper = mapper;
            _nameValidator = nameValidator;
        }

        public void Add(AddLessonDto dto)
        {
            _lessonValidator.ThrowIfPolishNameIsNull(dto.PolishName);
            _lessonValidator.ThrowIfEnglishNameIsNull(dto.EnglishName);

            _nameValidator.ThrowIfNumbersOrSpecialCharacters(dto.PolishName);
            _nameValidator.ThrowIfNumbersOrSpecialCharacters(dto.EnglishName);

            _nameValidator.ValidateNameLength(dto.PolishName);
            _nameValidator.ValidateNameLength(dto.EnglishName);

            _lessonValidator.ThrowIfCategoryIdDoesNotExists(dto.CategoryId);

            dto.PolishName = dto.PolishName.ToLower();
            dto.EnglishName = dto.EnglishName.ToLower();

            var lesson = _mapper.Map<Lesson>(dto);

            _repository.Add(lesson);
        }

        public List<GetLessonDto> Get()
        {
            List<Lesson> lessons = _repository.Get();

            var dto = _mapper.Map<List<GetLessonDto>>(lessons);

            return dto;
        }

        public GetLessonDto Get(int id)
        {
            Lesson? lesson = _repository.Get(id);

            if (lesson == null)
            {
                throw new NotFoundException("Nie znaleziono lekcji o takim numerze Id!");
            }

            var dto = _mapper.Map<GetLessonDto>(lesson);

            return dto;
        }

        public void Remove(int id)
        {
            Lesson? lesson = _repository.Get(id);

            if (lesson == null)
            {
                throw new NotFoundException("Nie znaleziono lekcji o takim numerze Id!");
            }

            _repository.Remove(lesson);
        }
    }
}