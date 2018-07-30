$(document).ready(function () {
    GetClient();
    $('form').attr('autocomplete', 'off');
});


var TableName = $('#tblGetClient');

//Create column to show in datatable
var datatableColumn = [
    { "sTitle": "ClientID", "data": "OrganizationClientID", "visible": false},
    { "sTitle": "Client Name", "data": "ClientName", "width": "20%" },
    { "sTitle": "GSTIN No.", "data": "GSTINNo", "width": "15%" },
    { "sTitle": "Mobile No.", "data": "MobileNo", "width": "15%" },
    { "sTitle": "Email ID", "data": "Email", "width": "15%" },
    { "sTitle": "Action", "data": "Action", "width": "10%" }

]

//Get All Client Data 
function GetClient() {
    debugger;
    var objClient = new Object();
    //objClient.UserID = null;
    createDataTable(false, TableName, "Api/V1/GetClient", fnDataTableCallBack, datatableColumn, objClient, [], []);
}
function fnDataTableCallBack() { }


$('#btnaddClient').off('click').on('click', function (e) {
    return window.location = '/Client/CreateClient';
})

