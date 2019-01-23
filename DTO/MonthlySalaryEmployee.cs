using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class MonthlySalaryEmployee : Employee
    {
        public Decimal monthlySalary { get; set; }

        public override Decimal GetAnnualSalary()
        {
            return monthlySalary * 12;
        }
    }
}
