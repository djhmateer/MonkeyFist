using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Specs.Authentication {

    [Trait("Authentication", "Empty email or password")]
    public class EmptyEmailOrPassword {
        [Fact(DisplayName = "Not Authenticated")]
        public void NotAuthenticated() {
            throw new NotImplementedException();
        }
        [Fact(DisplayName = "A message is returned explaining")]
        public void AMessageIsReturned() {
            throw new NotImplementedException();
        }
    }
}
