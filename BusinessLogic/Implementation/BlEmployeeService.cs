using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DTO;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Implementation;

namespace BusinessLogic.Implementation
{
    public class BLEmployeeService : Interfaces.BLIEmployeeService
    {
        private IEmployeeService _employeeService;

        public BLEmployeeService()
        {
            _employeeService = new EmployeeService();
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await _employeeService.GetEmployees();
        }

        public async Task<Employee> GetEmployee(string id)
        {
            return await _employeeService.GetEmployee(id);
        }
    }
}
