var TableName = $('#tblGetClient');

$(document).ready(function () {
    ClientGet();
    $('form').attr('autocomplete', 'off');
    $.material.options.autofill = true;
    $.material.init();

    var objCtry = new Object();
    objCtry.CountryID = 1; //'US';
    fnDDLBind("#ddlState", "/Master/CountryStateGet", "CountryStateID", "StateName", "Select State", objCtry, null, true);

});

//var btnNotePadActions = '<a href="#!" class="custom-div notepad" data-activates="slide-out"><i class="material-icons">assignment</i></a>'

function fnAction() {
    var btnNotePadActions = '<a href="#!" class="custom-div edit_Mode" data-toggle="modal" data-target="#ClientUpateModal"><i class="material-icons">edit</i></a>';
    btnNotePadActions = btnNotePadActions + '<a href="#!" class="custom-div delete_Mode" data-toggle="modal" data-target="#modalDelete"><i class="material-icons">delete</i></a>';
    return btnNotePadActions;
}

//Create column to show in datatable
var datatableColumn = [
    { "sTitle": "ClientID", "data": "OrganizationClientID", "visible": false },
    { "sTitle": "Client Name", "data": "ClientName", "width": "25%" },
    { "sTitle": "GSTIN No.", "data": "ClientGSTIN", "width": "15%" },
    { "sTitle": "Mobile No.", "data": "MobileNo", "width": "15%" },
    { "sTitle": "Email ID", "data": "EmailID", "width": "20%" },
    { "sTitle": "Action", "data": "Action", "width": "5%", "class": "right-align", "render": fnAction }
]

//Get All Client Data 
function ClientGet() {
    var objClient = new Object();
    createDataTable(false, TableName, "/Client/ClientGet", fnDataTableCallBack, datatableColumn, objClient, [], []);
}

var ClientModel = new Object();
var ClientDetails = new Object();
ClientDetails = { "objClient": ClientModel }

function fnDataTableCallBack() {
    $('.edit_Mode').off('click').on('click', function () {
        var objClient = new Object();
        var row = returnRowData($(this), TableName)
        //objClient.OrganizationID = 'CDDBCAB3-DFB4-44A8-9F9C-871440862F8A';
        objClient.OrganizationClientID = row.OrganizationClientID
        fnAjax(BaseUrl + "/Client/ClientGet", "GET", objClient, fnSuccess, fnError);
    });

    $('.delete_Mode').off('click').on('click', function () {        
        var objClient = new Object();
        var row = returnRowData($(this), TableName)
        $('#OrganizationClientID').val(row.OrganizationClientID);

        fnModalDelete("<b>Client</b>", "<div>Are you sure to delete <b>" + row.ClientName + "</b>?</div>", true, fnClientDelete);

    });

    function fnSuccess(res) {
        $.each(res, function (data, value) {
            if (data == 0) {
                $('#OrganizationClientID').val(value.OrganizationClientID);
                $('#ClientName').val(value.ClientName);
                $('#ClientGSTIN').val(value.ClientGSTIN);
                $('#ClientAddress1').val(value.ClientAddress1);
                $('#ClientAddress2').val(value.ClientAddress2);
                $('#ddlState').val((value.CountryStateID ? value.CountryStateID : "0")).trigger('change');
                $('#City').val(value.City);
                $('#PinCode').val(value.PinCode);
                $('#MobileNo').val(value.MobileNo);
                $('#ContactNo').val(value.ContactNo);
                $('#EmailID').val(value.EmailID);
                $.material.options.autofill = true;
                $.material.init();
            }
        });
    }
    function fnError() {
    }

    function fnClientDelete() {
        var objDel = new Object();
        objDel.OrganizationClientID = $("#OrganizationClientID").val();
        fnAjax(BaseUrl + "/Client/ClientDelete", "DELETE", objDel, fnDeleteSuccess, fnDeleteError, "JSON");
    }

    function fnDeleteSuccess(res) {
        if (res == "success") {
            createDataTable(true, TableName, "/Client/ClientGet", fnDataTableCallBack, datatableColumn, null, [], []);
            HCSStaff.showAlert('delete-message');
            $('.modalClose').trigger('click');
        }
        else {
            HCSStaff.showAlert('failed-message');
        }
    }
    function fnDeleteError() {
        HCSStaff.showAlert('error-message');
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
    objClient.CountryID = $('#ddlCountry').val();
    objClient.CountryStateID = $('#ddlState').val();
    objClient.City = $('#City').val();
    objClient.PinCode = $('#PinCode').val();
    objClient.MobileNo = $('#MobileNo').val();
    objClient.ContactNo = $('#ContactNo').val();
    objClient.EmailID = $('#EmailID').val();
    fnAjax(BaseUrl + "/Client/ClientInsertUpdate", "POST", objClient, fnUpdateSuccess, fnUpdateError, "JSON");

});

function fnUpdateSuccess(res) {
    if (res == "update") {
        createDataTable(true, TableName, "/Client/ClientGet", fnDataTableCallBack, datatableColumn, null, [], []);
        HCSStaff.showAlert('update-message');
        $('#ClientUpateModal').modal('toggle');
    }
    else {
        HCSStaff.showAlert('error-message');
    }      
}

function fnUpdateError(res) {
    HCSStaff.showAlert('error-message');
}

$('#btnAddClient').off('click').on('click', function (e) {
    return window.location = BaseUrl+ '/Client/ClientCreate';
});






