using EnterpriseAdmin_BE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseAdmin_BE.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IConfiguration _config;

        public EmployeeController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet("get-all-employees")]
        public async Task<ActionResult<IEnumerable<ApiEmployees>>> getAllEmployeesAsync()
        {
            try
            {
                return Ok(await Core.Admin.Core.getAllEmployeesAsync(_config));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost("save-employee-changes")]
        public async Task<ActionResult<ApiResponse>> createEmployeeAsync(ApiEmployees newEmployee)
        {
            try
            {
                if (newEmployee.Id ==0)
                {
                    return await Core.Admin.Core.createEmployeeAsync(_config, newEmployee);
                }
                else
                {
                    return await Core.Admin.Core.updateEmployeeAsync(_config, newEmployee);
                }
                
            }
            catch
            {
                ApiResponse response = new ApiResponse();
                response.Success = false;
                return response;
            }
        }

        [HttpPost("get-employees-by-email")]
        public async Task<ActionResult<ApiEmployees>> getEmployeeByEmailAsync(ApiEmployeeByEmail email)
        {
            try
            {
                return Ok(await Core.Admin.Core.getEmployeeByEmailAsync(_config, email.Email));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost("get-employees-by-id")]
        public async Task<ActionResult<ApiEmployees>> getEmployeeByIdAsync(ApiEmployeeById id)
        {
            try
            {
                return Ok(await Core.Admin.Core.getEmployeeByIdAsync(_config, id.Id));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
