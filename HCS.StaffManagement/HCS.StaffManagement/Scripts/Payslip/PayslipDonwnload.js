$(document).ready(function () {
    PayslipDownloadSearch();
    //$('input[id$=payslipdate]').datepicker({
    //    onSet: function (dateText, inst) {
    //        alert('HI');
    //        var ele = $(this).parent().find('div');
    //        $(ele).removeClass('is-empty');
    //        //$("#tbToSetFocus").focus();
    //    }
    //});
});

var TableName = $('#tblPayslipDonwload');

//Create column to show in datatable
var datatableColumn = [
    { "sTitle": "EmployeeID", "data": "EmployeeID", "visible": false },
    { "sTitle": "Employee Code", "data": "EmployeeCode", "width": "20%" },
    { "sTitle": "Employee Name", "data": "EmployeeName", "width": "15%" },
    { "sTitle": "Net Amount", "data": "NetAmount", "width": "15%" },
    { "sTitle": "View", "data": "", "width": "10%", "render": fnAction }

]

function fnAction() {

}
//Get payslip download search filter
function PayslipDownloadSearch() {
    var objPay = new Object();
    //objClient.UserID = null;
    createDataTable(false, TableName, "Api/V1/PayslipDownloadSearchEmpty", fnDataTableCallBack, datatableColumn, objPay, [], []);
}

function fnDataTableCallBack() {

}
