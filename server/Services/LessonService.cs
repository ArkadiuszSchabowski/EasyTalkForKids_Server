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
        private readonly ITextFormatter _textFormatter;

        public LessonService(IRepository<Lesson> lessonRepository, IRepository<Category> categoryRepository, ILessonValidator lessonValidator, ICategoryValidator categoryValidator, INameValidator nameValidator, IMapper mapper, ITextFormatter textFormatter)
        {
            _lessonRepository = lessonRepository;
            _categoryRepository = categoryRepository;
            _lessonValidator = lessonValidator;
            _categoryValidator = categoryValidator;
            _nameValidator = nameValidator;
            _mapper = mapper;
            _textFormatter = textFormatter;
        }

        public void Add(AddLessonDto dto)
        {
            dto.PolishName = _textFormatter.NormalizeText(dto.PolishName);
            dto.EnglishName = _textFormatter.NormalizeText(dto.EnglishName);

            _lessonValidator.ThrowIfPolishNameIsNullOrEmpty(dto.PolishName);
            _lessonValidator.ThrowIfEnglishNameIsNullOrEmpty(dto.EnglishName);

            _nameValidator.ValidateNameAllowingSpaces(dto.PolishName);
            _nameValidator.ValidateNameAllowingSpaces(dto.EnglishName);

            var category = _categoryRepository.Get(dto.CategoryId);

            _categoryValidator.ThrowIfCategoryIsNull(category);


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