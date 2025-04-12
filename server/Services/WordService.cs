using AutoMapper;
using EasyTalkForKids.Interfaces;
using EasyTalkForKids.Models;
using EasyTalkForKids.Validators;
using EasyTalkForKids_Database.Entities;

namespace EasyTalkForKids.Services
{
    public class WordService : IAddService<AddWordDto>, IGetService<GetWordDto>,
        IRemoveService<RemoveWordDto>
    {
        private readonly IRepository<Word> _wordRepository;
        private readonly IRepository<Lesson> _lessonRepository;
        private readonly IWordValidator _wordValidator;
        private readonly ILessonValidator _lessonValidator;
        private readonly INameValidator _nameValidator;
        private readonly IMapper _mapper;

        public WordService(IRepository<Word> wordRepository, IRepository<Lesson> lessonRepository, IWordValidator wordValidator, ILessonValidator lessonValidator, INameValidator nameValidator, IMapper mapper)
        {
            _wordRepository = wordRepository;
            _lessonRepository = lessonRepository;
            _wordValidator = wordValidator;
            _lessonValidator = lessonValidator;
            _nameValidator = nameValidator;
            _mapper = mapper;
        }

        public void Add(AddWordDto dto)
        {
            _wordValidator.ThrowIfPolishNameIsNull(dto.PolishName);
            _wordValidator.ThrowIfEnglishNameIsNull(dto.EnglishName);

            _nameValidator.ValidateName(dto.PolishName);
            _nameValidator.ValidateName(dto.EnglishName);

            var lesson = _lessonRepository.Get(dto.LessonId);

            _lessonValidator.ThrowIfLessonIsNull(lesson);

            dto.PolishName = dto.PolishName.ToLower();
            dto.EnglishName = dto.EnglishName.ToLower();

            var word = _mapper.Map<Word>(dto);

            _wordRepository.Add(word);
        }

        public List<GetWordDto> Get()
        {
            List<Word> words = _wordRepository.Get();

            var dto = _mapper.Map<List<GetWordDto>>(words);

            return dto;
        }

        public GetWordDto Get(int id)
        {
            Word? word = _wordRepository.Get(id);

            _wordValidator.ThrowIfWordIsNull(word);

            var dto = _mapper.Map<GetWordDto>(word);

            return dto;
        }

        public void Remove(int id)
        {
            Word? word = _wordRepository.Get(id);

            _wordValidator.ThrowIfWordIsNull(word);

            _wordRepository.Remove(word!);
        }
    }
}
