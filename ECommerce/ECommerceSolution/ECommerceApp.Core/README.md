
First make sure that the correct ```data source & initial catalog``` is configured.

``` Web.config
<connectionStrings>
    <add name="AddressBookDBConnectionString" connectionString="data source=DESKTOP-LM7PGQ6; initial catalog=AddressBookDB; 
    integrated security=SSPI" providerName="System.Data.SqlClient" />
</connectionStrings>
```

Here I add all fields to be saved in the database.

``` AddressBook.cs 
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
```

The following code adds new contact to the address book.

``` AddressBookController.cs
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
​
    aContext.AddressBook.Add(aBook);
​
    // Save changes to database
    aContext.SaveChanges();
​
    // Return partial view; Send data along with view name so that view binds with this data and results are sent in ajax
    return PartialView("_AddressItem", aBook);
}
```

The code below updates an existing contact in the Address Book.

``` AddressBookController.cs
public ActionResult UpdateAddress(AddressBook addressBook)
{
    AddressBookContext aContext = new AddressBookContext();
​
    // Get that addressbook item which got modified
    var targetAddress = aContext.AddressBook.Where(r => r.ID == addressBook.ID).FirstOrDefault();
​
    // Update could be any of below attribute so reassign every attribute
    targetAddress.Name = addressBook.Name;
    targetAddress.Address = addressBook.Address;
    targetAddress.PhoneNumber = addressBook.PhoneNumber;
    targetAddress.UpdateDate = DateTime.UtcNow;
​
    // Save changes to db
    aContext.SaveChanges();
​
    // Return partial view with model bind; view with new updated data will be sent in ajax response
    return PartialView("_AddressItem", targetAddress);
}
```

The code below deletes an existing contact from the address book.

``` AddressBookController.cs
public JsonResult DeleteAddress(Guid addressID)
{
    if (addressID == Guid.Empty) return Json("");
​
    AddressBookContext aContext = new AddressBookContext();
​
    // Search and get item we want to remove
    var targetAddress = aContext.AddressBook.Where(r => r.ID == addressID).FirstOrDefault();
​
    aContext.AddressBook.Remove(targetAddress);
​
    // Change in db
    aContext.SaveChanges();
​
    // Simply return success in ajax response
    return Json("success");
}
```