using AutoMapper;
using EasyTalkForKids.Interfaces;
using EasyTalkForKids.Models;
using EasyTalkForKids.Services;
using EasyTalkForKids_Database.Entities;
using Moq;

namespace EasyTalkForKids_UnitTests.Services
{
    [Trait("Category", "Unit")]
    public class LessonServiceTests
    {
        private readonly Mock<IRepository<Lesson>> _mocklessonRepository;
        private readonly Mock<INameValidator> _mockNameValidator;
        private readonly Mock<ILessonValidator> _mockLessonValidator;
        private readonly Mock<ICategoryValidator> _mockCategoryValidator;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IRepository<Category>> _mockCategoryRepository;
        private readonly Mock<ITextFormatter> _mockTextFormatter;

        public LessonServiceTests()
        {
            _mocklessonRepository = new Mock<IRepository<Lesson>>();
            _mockCategoryRepository = new Mock<IRepository<Category>>();
            _mockLessonValidator = new Mock<ILessonValidator>();
            _mockCategoryValidator = new Mock<ICategoryValidator>();
            _mockNameValidator = new Mock<INameValidator>();
            _mockMapper = new Mock<IMapper>();
            _mockTextFormatter = new Mock<ITextFormatter>();
        }
        [Fact]
        public void Add_WhenCorrectData_ShouldPassLessonToRepository()
        {
            var lessonService = new LessonService(_mocklessonRepository.Object, _mockCategoryRepository.Object, _mockLessonValidator.Object, _mockCategoryValidator.Object, _mockNameValidator.Object, _mockMapper.Object, _mockTextFormatter.Object);

            var dto = new AddLessonDto()
            {
                PolishName = "Lekcja 1",
                EnglishName = "Lesson 1",
                CategoryId = 1
            };

            var lesson = new Lesson()
            {
                Id = 1,
                PolishName = "Lekcja 1",
                EnglishName = "Lesson 1",
                CategoryId = 1
            };

            var category = new Category();

            _mockCategoryRepository.Setup(x =>x.Get(dto.CategoryId)).Returns(category);

            _mockMapper.Setup(x => x.Map<Lesson>(dto)).Returns(lesson);

            lessonService.Add(dto);

            _mocklessonRepository.Verify(x => x.Add(lesson), Times.Once);
        }
    }
}
