using System;

namespace MonkeyFist.Models {
    public class UserActivityLog {
        public UserActivityLog() {
            this.ID = Guid.NewGuid();
            this.CreatedAt = DateTime.Now;
        }
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public string Subject { get; set; }
        public string Entry { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
