using System;

namespace MonkeyFist.Models {
    public enum ApplicationStatus {
        NotProcessed,
        Invalid,
        Validated,
        Accepted,
        Denied
    }

    public class Application {

        public string Email { get; set; }
        public string Password { get; set; }
        public string Confirmation { get; set; }
        public ApplicationStatus Status { get; set; }
        public string UserMessage { get; set; }

        public Application(string email, string password, string confirm) {
            this.Email = email;
            this.Password = password;
            this.Confirmation = confirm;
            this.Status = ApplicationStatus.NotProcessed;
        }

        public bool IsAccepted() {
            return this.Status == ApplicationStatus.Accepted;
        }

        public bool IsInvalid() {
            return !IsValid();
        }

        public bool IsValid() {
            return this.Status == ApplicationStatus.Validated ||
              this.Status == ApplicationStatus.Accepted;
        }
    }
}
