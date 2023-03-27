using System.Collections.Generic;

namespace EmployeeManagement.Models
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployee(int id);
        Employee Add(Employee employee);
    }

    //public class EmployeeRepository : IEmployeeRepository
    //{
    //    public Employee GetEmployee(int id)
    //    {
    //        // Logic to retrieve employee details
    //        return new Employee();
    //    }

    //    public void Save(Employee employee)
    //    {
    //        // Logic to save employee details
    //    }
    //}
}
