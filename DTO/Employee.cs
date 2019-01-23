using System;

namespace DTO
{
    public class Employee
    {
        public string id { get; set; }
        public string name { get; set; }
        public string contractTypeName { get; set; }
        public string roleId { get; set; }
        public string roleName { get; set; }
        public string roleDescription { get; set; }
        public Decimal AnnualSalary { get; set; }

        public virtual Decimal GetAnnualSalary() { return 0; }
    }
}
