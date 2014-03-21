using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyFist.Models {
    public class UserSession {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public DateTime StartsAt { get; set; }
        public DateTime EndsAt { get; set; }

        public UserSession(Guid userID) {
            this.StartsAt = DateTime.Now;
            this.ID = Guid.NewGuid();
            this.UserID = userID;
            //default ends at to 30 days
            this.EndsAt = DateTime.Today.AddDays(30);
        }

    }
}
