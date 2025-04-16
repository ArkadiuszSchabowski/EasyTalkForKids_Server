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
        private readonly Mock<IRepository<Category>> _mockCategoryRepository;
        private readonly Mock<INameRepository<Category>> _mockNameRepository;
        private readonly Mock<INameValidator> _mockNameValidator;
        private readonly Mock<ICategoryValidator> _mockCategoryValidator;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<ITextFormatter> _mockTextFormatter;
        public CategoryServiceTests()
        {
            _mockCategoryRepository = new Mock<IRepository<Category>>();
            _mockNameRepository = new Mock<INameRepository<Category>>();
            _mockNameValidator = new Mock<INameValidator>();
            _mockCategoryValidator = new Mock<ICategoryValidator>();
            _mockMapper = new Mock<IMapper>();
            _mockTextFormatter = new Mock<ITextFormatter>();
        }
        [Fact]
        public void Add_WhenCorrectData_ShouldPassCategoryToRepository()
        {
            var categoryService = new CategoryService(_mockCategoryRepository.Object, _mockNameRepository.Object, _mockCategoryValidator.Object, _mockNameValidator.Object, _mockMapper.Object, _mockTextFormatter.Object);

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

            _mockMapper.Setup(x => x.Map<Category>(dto)).Returns(category);   

            categoryService.Add(dto);

            _mockCategoryRepository.Verify(x => x.Add(category), Times.Once);
        }
    }
}