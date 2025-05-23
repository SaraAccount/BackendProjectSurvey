using Repository.Entities;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class AnswerRepository : IRepository<Answer>
    {
        private readonly IContext context;
        public AnswerRepository(IContext context)
        {
            this.context = context;
        }
        public Answer AddItem(Answer item)
        {
            context.Answers.Add(item);
            context.Save();
            return item;
        }

        public void DeleteItem(int id)
        {
            Answer answer = context.Answers.FirstOrDefault(x => x.Id == id);
            if (answer != null)
                context.Answers.Remove(answer);
            context.Save();
        }

        public List<Answer> GetAll()
        {
            return context.Answers.ToList();
        }

        public Answer GetById(int id)
        {
            return context.Answers.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateItem(Answer item)
        {
            Answer answer = context.Answers.FirstOrDefault(x => x.Id == item.Id);
            answer.User = item.User;
            answer.UserId = item.UserId;
            answer.AnswerValue = item.AnswerValue;
            answer.IsAnswered = item.IsAnswered;
            answer.Question = item.Question;
            answer.QuestionId = item.QuestionId;
            context.Save();
        }

    }
}
