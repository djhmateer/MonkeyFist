using MonkeyFist.DB;
using MonkeyFist.Models;
using MonkeyFist.Services;
using System;
using Xunit;

namespace Specs.Registration {
    [Trait("A Valid Application is Submitted", "")]
    public class ValidApplicationReceived : IDisposable {
        Registrator _reg;
        RegistrationResult _result;
        User _user;

        public ValidApplicationReceived() {
            new Session().Database.ExecuteSqlCommand("DELETE FROM Users");

            _reg = new Registrator();
            var app = new Application("dave@dave.com", "password", "password");
            _result = _reg.ApplyForMembership(app);
            _user = _result.NewUser;
        }
        [Fact(DisplayName = "Application is validated")]
        public void ApplicationValidated() {
            Assert.True(_result.Application.IsValid);
        }
        [Fact(DisplayName = "A user is added to the system")]
        public void User_Is_Added_To_System() {
            Assert.NotNull(_user);
        }
        [Fact(DisplayName = "User status set to Pending")]
        public void User_Status_Set_to_Pending() {
            Assert.Equal(UserStatus.Pending, _user.Status);
        }
        [Fact(DisplayName = "Log entry created for event")]
        public void Log_Entry_Is_Created_For_Event() {
            Assert.Equal(1, _user.ActivityLogs.Count);
        }
        [Fact(DisplayName = "Email sent to confirm address")]
        public void Email_Sent_to_Confirm_Address() {
            Assert.Equal(1, _user.MailerLogs.Count);
        }
        [Fact(DisplayName = "A confirmation message is provided to show to the user")]
        public void A_Message_is_Provided_for_User() {
            Assert.Equal("Welcome!", _result.Application.UserMessage);
        }

        // a global dispose?
        public void Dispose() {
            new Session().Database.ExecuteSqlCommand("DELETE FROM Users");
        }
    }
}
