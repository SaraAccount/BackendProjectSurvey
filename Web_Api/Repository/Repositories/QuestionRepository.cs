using Repository.Entities;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class QuestionRepository
    {

        private readonly IContext context;
        public QuestionRepository(IContext context)
        {
            this.context = context;
        }
        public Question AddItem(Question item)
        {
            context.Questions.Add(item);
            return item;
        }

        public void DeleteItem(int id)
        {
            Question question = context.Questions.FirstOrDefault(x => x.Id == id);
            if (question != null)
                context.Questions.Remove(question);
        }

        public List<Question> GetAll()
        {
            return context.Questions.ToList();
        }

        public Question GetById(int id)
        {
            return context.Questions.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateItem(Question item)
        {
            Question question = context.Questions.FirstOrDefault(x => x.Id == item.Id);
            question.Answers = item.Answers;
            question.IsRequired= item.IsRequired;
            question.Options = item.Options;
            question.Label = item.Label;
            question.TypeTag = item.TypeTag;
        }
    }
}
