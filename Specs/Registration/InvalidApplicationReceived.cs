using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Specs.Registration {
    [Trait("An Invalid Application is Received", "")]
    public class InvalidApplicationReveived {

        [Fact(DisplayName = "Application is denied")]
        public void UserDenied() {
            throw new NotImplementedException();
        }
        [Fact(DisplayName = "A message is shown explaining why")]
        public void MessageIsShown() {
            throw new NotImplementedException();
        }
    }
}
