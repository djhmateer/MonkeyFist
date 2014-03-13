using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Specs.Registration {

    [Trait("An application is received with empty email or password", "")]
    public class EmptyEmailOrPassword {

        [Fact(DisplayName = "Application is invalid")]
        public void ApplicaitonConsideredInvalid() {
            throw new NotImplementedException();
        }

        [Fact(DisplayName = "A message is returned")]
        public void A_Message_is_Returned() {
            throw new NotImplementedException();
        }
    }
}
