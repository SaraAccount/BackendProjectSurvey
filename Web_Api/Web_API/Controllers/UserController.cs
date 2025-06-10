using AutoMapper;
using Common.Dto;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Repository.Interface;

namespace Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IRepository<User> repository;
        private readonly Mapper mapper;
        public UserController(IRepository<User> repository, Mapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IEnumerable<UserDto>> Get()
        {
            var Users = await repository.GetAll();
            return mapper.Map<List<UserDto>>(Users);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> Get(int id)
        {
            var user = await repository.GetById(id);
            return mapper.Map<UserDto>(user); 
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserDto userDto)
        {
            var user = mapper.Map<User>(userDto);
            await repository.AddItem(user);
            await repository.SaveChangesAsync();
            return Ok();
        }

        // PUT api/<ValuesController>/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UserDto userDto)
        {
            var user =mapper.Map<User>(userDto);
            await repository.UpdateItem(user);
            await repository.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await repository.DeleteItem(id);
            await repository.SaveChangesAsync();
            return Ok();
        }
    }
}

