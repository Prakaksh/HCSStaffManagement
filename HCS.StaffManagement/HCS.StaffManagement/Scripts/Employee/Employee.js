
//Globally Declare Table name
var TableName = $('#tblGetEmployee');

$(document).ready(function () {
    GetEmployee();
});

//Create column to show in datatable
var datatableColumn = [
    { "sTitle": "OrganizationID", "data": "OrganizationID", "visible": false },
    { "sTitle": "SL No.", "data": "SlNo", "width": "5%" },
    { "sTitle": "EMP No..", "data": "EmployeeNo", "width": "10%" },
    { "sTitle": "Employee Name", "data": "EmployeeName", "width": "20%" },
    { "sTitle": "Mobile No.", "data": "MobileNo", "width": "10%" },
    { "sTitle": "Client Location", "data": "ClientLocation", "width": "20%" },
    { "sTitle": "Joining Date", "data": "JoiningDate", "width": "15%" },
    { "sTitle": "Action", "data": "Action", "width": "5%" }

]

//Get All Employee Details
function GetEmployee() {
    debugger;
    var objEmp = new Object();
    //objClient.UserID = null;
    createDataTable(false, TableName, "Api/V1/GetEmployee", fnDataTableCallBack, datatableColumn, objEmp, [], []);
}
function fnDataTableCallBack() { }


$('#addEmployee').off('click').on('click', function (e) {
    return window.location = '/Employee/CreateEmployee';
})
