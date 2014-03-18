using MonkeyFist.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyFist.DB {
    public class Session : DbContext {
        public Session() : base(nameOrConnectionString: "MonkeyFist") { }
        public DbSet<User> Users { get; set; }
        public DbSet<UserActivityLog> ActivityLogs{ get; set; }
        public DbSet<UserMailerLog> MailerLogs { get; set; }
    }
}
