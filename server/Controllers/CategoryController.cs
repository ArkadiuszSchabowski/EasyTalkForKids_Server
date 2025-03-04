using EasyTalkForKids.Interfaces;
using EasyTalkForKids.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasyTalkForKids.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IAddService<AddCategoryDto> _addService;
        private readonly IGetService<GetCategoryDto> _getService;
        private readonly IRemoveService<RemoveCategoryDto> _removeService;

        public CategoryController(IAddService<AddCategoryDto> addService, IGetService<GetCategoryDto> getService, IRemoveService<RemoveCategoryDto> removeService)
        {
            _addService = addService;
            _getService = getService;
            _removeService = removeService;
        }

        [HttpGet]
        public ActionResult<List<GetCategoryDto>> Get()
        {
            List<GetCategoryDto> dto = _getService.Get();

            return dto;
        }


        [HttpPost]
        public ActionResult Add([FromBody] AddCategoryDto dto)
        {
            _addService.Add(dto);

            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult<AddCategoryDto> Get([FromRoute] int id)
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
