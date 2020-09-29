using System.Collections.Generic;
using App.Models;

namespace App
{
    public interface IRepository
    {
        void Insert(Person person);

        Person GetById(int id);

        IEnumerable<Person> GetAll();

        void Update(Person person);

        void Remove(int person);
    }
}
