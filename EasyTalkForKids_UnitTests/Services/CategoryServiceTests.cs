using AutoMapper;
using EasyTalkForKids.Interfaces;
using EasyTalkForKids.Models;
using EasyTalkForKids.Services;
using EasyTalkForKids_Database.Entities;
using Moq;

namespace EasyTalkForKids_UnitTests.Services
{
    [Trait("Category", "Unit")]
    public class CategoryServiceTests
    {
        private readonly Mock<IRepository<Category>> _mockRepository;
        private readonly Mock<INameValidator> _mockNameValidator;
        private readonly Mock<ICategoryValidator> _mockCategoryValidator;
        private readonly Mock<IMapper> _mockMapper;
        public CategoryServiceTests()
        {
            _mockRepository = new Mock<IRepository<Category>>();
            _mockNameValidator = new Mock<INameValidator>();
            _mockCategoryValidator = new Mock<ICategoryValidator>();
            _mockMapper = new Mock<IMapper>();
        }
        [Fact]
        public void Add_WhenCorrectData_ShouldPassCategoryToRepository()
        {
            var categoryService = new CategoryService(_mockRepository.Object, _mockNameValidator.Object, _mockCategoryValidator.Object ,_mockMapper.Object);

            var dto = new AddCategoryDto()
            {
                PolishName = "zwierzęta",
                EnglishName = "animals"
            };

            var category = new Category()
            {
                PolishName = "zwierzęta",
                EnglishName = "animals"
            };

            _mockCategoryValidator.Setup(x => x.ThrowIfPolishNameIsNull(dto.PolishName));
            _mockCategoryValidator.Setup(x => x.ThrowIfEnglishNameIsNull(dto.EnglishName));

            _mockNameValidator.Setup(x => x.ValidateName(dto.PolishName));
            _mockNameValidator.Setup(x => x.ValidateName(dto.EnglishName));

            _mockCategoryValidator.Setup(x => x.ThrowIfPolishNameExists(dto.PolishName));
            _mockCategoryValidator.Setup(x => x.ThrowIfEnglishNameExists(dto.EnglishName));

            _mockMapper.Setup(x => x.Map<Category>(dto)).Returns(category);   

            categoryService.Add(dto);

            _mockRepository.Verify(x => x.Add(category), Times.Once);
        }

        [Fact]
        public void Add_WhenPolishNameContainsUppercaseLetters_ShouldConvertToLowercase()
        {
            var categoryService = new CategoryService(_mockRepository.Object, _mockNameValidator.Object, _mockCategoryValidator.Object, _mockMapper.Object);

            var dto = new AddCategoryDto
            {
                PolishName = "KOT",
                EnglishName = "cat"
            };

            _mockCategoryValidator.Setup(x => x.ThrowIfPolishNameIsNull(dto.PolishName));
            _mockCategoryValidator.Setup(x => x.ThrowIfEnglishNameIsNull(dto.EnglishName));

            _mockNameValidator.Setup(x => x.ValidateName(dto.PolishName));
            _mockNameValidator.Setup(x => x.ValidateName(dto.EnglishName));

            _mockCategoryValidator.Setup(x => x.ThrowIfPolishNameExists(dto.PolishName));
            _mockCategoryValidator.Setup(x => x.ThrowIfEnglishNameExists(dto.EnglishName));

            _mockMapper.Setup(x => x.Map<Category>(dto));

            categoryService.Add(dto);

            Assert.Equal("kot", dto.PolishName);
        }

        [Fact]
        public void Add_WhenEnglishNameContainsUppercaseLetters_ShouldConvertToLowercase()
        {
            var categoryService = new CategoryService(_mockRepository.Object, _mockNameValidator.Object, _mockCategoryValidator.Object, _mockMapper.Object);

            var dto = new AddCategoryDto
            {
                PolishName = "kot",
                EnglishName = "CAT"
            };

            _mockCategoryValidator.Setup(x => x.ThrowIfPolishNameIsNull(dto.PolishName));
            _mockCategoryValidator.Setup(x => x.ThrowIfEnglishNameIsNull(dto.EnglishName));

            _mockNameValidator.Setup(x => x.ValidateName(dto.PolishName));
            _mockNameValidator.Setup(x => x.ValidateName(dto.EnglishName));

            _mockCategoryValidator.Setup(x => x.ThrowIfPolishNameExists(dto.PolishName));
            _mockCategoryValidator.Setup(x => x.ThrowIfEnglishNameExists(dto.EnglishName));

            _mockMapper.Setup(x => x.Map<Category>(dto));

            categoryService.Add(dto);

            Assert.Equal("cat", dto.EnglishName);
        }
    }
}