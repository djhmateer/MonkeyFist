using MonkeyFist.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Specs.Authentication {

    [Trait("Authentication", "Empty email or password")]
    public class EmptyEmail : TestBase {
        AuthenticationResult _result;
        public EmptyEmail() {
            _result = new Authenticator().AuthenticateUser(new Credentials { Email = "", Password = "password" });
        }
        [Fact(DisplayName = "Not Authenticated")]
        public void NotAuthenticated() {
            Assert.False(_result.Authenticated);
        }
        [Fact(DisplayName = "A message is returned explaining")]
        public void AMessageIsReturned() {
            Assert.Contains("required", _result.Message);
        }
    }

    [Trait("Authentication", "Empty email or password")]
    public class EmptyPassword : TestBase {
        AuthenticationResult _result;
        public EmptyPassword() {
            _result = new Authenticator().AuthenticateUser(new Credentials { Email = "dave@dave.com", Password = "" });
        }
        [Fact(DisplayName = "Not Authenticated")]
        public void NotAuthenticated() {
            Assert.False(_result.Authenticated);
        }
        [Fact(DisplayName = "A message is returned explaining")]
        public void AMessageIsReturned() {
            Assert.Contains("required", _result.Message);
        }
    }
}
