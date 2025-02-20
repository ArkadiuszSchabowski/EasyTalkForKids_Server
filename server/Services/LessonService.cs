using AutoMapper;
using EasyTalkForKids.Interfaces;
using EasyTalkForKids.Models;
using EasyTalkForKids_Database.Entities;
using EasyTalkForKids_Server.Interfaces;

namespace EasyTalkForKids.Services
{
    public class LessonService : IService<LessonDto>
    {
        private readonly IRepository<Lesson> _repository;
        private readonly IMapper _mapper;

        public LessonService(IRepository<Lesson> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Add(LessonDto dto)
        {
            var lesson = _mapper.Map<Lesson>(dto);

            lesson.Id = 0;

            _repository.Add(lesson);
        }

        public List<LessonDto> Get()
        {
            List<Lesson> lessons = _repository.Get();

            var dto = _mapper.Map<List<LessonDto>>(lessons);

            return dto;
        }

        public LessonDto Get(int id)
        {
            Lesson? lesson = _repository.Get(id);

            if (lesson == null)
            {
                throw new Exception("Nie znaleziono lekcji o podanym Id!");
            }

            var dto = _mapper.Map<LessonDto>(lesson);

            return dto;
        }

        public void Remove(int id)
        {
            Lesson? lesson = _repository.Get(id);

            if (lesson == null)
            {
                throw new Exception("Nie znaleziono lekcji o podanym Id!");
            }

            _repository.Remove(lesson);
        }
    }
}