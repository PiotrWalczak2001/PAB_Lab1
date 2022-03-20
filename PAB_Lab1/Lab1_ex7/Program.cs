using System;
using System.Text.Json;

namespace Lab1_ex7_ex8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 7.Convert Java object to JSON (https://dirask.com/posts/Java-convert-object-to-JSON-String-with-Jackson-lib-3D7OrD)
            // 8.Convert JSON to Java object (https://dirask.com/posts/Java-parse-JSON-to-object-with-Jackson-lib-jMmzXj)
            Console.WriteLine("Lab1 Ex7");
            User user = new User() { Name = "John", Age = 21 };
            string userJson = JsonSerializer.Serialize(user);
            Console.WriteLine(userJson);
            var deserializedUser = JsonSerializer.Deserialize<User>(userJson);
            Console.WriteLine(deserializedUser.Name + " " + deserializedUser.Age);
        }
    }
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
