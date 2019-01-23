using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DTO;


namespace BusinessLogic.Interfaces
{
    public interface BLIEmployeeService
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployee(String id);
    }
}
