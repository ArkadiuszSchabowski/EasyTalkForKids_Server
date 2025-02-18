using EasyTalkForKids.Models;
using EasyTalkForKids_Server.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EasyTalkForKids.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordController : ControllerBase
    {
        private readonly IService<WordDto> _service;

        public WordController(IService<WordDto> service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<WordDto>> Get()
        {
            List<WordDto> words = _service.Get();

            return words;
        }


        [HttpPost]
        public ActionResult Add([FromBody] WordDto dto)
        {
            _service.Add(dto);

            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult<WordDto> Get([FromRoute] int id)
        {
            var dto = _service.Get(id);

            return Ok(dto);
        }

        [HttpDelete("{Id}")]
        public ActionResult Remove([FromRoute] int id)
        {
            _service.Remove(id);

            return NoContent();
        }
    }
}
