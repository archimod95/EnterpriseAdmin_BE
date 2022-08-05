using EnterpriseAdmin_BE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseAdmin_BE.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private IConfiguration _config;

        public DepartmentController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet("get-all-departments")]
        public async Task<ActionResult<IEnumerable<ApiDepartments>>> getAllDepartments()
        {
            try
            {
                return Ok(await Core.Admin.Core.getAllDepartmentsAsync(_config));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost("save-departments-changes")]
        public async Task<ActionResult<ApiResponse>> saveDepartmentsChangesAsync(ApiDepartments incomingEnterprise)
        {
            try
            {
                if (incomingEnterprise.Id == 0)
                {
                    return await Core.Admin.Core.createDepartmentAsync(_config, incomingEnterprise);
                }
                else
                {
                    return await Core.Admin.Core.updateDepartmentAsync(_config, incomingEnterprise);
                }

            }
            catch
            {
                ApiResponse response = new ApiResponse();
                response.Success = false;
                return response;
            }
        }

        [HttpPost("get-department-by-id")]
        public async Task<ActionResult<ApiEnterprises>> getDepartmentByIdAsync(ApiDepartmentsById id)
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
