using MonkeyFist.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specs {
    public class TestBase : IDisposable {
        public TestBase() {
            new Session().Database.ExecuteSqlCommand("DELETE FROM Users");
        }
        public void Dispose() {
            new Session().Database.ExecuteSqlCommand("DELETE FROM Users");
        }
    }
}
