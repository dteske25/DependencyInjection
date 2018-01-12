function getContacts() {
    return $.get("/api/contact");
}

function getContact(id) {
    return $.get("/api/contact/" + id);
}

function createContact(firstName, lastName, emailAddress, phoneNumber) {
    var contact = { firstName, lastName, emailAddress, phoneNumber };
    return $.ajax({
        url: "/api/contact",
        type: 'POST',
        data: contact
    });
}

function updateContact(id, firstName, lastName, emailAddress, phoneNumber) {
    var contact = { id, firstName, lastName, emailAddress, phoneNumber };
    return $.ajax({
        url: "/api/contact/" + id,
        type: 'PUT',
        data: contact
    });
}

function deleteContact(id) {
    return $.ajax({
        url: "/api/contact/" + id,
        type: 'DELETE'
    });
}
