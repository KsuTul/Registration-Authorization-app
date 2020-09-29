using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using App.Helpers;
using App.Models;

namespace App.Services
{
     public class PersonTextRepository : IRepository
     {
         private static readonly List<Person> Persons = new List<Person>();
         private static string path = "user.txt";
         private static string _jsonFile;

         public string Read(string email, string password)
         {
             GetPersonsList();
             if (email != null)
             {
                 return Persons.Any(x => x.Email == email && x.Password == password)
                     ? "This user exist"
                     : "Please, registrate!";
             }

             throw new Exception(Messages.ExceptionMessage);
         }

         public void Insert(Person person)
         {
             _jsonFile = JsonSerializer.Serialize<Person>(person, new JsonSerializerOptions());
                 using var stream = new StreamWriter(path, true);
                 {
                     stream.WriteLineAsync(_jsonFile);
                 }
         }

         public Person GetById(int id)
         {
             throw new NotImplementedException();
         }

         public IEnumerable<Person> GetAll()
         {
             throw new NotImplementedException();
         }

         public void Update(Person person)
         {
             throw new NotImplementedException();
         }

         public void Remove(int id)
         {
             throw new NotImplementedException();
         }

         public List<Person> GetPersonsList()
         {
             using var read = new StreamReader(path, true);
             {
                 var line = "";
                 while ((line = read.ReadLine()) != null)
                 {
                     Persons.Add(JsonSerializer.Deserialize<Person>(line, new JsonSerializerOptions()));
                 }
             }
             return Persons;
         }
     }
}
