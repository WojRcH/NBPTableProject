using Microsoft.AspNetCore.Mvc;
using NBPTableApi.Services;

namespace NBPTableApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NBPTableController : ControllerBase
    {
        private readonly INBPService nBPService;
        public NBPTableController(INBPService nBPService)
        {
            this.nBPService = nBPService;
        }

        [HttpGet]
        public IActionResult GetNBPTable()
        {
            var data = nBPService.GetNBPTable();
            return Ok(data);
        }
    }
}
