using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MonkeyFist.Models {
    public enum UserStatus {
        Pending
    }
    
    public class User {
        public User() {
            this.ID = Guid.NewGuid();
            this.Status = UserStatus.Pending;
            this.Logs = new List<UserActivityLog>();
            this.MailerLogs = new List<UserMailerLog>();
            this.Sessions = new List<UserSession>();
            this.CreatedAt = DateTime.Now;
        }

        [MaxLength(255)]
        public string Email { get; set; }
        [Required]
        public string HashedPassword { get; set; }
        
        public Guid ID { get; set; }
        public UserStatus Status;
        public ICollection<UserActivityLog> Logs { get; set; }
        public ICollection<UserMailerLog> MailerLogs { get; set; }
        public ICollection<UserSession> Sessions { get; set; }
        public DateTime CreatedAt { get; set; }

        public void AddLogEntry(string subject, string entry) {
            this.Logs.Add(new UserActivityLog { Subject = subject, Entry = entry });
        }

        public UserSession CurrentSession {
            get {
                return this.Sessions.OrderByDescending(s => s.EndsAt).FirstOrDefault();
            }
        }

    }
}
