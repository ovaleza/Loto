using Loto.Application.Contract;
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
    public class BranchController : ControllerBase
    {
        private readonly IBranchService branchService;
      
        public BranchController(IBranchService branchService)
        {
            this.branchService = branchService;
        }
        // GET: api/<BranchController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await this.branchService.Get();
            return Ok(list);
        }


        // GET api/<BranchController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await this.branchService.GetById(id);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        // POST api/<BranchController>
        [HttpPost("SaveBranch")]
        public async Task<IActionResult> Post([FromBody] BranchDto branchDto)
        {
            var result = await this.branchService.Save(branchDto);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("UpdateBranch")]
        public async Task<IActionResult> Put([FromBody] BranchDto branchDto)
        {
            var result = await this.branchService.Update(branchDto);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await this.branchService.Delete(id);

            if (!result.Success)
                return BadRequest(result);


            return Ok(result);

        }

    }
}
