using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployee(String id);
    }
}
