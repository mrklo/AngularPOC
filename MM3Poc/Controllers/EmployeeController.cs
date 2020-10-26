using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MM3Poc.Models;

namespace MM3Poc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee{ Id=1, Name = "Name 1", Age=20, NickName="" },
                new Employee{ Id=2, Name = "Name 2", Age=30, NickName="" },
                new Employee{ Id=3, Name = "Name 3", Age=40, NickName="" }
            };

            return employees;
        }
    }
}
