$(document).ready(function () {
  
});


GetReport();


//Create column to show in datatable
var datatableColumn = [
    { "sTitle": "ClientID", "data": "OrganizationClientID", "visible": false },
    { "sTitle": "Client Name", "data": "ClientName", "width": "15%" },
    { "sTitle": "GSTIN No.", "data": "GSTINNo", "width": "15%" },
    { "sTitle": "Mobile No.", "data": "MobileNo", "width": "15%" },
    { "sTitle": "Email ID", "data": "Email", "width": "15%" },
    { "sTitle": "Action", "data": "Action", "width": "15%" }

]
