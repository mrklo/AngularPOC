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
    public class TriggerController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Trigger> Get()
        {
            List<Trigger> triggers = new List<Trigger>
            {
                new Trigger{ Id=1, Name = "Trigger 1" },
                new Trigger{ Id=2, Name = "Trigger 2" },
                new Trigger{ Id=3, Name = "Trigger 3" }
            };
            return triggers;
        }
    }
}
