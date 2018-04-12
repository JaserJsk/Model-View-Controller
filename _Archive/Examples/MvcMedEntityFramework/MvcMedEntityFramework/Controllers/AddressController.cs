using System;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using MvcMedEntityFramework.Data;
using MvcMedEntityFramework.Data.Repositories;

namespace MvcMedEntityFramework.Controllers
{

    public class AddressController : Controller
    {
        private IAddressRepository repository;

        public AddressController(IAddressRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            return View(repository.All());
        }

        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(string streetName, int streetNumber)
        {
            var address = new Address();

            address.StreetName = streetName;
            address.StreetNumber = streetNumber;

            repository.Add(address);

            return PartialView("List", repository.All());
        }

        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            repository.Delete(id);

            return PartialView("List", repository.All());
        }
    }
}