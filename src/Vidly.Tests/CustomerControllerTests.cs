using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vidly.Controllers;

namespace Vidly.Tests
{
    [TestFixture]
    public class CustomerControllerTests
    {
        [Test]
        public void CustomerController_EditWhenCustomerIsNull()
        {
            var customer = new CustomerController();
            
        }
    }
}
