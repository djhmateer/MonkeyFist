using MonkeyFist.Models;
using MonkeyFist.Services;
using System;
using Xunit;

namespace Specs.Registration {

    [Trait("Registration", "Empty email or password")]
    public class EmptyEmailOrPassword {
        RegistrationResult _result;
        public EmptyEmailOrPassword() {
            var reg = new Registrator();
            _result = reg.ApplyForMembership(new Application("", "password", ""));
        }

        [Fact(DisplayName = "The application is invalid")]
        public void ApplicationInvalid() {
            Assert.True(_result.Application.IsInvalid());
        }
        [Fact(DisplayName = "A message explains invalidation")]
        public void MessageReturned() {
            Assert.Contains("required", _result.Application.UserMessage);
        }
    }
}
