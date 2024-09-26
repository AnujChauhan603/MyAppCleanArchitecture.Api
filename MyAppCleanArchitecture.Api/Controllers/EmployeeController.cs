using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAppCleanArchitecture.Application.Commands;
using MyAppCleanArchitecture.Application.Queries;
using MyAppCleanArchitecture.Core.Entities;

namespace MyAppCleanArchitecture.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(ISender sender) : ControllerBase
    {
        [HttpPost("")]
        
        public async Task<IActionResult> AddEmployeeAsync([FromBody] EmployeeEntity employeeEntity)
        {
            var result =await sender.Send(new AddEmployeeCommand(employeeEntity));
            return Ok(result);
        }

        [HttpGet("employees")]

        public async Task<IActionResult> GetAllEmployeesAsync()
        {
            var result = await sender.Send(new GetAllEmployeesQuery());
            return Ok(result);
        }
        [HttpGet("employees/{employeeId}")]

        public async Task<IActionResult> GetAllEmployeesByIdAsync([FromRoute] Guid employeeId)
        {
            var result = await sender.Send(new GetEmployeeByIdQuery(employeeId));
            return Ok(result);
        }

        [HttpPut("employees/{employeeId}")]

        public async Task<IActionResult> UpdateEmployeeAsync([FromRoute] Guid employeeId, [FromBody] EmployeeEntity employee)
        {
            var result = await sender.Send(new UpdateEmployeeCommand(employeeId,employee));
            return Ok(result);
        }

        [HttpDelete("employees/{employeeId}")]
        public async Task<IActionResult> DeleteEmployeeAsync([FromRoute] Guid employeeId)
        {
            var result = await sender.Send(new DeleteEmployeeCommand(employeeId));
            return Ok(result);
        }
    }   
}
