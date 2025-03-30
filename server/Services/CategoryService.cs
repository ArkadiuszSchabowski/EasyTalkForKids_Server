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
        private readonly INameValidator _nameValidator;
        private readonly ICategoryValidator _categoryValidator;
        private readonly IMapper _mapper;

        public CategoryService(IRepository<Category> repository, INameValidator nameValidator, ICategoryValidator categoryValidator, IMapper mapper)
        {
            _repository = repository;
            _nameValidator = nameValidator;
            _categoryValidator = categoryValidator;
            _mapper = mapper;
        }

        public void Add(AddCategoryDto dto)
        {
            _categoryValidator.ThrowIfPolishNameIsNull(dto.PolishName);
            _categoryValidator.ThrowIfEnglishNameIsNull(dto.EnglishName);

            _nameValidator.ValidateName(dto.PolishName);
            _nameValidator.ValidateName(dto.EnglishName);

            dto.PolishName = dto.PolishName.ToLower();
            dto.EnglishName = dto.EnglishName.ToLower();

            _categoryValidator.ThrowIfPolishNameExists(dto.PolishName);
            _categoryValidator.ThrowIfEnglishNameExists(dto.EnglishName);

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