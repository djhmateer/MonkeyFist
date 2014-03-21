using MonkeyFist.Models;
using MonkeyFist.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Specs.Authentication {
    [Trait("Authentication", "Valid login")]
    public class ValidLogin : TestBase {
        AuthenticationResult _result;
        public ValidLogin() {
            //register the new user...
            var app = new Application("dave@dave.com", "password", "password");
            new Registrator().ApplyForMembership(app);
            
            var auth = new Authenticator();
            _result = auth.AuthenticateUser(new Credentials { Email = "dave@dave.com", Password = "password" });
        }

        [Fact(DisplayName = "User authenticated")]
        public void AuthenticateTheUser() {
            Assert.True(_result.Authenticated);
        }
        [Fact(DisplayName = "User is returned")]
        public void UserReturned() {
            Assert.NotNull(_result.User);
        }
        [Fact(DisplayName = "Log entry created")]
        public void CreateLogEntry() {
            Assert.True(_result.User.Logs.Count > 0);
        }
        [Fact(DisplayName = "A session is created")]
        public void SessionCreated() {
            Assert.True(_result.User.Sessions.Count > 0);
        }
        [Fact(DisplayName = "User has current session")]
        public void UserHasCurrentSession() {
            Assert.NotNull(_result.User.CurrentSession);
        }
        [Fact(DisplayName = "A session expires in 30 days")]
        public void RememberMeExpires() {
            Assert.True(_result.User.CurrentSession.EndsAt == DateTime.Today.AddDays(30));
        }
        
        [Fact(DisplayName = "A welcome message is provided")]
        public void WelcomeMessageProvided() {
            Assert.Contains("Welcome", _result.Message);
        }
    }
}
