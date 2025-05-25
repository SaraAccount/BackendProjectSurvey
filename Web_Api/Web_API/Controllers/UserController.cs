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
            return await repository.GetAllAsync();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return repository.GetById(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] User user)
        {
            repository.AddItem(user);
        }

        // PUT api/<ValuesController>/5
        [HttpPut]
        public void Put([FromBody] User user)
        {
            repository.UpdateItem(user);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.DeleteItem(id);
        }
    }
}

