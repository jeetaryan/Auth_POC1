using jwt_auth_api.Interfaces;
using jwt_auth_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace jwt_auth_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService; 
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        // GET: api/<EmployeesController>
        [HttpGet]
        public List<Employee> Get()
        {
            var employees = _employeeService.GetEmployeeList(); 
            return employees;
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            var emp = _employeeService.GetEmployeeDetails(id);
            return emp;
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public String Post([FromBody] Employee employee)
        {
            var emp = _employeeService.AddEmployee(employee);   
            return emp; 
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public String Put(int id, [FromBody] Employee employee)
        {
            var emp = _employeeService.UpdateEmployee(id,employee);
            return emp; 
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var isDeleted = _employeeService.DeleteEmployee(id);    
            return isDeleted;
        }
    }
}
