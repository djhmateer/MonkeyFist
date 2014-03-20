using MonkeyFist.Models;
using MonkeyFist.Services;
using Xunit;

namespace Specs.Registration {
    [Trait("Valid Application", "")]
    public class ValidApplicationReceived : TestBase {
        Registrator _reg;
        RegistrationResult _result;
        User _user;

        public ValidApplicationReceived() : base() {
            var app = new Application("dave@dave.com", "password", "password");
            _reg = new Registrator();
            _result = _reg.ApplyForMembership(app);
            _user = _result.NewUser;
        }
        [Fact(DisplayName = "Application is validated")]
        public void ApplicationValidated() {
            Assert.True(_result.Application.IsValid());
        }
        [Fact(DisplayName = "Application is accepted")]
        public void ApplicationAccepted() {
            Assert.True(_result.Application.IsAccepted());
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
    }
}
