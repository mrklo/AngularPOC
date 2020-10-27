using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

        [HttpGet("{id}", Name = "GetFee")]
        public Fee GetFee(int id)
        {
            return new Fee();
        }

        [HttpPost]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Fee), StatusCodes.Status201Created)]
        public async Task<ActionResult<ApiResponse>> PostFee(Fee fee)
        {
            await Task.Run(() => Console.WriteLine("PostFee"));

            fee.Id = 1;

            if (fee.FeeTypeId == 0)
            {
                return BadRequest("A dropdown option of invalid");
            }

            return CreatedAtAction("GetFee", new { id = fee.Id }, fee);
        }
    }
}
