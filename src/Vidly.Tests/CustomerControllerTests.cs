using NUnit.Framework;
using System.Web.Mvc;
using Vidly.Controllers;

namespace Vidly.Tests
{
    [TestFixture]
    public class CustomerControllerTests
    {
        [Test]
        public void CustomerController_EditWhenCustomerIsNull_returnHttpNotFound()
        {
            //arrange
            var customer = new CustomerController();
            //Act
            var result = customer.Edit(0);
            //Assert
            Assert.That(result, Is.TypeOf<HttpNotFoundResult>());
            
        }
    }
}
