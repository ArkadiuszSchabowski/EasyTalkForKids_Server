using AutoMapper;
using EasyTalkForKids.Exceptions;
using EasyTalkForKids.Interfaces;
using EasyTalkForKids.Models;
using EasyTalkForKids_Database.Entities;
using EasyTalkForKids_Server.Interfaces;

namespace EasyTalkForKids.Services
{
    public class WordService : IService<WordDto>
    {
        private readonly IRepository<Word> _repository;
        private readonly IRepository<Lesson> _lessonRepository;
        private readonly IMapper _mapper;

        public WordService(IRepository<Word> repository, IRepository<Lesson> lessonRepository,IMapper mapper)
        {
            _repository = repository;
            _lessonRepository = lessonRepository;
            _mapper = mapper;
        }

        public void Add(WordDto dto)
        {
            var lesson = _lessonRepository.Get(dto.LessonId);

            if(lesson == null)
            {
                throw new NotFoundException("Nie znaleziono lekcji o takim numerze Id");
            }

            var word = _mapper.Map<Word>(dto);

            _repository.Add(word);
        }

        public List<WordDto> Get()
        {
            List<Word> words = _repository.Get();

            var dto = _mapper.Map<List<WordDto>>(words);

            return dto;
        }

        public WordDto Get(int id)
        {
            Word? word = _repository.Get(id);

            if (word == null)
            {
                throw new NotFoundException("Nie znaleziono słowa o takim numerze Id!");
            }

            var dto = _mapper.Map<WordDto>(word);

            return dto;
        }

        public void Remove(int id)
        {
            Word? word = _repository.Get(id);

            if(word == null)
            {
                throw new NotFoundException("Nie znaleziono słowa o takim numerze Id!");
            }

            _repository.Remove(word);
        }
    }
}
