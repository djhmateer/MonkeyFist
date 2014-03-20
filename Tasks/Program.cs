using MonkeyFist.DB;
using MonkeyFist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks {
    class Program {
        static void Main(string[] args) {
            var session = new Session();
            foreach (var log in session.ActivityLogs) {
                Console.WriteLine(log.Entry);
            }

            //var user = new User { Email = "dave@dave.com" };
            //session.Users.Add(user);
            //session.SaveChanges();
            Console.WriteLine("Done!");
            Console.Read();
        }
    }
}
