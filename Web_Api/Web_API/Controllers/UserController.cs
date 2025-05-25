using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Repository.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IRepository<User> repository;
        public UserController(IRepository<User> repository)
        {
            this.repository = repository;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await repository.GetAll();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<User> Get(int id)
        {
            return await repository.GetById(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task Post([FromBody] User user)
        {
            await repository.AddItem(user);
        }

        // PUT api/<ValuesController>/5
        [HttpPut]
        public async Task Put([FromBody] User user)
        {
            await repository.UpdateItem(user);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await repository.DeleteItem(id);
        }
    }
}

