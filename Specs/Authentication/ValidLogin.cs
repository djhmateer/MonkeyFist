using MonkeyFist.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Specs.Authentication {
    [Trait("Authentication", "Valid login")]
    public class ValidLogin {
        AuthenticationResult _result;
        public ValidLogin() {
            var auth = new Authenticator();
            _result = auth.AuthenticateUser(new Credentials { Email = "dave@dave.com", Password = "password" });
        }

        [Fact(DisplayName = "User authenticated")]
        public void AuthenticateTheUser() {
            Assert.True(_result.Authenticated);
        }
        [Fact(DisplayName = "Log entry created")]
        public void CreateLogEntry() {
            throw new NotImplementedException();
        }
        [Fact(DisplayName = "Remember me token is created")]
        public void RememberMeToken() {
            throw new NotImplementedException();
        }
        [Fact(DisplayName = "Remember me expires in 30 days")]
        public void RememberMeExpires() {
            throw new NotImplementedException();
        }
        [Fact(DisplayName = "User is returned")]
        public void UserReturned() {
            throw new NotImplementedException();
        }
        [Fact(DisplayName = "A welcome message is provided")]
        public void WelcomeMessageProvided() {
            throw new NotImplementedException();
        }
    }
}
