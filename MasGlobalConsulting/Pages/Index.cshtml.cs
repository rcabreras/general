using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MasGlobalConsulting.Pages
{
    public class EmployeesModel : PageModel
    {
        public string Message { get; set; }
        public List<Employee> _employees;

        MasGlobalConsulting.Services.EmployeeService _employeeService;

        public EmployeesModel() {
            _employeeService = new Services.EmployeeService();
        }


        public void OnGet()
        {
            Message = "Your application description page.";
        }
        

        [BindProperty]
        public Employee employee{ get; set; }

        public async Task<IActionResult> OnGetEmployeesById(String id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            this._employees = new List<Employee>();


            if (String.IsNullOrEmpty(id))
            {
                this._employees.AddRange(await _employeeService.GetEmployees());
            }
            else {
                this._employees.Add(await _employeeService.GetEmployee(id));
            }

            
            

            ViewData.Model = this;

            return Page();
        }

    }
}
