using jwt_auth_api.Models;

namespace jwt_auth_api.Interfaces
{
    public interface IEmployeeService
    {
        public List<Employee> GetEmployeeList();
        public Employee GetEmployeeDetails(int id);
        public Employee AddEmployee(Employee employee);
        public Employee UpdateEmployee(int id,Employee employee);
        public bool DeleteEmployee(int id);

    }
}
