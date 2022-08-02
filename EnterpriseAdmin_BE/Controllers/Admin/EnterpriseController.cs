using EnterpriseAdmin_BE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseAdmin_BE.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnterpriseController : ControllerBase
    {
        private IConfiguration _config;

        public EnterpriseController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet("get-all-enterprises")]
        public async Task<ActionResult<IEnumerable<ApiEnterprises>>> getAllEnterprises()
        {
            try
            {
                return Ok(await Core.Admin.Core.getAllEnterprisesAsync(_config));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
            
        } 
    }
}
