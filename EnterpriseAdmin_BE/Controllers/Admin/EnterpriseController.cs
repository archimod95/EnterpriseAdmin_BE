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
        public async Task<ActionResult<IEnumerable<ApiEnterprises>>> getAllEnterprisesAsync()
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

        [HttpPost("save-enterprise-changes")]
        public async Task<ActionResult<ApiResponse>> saveEnterpriseChangesAsync(ApiEnterprises incomingEnterprise)
        {
            try
            {
                if (incomingEnterprise.id == 0)
                {
                    return await Core.Admin.Core.createEnterpriseAsync(_config, incomingEnterprise);
                }
                else
                {
                    return await Core.Admin.Core.updateEnterpriseAsync(_config, incomingEnterprise);
                }

            }
            catch
            {
                ApiResponse response = new ApiResponse();
                response.Success = false;
                return response;
            }
        }

        [HttpPost("get-enterprise-by-id")]
        public async Task<ActionResult<ApiEnterprises>> getEnterpriseByIdAsync(ApiEnterprisesById id)
        {
            try
            {
                return Ok(await Core.Admin.Core.getEnterpriseByIdAsync(_config, id.Id));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
