using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserSyncApp.Domain.Interfaces;

namespace UserSyncApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserRepository repository) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await repository.GetAllAsync());
    }
}
