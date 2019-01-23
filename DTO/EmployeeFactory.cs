using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class EmployeeFactory
    {
        public Employee GetEmployee(String _id, String _name, 
            String _contractTypeName, String _roleId, String _roleName, String _roleDescription, Decimal _hourlySalary, Decimal _monthlySalary)
        {

            Employee e = null;
            if (_contractTypeName.Contains("HourlySalaryEmployee")) e= new HourlySalaryEmployee{
                id = _id, contractTypeName = _contractTypeName, name = _name, roleId = _roleId, roleName = _roleName, roleDescription = _roleDescription, hourlySalary = _hourlySalary};
            else
            if (_contractTypeName.Contains("MonthlySalaryEmployee")) e= new MonthlySalaryEmployee {
                id = _id,
                contractTypeName = _contractTypeName,
                name = _name,
                roleId = _roleId,
                roleName = _roleName,
                roleDescription = _roleDescription,
                monthlySalary = _monthlySalary
            };

            if (e != null) e.AnnualSalary = e.GetAnnualSalary();

            return e;
        }
    }
}
