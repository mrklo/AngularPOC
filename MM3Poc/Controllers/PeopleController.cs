using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MM3Poc.Data;
using MM3Poc.Models;
using NSwag.Annotations;

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

        [HttpGet("{id}", Name = "GetPerson")]
        public Person GetPerson(int id)
        {
            return new Person();
        }

        [HttpPost]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Person), StatusCodes.Status201Created)]
        public async Task<ActionResult<ApiResponse>> PostPerson(Person person)
        {
            await Task.Run(() => Console.WriteLine("PostPerson"));

            person.Id = 123;

            if (person.SSN == "111")
            {
                return BadRequest("An SSN of 111-11-1111");
            }

            if (person.Name.Equals("Error", StringComparison.CurrentCultureIgnoreCase))
            {
                return BadRequest("The word error in a textbox");
            }

            return CreatedAtAction("GetPerson", new { id = person.Id }, person);
        }

    }
}
