using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MasGlobalConsulting.Services
{
    public class EmployeeService
    {
        HttpClient _client = new HttpClient();

        public EmployeeService()
        {
           
            // Update port # in the following line.
            _client.BaseAddress = new Uri("https://localhost:44335/");
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
            List<Employee> emps = null;
            HttpResponseMessage response = await _client.GetAsync("api/Employee");
            
            if (response.IsSuccessStatusCode)
            {
                emps = await response.Content.ReadAsAsync<List<Employee>>();
            }

            return emps;
        }

    }
}
