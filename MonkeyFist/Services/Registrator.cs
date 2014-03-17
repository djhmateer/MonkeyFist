using MonkeyFist.Models;
using System;

namespace MonkeyFist.Services {
    public class RegistrationResult {
        public User NewUser { get; set; }
        public Application Application { get; set; }
    }

    public class Registrator {
        Application _app;

        //public virtual Application ValidateApplication(Application app) {
        //    if (app.Email.Length < 6) {
        //        app.IsValid = false;
        //        app.Status = ApplicationStatus.Denied;
        //        app.UserMessage = Properties.Resources.InvalidEmailMessage;
        //    } else {
        //        app.IsValid = true;
        //    }
        //    return app;
        //}

        public virtual RegistrationResult ApplicationAccepted() {
            var result = new RegistrationResult();
            _app.Status = ApplicationStatus.Accepted;
            result.Application = _app;

            result.Application.UserMessage = "Welcome!";
            result.NewUser = new User();
            result.NewUser.ActivityLogs.Add(new UserActivityLog { Subject = "Registration", Entry = "User " + result.NewUser.Email + " successfully registered ", UserID = result.NewUser.ID });

            result.NewUser.MailerLogs.Add(new UserMailerLog { Subject = "Please confirm your email", Body = "Lorem Ipsum", UserID = result.NewUser.ID });
            result.Application.IsValid = true;
            return result;
        }

        bool EmailOrPasswordNotPresent() {
            return String.IsNullOrWhiteSpace(_app.Email) || String.IsNullOrWhiteSpace(_app.Password);
        }

        public virtual bool EmailIsInvalid() {
            return _app.Email.Length <= 5;
        }

        public virtual bool PasswordIsInvalid() {
            return _app.Password.Length <= 4;
        }

        public virtual bool PasswordDoesNotMatchConfirmation() {
            return !_app.Password.Equals(_app.Confirmation);
        }

        public RegistrationResult InvalidApplication(string reason) {
            var result = new RegistrationResult();
            _app.Status = ApplicationStatus.Denied;
            result.Application = _app;
            result.Application.UserMessage = reason;
            return result;
        }

        public RegistrationResult ApplyForMembership(Application app) {
            _app = app;
            var result = new RegistrationResult();
           
            result.Application = app;
            result.Application.UserMessage = "Welcome!";

            if (EmailOrPasswordNotPresent())
                return InvalidApplication("Invalid - email and password are required");

            if (EmailIsInvalid())
                return InvalidApplication(Properties.Resources.InvalidEmailMessage);

            if (PasswordIsInvalid())
                return InvalidApplication("Invalid password - < 5 chars");

            if (PasswordDoesNotMatchConfirmation())
                return InvalidApplication("Password doesn't match confirmation");

            //if (EmailAlreadyRegistered())
            //    return InvalidApplication(Properties.Resources.EmailExists);

            return ApplicationAccepted();
        }
    }


}
