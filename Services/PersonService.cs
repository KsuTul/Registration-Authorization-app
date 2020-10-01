namespace WPF_APP.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using WPF_APP.Mapping;
    using WPF_APP.Models;

    public class PersonService
    {
        private static IRepository personRepository;

        public PersonService(IRepository personRepository)
        {
            PersonService.personRepository = personRepository;
        }

        public static void Insert(Person person)
        {
            personRepository.Insert(person);
        }

        public static Person GetById(int id)
        {
            return personRepository.GetById(id);
        }

        public IList<Person> GetAll()
        {
            return personRepository.GetAll().ToList();
        }

        public void Update(Person person)
        {
            personRepository.Update(person);
        }

        public void Remove(int id)
        {
            personRepository.Remove(id);
        }

    }
}
