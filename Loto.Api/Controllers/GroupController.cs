using Loto.Application.Contract;
using Loto.Application.Dtos;
using Loto.Application.Dtos.Branch;
using Loto.Application.Services;
using Loto.Infrastructure.Interfaces;
using Loto.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Emit;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Loto.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService groupService;

        public GroupController(IGroupService groupService)
        {
            this.groupService = groupService;


        }
        // GET: api/<GroupController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var list = await this.groupService.Get();

            return Ok(list);
        }

        // GET api/<GroupController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await this.groupService.GetById(id);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        // POST api/<groupController>
        [HttpPost("Savegroup")]
        public async Task<IActionResult> Post([FromBody] GroupDto groupDto)
        {
            var result = await this.groupService.Save(groupDto);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("Updategroup")]
        public async Task<IActionResult> Put([FromBody] GroupDto groupDto)
        {
            var result = await this.groupService.Update(groupDto);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        // PUT api/<groupController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<groupController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await this.groupService.Delete(id);

            if (!result.Success)
                return BadRequest(result);


            return Ok(result);

        }

    }
}
