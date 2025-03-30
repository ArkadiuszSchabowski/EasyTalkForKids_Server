using AutoMapper;
using EasyTalkForKids.Interfaces;
using EasyTalkForKids.Models;
using EasyTalkForKids.Services;
using EasyTalkForKids.Validators;
using EasyTalkForKids_Database.Entities;
using Moq;

namespace EasyTalkForKids_UnitTests.Services
{
    [Trait("Category", "Unit")]
    public class LessonServiceTests
    {
        private readonly Mock<IRepository<Lesson>> _mockRepository;
        private readonly Mock<INameValidator> _mockNameValidator;
        private readonly Mock<ILessonValidator> _mockLessonValidator;
        private readonly Mock<IMapper> _mockMapper;

        public LessonServiceTests()
        {
            _mockRepository = new Mock<IRepository<Lesson>>();
            _mockNameValidator = new Mock<INameValidator>();
            _mockLessonValidator = new Mock<ILessonValidator>();
            _mockMapper = new Mock<IMapper>();
        }
        [Fact]
        public void Add_WhenCorrectData_ShouldPassLessonToRepository()
        {
            var lessonService = new LessonService(_mockRepository.Object, _mockNameValidator.Object, _mockLessonValidator.Object, _mockMapper.Object);

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

            _mockLessonValidator.Setup(x => x.ThrowIfPolishNameIsNull(dto.PolishName));
            _mockLessonValidator.Setup(x => x.ThrowIfEnglishNameIsNull(dto.EnglishName));

            _mockNameValidator.Setup(x => x.ValidateNameAllowingSpaces(dto.PolishName));
            _mockNameValidator.Setup(x => x.ValidateNameAllowingSpaces(dto.EnglishName));

            _mockLessonValidator.Setup(x => x.ThrowIfCategoryIdDoesNotExists(dto.CategoryId));

            _mockMapper.Setup(x => x.Map<Lesson>(dto)).Returns(lesson);

            lessonService.Add(dto);

            _mockRepository.Verify(x => x.Add(lesson), Times.Once);
        }
        [Fact]
        public void Add_WhenPolishNameContainsUppercaseLetters_ShouldConvertToLowercase()
        {
            var lessonService = new LessonService(_mockRepository.Object, _mockNameValidator.Object, _mockLessonValidator.Object, _mockMapper.Object);

            var dto = new AddLessonDto
            {
                PolishName = "LeKCJa 1",
                EnglishName = "lesson 1"
            };

            _mockLessonValidator.Setup(x => x.ThrowIfPolishNameIsNull(dto.PolishName));
            _mockLessonValidator.Setup(x => x.ThrowIfEnglishNameIsNull(dto.EnglishName));

            _mockNameValidator.Setup(x => x.ValidateNameAllowingSpaces(dto.PolishName));
            _mockNameValidator.Setup(x => x.ValidateNameAllowingSpaces(dto.EnglishName));

            _mockLessonValidator.Setup(x => x.ThrowIfCategoryIdDoesNotExists(dto.CategoryId));

            lessonService.Add(dto);

            Assert.Equal("lekcja 1", dto.PolishName);
        }

        [Fact]
        public void Add_WhenEnglishNameContainsUppercaseLetters_ShouldConvertToLowercase()
        {
            var lessonService = new LessonService(_mockRepository.Object, _mockNameValidator.Object, _mockLessonValidator.Object, _mockMapper.Object);

            var dto = new AddLessonDto
            {
                PolishName = "lekcja 1",
                EnglishName = "LEsSon 1"
            };

            _mockLessonValidator.Setup(x => x.ThrowIfPolishNameIsNull(dto.PolishName));
            _mockLessonValidator.Setup(x => x.ThrowIfEnglishNameIsNull(dto.EnglishName));

            _mockNameValidator.Setup(x => x.ValidateNameAllowingSpaces(dto.PolishName));
            _mockNameValidator.Setup(x => x.ValidateNameAllowingSpaces(dto.EnglishName));

            _mockLessonValidator.Setup(x => x.ThrowIfCategoryIdDoesNotExists(dto.CategoryId));

            lessonService.Add(dto);

            Assert.Equal("lesson 1", dto.EnglishName);
        }
    }
}
