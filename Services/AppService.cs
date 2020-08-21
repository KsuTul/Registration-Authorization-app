using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace App
{
     public class AppService
     {
         private static readonly List<Person> persons = new List<Person>();
         private static string _jsonFile;

         private static bool ReadPerson(string email)
         {
             using var read = new StreamReader("user.txt", true);
             {
                 var line = "";
                 while ((line = read.ReadLine()) != null)
                 {
                     persons.Add(JsonSerializer.Deserialize<Person>(line, new JsonSerializerOptions()));
                 }
             }
             var users = persons;
             return users.Any(x => x.Email == email);
        }

         //private static bool CheckUnique(string email)
         //{
         //    var users = ReadPerson().Result;
         //    return users.Any(x=>x.Email == email);
         //}
         public static void SavePerson(Person person)
         {
             if (ReadPerson(person.Email) == false)
             {
                 _jsonFile = JsonSerializer.Serialize<Person>(person, new JsonSerializerOptions());
                 using var stream = new StreamWriter("user.txt", true);
                 {
                     stream.WriteLineAsync(_jsonFile);
                 }
                 MessageBox.Show("Now you are with us!");
             }
             else
             {
                 MessageBox.Show("This user exist");
             }

         }
     }
}
