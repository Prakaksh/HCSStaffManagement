//Globally Declare Table name
var TableName = $('#tblGetEmployee');

$(document).ready(function () {
    EmployeeGet();
});


function fnActionLink() {
    var btnNotePadActions = '<a href="#" class="custom-div edit_Mode" data-toggle="modal"><i class="material-icons">edit</i></a>';
    //btnNotePadActions = btnNotePadActions + '<a href="#" class="custom-div delete_Mode" data-toggle="modal" data-target="#modalDelete"><i class="material-icons">delete</i></a>';
    btnNotePadActions = btnNotePadActions + '<a href="#" class="custom-div wage_Click"><i class="material-icons">account_balance_wallet</i></a>';
    return btnNotePadActions;
}

//Create column to show in datatable
var datatableColumn = [
    { "sTitle": "OrganizationID", "data": "OrganizationID", "visible": false },
    //{
    //    "sTitle": "SL No.", "data": "", "width": "5%", "class": "left-align"
    //    //, "fnRowCallback": function (nRow, aData, iDisplayIndex) { $("td:eq(0)", nRow).html(iDisplayIndex + 1); return nRow; }
    //},
    { "sTitle": "EMP No.", "data": "EmployeeNo", "width": "10%" },
    { "sTitle": "Employee Name", "data": "EmployeeName", "width": "20%" },
    { "sTitle": "Mobile No.", "data": "MobileNo", "width": "10%" },
    { "sTitle": "Client Location", "data": "ClientLocation", "width": "20%" },
    { "sTitle": "Joining Date", "data": "DateofJoin", "width": "15%" },
    { "sTitle": "Action", "width": "5%", "defaultContent": "<a href='#' />", "class": "right-align", "render": fnActionLink }
]

//Get All Employee Details
function EmployeeGet() {
    createDataTable(false, TableName, "/Employee/EmployeeGet", fnDataTableCallBack, datatableColumn, null, [], []);
}
function fnDataTableCallBack() {
    $('.edit_Mode').off("click").on("click", function (e) {
        e.preventDefault();
        var row = returnRowData($(this), TableName);
        return window.location = '/Employee/EmployeeCreate?employeeID='+row.EmployeeID;
    });
    
    $('.wage_Click').off("click").on("click", function (e) {
        e.preventDefault();
        $("#btnModalWageTrigger").trigger("click");
        var row = returnRowData($(this), TableName)
        $("#hEmployeeID").val(row.EmployeeID);
        fnAjax("/Employee/EmployeePayScaleGet?employeeID=" + row.EmployeeID, "GET", null, fnPayScaleGetSuccess, fnPayScaleGetError, "JSON");

        //fnModalDelete("<b>Employee</b>", "<div>Are you sure to delete <b>" + row.EmployeeName + "</b>?</div>", true, fnEmployeeDelete);        
    });
    //$('.delete_Mode').off("click").on("click", function (e) {
    //    e.preventDefault();
    //    var objClient = new Object();
    //    var row = returnRowData($(this), TableName)
    //    $('#hEmployeeID').val(row.EmployeeID);
    //    fnModalDelete("<b>Employee</b>", "<div>Are you sure to delete <b>" + row.EmployeeName + "</b>?</div>", true, fnEmployeeDelete);        
    //});
}

$('#btnWage').off("click").on("click", function (e) {
    e.preventDefault();
    var $valid = $('#formWages').valid();
    if (!$valid) {
        return false;
    } else {
        var objPayScale = new Object();
        objPayScale.EmployeeID = $("#hEmployeeID").val();
        objPayScale.EmployeePayScaleID = $("#hEmployeePayScaleID").val();
        objPayScale.BasicPerMonth = $("#txtBasicSalary").val();
        objPayScale.WagesDAPerMonth = $("#txtWages").val();
        objPayScale.BonusPercentage = $("#txtBonusPercentage").val();
        objPayScale.IncentivePerMonth = $("#txtIncentivePercentage").val();
        fnAjax("/Employee/EmployeePayScaleInsertUpdate", "POST", objPayScale, fnPayScaleInsertUpdateSuccess, fnPayScaleInsertUpdateError, "JSON");
    }
});

function fnPayScaleGetSuccess(res) {
    if (res) {
        $("#hEmployeePayScaleID").val(res.EmployeePayScaleID);
        $("#txtBasicSalary").val(res.BasicPerMonth);
        $("#txtWages").val(res.WagesDAPerMonth);
        $("#txtBonusPercentage").val(res.BonusPercentage);
        $("#txtIncentivePercentage").val(res.IncentivePerMonth);
        $.material.options.autofill = true;
        $.material.init();
    }
}

function fnPayScaleGetError(res) {
}

function fnPayScaleInsertUpdateSuccess(result) {
    if (result == "success") {       
        if ($("#hEmployeePayScaleID").val()) {
            HCSStaff.showAlert('update-message');
        } else {
            HCSStaff.showAlert('success-message');
        }
        $('.modalClose').trigger('click');
    }
}
function fnPayScaleInsertUpdateError(err) {

}


function fnEmployeeDelete() {
    var objDel = new Object();
    objDel.EmployeeID = $("#hEmployeeID").val();
    fnAjax(BaseUrl + "/Employee/EmployeeDelete", "DELETE", objDel, fnDeleteSuccess, fnDeleteError, "JSON");
}

function fnDeleteSuccess(res) {
    if (res == "success") {
        createDataTable(true, TableName, "/Employee/EmployeeGet", fnDataTableCallBack, datatableColumn, null, [], []);
        HCSStaff.showAlert('update-message');
        $('.modalClose').trigger('click');
    }
    else {
        HCSStaff.showAlert('failed-message');
    }
}
function fnDeleteError() {
    HCSStaff.showAlert('error-message');
}


$('#addEmployee').off('click').on('click', function (e) {
    return window.location = '/Employee/EmployeeCreate';
})


$('#EmployeeBank').off('click').on('click', function (e) {
  
})
