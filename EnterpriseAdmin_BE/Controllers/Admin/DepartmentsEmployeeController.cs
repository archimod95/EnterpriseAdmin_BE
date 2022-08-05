using EnterpriseAdmin_BE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseAdmin_BE.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsEmployeeController : ControllerBase
    {
        private IConfiguration _config;

        public DepartmentsEmployeeController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet("get-all-departments-employees")]
        public async Task<ActionResult<IEnumerable<ApiDepartmentsEmployee>>> getAllDepartmentsEmployeeAsync()
        {
            try
            {
                return Ok(await Core.Admin.Core.getAllDepartmentsEmployeesAsync(_config));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost("save-department-employee-changes")]
        public async Task<ActionResult<ApiResponse>> saveDepartmentEnterpriseChangesAsync(ApiDepartmentsEmployee incomingEnterprise)
        {
            try
            {
                if (incomingEnterprise.Id == 0)
                {
                    return await Core.Admin.Core.createDepartmentEmployeeAsync(_config, incomingEnterprise);
                }
                else
                {
                    return await Core.Admin.Core.updateDepartmentEmployeeAsync(_config, incomingEnterprise);
                }

            }
            catch
            {
                ApiResponse response = new ApiResponse();
                response.Success = false;
                return response;
            }
        }

        [HttpPost("get-deparments-employees-by-id")]
        public async Task<ActionResult<ApiEmployees>> getDepartmentsEmployeesByIdAsync(ApiDepartmentsEmployee id)
        {
            try
            {
                return Ok(await Core.Admin.Core.getDeparmentsEmployeesByIdAsync(_config, id.Id));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
