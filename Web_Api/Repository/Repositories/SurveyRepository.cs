using Repository.Entities;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class SurveyRepository
    {

        private readonly IContext context;
        public SurveyRepository(IContext context)
        {
            this.context = context;
        }
        public Survey AddItem(Survey item)
        {
            context.Surveys.Add(item);
            return item;
        }

        public void DeleteItem(int id)
        {
            Survey Survey = context.Surveys.FirstOrDefault(x => x.Id == id);
            if (Survey != null)
                context.Surveys.Remove(Survey);
        }

        public List<Survey> GetAll()
        {
            return context.Surveys.ToList();
        }

        public Survey GetById(int id)
        {
            return context.Surveys.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateItem(Survey item)
        {
            Survey survey = context.Surveys.FirstOrDefault(x => x.Id == item.Id);
            survey.Surveyor=item.Surveyor;
            survey.Questions=item.Questions;
            survey.Subject=item.Subject;
            survey.DateClose=item.DateClose;
            survey.Respondents=item.Respondents;
            survey.MaxPeople=item.MaxPeople;            
            
        }
    }
}
