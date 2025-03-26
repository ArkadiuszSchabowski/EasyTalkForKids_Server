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
        private readonly Mock<IValidator> _mockValidator;
        private readonly Mock<ICategoryValidator> _mockCategoryValidator;
        private readonly Mock<IMapper> _mockMapper;
        public CategoryServiceTests()
        {
            _mockRepository = new Mock<IRepository<Category>>();
            _mockValidator = new Mock<IValidator>();
            _mockCategoryValidator = new Mock<ICategoryValidator>();
            _mockMapper = new Mock<IMapper>();
        }
        [Fact]
        public void Add_WhenCorrectData_ShouldPassCategoryToRepository()
        {
            var categoryService = new CategoryService(_mockRepository.Object, _mockValidator.Object, _mockCategoryValidator.Object ,_mockMapper.Object);

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

            _mockValidator.Setup(x => x.ThrowIfNumbersOrSpecialCharacters(dto.PolishName));
            _mockValidator.Setup(x => x.ThrowIfNumbersOrSpecialCharacters(dto.EnglishName));

            _mockValidator.Setup(x => x.ValidateNameLength(dto.PolishName));
            _mockValidator.Setup(x => x.ValidateNameLength(dto.EnglishName));

            _mockCategoryValidator.Setup(x => x.ThrowIfPolishNameExists(dto.PolishName));
            _mockCategoryValidator.Setup(x => x.ThrowIfEnglishNameExists(dto.EnglishName));

            _mockMapper.Setup(x => x.Map<Category>(dto)).Returns(category);   

            categoryService.Add(dto);

            _mockRepository.Verify(x => x.Add(category), Times.Once);
        }

        [Fact]
        public void Add_WhenPolishNameContainsUppercaseLetters_ShouldConvertToLowercase()
        {
            var categoryService = new CategoryService(_mockRepository.Object, _mockValidator.Object, _mockCategoryValidator.Object, _mockMapper.Object);

            var dto = new AddCategoryDto
            {
                PolishName = "KOT",
                EnglishName = "cat"
            };

            _mockValidator.Setup(x => x.ThrowIfNumbersOrSpecialCharacters(dto.PolishName));
            _mockValidator.Setup(x => x.ThrowIfNumbersOrSpecialCharacters(dto.EnglishName));

            _mockValidator.Setup(x => x.ValidateNameLength(dto.PolishName));
            _mockValidator.Setup(x => x.ValidateNameLength(dto.EnglishName));

            _mockCategoryValidator.Setup(x => x.ThrowIfPolishNameExists(dto.PolishName));
            _mockCategoryValidator.Setup(x => x.ThrowIfEnglishNameExists(dto.EnglishName));

            _mockMapper.Setup(x => x.Map<Category>(dto));

            categoryService.Add(dto);

            Assert.Equal("kot", dto.PolishName);
        }

        [Fact]
        public void Add_WhenEnglishNameContainsUppercaseLetters_ShouldConvertToLowercase()
        {
            var categoryService = new CategoryService(_mockRepository.Object, _mockValidator.Object, _mockCategoryValidator.Object, _mockMapper.Object);

            var dto = new AddCategoryDto
            {
                PolishName = "kot",
                EnglishName = "CAT"
            };

            _mockValidator.Setup(x => x.ThrowIfNumbersOrSpecialCharacters(dto.PolishName));
            _mockValidator.Setup(x => x.ThrowIfNumbersOrSpecialCharacters(dto.EnglishName));

            _mockValidator.Setup(x => x.ValidateNameLength(dto.PolishName));
            _mockValidator.Setup(x => x.ValidateNameLength(dto.EnglishName));

            _mockCategoryValidator.Setup(x => x.ThrowIfPolishNameExists(dto.PolishName));
            _mockCategoryValidator.Setup(x => x.ThrowIfEnglishNameExists(dto.EnglishName));

            _mockMapper.Setup(x => x.Map<Category>(dto));

            categoryService.Add(dto);

            Assert.Equal("cat", dto.EnglishName);
        }
    }
}