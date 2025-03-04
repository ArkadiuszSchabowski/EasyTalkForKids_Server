using EasyTalkForKids.Interfaces;
using EasyTalkForKids.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasyTalkForKids.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly IAddService<AddTopicDto> _addService;
        private readonly IGetService<GetTopicDto> _getService;
        private readonly IRemoveService<RemoveTopicDto> _removeService;

        public TopicController(IAddService<AddTopicDto> addService, IGetService<GetTopicDto> getService, IRemoveService<RemoveTopicDto> removeService)
        {
            _addService = addService;
            _getService = getService;
            _removeService = removeService;
        }

        [HttpGet]
        public ActionResult<List<GetTopicDto>> Get()
        {
            List<GetTopicDto> dto = _getService.Get();

            return dto;
        }


        [HttpPost]
        public ActionResult Add([FromBody] AddTopicDto dto)
        {
            _addService.Add(dto);

            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult<AddTopicDto> Get([FromRoute] int id)
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
