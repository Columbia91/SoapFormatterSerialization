using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;
using Newtonsoft.Json;

namespace SoapFormatterSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Брэдли", "Купер", "+77011012233", 1980);
            Person person2 = new Person("Эбби", "Корниш", "+77014040140", 1985);
            Person[] people = { person, person2 };

            // Задание: Сериализовать коллекцию с помощью класса SoapFormatter 
            // SoapFormatter не поддерживает сериализацию коллекции https://john475.files.wordpress.com/2014/07/serializecomparison.png
            SoapFormatter soapFormatter = new SoapFormatter();
            string path = "people.csv";
            using (FileStream fs = File.Create(path))
            {
                soapFormatter.Serialize(fs, people);
            }

            List<Person> list = new List<Person>();
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                Person[] newPeople = (Person[])soapFormatter.Deserialize(fs);
                for (int i = 0; i < newPeople.Length; i++)
                {
                    list.Add(newPeople[i]);
                }
            }

            JsonSerializer jsonSerializer = new JsonSerializer();
            using(StreamWriter fs = new StreamWriter("people.json"))
            {
                jsonSerializer.Serialize(fs, list);
            }
        }
    }
}