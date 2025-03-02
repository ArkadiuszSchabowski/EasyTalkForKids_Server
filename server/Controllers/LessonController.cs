using EasyTalkForKids.Interfaces;
using EasyTalkForKids.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasyTalkForKids.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly IAddService<AddLessonDto> _addService;
        private readonly IGetService<GetLessonDto> _getService;
        private readonly IRemoveService<RemoveLessonDto> _removeService;

        public LessonController(IAddService<AddLessonDto> addService, IGetService<GetLessonDto> getService, IRemoveService<RemoveLessonDto> removeService)
        {
            _addService = addService;
            _getService = getService;
            _removeService = removeService;
        }

        [HttpGet]
        public ActionResult<List<GetLessonDto>> Get()
        {
            List<GetLessonDto> dto = _getService.Get();

            return dto;
        }


        [HttpPost]
        public ActionResult Add([FromBody] AddLessonDto dto)
        {
            _addService.Add(dto);

            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult<GetLessonDto> Get([FromRoute] int id)
        {
            var dto = _getService.Get(id);

            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public ActionResult Remove([FromRoute] int id)
        {
            _removeService.Remove(id);

            return NoContent();
        }
    }
}
