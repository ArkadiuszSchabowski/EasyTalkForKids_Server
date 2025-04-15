using AutoMapper;
using EasyTalkForKids.Interfaces;
using EasyTalkForKids.Models;
using EasyTalkForKids.Services;
using EasyTalkForKids_Database.Entities;
using Moq;

namespace EasyTalkForKids_UnitTests.Services
{
    [Trait("Category", "Unit")]
    public class WordServiceTests
    {
        private readonly Mock<IRepository<Word>> _mockWordRepository;
        private readonly Mock<IRepository<Lesson>> _mockLessonRepository;
        private readonly Mock<IWordValidator> _mockWordValidator;
        private readonly Mock<ILessonValidator> _mockLessonValidator;
        private readonly Mock<INameValidator> _mockNameValidator;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<ITextFormatter> _mockTextFormatter;
        public WordServiceTests()
        {
            _mockWordRepository = new Mock<IRepository<Word>>();
            _mockLessonRepository = new Mock<IRepository<Lesson>>();
            _mockWordValidator = new Mock<IWordValidator>();
            _mockLessonValidator = new Mock<ILessonValidator>();
            _mockNameValidator = new Mock<INameValidator>();
            _mockMapper = new Mock<IMapper>();
            _mockTextFormatter = new Mock<ITextFormatter>();
        }
        [Fact]
        public void Add_WhenCorrectData_ShouldPassWordToRepository()
        {
            var wordService = new WordService(_mockWordRepository.Object, _mockLessonRepository.Object, _mockWordValidator.Object, _mockLessonValidator.Object, _mockNameValidator.Object, _mockMapper.Object, _mockTextFormatter.Object);

            var dto = new AddWordDto()
            {
                PolishName = "Samochód",
                EnglishName = "Car",
                LessonId = 1
            };

            var lesson = new Lesson();
            var word = new Word();

            _mockLessonRepository.Setup(x => x.Get(dto.LessonId)).Returns(lesson);
            _mockMapper.Setup(x => x.Map<Word>(dto)).Returns(word);

            wordService.Add(dto);

            _mockWordRepository.Verify(x => x.Add(word), Times.Once);
        }
    }
}
