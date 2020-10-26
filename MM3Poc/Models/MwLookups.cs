using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MM3Poc.Models
{
    public partial class Person
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string SSN { get; set; }
        public DateTime HireDate { get; set; }
        public bool IsFullTime { get; set; }
    }

    public partial class Fee
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public int? FeeTypeId { get; set; }
        public int? TriggerId { get; set; }
    }

    public partial class FeeType
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public partial class Trigger
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public partial class Employee
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public int Age { get; set; }
    }

    public class ApiResponse
    {
        public bool Success { get; set; }
        public string Errors { get; set; }
    }

}

