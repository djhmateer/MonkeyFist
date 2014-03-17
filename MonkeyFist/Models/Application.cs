using System;

namespace MonkeyFist.Models {
    public enum ApplicationStatus {
        Pending,
        Accepted,
        Denied
    }

    public class Application {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Confirmation { get; set; }
        public bool IsValid { get; set; }
        public ApplicationStatus Status { get; set; }
        public string UserMessage { get; set; }

        public Application(string email, string password, string confirm) {
            this.Email = email;
            this.Password = password;
            this.Confirmation = confirm;
            this.Status = ApplicationStatus.Pending;

            if (String.IsNullOrWhiteSpace(this.Email) || string.IsNullOrWhiteSpace(this.Password))
                throw new InvalidOperationException("Can't have an Application without Email or Password!");

            this.IsValid = false;
        }
    }
}
