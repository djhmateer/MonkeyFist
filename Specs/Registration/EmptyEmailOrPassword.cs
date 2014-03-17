using MonkeyFist.Models;
using MonkeyFist.Services;
using System;
using Xunit;

namespace Specs.Registration {

    [Trait("An application is created with empty email or password", "")]
    public class EmptyEmailOrPassword {
        [Fact(DisplayName = "An exception is thrown with empty email")]
        public void ApplicaitonConsideredInvalid() {
            Assert.Throws<InvalidOperationException>(
                () => new Application("","password", "password")
            );
        }

        [Fact(DisplayName = "An exception is thrown with empty password")]
        public void A_Message_is_Returned() {
            Assert.Throws<InvalidOperationException>(
                () => new Application("dave@dave.com", "", "password")
            );
        }
    }
}
