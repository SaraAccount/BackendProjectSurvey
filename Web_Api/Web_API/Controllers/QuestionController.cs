using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        IRepository<Question> repository;
        public QuestionController(IRepository<Question> repository)
        {
            this.repository = repository;
        }

        // GET: api/<QuestionController>
        [HttpGet]
        public async Task<IEnumerable<Question>> Get()
        {
            return await repository.GetAll();
        }

        // GET api/<QuestionController>/5
        [HttpGet("{id}")]
        public async Task<Question> Get(int id)
        {
            return await repository.GetById(id);
        }

        // POST api/<QuestionController>
        [HttpPost]
        public async Task Post([FromBody] Question question)
        {
            await repository.AddItem(question);
        }

        // PUT api/<QuestionController>
        [HttpPut]
        public async Task Put([FromBody] Question question)
        {
            await repository.UpdateItem(question);
        }

        // DELETE api/<QuestionController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await repository.DeleteItem(id);
        }
    }
}
