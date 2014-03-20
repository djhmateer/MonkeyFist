using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonkeyFist.Models;

namespace MonkeyFist.Services {
    public class AuthenticationResult {
        public bool Authenticated { get; set; }
        public string Message { get; set; }
        public User User { get; set; }
    }

    public class Credentials {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class Authenticator {
        Credentials CurrentCredentials;

        public AuthenticationResult AuthenticateUser(Credentials creds) {
            var result = new AuthenticationResult();
            this.CurrentCredentials = creds;

            //success!
            result.Authenticated = true;

            return result;
        }
    }
}
