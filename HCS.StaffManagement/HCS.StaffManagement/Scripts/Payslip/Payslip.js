var grossAmount = 0.00, totalEarnings = 0.00, totalDeductions = 0.00;

$(document).ready(function () {
    $("#divPaysliContent").hide();
    $(".datepicker").focus();
    
    initMaterialWizard();

    $("#ddlEmployee").on("change", function () {
        $("#divPaysliContent").show();
        if ($(this).val() != "") {
            var objEmp = new Object();
            objEmp.EmployeeID = $(this).val();
            fnClearPayScale();
            fnAjax(BaseUrl + "Payslip/PayslipGet", "GET", objEmp, fnPayScaleGetSuccess, fnPayScaleGetFailure);

            //Sample Payslip
            var lst = [];
            var obj1 = new Object();
            obj1.EmployeeID = "CA3AEBEB-2A0A-40F9-A6F7-17EDC8B43F04";
            lst.push(obj1);
            var obj2 = new Object();
            obj2.EmployeeID = "CA3AEBEB-2A0A-40F9-A6F7-17EDC8B43F04";
            lst.push(obj2);
            var obj3 = new Object();
            obj3.EmployeeID = "CA3AEBEB-2A0A-40F9-A6F7-17EDC8B43F04";
            lst.push(obj3);
            var obj4 = new Object();
            obj4.EmployeeID = "CA3AEBEB-2A0A-40F9-A6F7-17EDC8B43F04";
            lst.push(obj4);
            var obj5 = new Object();
            obj5.EmployeeID = "CA3AEBEB-2A0A-40F9-A6F7-17EDC8B43F04";
            lst.push(obj5);

            //lst.push({ "EmployeeID": "CA3AEBEB-2A0A-40F9-A6F7-17EDC8B43F04", "EmployeeNo": "" });
            //lst.push({ "EmployeeID": "CA3AEBEB-2A0A-40F9-A6F7-17EDC8B43F04", "EmployeeNo": "" });
            var objPS = new Object();
            objPS.Year = 2018;
            objPS.Month = 7;
            objPS.EmployeeList = lst;// JSON.stringify(lst);
            objPS.OrganizationId = 'CDDBCAB3-DFB4-44A8-9F9C-871440862F8A';
            debugger;
            fnAjax(BaseUrl + "Payslip/PayslipGeneration", "GET", objPS, fnPayScaleGetSuccess, fnPayScaleGetFailure);
        }
        else {
            //Toastr -- select an employee
            $("#divPaysliContent").hide();
        }
    });

    //on Working Days selection to auto-populate salary details
    $("#txtWorkingDays").on("propertychange change keyup paste input", function () {
        var NoOfDays = $(this).val();
        if (NoOfDays && NoOfDays <= 31) {
            var basicVal = $("#txtBasicPerDay").val();
            var wagesVal = $("#txtWagesDAPerDay").val();
            if (basicVal) {
                basicVal = parseFloat(basicVal);
                $("#txtBasicPerMonth").val((basicVal * NoOfDays));
                fnLabelInOut("#txtBasicPerMonth", false);
            }
            if (wagesVal) {
                wagesVal = parseFloat(wagesVal);
                $("#txtWagesDAPerMonth").val((wagesVal * NoOfDays));
                fnLabelInOut("#txtWagesDAPerMonth", false);
            }
        } else {
            if(!NoOfDays)
                alert("Please enter Working days");
            else
                alert("Please enter correct Working days");
        }
    });

    //on BasicPerDay change to auto-populate Basic Per Month 
    $("#txtBasicPerDay").on("blur", function () {
        var Basic = $(this).val();
        var NoOfDays = $("#txtWorkingDays").val();
        if (Basic && NoOfDays) {
            $("#txtBasicPerMonth").val((Basic * NoOfDays));
            fnLabelInOut("#txtBasicPerMonth", false);
        } 
    });

    //on WagesDAPerDay change to auto-populate WagesDA Per Month 
    $("#txtWagesDAPerDay").on("blur", function () {
        var DA = $(this).val();
        var NoOfDays = $("#txtWorkingDays").val();
        if (DA && NoOfDays) {
            $("#txtWagesDAPerMonth").val((DA * NoOfDays));
            fnLabelInOut("#txtWagesDAPerMonth", false);
        }
    });

    $(".earnings").on("blur", function () {
        totalEarnings = 0.00, basic = 0, wages = 0, incentive = 0;
        $("#lblEarnings").html(totalEarnings);
        basic = (($("#txtBasicPerMonth").val() == undefined || $("#txtBasicPerMonth").val() == "") ? 0 : $("#txtBasicPerMonth").val());
        wages = (($("#txtWagesDAPerMonth").val() == undefined || $("#txtWagesDAPerMonth").val() == "") ? 0 : $("#txtWagesDAPerMonth").val());
        incentive = (($("#txtIncentivePerMonth").val() == undefined || $("#txtIncentivePerMonth").val() == "") ? 0 : $("#txtIncentivePerMonth").val());
        totalEarnings = (parseFloat(basic) + parseFloat(wages) + parseFloat(incentive));
        $("#lblEarnings").html(totalEarnings.toFixed(2));

        grossAmount = parseFloat(totalEarnings) - parseFloat(totalDeductions);
        $("#spnGross").html(grossAmount.toFixed(2));
    });

    $(".deductions").on("blur", function () {
        totalDeductions = 0.00, advance = 0, fAdvance = 0, pf = 0, esi = 0, lic = 0, pt = 0, wwf = 0;
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
        if (selectedDate != undefined && selectedDate != "") {
            month = (new Date(selectedDate).getMonth()) + 1;
            monthName = MonthName[new Date(selectedDate).getMonth()];
            year = new Date(selectedDate).getFullYear();
        }
        var objPaySlip = new Object();
        //objPaySlip.EmployeeNo = $("#ddlEmployee").val();
        objPaySlip.EmployeeID = $("#ddlEmployee").val();
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
        fnAjax(BaseUrl + "/Payslip/PayslipInsertUpdate", "POST", JSON.stringify(objPaySlip), fnPayslipInsertUpdateSuccess, fnPayslipInsertUpdateFailure)
    });
});

//PayslipInsertUpdate success callback
function fnPayslipInsertUpdateSuccess(result) {
    alert("Payslip Inserted " + result + "!")
}

//PayslipInsertUpdate failure callback
function fnPayslipInsertUpdateFailure(xhr, msg, err) {
    alert("Failed");
}

//PayScale Data Get Success
function fnPayScaleGetSuccess(result) {
    //$("#divPaysliContent").show();
    if (result) {
        $("#txtBasicPerDay").val((result.BasicPerDay? result.BasicPerDay : 0));
        //$("#txtBasicPerMonth").val((result.BasicPerMonth? result.BasicPerMonth : 0));
        $("#txtWagesDAPerDay").val((result.WagesDAPerDay? result.WagesDAPerDay : 0));
        //$("#txtWagesDAPerMonth").val((result.WagesDAPerMonth? result.WagesDAPerMonth : 0));
        $("#txtIncentivePerMonth").val((result.IncentivePerMonth? result.IncentivePerMonth : 0));
        fnLabelInOut("#txtBasicPerDay,#txtBasicPerMonth,#txtWagesDAPerDay,#txtWagesDAPerMonth,#txtIncentivePerMonth", false);
    } 
}

//PayScale Data Get Error
function fnPayScaleGetFailure(xhr, obj, err) {
    debugger;
}

function fnClearPayScale() {
    $("#txtWorkingDays,#txtBasicPerDay,#txtBasicPerMonth,#txtWagesDAPerDay,#txtWagesDAPerMonth,#txtIncentivePerMonth").val("");
    //ss$("#txtAdvance,#txtFutureAdvance,#txtPF,#txtESI,#txtLIC,#txtPT,#txtWWF").val();
    fnLabelInOut("#txtWorkingDays,#txtBasicPerDay,#txtBasicPerMonth,#txtWagesDAPerDay,#txtWagesDAPerMonth,#txtIncentivePerMonth", true);
}

function initMaterialWizard() {
    // Code for the Validator
    var $validator = $('#frmPayslip').validate({
        rules: {
            dtPayslipFor: {
                required: true,
            },
            ddlEmployee: {
                required: true,
            },
            txtWorkingDays: {
                required: true,
                min: 0,
                max:31
            },
            txtBasicPerDay: {
                required: true,
            },
            txtBasicPerMonth: {
                required: true,
            },
            txtWagesDAPerDay: {
                required: true,
            },
            txtWagesDAPerMonth: {
                required: true,
            },
            txtPF: {
                required: true,
            },
            txtESI: {
                required: true,
            }

        },

        errorPlacement: function (error, element) {
            $(element).parent('div').addClass('has-error');
        }
    });

    // Wizard Initialization
    $('#frmPayslip').bootstrapWizard({ //.wizard-card
        'tabClass': 'nav nav-tabs navbar navbar-ligh',
        'nextSelector': '.btn-next',
        'previousSelector': '.btn-previous',
        onNext: function (tab, navigation, index) {
            var $valid = $('#frmPayslip').valid();
            if (!$valid) {
                $validator.focusInvalid();
                return false;
            }
        },

        onInit: function (tab, navigation, index) {
            //check number of tabs and fill the entire row
            var $total = navigation.find('li').length;
            $width = 100 / $total;
            var $wizard = navigation.closest('.wizard-card');
            $display_width = $(document).width();

            if ($display_width < 600 && $total > 3) {
                $width = 50;
            }

            navigation.find('li').css('width', $width + '%');
            $first_li = navigation.find('li:first-child a').html();
            $moving_div = $('<div class="moving-tab">' + $first_li + '</div>');
            $('.wizard-card .wizard-navigation').append($moving_div);
            refreshAnimation($wizard, index);
            $('.moving-tab').css('transition', 'transform 0s');
        },

        onTabClick: function (tab, navigation, index) {
            var $valid = $('#frmPayslip').valid();

            if (!$valid) {
                return false;
            } else {
                return true;
            }
        },

        onTabShow: function (tab, navigation, index) {
            var $total = navigation.find('li').length;
            var $current = index + 1;

            var $wizard = navigation.closest('.wizard-card');

            // If it's the last tab then hide the last button and show the finish instead
            if ($current >= $total) {
                $($wizard).find('.btn-next').hide();
                $($wizard).find('.btn-finish').show();
            } else {
                $($wizard).find('.btn-next').show();
                $($wizard).find('.btn-finish').hide();
            }

            button_text = navigation.find('li:nth-child(' + $current + ') a').html();

            setTimeout(function () {
                $('.moving-tab').text(button_text);
            }, 150);

            var checkbox = $('.footer-checkbox');

            if (!index == 0) {
                $(checkbox).css({
                    'opacity': '0',
                    'visibility': 'hidden',
                    'position': 'absolute'
                });
            } else {
                $(checkbox).css({
                    'opacity': '1',
                    'visibility': 'visible'
                });
            }

            refreshAnimation($wizard, index);
        }
    });
}
$(window).resize(function () {
    $('.wizard-card').each(function () {
        $wizard = $(this);
        index = $wizard.bootstrapWizard('currentIndex');
        refreshAnimation($wizard, index);

        $('.moving-tab').css({
            'transition': 'transform 0s'
        });
    });
});

function refreshAnimation($wizard, index) {
    total_steps = $wizard.find('li').length;
    move_distance = $wizard.width() / total_steps;
    step_width = move_distance;
    move_distance *= index;

    $current = index + 1;

    if ($current == 1) {
        move_distance -= 8;
    } else if ($current == total_steps) {
        move_distance += 8;
    }

    $wizard.find('.moving-tab').css('width', step_width);
    $('.moving-tab').css({
        'transform': 'translate3d(' + move_distance + 'px, 0, 0)',
        'transition': 'all 0.5s cubic-bezier(0.29, 1.42, 0.79, 1)'

    });
}
