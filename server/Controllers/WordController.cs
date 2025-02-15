using EasyTalkForKids.Models;
using EasyTalkForKids_Server.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EasyTalkForKids.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordController : ControllerBase
    {
        private readonly IService<WordDto> _wordService;

        public WordController(IService<WordDto> wordService)
        {
            _wordService = wordService;
        }
        [HttpGet]
        public ActionResult<List<WordDto>> Get()
        {
            List<WordDto> words = _wordService.Get();

            return words;
        }

        [HttpGet("{id}")]
        public ActionResult<List<WordDto>> Get([FromRoute] int id)
        {
            List<WordDto> words = _wordService.Get(id);

            return words;
        }

        [HttpPost]
        public ActionResult Add([FromBody] WordDto dto)
        {
            _wordService.Add(dto);

            return Ok();
        }
    }
}
