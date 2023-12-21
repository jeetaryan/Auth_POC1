using jwt_auth_api.Context;
using jwt_auth_api.Interfaces;
using jwt_auth_api.Models;

namespace jwt_auth_api.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly JwtContext _jwtContext;

        public EmployeeService(JwtContext jwtContext)
        {
            _jwtContext = jwtContext;
        }

        public string AddEmployee(Employee employee)
        {
            _jwtContext.Employees.Add(employee);
            _jwtContext.SaveChanges();
            return "Record added";
        }

        public bool DeleteEmployee(int id)
        {
            try
            {
                var empData = _jwtContext.Employees.FirstOrDefault(x => x.Id == id);
                if (empData != null)
                {
                    _jwtContext.Employees.Remove(empData);
                    _jwtContext.SaveChanges(true);
                    return true;
                }
                else
                {
                    throw new Exception("Employee is not available");
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Employee GetEmployeeDetails(int id)
        {

            var employeeDetails = _jwtContext.Employees.SingleOrDefault(x => x.Id == id);
            return employeeDetails;
        }

        public List<Employee> GetEmployeeList()
        {
            var employeesList = _jwtContext.Employees.ToList();
            return employeesList;
        }

        public string UpdateEmployee(int id, Employee employee)
        {
            var data = _jwtContext.Employees.SingleOrDefault(x => x.Id == id);
            if (data != null)
            {
                data.Position = employee.Position;
                data.Name = employee.Name;
                data.Company = employee.Company;
                _jwtContext.SaveChanges();
                return "Record updated";
            }
            else
            {
                return "Record could not be updated";
            }

        }
    }
}
