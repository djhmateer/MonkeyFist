﻿using System;

namespace MonkeyFist.Models {
    public class UserMailerLog {
        public UserMailerLog() {
            this.ID = Guid.NewGuid();
            this.CreatedAt = DateTime.Now;
        }
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
