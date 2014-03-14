using MonkeyFist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyFist.Services {

    public class Registrator {
        public RegistrationResult ApplyForMembership() {
            var result = new RegistrationResult();

            //successful registration!
            result.Message = "Welcome!";
            result.NewUser = new User();
            result.NewUser.ActivityLogs.Add(new UserActivityLog { Subject = "Registration", Entry = "User " + result.NewUser.Email + " successfully registered ", UserID = result.NewUser.ID });
            result.NewUser.MailerLogs.Add(new UserMailerLog { Subject = "Please confirm your email", Body = "Lorem Ipsum", UserID = result.NewUser.ID });
            return result;
        }
    }

    public class RegistrationResult {
        public User NewUser { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
        public RegistrationResult() {
            this.Success = false;
        }
    }
}
