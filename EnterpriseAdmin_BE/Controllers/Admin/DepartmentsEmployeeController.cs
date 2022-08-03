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

        [HttpPost("create-department-employee")]
        public async Task<ActionResult> createDepartmentEmployeeAsync(ApiDepartmentsEmployee newDepartmentsEmployee)
        {
            try
            {
                bool success = await Core.Admin.Core.createDepartmentEmployeeAsync(_config, newDepartmentsEmployee);

                return success ? Ok() : BadRequest(newDepartmentsEmployee);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost("update-department-employee")]
        public async Task<ActionResult> updateDepartmentEmployeeAsync(ApiDepartmentsEmployee newDepartmentsEmployee)
        {
            try
            {
                bool success = await Core.Admin.Core.updateDepartmentEmployeeAsync(_config, newDepartmentsEmployee);

                return success ? Ok() : BadRequest(newDepartmentsEmployee);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
