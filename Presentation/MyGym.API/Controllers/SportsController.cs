using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Post(string name)
        {
            await _sportWrite.AddAsync(new Sport { Name = name });
            await _sportWrite.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_sportRead.Table);
        }
    }
}
