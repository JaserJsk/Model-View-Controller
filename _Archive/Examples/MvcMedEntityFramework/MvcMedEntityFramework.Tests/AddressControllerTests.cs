using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcMedEntityFramework.Controllers;
using MvcMedEntityFramework.Data;
using MvcMedEntityFramework.Data.Repositories;
using NSubstitute;

namespace MvcMedEntityFramework.Tests
{
    [TestClass]
    public class AddressControllerTests
    {
        [TestMethod]
        public void Index_SimpleCall_ShouldReturn_ViewDataWithAddresses()
        {
            var  addresses = new[]
            {
                new Address {StreetName = "From a test!"}
            };

            var repository = Substitute.For<IAddressRepository>();
            repository.All().Returns(addresses);

            var controller = new AddressController(repository);

            ViewResult indexResult = controller.Index() as ViewResult;

            Assert.IsNotNull(indexResult.Model);

            var firstAddressInModel = ((IEnumerable<Address>) indexResult.Model).First();

            Assert.AreEqual("From a test!", firstAddressInModel.StreetName);
        }
    }
}
