using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        IRepository<Survey> repository;
        public SurveyController(IRepository<Survey> repository)
        {
            this.repository = repository;
        }

        // GET: api/<SurveyController>
        [HttpGet]
        public async Task<IEnumerable<Survey>> Get()
        {
            return await repository.GetAll();
        }

        // GET api/<SurveyController>/5
        [HttpGet("{id}")]
        public async Task<Survey> Get(int id)
        {
            return await repository.GetById(id);
        }

        // POST api/<SurveyController>
        [HttpPost]
        public async Task Post([FromBody] Survey survey)
        {
            await repository.AddItem(survey);
        }

        // PUT api/<SurveyController>/5
        [HttpPut]
        public async Task Put([FromBody] Survey survey)
        {
            await repository.UpdateItem(survey);
        }

        // DELETE api/<SurveyController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await repository.DeleteItem(id);
        }
    }
}
