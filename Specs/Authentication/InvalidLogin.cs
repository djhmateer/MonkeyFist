using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Specs.Authentication {

    [Trait("Authentication", "Invalid Login")]
    public class InvalidLogin {
        [Fact(DisplayName = "Not authenticated")]
        public void NotAuthenticated() {
            throw new NotImplementedException();
        }
        [Fact(DisplayName = "Message provided")]
        public void MessageProvided() {
            throw new NotImplementedException();
        }
    }

    [Trait("Authentication","Email is not found")]
    public class EmailNotFound {
        [Fact(DisplayName = "Not authenticated")]
        public void NotAuthenticated() {
            throw new NotImplementedException();
        }
        [Fact(DisplayName = "Message provided")]
        public void MessageProvided() {
            throw new NotImplementedException();
        }
    }

    [Trait("Authentication", "Password does not match")]
    public class PasswordDoesNotMatch {
        [Fact(DisplayName = "Not authenticated")]
        public void NotAuthenticated() {
            throw new NotImplementedException();
        }
        [Fact(DisplayName = "Message provided")]
        public void MessageProvided() {
            throw new NotImplementedException();
        }
    }

}
