using jwt_auth_api.Models;

namespace jwt_auth_api.Interfaces
{
    public interface IEmployeeService
    {
        public List<Employee> GetEmployeeList();
        public Employee GetEmployeeDetails(int id);
        public String AddEmployee(Employee employee);
        public String UpdateEmployee(int id,Employee employee);
        public bool DeleteEmployee(int id);

    }
}
