using Microsoft.AspNetCore.Mvc;
using MyGym.Application.DTOs.Sports;
using MyGym.Application.Repositories;
using MyGym.Domain.Enities;

namespace MyGym.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportsController : ControllerBase
    {
        ISportReadRepository _sportRead { get; }
        ISportWriteRepository _sportWrite { get; }
        public SportsController(ISportReadRepository sportRead, ISportWriteRepository sportWrite)
        {
            _sportRead = sportRead;
            _sportWrite = sportWrite;
        }
        [HttpPost]
        public async Task<IActionResult> Post(SportCreateDTO sportCreate)
        {
            await _sportWrite.AddAsync(new Sport { Name = sportCreate.Name });
            await _sportWrite.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_sportRead.Table.OrderBy(t=>t.Id));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _sportRead.GetByIdAsync(id);
            return Ok(data);
        }
        [HttpPut]
        public async Task<IActionResult> Put(SportUpdateDTO sportUpdate)
        {
            var data = await _sportRead.GetSingleAsync(s => s.Id == sportUpdate.Id, true);
            data.Name = sportUpdate.Name;
            await _sportWrite.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _sportWrite.RemoveAsync(id);
            await _sportWrite.SaveChangesAsync();
            return Ok();
        }
    }
}
