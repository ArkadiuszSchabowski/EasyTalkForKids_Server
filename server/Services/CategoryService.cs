using AutoMapper;
using EasyTalkForKids.Exceptions;
using EasyTalkForKids.Interfaces;
using EasyTalkForKids.Models;
using EasyTalkForKids_Database.Entities;

namespace EasyTalkForKids.Services
{
    public class CategoryService : IAddService<AddCategoryDto>, IGetService<GetCategoryDto>, IRemoveService<RemoveCategoryDto>
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly ICategoryValidator _categoryValidator;
        private readonly INameValidator _nameValidator;
        private readonly IMapper _mapper;

        public CategoryService(IRepository<Category> categoryRepository, ICategoryValidator categoryValidator, INameValidator nameValidator, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _categoryValidator = categoryValidator;
            _nameValidator = nameValidator;
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

            _categoryRepository.Add(category);
        }

        public List<GetCategoryDto> Get()
        {
            List<Category> categories = _categoryRepository.Get();

            var dto = _mapper.Map<List<GetCategoryDto>>(categories);

            return dto;
        }

        public GetCategoryDto Get(int id)
        {
            Category? category = _categoryRepository.Get(id);

            _categoryValidator.ThrowIfCategoryIsNull(category);

            var dto = _mapper.Map<GetCategoryDto>(category);

            return dto;
        }

        public void Remove(int id)
        {
            Category? category = _categoryRepository.Get(id);

            _categoryValidator.ThrowIfCategoryIsNull(category);

            _categoryRepository.Remove(category!);
        }
    }
}