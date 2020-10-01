namespace WPF_App.Services
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using WPF_APP.Mapping;
    using WPF_APP.Models;

    public class PersonRepository : IRepository
    {
        private readonly IAppDbContextFactory appDbContextFactory;

        public PersonRepository(IAppDbContextFactory appDbContextFactory)
        {
            this.appDbContextFactory = appDbContextFactory;
        }

        public void Insert(Person person)
        {
            using var appDbContext = this.appDbContextFactory.Create();
            appDbContext.People.Add(person);
            appDbContext.SaveChanges();
        }

        public Person GetById(int id)
        {
            using var appDbContext = this.appDbContextFactory.Create();
            return appDbContext.People.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Person> GetAll()
        {
            using var appDbContext = this.appDbContextFactory.Create();
            var persons = appDbContext.People.ToList();
            return persons;
        }

        public void Update(Person person)
        {
            using var appDbContext = this.appDbContextFactory.Create();
            var user = appDbContext.People.Find(person.Id);
            if (user == null) return;
            MapPersonInfo(person, user);
            appDbContext.Entry(user).State = EntityState.Modified;
            appDbContext.SaveChanges();
        }

        public void Remove(int id)
        {
            using var appDbContext = this.appDbContextFactory.Create();
            var user = appDbContext.People.First(x => x.Id == id);
            appDbContext.People.Remove(user);
            appDbContext.SaveChanges();
        }

        private static void MapPersonInfo(Person person, Person user)
        {
            user.Name = person.Name;
            user.DateOfBirth = person.DateOfBirth;
            user.City = person.City;
            user.Email = person.Email;
            user.Password = person.Password;
            user.PhoneNumber = person.PhoneNumber;
        }
    }
}
