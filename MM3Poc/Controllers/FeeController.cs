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
    public class FeeController : ControllerBase
    {
        // GET: api/Fee
        [HttpGet]
        public IEnumerable<Fee> Get()
        {
            List<Fee> fees = new List<Fee>
            {
                new Fee{ Id=1, Name = "Fee 1", Amount=8.0M, FeeTypeId=1,TriggerId=1  },
                new Fee{ Id=2, Name = "Fee 2", Amount=2.0M, FeeTypeId=1, TriggerId=1 },
                new Fee{ Id=3, Name = "Fee 3", Amount=14.0M, FeeTypeId=1, TriggerId=1 }
            };

            return fees;
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> PostFee(Fee person)
        {
            await Task.Run(() => Console.WriteLine("PostFee")
            );

            return new ApiResponse() { Success = true, Errors = "" };
        }
    }
}
