using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        IRepository<Answer> repository;
        public AnswerController(IRepository<Answer> repository)
        {
            this.repository = repository;
        }

        // GET: api/<AnswerController>
        [HttpGet]
        public async Task<IEnumerable<Answer>> Get()
        {
            return await repository.GetAll();
        }

        // GET api/<AnswerController>/5
        [HttpGet("{id}")]
        public async Task<Answer> Get(int id)
        {
            return await repository.GetById(id);
        }

        // POST api/<AnswerController>
        [HttpPost]
        public async Task Post([FromBody] Answer answer)
        {
            await repository.AddItem(answer);
        }

        // PUT api/<AnswerController>
        [HttpPut]
        public async Task Put([FromBody] Answer answer)
        {
            await repository.UpdateItem(answer);
        }

        // DELETE api/<AnswerController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await repository.DeleteItem(id);
        }
    }
}
