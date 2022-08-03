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

        [HttpPost("create-department")]
        public async Task<ActionResult> createDepartmentAsync(ApiDepartments newDepartments)
        {
            try
            {
                bool success = await Core.Admin.Core.createDepartmentAsync(_config, newDepartments);

                return success ? Ok() : BadRequest(newDepartments);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost("update-department")]
        public async Task<ActionResult> updateDepartmentAsync(ApiDepartments newDepartments)
        {
            try
            {
                bool success = await Core.Admin.Core.updateDepartmentAsync(_config, newDepartments);

                return success ? Ok() : BadRequest(newDepartments);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
