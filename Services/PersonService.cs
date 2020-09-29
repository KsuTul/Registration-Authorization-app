using System.Collections.Generic;
using System.Linq;
using App.Models;

namespace App.Services
{
    public class PersonService
    {
        private static IRepository _personRepository;

        public PersonService(IRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public static void Insert(Person person)
        {
            _personRepository.Insert(person);
        }

        public static Person GetById(int id)
        {
            return _personRepository.GetById(id);
        }

        public IList<Person> GetAll()
        {
            return _personRepository.GetAll().ToList();
        }

        public void Update(Person person)
        {
            _personRepository.Update(person);
        }

        public void Remove(int id)
        {
            _personRepository.Remove(id);
        }

    }
}
