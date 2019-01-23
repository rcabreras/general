using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        BusinessLogic.Interfaces.BLIEmployeeService _employeeService = new BusinessLogic.Implementation.BLEmployeeService();

        public EmployeeController() {
            this._employeeService = new BusinessLogic.Implementation.BLEmployeeService();
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTO.Employee>>> GetEmployees()
        {
            return await _employeeService.GetEmployees();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DTO.Employee>> GetEmployee(String id)
        {

            return  await _employeeService.GetEmployee(id);
        }

    }
}