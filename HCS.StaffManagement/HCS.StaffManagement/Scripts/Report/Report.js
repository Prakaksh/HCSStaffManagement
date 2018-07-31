$(document).ready(function () {

});


GetReport();


//Create column to show in datatable
var datatableColumn = [
    { "sTitle": "OrganizationID", "data": "OrganizationID", "visible": false },
    { "sTitle": "Sl.No.", "data": "SlNo", "width": "15%" },
    { "sTitle": "Emp No.", "data": "EmpNo", "width": "15%" },
    { "sTitle": "Name of Employee", "data": "EmployeeName", "width": "15%" },
    { "sTitle": "Days Paid", "data": "DaysPaid", "width": "15%" },
    { "sTitle": "Rate of Basic", "data": "RateOfBasic", "width": "15%" },
    { "sTitle": "Wages D.A", "data": "WagesDA", "width": "15%" },
    { "sTitle": "Earned Basic", "data": "EarnedBasic", "width": "15%" },
    { "sTitle": "Total Wages D.A ", "data": "TotalWagesDA ", "width": "15%" },
    { "sTitle": "Total Wages", "data": "TotalWages", "width": "15%" },
    { "sTitle": "Incentive", "data": "Incentive", "width": "15%" },
    { "sTitle": "Gross Payable", "data": "GrossPayable", "width": "15%" },
    { "sTitle": "Adv", "data": "Adv", "width": "15%" },
    { "sTitle": "F.Adv", "data": "FAdv", "width": "15%" },
    { "sTitle": "P.F", "data": "PF", "width": "15%" },
    { "sTitle": "E.S.I", "data": "ESI", "width": "15%" },
    { "sTitle": "L.I.C", "data": "LIC", "width": "15%" },
    { "sTitle": "P.T", "data": "PT", "width": "15%" },
    { "sTitle": "W.W.F", "data": "WWF", "width": "15%" },
    { "sTitle": "TotalDeduction", "data": "TotalDeduction", "width": "15%" },
    { "sTitle": " Net Paid", "data": " NetPaid", "width": "15%" },
    { "sTitle": "Sig or Thumb Impression of Employee", "data": " Sign", "width": "15%" }
    ]
