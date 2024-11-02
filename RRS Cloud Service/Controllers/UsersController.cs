using Microsoft.AspNetCore.Mvc;
using RRS_Cloud_Service.Data;
using RRS_Cloud_Service.Models;

namespace RRS_Cloud_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsers _users;
       

        public UsersController(IUsers users)
        {
            _users = users;
        }

        [HttpGet("usersData")]
        public async Task<ActionResult<IEnumerable<UserData>>> GetCosmosUsers()
        {
            
            var task = await _users.GetAllUsers();
            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

    }
}
