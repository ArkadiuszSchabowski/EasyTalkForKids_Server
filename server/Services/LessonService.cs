using AutoMapper;
using EasyTalkForKids.Interfaces;
using EasyTalkForKids.Models;
using EasyTalkForKids_Database.Entities;

namespace EasyTalkForKids.Services
{
    public class LessonService : IAddService<AddLessonDto>, IGetService<GetLessonDto>, IRemoveService<RemoveLessonDto>
    {
        private readonly IRepository<Lesson> _lessonRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly ILessonValidator _lessonValidator;
        private readonly ICategoryValidator _categoryValidator;
        private readonly INameValidator _nameValidator;
        private readonly IMapper _mapper;

        public LessonService(IRepository<Lesson> lessonRepository, IRepository<Category> categoryRepository, ILessonValidator lessonValidator, ICategoryValidator categoryValidator, INameValidator nameValidator, IMapper mapper)
        {
            _lessonRepository = lessonRepository;
            _categoryRepository = categoryRepository;
            _lessonValidator = lessonValidator;
            _categoryValidator = categoryValidator;
            _nameValidator = nameValidator;
            _mapper = mapper;
        }

        public void Add(AddLessonDto dto)
        {
            _lessonValidator.ThrowIfPolishNameIsNull(dto.PolishName);
            _lessonValidator.ThrowIfEnglishNameIsNull(dto.EnglishName);

            _nameValidator.ValidateNameAllowingSpaces(dto.PolishName);
            _nameValidator.ValidateNameAllowingSpaces(dto.EnglishName);

            var category = _categoryRepository.Get(dto.CategoryId);

            _categoryValidator.ThrowIfCategoryIsNull(category);

            dto.PolishName = dto.PolishName.ToLower();
            dto.EnglishName = dto.EnglishName.ToLower();

            var lesson = _mapper.Map<Lesson>(dto);

            _lessonRepository.Add(lesson);
        }

        public List<GetLessonDto> Get()
        {
            List<Lesson> lessons = _lessonRepository.Get();

            var dto = _mapper.Map<List<GetLessonDto>>(lessons);

            return dto;
        }

        public GetLessonDto Get(int id)
        {
            Lesson? lesson = _lessonRepository.Get(id);

            _lessonValidator.ThrowIfLessonIsNull(lesson);

            var dto = _mapper.Map<GetLessonDto>(lesson);

            return dto;
        }

        public void Remove(int id)
        {
            Lesson? lesson = _lessonRepository.Get(id);

            _lessonValidator.ThrowIfLessonIsNull(lesson);

            _lessonRepository.Remove(lesson!);
        }
    }
}