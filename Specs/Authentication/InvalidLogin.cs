using MonkeyFist.Models;
using MonkeyFist.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Specs.Authentication {

    [Trait("Authentication","Email is not found")]
    public class EmailNotFound {
        AuthenticationResult _result;
        public EmailNotFound() {
            _result = new Authenticator().AuthenticateUser(new Credentials { Email = "dave@dave.com", Password = "password" });
        }
        [Fact(DisplayName = "Not Authenticated")]
        public void AuthDenied() {
            Assert.False(_result.Authenticated);
        }
        [Fact(DisplayName = "A message is returned explaining")]
        public void AMessageIsReturned() {
            Assert.Contains("Invalid email", _result.Message);
        }
    }

    [Trait("Authentication", "Password does not match")]
    public class PasswordDoesNotMatch : TestBase {
        
        AuthenticationResult _result;
        public PasswordDoesNotMatch() {
            var app = new Application("dave@dave.com", "password", "password");
            new Registrator().ApplyForMembership(app);

            _result = new Authenticator().AuthenticateUser(new Credentials { Email = "dave@dave.com", Password = "asdf" });
        }
        [Fact(DisplayName = "Not authenticated")]
        public void NotAuthenticated() {
            Assert.False(_result.Authenticated);
        }
        [Fact(DisplayName = "Message provided")]
        public void MessageProvided() {
            Assert.Contains("Invalid email", _result.Message);
        }
    }
}
