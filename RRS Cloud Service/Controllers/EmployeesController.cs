using Microsoft.AspNetCore.Mvc;
using RRS_Cloud_Service.Data;
using RRS_Cloud_Service.Models;
using RRS_Cloud_Service.Services;

namespace RRS_Cloud_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly IEmployeeService _employeeService;

        public EmployeesController(ApplicationDBContext dbContext, IEmployeeService employeeService)
        {
            _dbContext = dbContext;
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            return Ok(_employeeService.GetAllEmployees());
        }

        [HttpGet]
        [Route("{userName}")]
        public IActionResult GetAllEmployees(string userName)
        {
            return Ok(_employeeService.GetEmployeesByUserName(userName));
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee) 
        { 
            return Ok(_employeeService.AddEmployee(employee));
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateEmployee(int id, Employee employee)
        {
            var response = _employeeService.UpdateEmployee(id, employee);
            if(response is null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteEmployee(int id)
        {
            var response = _employeeService.DeleteEmployee(id);
            if (response is null)
            {
                return NotFound();
            }
            return Ok(response);
        }

    }
}
