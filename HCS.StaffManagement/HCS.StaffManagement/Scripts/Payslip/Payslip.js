var grossAmount = 0.00, totalEarnings = 0.00, totalDeductions = 0.00;

$(document).ready(function () {
    $(".datepicker").focus();

    //on BasicPerDay change to auto-populate Basic Per Month 
    $("#txtBasicPerDay").on("blur", function () {
        var Basic = $(this).val();
        var NoOfDays = $("#txtWorkingDays").val();
        $("#txtBasicPerMonth").val((Basic * NoOfDays));
    });

    //on WagesDAPerDay change to auto-populate WagesDA Per Month 
    $("#txtWagesDAPerDay").on("blur", function () {
        var DA = $(this).val();
        var NoOfDays = $("#txtWorkingDays").val();
        $("#txtWagesDAPerMonth").val((DA * NoOfDays));
    });

    $(".earnings").on("blur", function () {
        totalEarnings = 0.00, basic = 0, wages = 0, incentive=0;
        $("#lblEarnings").html(totalEarnings);
        basic = (($("#txtBasicPerMonth").val() == undefined || $("#txtBasicPerMonth").val() == "") ? 0 : $("#txtBasicPerMonth").val());
        wages = (($("#txtWagesDAPerMonth").val() == undefined || $("#txtWagesDAPerMonth").val() == "")? 0 : $("#txtWagesDAPerMonth").val());
        incentive = (($("#txtIncentivePerMonth").val() == undefined || $("#txtIncentivePerMonth").val() == "")? 0 : $("#txtIncentivePerMonth").val());
        totalEarnings = (parseFloat(basic) + parseFloat(wages) + parseFloat(incentive));
        $("#lblEarnings").html(totalEarnings.toFixed(2));

        grossAmount = parseFloat(totalEarnings) - parseFloat(totalDeductions);
        $("#spnGross").html(grossAmount.toFixed(2));
    });

    $(".deductions").on("blur", function () {
        totalDeductions = 0.00,advance=0,fAdvance=0, pf=0, esi=0, lic=0, pt=0, wwf=0;
        $("#lblDeductions").html(totalDeductions);
        advance = (($("#txtAdvance").val() == undefined || $("#txtAdvance").val() == "") ? 0 : $("#txtAdvance").val());
        fAdvance = (($("#txtFutureAdvance").val() == undefined || $("#txtFutureAdvance").val() == "") ? 0 : $("#txtFutureAdvance").val());
        pf = (($("#txtPF").val() == undefined || $("#txtPF").val() == "") ? 0 : $("#txtPF").val());
        esi = (($("#txtESI").val() == undefined || $("#txtESI").val() == "") ? 0 : $("#txtESI").val());
        lic = (($("#txtLIC").val() == undefined || $("#txtLIC").val() == "") ? 0 : $("#txtLIC").val());
        pt = (($("#txtPT").val() == undefined || $("#txtPT").val() == "") ? 0 : $("#txtPT").val());
        wwf = (($("#txtWWF").val() == undefined || $("#txtWWF").val() == "") ? 0 : $("#txtWWF").val());
        
        totalDeductions = (parseFloat(advance) + parseFloat(fAdvance) + parseFloat(pf) + parseFloat(esi) + parseFloat(lic) + parseFloat(pt) + parseFloat(wwf));
        $("#lblDeductions").html(totalDeductions.toFixed(2));

        grossAmount = parseFloat(totalEarnings) - parseFloat(totalDeductions);
        $("#spnGross").html(grossAmount.toFixed(2));
    });

    $('.datepicker').datetimepicker({
        format: 'DD/MM/YYYY',
        icons: {
            time: "fa fa-clock-o",
            date: "fa fa-calendar",
            up: "fa fa-chevron-up",
            down: "fa fa-chevron-down",
            previous: 'fa fa-chevron-left',
            next: 'fa fa-chevron-right',
            today: 'fa fa-screenshot',
            clear: 'fa fa-trash',
            close: 'fa fa-remove',
            inline: true
        }
    })
    //    .on("changeDate", function (e) {
    //    debugger;
    //}).on('changeMonth', function (e) {
    //    var currMonth = new Date(e.date).getMonth() + 1;
    //    debugger;
    //}).on('changeYear', function (e) {
    //    var currYear = String(e.date).split(" ")[3];
    //    debugger;
    //});
    ////Get Month
    //$("#dtPayslipFor").datetimepicker().on('changeMonth', function (e) {
    //    var currMonth = new Date(e.date).getMonth() + 1;
    //    debugger;
    //});
    
    ////Get year
    //$("#dtPayslipFor").datetimepicker().on('changeYear', function (e) {
    //    var currYear = String(e.date).split(" ")[3];
    //    debugger;
    //});

    //Submit button to save Payslip
    $("#btnGenerate").off('click').on('click', function () {
        var month, monthName, year;
        var selectedDate = $("#dtPayslipFor").val();
        if (selectedDate != undefined && selectedDate != "")
        {
            month = (new Date(selectedDate).getMonth()) + 1;
            monthName = monthNames[new Date(selectedDate).getMonth()];
            year = new Date(selectedDate).getFullYear();
        }
        var objPaySlip = new Object();
        objPaySlip.EmployeeNo = $("#ddlEmployee").val();
        //objPaySlip.EmployeeID = null;//$("#ddlEmployee").val();
        objPaySlip.EmployeePaymentID = $("#hEmployeePaymentID").val();
        objPaySlip.Year = year; // $("#dtPayslipFor").val();
        objPaySlip.Month = month; // $("#dtPayslipFor").val();
        objPaySlip.MonthName = monthName; // $("#dtPayslipFor").val();
        //objPaySlip.DaysInMonth = $("#txtDaysInMonth").val();
        objPaySlip.WorkingDays = $("#txtWorkingDays").val();
        objPaySlip.BasicPerDay = $("#txtBasicPerDay").val();
        objPaySlip.BasicPerMonth = $("#txtBasicPerMonth").val();
        objPaySlip.WagesDAPerDay = $("#txtWagesDAPerDay").val();
        objPaySlip.WagesDAPerMonth = $("#txtWagesDAPerMonth").val();
        //objPaySlip.IncentivePerDay = $("#txtIncentivePerDay").val();
        objPaySlip.IncentivePerMonth = $("#txtIncentivePerMonth").val();
        //objPaySlip.Bonus = $("#txtBonus").val();
        objPaySlip.Advance = $("#txtAdvance").val();
        objPaySlip.FutureAdvance = $("#txtFutureAdvance").val();
        objPaySlip.PF = $("#txtPF").val();
        objPaySlip.ESI = $("#txtESI").val();
        objPaySlip.LIC = $("#txtLIC").val();
        objPaySlip.PT = $("#txtPT").val();
        objPaySlip.WWF = $("#txtWWF").val();
        objPaySlip.Remarks = $("#txtRemarks").val();
        debugger;
        fnAjax(Url + "/Payslip/PayslipInsertUpdate", "POST", objPaySlip, "JSON", "application/json", fnPayslipInsertUpdateSuccess, fnPayslipInsertUpdateFailure)
    });
});

//PayslipInsertUpdate success callback
function fnPayslipInsertUpdateSuccess(result) {
    debugger;
}

//PayslipInsertUpdate failure callback
function fnPayslipInsertUpdateFailure(xhr, msg, err) {
    alert("0");
    debugger;
}