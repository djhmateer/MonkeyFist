using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyFist.Models {
    public enum UserStatus {
        Pending
    }
    
    public class User {
        public Guid ID { get; set; }
        public UserStatus Status;
        public ICollection<UserActivityLog> ActivityLogs { get; set; }
        public ICollection<UserMailerLog> MailerLogs { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public User() {
            this.ID = Guid.NewGuid();
            this.Status = UserStatus.Pending;
            this.ActivityLogs = new List<UserActivityLog>();
            this.MailerLogs = new List<UserMailerLog>();
            this.CreatedAt = DateTime.Now;
        }
    }
}
