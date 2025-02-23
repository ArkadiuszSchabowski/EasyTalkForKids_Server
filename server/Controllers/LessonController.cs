using EasyTalkForKids.Models;
using EasyTalkForKids_Server.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EasyTalkForKids.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly IService<LessonDto> _service;

        public LessonController(IService<LessonDto> service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<LessonDto>> Get()
        {
            List<LessonDto> dto = _service.Get();

            return dto;
        }


        [HttpPost]
        public ActionResult Add([FromBody] LessonDto dto)
        {
            _service.Add(dto);

            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult<LessonDto> Get([FromRoute] int id)
        {
            var dto = _service.Get(id);

            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public ActionResult Remove([FromRoute] int id)
        {
            _service.Remove(id);

            return NoContent();
        }
    }
}
