$(function () {

    // URL OF CONTACT GET/ADD/EDIT/UPDATE

    var controllerURL = "/AddressBook";
    var getURL = controllerURL + "/Get";
    var addURL = controllerURL + "/AddAddress";
    var updateURL = controllerURL + "/UpdateAddress";
    var removeURL = controllerURL + "/DeleteAddress";

    // This object will hold all methods (helper) to do CRUD operations
    var AddressCRUD = {

        // GET any address data by GUID
        get: function (addressID) {

            // return ajax response so other methods can use it like promise
            return $.ajax({
                type: "GET",
                url: getURL,
                dataType: "json",
                data: { addressID: addressID },

                // show ajax loader 
                beforeSend: function () {
                    showLoader();
                },
                // hide ajax loader
                complete: function () {
                    hideLoader();
                }
            });
        },

        // Add new contact address
        add: function (address) {

            // return promise for other methods to rely on
            return $.ajax({
                type: "POST",
                url: addURL,
                data: address, // send entire address model

                // show/hide spinner on waiting time of ajax response
                beforeSend: function () {
                    showLoader();
                },
                complete: function () {
                    hideLoader();
                }
            });
        },

        // Update any contact address; post entire address object so backend can update attributes
        update: function (address) {

            // return promise for other methods to rely on
            return $.ajax({
                type: "POST",
                url: updateURL,
                data: address,

                // show/hide ajax loader or spinner
                beforeSend: function () {
                    showLoader();
                },
                complete: function () {
                    hideLoader();
                }
            });
        },


        // Delete any address or contact information by passing just address id or guid of item
        remove: function (addressID) {
            // return promise for other methods to rely on
            return $.ajax({
                type: "POST",
                url: removeURL,
                dataType: "json",
                data: { addressID: addressID },

                beforeSend: function () {
                    showLoader();
                },
                complete: function () {
                    hideLoader();
                }
            });
        }

    }

    // ********************************************************
    // HELPER METHODS
    // ********************************************************

    // Whenever we open Add New Address Model, clear entire form like name, phone, address for user to enter
    $("#addAddressModal").on("show.bs.modal", function () {
        clearForm();
    });

    // To clear all values entered inside add new address modal form
    function clearForm() {
        $("#addAddressModal input").add("#addAddressModal textarea").val("");
    }

    // Show spinner when we wait for any operation
    function showLoader() {
        $("#loading-gif").show();
    }

    // Hide spinner when waiting for any operation is complete
    function hideLoader() {
        $("#loading-gif").hide();
    }

    // When address is updated we want to replace existing address item with new one
    function flipView(addressID, newAddressItem) {
        $("#" + addressID).replaceWith(newAddressItem);
    }

    // Same modal is used for add/update and this method is used at both place
    // So instead of duplicating making this common function here
    // To extract form values user enters
    function getFormValues() {
        // address book name
        var name = $("#txtName").val();
        // address book phone number
        var phone = $("#txtPhone").val();
        // address book full address
        var address = $("#txtAddress").val();

        // if any of these entries are empty, do not proceed further
        if (!name || !phone || !address) {
            alert("Please fill all values");
            return;
        }

        // if they are all having values, prepare object type
        // Property names below should match with backend model attribute names
        var data = {
            Name: name,
            PhoneNumber: phone,
            Address: address
        };

        return data;
    }

    // ********************************************************
    // PAGE OPERATIONS
    // ********************************************************

    // when we want to edit any address info, store that selected guid to use anywhere else
    // common variable shared across functions
    var selectedAddressID = "";

    // When we click add address button in page, show modal to enter values to user
    $("#btnAddAddress").click(function (e) {
        // Same model is used for add/edit
        // We toggle to show either add or update title and button

        // do not do any defaults
        e.preventDefault();

        // show add related button and heading in modal
        $("#btnAddSubmit").show();
        $("#modalTitleAdd").show();

        // as this is not update, so hide update button and heading
        $("#btnUpdateSubmit").hide();
        $("#modalTitleUpdate").hide();

        // now show modal to user
        $("#addAddressModal").modal("show");
    });

    // show same form as add address with edit mode
    $(document).delegate(".btnEdit", "click", function (e) {

        // do not do any defaults
        e.preventDefault();

        // hide add related heading and button
        $("#btnAddSubmit").hide();
        $("#modalTitleAdd").hide();

        // show update related heading and button in modal
        $("#btnUpdateSubmit").show();
        $("#modalTitleUpdate").show();

        // Whatever address is selected for edit, get its latest copy from server
        // and populate in modal
        // Also set this selected GUID at global level for other methods to use
        var addressID = selectedAddressID = $.trim($(this).attr("data-id"));

        // show modal to user
        $("#addAddressModal").modal("show");

        // get latest copy of selected record to edit
        var getPromise = AddressCRUD.get(addressID);

        getPromise.success(function (d) {
            // populate what server has sent in modal form
            $("#txtName").val(d.Name);
            $("#txtPhone").val(d.PhoneNumber);
            $("#txtAddress").val(d.Address);
        });

    });

    // Remove or delete any record
    $(document).delegate(".btnRemove", "click", function (e) {

        // do not do deafults
        e.preventDefault();

        // get selected address ID to be deleted
        var addressID = $.trim($(this).attr("data-id"));

        // Always confirm with user if they really want to remove this entry
        var confirmResponse = confirm("Are you sure?");

        // is true, then post server with selected address id
        if (confirmResponse) {
            var removePromise = AddressCRUD.remove(addressID);
            removePromise.success(function () {
                // delete on server is done, now remove that item in client side
                $("#" + addressID).remove();
            });
        }

    });

    // ********************************************************
    // CORE ADD/UPDATE METHODS AFTER CLICK IN MODAL
    // ********************************************************

    // Modal - Add entered data in form to db
    $("#btnAddSubmit").click(function () {

        // get all form values
        var data = getFormValues();

        // Hide Modal
        $("#addAddressModal").modal("hide");

        // use utility method to add data
        var addPromise = AddressCRUD.add(data)

        addPromise.success(function (d) {
            // add is success now append new data inside view
            $("#address-panel").append($(d));
        });

    });

    // Modal - Update entered data in form to db
    $("#btnUpdateSubmit").click(function () {

        // get all form values
        var data = getFormValues();

        // get selected address guid and set to object that will be sent
        // server needs to know which entry got updated by address guid
        data.ID = selectedAddressID;

        // Hide Modal
        $("#addAddressModal").modal("hide");

        var addPromise = AddressCRUD.update(data);

        addPromise.success(function (d) {
            // update is done, now replace old address item
            flipView(selectedAddressID, d);
        });

    });

});