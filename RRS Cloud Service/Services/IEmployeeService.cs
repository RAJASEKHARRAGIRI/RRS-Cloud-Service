using RRS_Cloud_Service.Models;

namespace RRS_Cloud_Service.Services
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployees();
        List<Employee> GetEmployeesByUserName(string userName);
        Employee AddEmployee(Employee employee);
        Employee UpdateEmployee(int id, Employee employee);
        string DeleteEmployee(int id);
    }
}
