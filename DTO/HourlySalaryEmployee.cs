using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class HourlySalaryEmployee : Employee
    {
        public Decimal hourlySalary { get; set; }

        public override Decimal GetAnnualSalary()
        {
            return 120 * hourlySalary * 12;
        }
    }
}
