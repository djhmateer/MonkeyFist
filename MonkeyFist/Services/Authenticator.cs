using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonkeyFist.Models;
using MonkeyFist.DB;
using DevOne.Security.Cryptography.BCrypt;

namespace MonkeyFist.Services {
    public class AuthenticationResult {
        public bool Authenticated { get; set; }
        public string Message { get; set; }
        public User User { get; set; }
    }

    public class Credentials {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class Authenticator {
        Credentials CurrentCredentials;

        public virtual void CreateSession(User user) {
            user.Sessions.Add(new UserSession(user.ID));
        }

        public virtual User LocateUser() {
            User user = null;
            using (var session = new Session()) {
                user = session.Users.FirstOrDefault(u => u.Email == CurrentCredentials.Email);
            }
            return user;
        }
        public virtual void SaveUserLogin(User user) {
            using (var session = new Session()) {
                //session.
            }
        }
        public AuthenticationResult AuthenticateUser(Credentials creds) {
            var result = new AuthenticationResult();
            this.CurrentCredentials = creds;

            if (EmailOrPasswordNotPresent())
                return InvalidLogin("Email and Password are required to login");

            var user = LocateUser();

            if (user == null)
                return InvalidLogin("Invalid email or password");

            if (HashedPasswordDoesNotMatch(user))
                return InvalidLogin("Invalid email or password");

            //success!
            user.AddLogEntry("Login", "User logged in");
            CreateSession(user);

            //save changes
            SaveUserLogin(user);

            result.Authenticated = true;
            result.User = user;
            result.Message = "Welcome! You are logged in";
            return result;
        }

        public virtual bool HashedPasswordDoesNotMatch(User user) {
            return !BCryptHelper.CheckPassword(CurrentCredentials.Password, user.HashedPassword);
        }

        private AuthenticationResult InvalidLogin(string message) {
            return new AuthenticationResult { Message = message, Authenticated = false };
        }

        private bool EmailOrPasswordNotPresent() {
            return String.IsNullOrWhiteSpace(CurrentCredentials.Email) ||
                String.IsNullOrWhiteSpace(CurrentCredentials.Password);
        }

    }
}
