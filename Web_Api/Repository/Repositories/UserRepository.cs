using Repository.Entities;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly IContext context;
        public UserRepository(IContext context)
        {
            this.context = context;
        }
        public User AddItem(User item)
        {
            context.Users.Add(item);
            context.Save();
            return item;
        }

        public void DeleteItem(int id)
        {
            User user = context.Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
                context.Users.Remove(user);
            context.Save();
        }

        public List<User> GetAll()
        {
            return context.Users.ToList();
        }

        public User GetById(int id)
        {
            return context.Users.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateItem(User item)
        {
            User user = context.Users.FirstOrDefault(x => x.Id == item.Id);
            user.FirstName = item.FirstName;
            user.LastName = item.LastName;
            user.BornDate = item.BornDate;
            user.Gender = item.Gender;
            user.Sector = item.Sector;
            user.City = item.City;
            user.Email = item.Email;
            user.Password = item.Password;
            user.Role = item.Role;
            user.OwnSurveys = item.OwnSurveys;
            user.AnsweredSurveys = item.AnsweredSurveys;
            context.Save();
        }

    }
}
