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
        private readonly IRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public LessonService(IRepository<Lesson> repository, IRepository<Category> categoryRepository, IMapper mapper)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public void Add(AddLessonDto dto)
        {
            var category = _categoryRepository.Get(dto.CategoryId);

            if (category == null)
            {
                throw new NotFoundException("Nie znaleziono kategorii o takim numerze Id!");
            }

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