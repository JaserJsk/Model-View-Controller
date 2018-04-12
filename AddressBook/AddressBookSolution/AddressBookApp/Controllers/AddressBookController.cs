using AddressBookApp.Models.AddressBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AddressBookApp.Controllers
{
    /// <summary>
    /// Handles all address book related actions
    /// </summary>
    public class AddressBookController : Controller
    {
        /// <summary>
        /// Load entire list of address info stored in database and send to view file
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            // Entity Framework Context
            AddressBookContext aContext = new AddressBookContext();

            // Get entire address book as list
            var allAddress = aContext.AddressBook.ToList();

            // Bind model to view
            return View(allAddress);
        }

        /// <summary>
        /// Get particular contact by id in json format
        /// </summary>
        /// <param name="addressID"></param>
        /// <returns></returns>
        public JsonResult Get(Guid addressID)
        {
            AddressBookContext aContext = new AddressBookContext();
            return Json(aContext.AddressBook.Where(r => r.ID == addressID).FirstOrDefault(), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// To add contact to address book
        /// Used from ajax calls
        /// </summary>
        /// <param name="addressBook"></param>
        /// <returns></returns>
        public ActionResult AddAddress(AddressBook addressBook)
        {
            AddressBookContext aContext = new AddressBookContext();

            // Create new instance of address book or can use same as parameter instance
            AddressBook aBook = new AddressBook()
            {
                // Generate new guid or so called ID
                ID = Guid.NewGuid(),
                Name = addressBook.Name,
                PhoneNumber = addressBook.PhoneNumber,
                Address = addressBook.Address,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow
            };

            aContext.AddressBook.Add(aBook);

            // Save changes to database
            aContext.SaveChanges();

            // Return partial view; Send data along with view name so that view binds with this data and results are sent in ajax
            return PartialView("_AddressItem", aBook);
        }

        /// <summary>
        /// Update address, it should be existing in db
        /// </summary>
        /// <param name="addressBook"></param>
        /// <returns></returns>
        public ActionResult UpdateAddress(AddressBook addressBook)
        {
            AddressBookContext aContext = new AddressBookContext();

            // Get that addressbook item which got modified
            var targetAddress = aContext.AddressBook.Where(r => r.ID == addressBook.ID).FirstOrDefault();

            // Update could be any of below attribute so reassign every attribute
            targetAddress.Name = addressBook.Name;
            targetAddress.Address = addressBook.Address;
            targetAddress.PhoneNumber = addressBook.PhoneNumber;
            targetAddress.UpdateDate = DateTime.UtcNow;

            // Save changes to db
            aContext.SaveChanges();

            // Return partial view with model bind; view with new updated data will be sent in ajax response
            return PartialView("_AddressItem", targetAddress);
        }

        /// <summary>
        /// Remove certain contact
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult DeleteAddress(Guid addressID)
        {
            if (addressID == Guid.Empty) return Json("");

            AddressBookContext aContext = new AddressBookContext();

            // Search and get item we want to remove
            var targetAddress = aContext.AddressBook.Where(r => r.ID == addressID).FirstOrDefault();

            aContext.AddressBook.Remove(targetAddress);

            // Change in db
            aContext.SaveChanges();

            // Simply return success in ajax response
            return Json("success");
        }
    }
}