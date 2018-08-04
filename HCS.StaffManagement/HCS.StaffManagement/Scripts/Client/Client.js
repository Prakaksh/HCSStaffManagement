$(document).ready(function () {
    GetClient();
    $('form').attr('autocomplete', 'off');
});


var TableName = $('#tblGetClient');

var btnNotePadActions = '<a href="#!" class="custom-div notepad" data-activates="slide-out"><i class="material-icons">assignment</i></a>'

function fnAction() {
    var btnNotePadActions = '<a href="#!" class="custom-div Edit_Mode"><i class="material-icons">edit</i></a>'
    return btnNotePadActions;

}

//Create column to show in datatable
var datatableColumn = [
    { "sTitle": "ClientID", "data": "OrganizationClientID", "visible": false},
    { "sTitle": "Client Name", "data": "ClientName", "width": "20%" },
    { "sTitle": "GSTIN No.", "data": "ClientGSTIN", "width": "15%" },
    { "sTitle": "Mobile No.", "data": "MobileNo", "width": "15%" },
    { "sTitle": "Email ID", "data": "EmailID", "width": "15%" },
    { "sTitle": "Action", "data": "Action", "width": "10%", "render": fnAction }

]

//Get All Client Data 
function GetClient() {
    
    var objClient = new Object();
    //objClient.UserID = null;
    createDataTable(false, TableName, "Api/V1/GetClient", fnDataTableCallBack, datatableColumn, objClient, [], []);
}

function fnDataTableCallBack() {
    $('.Edit_Mode').off('click').on('click', function () {
        alert('HI')
    });
}


$('#btnaddClient').off('click').on('click', function (e) {
    return window.location = '/Client/CreateClient';
});






