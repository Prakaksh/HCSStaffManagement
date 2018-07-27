$(document).ready(function () {

});

var TableName = $('#tblGetClient');

//Create column to show in datatable 
var datatableColumn = [
    { "sTitle": "Client Name", "data": "ClientName", "width": "15%" },
    { "sTitle": "GSTIN No.", "data": "GSTINNo", "width": "15%" },
    { "sTitle": "Mobile No.", "data": "MobileNo", "width": "15%" },
    { "sTitle": "Email ID", "data": "Email", "width": "15%" },
    { "sTitle": "Action", "data": "", "width": "15%" }

]


//Get All User
function GetClient() {
    var objClient = new Object();
     
        userObj.UserID = null;
    createDataTable(false,TableName, "", fnDataTableCallBack, datatableColumn, objClient, [], []);


    
}
function fnDataTableCallBack() { }
