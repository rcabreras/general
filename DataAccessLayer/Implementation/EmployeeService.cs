using DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Implementation
{

    class JsonEmployee {

        public string id { get; set; }
        public string name { get; set; }
        public string contractTypeName { get; set; }
        public string roleId { get; set; }
        public string roleName { get; set; }
        public string roleDescription { get; set; }
        public Decimal hourlySalary { get; set; }
        public Decimal monthlySalary { get; set; }
        
    }

    public class EmployeeService : Interfaces.IEmployeeService
    {

        HttpClient _client = new HttpClient();
        private DTO.EmployeeFactory _employeeFactory;

        public EmployeeService(){

            _employeeFactory = new EmployeeFactory();
            // Update port # in the following line.
            _client.BaseAddress = new Uri("http://masglobaltestapi.azurewebsites.net/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Employee> GetEmployee(String _id)
        {
            var employees = await GetEmployees();
            return employees.Find(x => x.id == _id);

        }

        public async Task<List<Employee>> GetEmployees()
        {
            List<JsonEmployee> jsonEmps = null;
            HttpResponseMessage response = await _client.GetAsync("api/Employees");

            List<Employee> emps = null;

            if (response.IsSuccessStatusCode)
            {
                jsonEmps = await response.Content.ReadAsAsync<List<JsonEmployee>>();

                if (jsonEmps != null && jsonEmps.Count > 0)
                {
                    emps = new List<Employee>(jsonEmps.Count);
                    jsonEmps.ForEach( (em) => emps.Add(
                       _employeeFactory.GetEmployee(em.id, em.name, em.contractTypeName, em.roleId, em.roleName, em.roleDescription, em.hourlySalary, em.monthlySalary)));
                }
            }
            
            return emps;
        }
    }
}
