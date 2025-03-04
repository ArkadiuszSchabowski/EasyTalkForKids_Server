using AutoMapper;
using EasyTalkForKids.Exceptions;
using EasyTalkForKids.Interfaces;
using EasyTalkForKids.Models;
using EasyTalkForKids_Database.Entities;

namespace EasyTalkForKids.Services
{
    public class CategoryService : IAddService<AddCategoryDto>, IGetService<GetCategoryDto>, IRemoveService<RemoveCategoryDto>
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public CategoryService(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Add(AddCategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);

            _repository.Add(category);
        }

        public List<GetCategoryDto> Get()
        {
            List<Category> categories = _repository.Get();

            var dto = _mapper.Map<List<GetCategoryDto>>(categories);

            return dto;
        }

        public GetCategoryDto Get(int id)
        {
            Category? category = _repository.Get(id);

            if (category == null)
            {
                throw new NotFoundException("Nie znaleziono kategorii o takim numerze Id!");
            }

            var dto = _mapper.Map<GetCategoryDto>(category);

            return dto;
        }

        public void Remove(int id)
        {
            Category? category = _repository.Get(id);

            if (category == null)
            {
                throw new NotFoundException("Nie znaleziono kategorii o takim numerze Id!");
            }

            _repository.Remove(category);
        }
    }
}