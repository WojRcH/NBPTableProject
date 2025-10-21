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
        public async Task<IActionResult> GetNBPTable()
        {
            var data = await nBPService.GetNBPTable();
            return Ok(data);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateNBPTable()
        {
            var data = await nBPService.UpdateNBPTable();
            return Ok(data);
        }
    }
}
