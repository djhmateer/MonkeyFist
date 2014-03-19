using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MonkeyFist.Models {
    public enum UserStatus {
        Pending
    }
    
    public class User {
        public User() {
            this.ID = Guid.NewGuid();
            this.Status = UserStatus.Pending;
            this.ActivityLogs = new List<UserActivityLog>();
            this.MailerLogs = new List<UserMailerLog>();
            this.CreatedAt = DateTime.Now;
        }

        [MaxLength(255)]
        public string Email { get; set; }
        [Required]
        public string HashedPassword { get; set; }
        
        public Guid ID { get; set; }
        public UserStatus Status;
        public ICollection<UserActivityLog> ActivityLogs { get; set; }
        public ICollection<UserMailerLog> MailerLogs { get; set; }
        public DateTime CreatedAt { get; set; }
        
    }
}
