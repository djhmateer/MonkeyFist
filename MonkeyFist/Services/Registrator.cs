using DevOne.Security.Cryptography.BCrypt;
using MonkeyFist.DB;
using MonkeyFist.Models;
using System;
using System.Linq;

namespace MonkeyFist.Services {
    public class RegistrationResult {
        public User NewUser { get; set; }
        public Application Application { get; set; }
    }

    public class Registrator {
        protected Application CurrentApplication;

        bool EmailOrPasswordNotPresent() {
            return String.IsNullOrWhiteSpace(CurrentApplication.Email) || String.IsNullOrWhiteSpace(CurrentApplication.Password);
        }

        public virtual bool EmailAlreadyRegistered() {
            var exists = false;
            using (var session = new Session()) {
                exists = session.Users.FirstOrDefault(u => u.Email == CurrentApplication.Email) != null;
            }
            return exists;
        }

        public virtual bool EmailIsInvalid() {
            return CurrentApplication.Email.Length <= 5;
        }

        public virtual bool PasswordIsInvalid() {
            return CurrentApplication.Password.Length <= 4;
        }

        public virtual bool PasswordDoesNotMatchConfirmation() {
            return !CurrentApplication.Password.Equals(CurrentApplication.Confirmation);
        }

        public RegistrationResult InvalidApplication(string reason) {
            var result = new RegistrationResult();
            CurrentApplication.Status = ApplicationStatus.Invalid;
            result.Application = CurrentApplication;
            result.Application.UserMessage = reason;
            return result;
        }

        public virtual string HashPassword() {
            return BCryptHelper.HashPassword(CurrentApplication.Password, BCryptHelper.GenerateSalt(10));
        }

        public virtual void SendConfirmationRequest(User user) {

            //TODO: Create mailing  bits

            //add a mail log
            //user.MailerLogs.Add(new UserMailerMessage { Subject = "Please Confirm Your Email", Body = "Lorem Ipsum" });
            user.MailerLogs.Add(new UserMailerLog { Subject = "Please Confirm Your Email", Body = "Lorem Ipsum" });

        }
        public virtual User CreateUserFromCurrentApplication() {
            return new User {
                Email = CurrentApplication.Email,
                HashedPassword = HashPassword(),
                Status = UserStatus.Pending
            };
        }
        public virtual void SaveNewUser(User user) {
            using (var session = new Session()) {
                session.Users.Add(user);
                session.SaveChanges();
            }
        }

        // Part 2 
        public virtual User AcceptApplication() {

            //set the status
            CurrentApplication.Status = ApplicationStatus.Accepted;

            //crete the new user
            var user = CreateUserFromCurrentApplication();

            //log the registration
            //user.AddLogEntry("Registration", "User with email " + user.Email + " successfully registered");
            user.ActivityLogs.Add( new UserActivityLog {Subject = "Registration", Entry = "User with email " + user.Email + " successfully registered"});

            //send off an email
            SendConfirmationRequest(user);
            //user.AddLogEntry("Registration", "Email confirmation request sent");

            //save the user changes with activity logs etc..
            SaveNewUser(user);

            return user;
        }

        // Part 1
        public RegistrationResult ApplyForMembership(Application app) {
            var result = new RegistrationResult();

            CurrentApplication = app;
            result.Application = app;
            result.Application.UserMessage = "Welcome!";

            if (EmailOrPasswordNotPresent())
                return InvalidApplication(Properties.Resources.EmailOrPasswordMissing);

            if (EmailIsInvalid())
                return InvalidApplication(Properties.Resources.InvalidEmailMessage);

            if (PasswordIsInvalid())
                return InvalidApplication(Properties.Resources.InvalidPassword);

            if (PasswordDoesNotMatchConfirmation())
                return InvalidApplication(Properties.Resources.PasswordConfirmationMismatch);

            if (EmailAlreadyRegistered())
                return InvalidApplication(Properties.Resources.EmailExists);

            //Accept the application
            result.NewUser = AcceptApplication();

            ////log them in
            //var auth = new Authenticator().AuthenticateUser(new Credentials { Email = result.NewUser.Email, Password = CurrentApplication.Password });
            //result.SessionToken = auth.Session.ID;

            return result;

        }
    }
}
