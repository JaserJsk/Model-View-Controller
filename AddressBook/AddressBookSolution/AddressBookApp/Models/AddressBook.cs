using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AddressBookApp.Models
{
    /// <summary>
    /// DB First Entity Framework Approach
    /// </summary>
    public class AddressBookContext : DbContext
    {
        public AddressBookContext() : base("name=AddressBookDBConnectionString") { }

        public DbSet<AddressBook> AddressBook { get; set; }
    }

    /// <summary>
    /// We need one model to capture address and contact details
    /// </summary>
    public class AddressBook
    {
        // unique row id, primary key
        public Guid ID { get; set; }
        // name
        public String Name { get; set; }
        // phone number
        public String PhoneNumber { get; set; }
        // address, could be multiple line
        public String Address { get; set; }
        // add created date
        public DateTime CreateDate { get; set; }
        // update date, keeps changing when update is done
        public DateTime UpdateDate { get; set; }
    }
}