using Abp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using RRS_Cloud_Service.Data;
using RRS_Cloud_Service.Models;

namespace RRS_Cloud_Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDBContext _dbContext;
        public EmployeeService(ApplicationDBContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public Employee AddEmployee(Employee employee)
        {
            var employeeEntity = new Employee() 
            { 
                FirstName = employee.FirstName, 
                LastName = employee.LastName,
                UserName = employee.UserName,
                Age = employee.Age,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber
            };
            _dbContext.Employees.Add(employeeEntity);
            _dbContext.SaveChanges();
            return employeeEntity;
        }

        public string DeleteEmployee(int id)
        {
            var emp = _dbContext.Employees.Find(id);

            if (emp is null)
            {
                return null;
            }
            _dbContext.Employees.Remove(emp);
            _dbContext.SaveChanges();
            return "Record deleted successfully !!";
        }

        public List<Employee> GetAllEmployees()
        {
            return _dbContext.Employees.ToList();
        }

        public List<Employee> GetEmployeesByUserName(string userName)
        {
            return _dbContext.Employees.ToList().Where(e => e.UserName == userName).ToList();
        }

        public Employee UpdateEmployee(int id, Employee employee)
        {
            var emp = _dbContext.Employees.Find(id);

            if(emp is null)
            {
                return null ;
            }

            emp.FirstName = employee.FirstName;
            emp.LastName = employee.LastName;
            emp.UserName = employee.UserName;
            emp.Age = employee.Age;
            emp.Email = employee.Email;
            emp.PhoneNumber = employee.PhoneNumber;

            _dbContext.SaveChanges();
            return emp;
        }
    }
}
