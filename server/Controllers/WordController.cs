using EasyTalkForKids.Interfaces;
using EasyTalkForKids.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasyTalkForKids.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordController : ControllerBase
    {
        private readonly IAddService<AddWordDto> _addService;
        private readonly IGetService<GetWordDto> _getService;
        private readonly IRemoveService<RemoveWordDto> _removeService;

        public WordController(IAddService<AddWordDto> addService, IGetService<GetWordDto> getService, IRemoveService<RemoveWordDto> removeService)
        {
            _addService = addService;
            _getService = getService;
            _removeService = removeService;
        }

        [HttpGet]
        public ActionResult<List<GetWordDto>> Get()
        {
            List<GetWordDto> words = _getService.Get();

            return words;
        }


        [HttpPost]
        public ActionResult Add([FromBody] AddWordDto dto)
        {
            _addService.Add(dto);

            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult<GetWordDto> Get([FromRoute] int id)
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
