namespace WPF_APP.Mapping
{
    using System.Collections.Generic;
    using WPF_APP.Models;

    public interface IRepository
    {
        void Insert(Person person);

        Person GetById(int id);

        IEnumerable<Person> GetAll();

        void Update(Person person);

        void Remove(int person);
    }
}
