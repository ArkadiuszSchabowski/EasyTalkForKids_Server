using AutoMapper;
using EasyTalkForKids.Interfaces;
using EasyTalkForKids.Models;
using EasyTalkForKids_Database.Entities;
using EasyTalkForKids_Server.Interfaces;

namespace EasyTalkForKids.Services
{
    public class WordService : IService<WordDto>
    {
        private readonly IRepository<Word> _repository;
        private readonly IMapper _mapper;

        public WordService(IRepository<Word> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Add(WordDto dto)
        {
            var word = _mapper.Map<Word>(dto);
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
                throw new Exception("Nie znaleziono słowa o podanym Id!");
            }

            var dto = _mapper.Map<WordDto>(word);

            return dto;
        }

        public void Remove(int id)
        {
            Word? word = _repository.Get(id);

            if(word == null)
            {
                throw new Exception("Nie znaleziono słowa o podanym Id!");
            }

            _repository.Remove(word);
        }
    }
}
