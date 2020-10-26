using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MM3Poc.Data;
using MM3Poc.Models;

namespace MM3Poc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            List<Person> persons = new List<Person>
            {
                new Person{ Id=1, Name = "Name 1", IsFullTime=false, SSN="123-45-6789" },
                new Person{ Id=2, Name = "Name 2", IsFullTime=false, SSN="123-45-6789" },
                new Person{ Id=3, Name = "Name 3", IsFullTime=false, SSN="123-45-6789" }
            };

            return persons;
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> PostPerson(Person person)
        {
            person.Id = 123;
            person.HireDate = DateTime.Now;

            await Task.Run(() => Console.WriteLine("PostPerson")
            );

            string errors = "";

            if (person.SSN == "111-11-1111")
            {
                errors = "Invalid SSN";
            }

            return new ApiResponse() { Success = true, Errors = errors };
        }

    }
}
