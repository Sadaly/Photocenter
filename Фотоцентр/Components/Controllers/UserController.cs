using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Фотоцентр.Data;
using Фотоцентр.Models;

namespace Фотоцентр.Components.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly AppDBContext _dbContext = new();
        public UserController(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public List<User> Get()
        {
            try
            {
                return _dbContext.Users.ToList();
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { User_Id = user.User_Id }, user);
        }

        [HttpPut]
        public async Task<ActionResult> Update(User user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();

            return Ok();
            
        }

        [HttpGet("{user_id}")]
        public async Task<ActionResult<User?>> GetById(int user_id)
        {
            return await _dbContext.Users.Where(x => x.User_Id == user_id).SingleOrDefaultAsync();
        }

        [HttpDelete("{user_id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var userGetById = await GetById(id);
            
            if(userGetById.Value is null)
                return NotFound();

            _dbContext.Remove(userGetById.Value);
            await _dbContext.SaveChangesAsync();
            return Ok();
            
        }
    }
}