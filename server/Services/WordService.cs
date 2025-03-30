using AutoMapper;
using EasyTalkForKids.Interfaces;
using EasyTalkForKids.Models;
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
        private readonly IMapper _mapper;

        public WordService(IRepository<Word> wordRepository, IRepository<Lesson> lessonRepository, IWordValidator wordValidator, ILessonValidator lessonValidator, IMapper mapper)
        {
            _wordRepository = wordRepository;
            _lessonRepository = lessonRepository;
            _wordValidator = wordValidator;
            _lessonValidator = lessonValidator;
            _mapper = mapper;
        }

        public void Add(AddWordDto dto)
        {
            var lesson = _lessonRepository.Get(dto.LessonId);

            _lessonValidator.ThrowIfLessonIsNull(lesson);

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
