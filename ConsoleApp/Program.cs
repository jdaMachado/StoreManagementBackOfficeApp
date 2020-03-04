using Data;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (var context = new Context())
            {
                // Creates the database if not exists
                context.Database.EnsureCreated();

                /* context.User.Add(new User
                 {
                     ISBN = "978-0547247762",
                     Title = "The Sealed Letter",
                     Author = "Emma Donoghue",
                     Language = "English",
                     Pages = 416,
                     Publisher = publisher
                 });*/

                // Saves changes
                context.SaveChanges();
            }

            Console.ReadLine();
        }
    }
}
