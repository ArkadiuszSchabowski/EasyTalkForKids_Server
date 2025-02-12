using EasyTalkForKids.Models;
using EasyTalkForKids_Server.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EasyTalkForKids.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordController : ControllerBase
    {
        private readonly IWord _wordService;

        public WordController(IWord wordService)
        {
            _wordService = wordService;
        }

        [HttpPost]
        public ActionResult Add([FromBody] AddWordDto dto)
        {
            _wordService.Add(dto);

            return Ok();
        }
    }
}
