using System;

namespace DAL.TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using var client = new DAL.Client("https://localhost:10042");
            var countries = client.Country.GetAllAsync().Result;
            Console.WriteLine("Hello World!");
        }
    }
}
