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

        [HttpPost("create-employee")]
        public async Task<ActionResult> createEmployeeAsync(ApiEmployees newEmployee)
        {
            try
            {
                bool success = await Core.Admin.Core.createEmployeeAsync(_config, newEmployee);

                return success ? Ok() : BadRequest(newEmployee);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost("update-employee")]
        public async Task<ActionResult> updateEmployeeAsync(ApiEmployees newEmployees)
        {
            try
            {
                bool success = await Core.Admin.Core.updateEmployeeAsync(_config, newEmployees);

                return success ? Ok() : BadRequest(newEmployees);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
