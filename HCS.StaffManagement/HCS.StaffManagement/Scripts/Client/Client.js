var TableName = $('#tblGetClient');

$(document).ready(function () {
    ClientGet();
    $('form').attr('autocomplete', 'off');
    $.material.options.autofill = true;
    $.material.init();
});



var btnNotePadActions = '<a href="#!" class="custom-div notepad" data-activates="slide-out"><i class="material-icons">assignment</i></a>'

function fnAction() {
    var btnNotePadActions = '<a href="#!" class="custom-div Edit_Mode" data-toggle="modal" data-target="#ClientUpateModal"><i class="material-icons">edit</i></a>'
    return btnNotePadActions;
}



//Create column to show in datatable
var datatableColumn = [
    { "sTitle": "ClientID", "data": "OrganizationClientID", "visible": false },
    { "sTitle": "Client Name", "data": "ClientName", "width": "20%" },
    { "sTitle": "GSTIN No.", "data": "ClientGSTIN", "width": "15%" },
    { "sTitle": "Mobile No.", "data": "MobileNo", "width": "15%" },
    { "sTitle": "Email ID", "data": "EmailID", "width": "15%" },
    { "sTitle": "Action", "data": "Action", "width": "10%", "render": fnAction }

]

//Get All Client Data 
function ClientGet() {
    debugger;
    var objClient = new Object();
    //objClient.OrganizationID = 'CDDBCAB3-DFB4-44A8-9F9C-871440862F8A';
    //objClient.UserID = null;
    //createDataTable(false, TableName, "Api/V1/ClientGet", fnDataTableCallBack, datatableColumn, objClient, [], []);
    createDataTable(false, TableName, "/Client/ClientGet", fnDataTableCallBack, datatableColumn, objClient, [], []);
}

var ClientModel = new Object();
var ClientDetails = new Object();
ClientDetails = { "objClient": ClientModel }

function fnDataTableCallBack() {
    $('.Edit_Mode').off('click').on('click', function () {
        var objClient = new Object();
        var row = returnRowData($(this), TableName)
        objClient.OrganizationID = 'CDDBCAB3-DFB4-44A8-9F9C-871440862F8A';
        objClient.OrganizationClientID = row.OrganizationClientID
        fnAjax(BaseUrl + "Api/V1/ClientGet", "GET", objClient, fnSuccess, fnError);
    });

    function fnSuccess(res) {
        $.each(res, function (data, value) {
            $('#OrganizationClientID').val(value.OrganizationClientID);
            $('#ClientName').val(value.ClientName);
            $('#ClientGSTIN').val(value.ClientGSTIN);
            $('#ClientAddress1').val(value.ClientAddress1);
            $('#ClientAddress2').val(value.ClientAddress2);
            $('#CountryStateID').val(value.CountryStateID);
            $('#City').val(value.City);
            $('#PinCode').val(value.PinCode);
            $('#MobileNo').val(value.MobileNo);
            $('#ContactNo').val(value.ContactNo);
            $('#EmailID').val(value.EmailID);
            $.material.options.autofill = true;
            $.material.init();
        });


    }
    function fnError() {

    }
}




$('#btnClientUpdate').off('click').on('click', function (e) {
    
    e.preventDefault();
    var $form = $('#formClientUpdate');

    // check if the input is valid
    if (!$form.valid())
        return false;

    var objClient = new Object();
    objClient.OrganizationClientID = $('#OrganizationClientID').val();
    objClient.ClientName = $('#ClientName').val();
    objClient.ClientGSTIN = $('#ClientGSTIN').val();
    objClient.ClientAddress1 = $('#ClientAddress1').val();
    objClient.ClientAddress2 = $('#ClientAddress2').val();
    objClient.CountryStateID = $('#CountryStateID').val();
    objClient.City = $('#City').val();
    objClient.PinCode = $('#PinCode').val();
    objClient.MobileNo = $('#MobileNo').val();
    objClient.ContactNo = $('#ContactNo').val();
    objClient.EmailID = $('#EmailID').val();
    fnAjax(BaseUrl + "Api/V1/ClientUpdate", "POST", objClient, fnSuccess, fnError);

});

function fnSuccess(res) {
    debugger;
    if (res == "update")
        createDataTable(true, TableName, "Api/V1/ClientGet", fnDataTableCallBack, datatableColumn, null, [], []);
        HCSStaff.showAlert('update-message');
        $('#ClientUpateModal').modal('toggle');
}

function fnError(res) {
}

    $('#btnaddClient').off('click').on('click', function (e) {
        return window.location = '/Client/CreateClient';
    });






