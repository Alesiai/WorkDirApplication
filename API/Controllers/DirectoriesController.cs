using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/directories")]
    public class DirectoryController : ControllerBase
    {
       private readonly IDirectoryService _directoryService;
        public IJsonConverterService _jsonConverterService { get; }
        public DirectoryController(IDirectoryService directoryService, IJsonConverterService jsonConverterService)
        {
            _jsonConverterService = jsonConverterService;
            _directoryService = directoryService;
        }

        [HttpGet]
        public ActionResult GetDirectoryStructure([FromQuery]string path){
            try {
                var structure = _directoryService.GetDirectoryStructure(path);
                return Ok(structure);
            }
            catch (Exception e){
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult CreateStructure([FromForm]string folder, [FromForm] IFormFile file){
            try{
                _jsonConverterService.GetStringFromJson(folder, file);
                return Ok();
            }
            catch (Exception e){
                return BadRequest(e.Message);
            }
        }
    }
}