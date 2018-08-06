$(document).ready(function () {
    initMaterialWizard();
    fnQualification();
    fnMaritalStatus();
    fnCountry();
    fnDDLBind("#CountryStateID,#CountryStateID1", "api/V1/CountryStateGet", "CountryStateID", "StateName", "Select State");
    //fnAjax("API URL", "GET", null, "json", null, fnSuccessMaritalStatusGet, fnErrorMaritalStatusGet);


});


    function initMaterialWizard() {
    // Code for the Validator
    var $validator = $('.wizard-card form').validate({
        rules: {
            firstname: {
                required: true,
                minlength: 3
            },
            //AadharNo: {
            //    required: true,
            //},
            lastname: {
                required: true,
                minlength: 3
            },
            email: {
                required: true,
                minlength: 3,
            }
        },

        errorPlacement: function (error, element) {
            $(element).parent('div').addClass('has-error');
        }
    });

    // Wizard Initialization
    $('.wizard-card').bootstrapWizard({
        'tabClass': 'nav nav-tabs navbar navbar-ligh',
        'nextSelector': '.btn-next',
        'previousSelector': '.btn-previous',

        onNext: function (tab, navigation, index) {
           
            var $valid = $('.wizard-card form').valid();
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
            //return true;
            var $valid = $('.wizard-card form').valid();

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


    // Prepare the preview for profile picture
        $("#profile-picture").change(function () {
            var imgID = $(this);
            var $IsImageValid = isImage(imgID);
            if ($IsImageValid) {
                readURL(this);
            }
            else {
                HCSStaff.showAlert('invalid-message');
            }
      
    });

    $('[data-toggle="wizard-radio"]').click(function () {
        wizard = $(this).closest('.wizard-card');
        wizard.find('[data-toggle="wizard-radio"]').removeClass('active');
        $(this).addClass('active');
        $(wizard).find('[type="radio"]').removeAttr('checked');
        $(this).find('[type="radio"]').attr('checked', 'true');
    });

    $('[data-toggle="wizard-checkbox"]').click(function () {
        if ($(this).hasClass('active')) {
            $(this).removeClass('active');
            $(this).find('[type="checkbox"]').removeAttr('checked');
        } else {
            $(this).addClass('active');
            $(this).find('[type="checkbox"]').attr('checked', 'true');
        }
    });

    $('.set-full-height').css('height', 'auto');

    //Function to show image before upload

        function readURL(input) {
            if (input.files[0].size <= 2097152) {

                if (input.files && input.files[0]) {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $('#wizardPicturePreview').attr('src', e.target.result).fadeIn('slow');
                    }
                    reader.readAsDataURL(input.files[0]);
                }
                // Create FormData object  
                var fileData = new FormData();
                // Looping over all files and add it to FormData object  
                for (var i = 0; i < input.files.length; i++) {
                    fileData.append(input.files[i].name, input.files[i]);
                }
                fnFileUpload("/Employee/ProfileImageUpload", fileData, fnSuccess)
                function fnSuccess(res) {
                    $('#EmployeeProfilePictureID').val(res.ID)
                }
            }
            else {
                return HCSStaff.showAlert('image-size');
            }
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
    }




//Success CallBack
function fnSuccessMaritalStatusGet() { }
function fnErrorMaritalStatusGet() { }

$('#btnSaveEmployee').on('click', function () {

    HCSStaff.showSwal('success-message')
   
    var objEmp = new Object();
    var AccountInfo = new Object();
    var objBankAccount = [];
    //var objBankAccount = new Object();
    objEmp.AadharNo = $('#AadharNo').val();
    objEmp.EmployeeFirstName = $('#EmployeeFirstName').val();
    objEmp.EmployeeLastName = $('#EmployeeLastName').val();
    objEmp.DOB = $('#DOB').val();
    objEmp.DateofJoin = $('#DateofJoin').val();
    objEmp.Gender = $('#Gender').val();
    objEmp.MobileNo = $('#MobileNo').val();
    objEmp.EmailID = $('#EmailID').val();
    objEmp.Natioality = $('#Natioality').val();
    objEmp.PanNo = $('#PanNo').val();
    objEmp.VoterCardNo = $('#VoterCardNo').val();
    objEmp.RationCardNo = $('#RationCardNo').val();
    objEmp.DrivingLicenseNo = $('#DrivingLicenseNo').val();

    objEmp.PanNo = $('#PanNo').val();
    objEmp.PanNo = $('#PanNo').val();
    objEmp.PanNo = $('#PanNo').val();
    objEmp.PanNo = $('#PanNo').val();
    objEmp.PanNo = $('#PanNo').val();
    objEmp.PanNo = $('#PanNo').val();

    //
    AccountInfo.AccountNo = 123456789;
    AccountInfo.BankName = "HDFC"
    //objEmp.AccountNo = AccountInfo
    debugger;/// TRY Now  objEmp for Employee class object..  EmployeeBankAccount
    //objBankAccount.push(objBankAccount.AccountNo);
    objEmp.objBankAccount = AccountInfo;   //now fine..s
    //objEmp.objBankAccount
    fnAjax("/Employee/EmployeeInsertUpdate", "POST", objEmp, fnSuccess, fnError)
    function fnSuccess() {
        alert("Created Successfully")

    }
    function fnError() {
        alert('HI');
    }
    //$.ajax({
    //    type: "POST",
    //    url: "/Employee/EmployeeInsertUpdate",
    //    contentType: "application/x-www-form-urlencoded; charset=UTF-8",
    //    data: objEmp,
    //    dataType: "json",
    //    success: function (result, status, xhr) {
    //        debugger;
    //        $("#dataDiv").html(result);
    //    },
    //    error: function (xhr, status, error) {
    //        $("#dataDiv").html("Result: " + status + " " + error + " " + xhr.status + " " + xhr.statusText)
    //    }
    //});  

    //object objEmp = new object();
    //objEmp.firstname = "fljksdlfjsldf";
});

function fnQualification() {
    $.each(QualificationList.Qualification, function (data, value) {
        $("#Qualification").append($("<option></option>").val(value.QualificationCode).html(value.QualificationName)).sort();
    })
 }

function fnMaritalStatus() {
    $.each(MaritalStatusList.MaritalStatus, function (data, value) {
        $("#MaritalStatusCode").append($("<option></option>").val(value.MaritalStatusCode).html(value.MaritalStatusName));
    })
}


function fnCountry() {
    $.each(CountryList.Country, function (data, value) {

        $("#CountryID,#CountryID1").append($("<option></option>").val(value.CountryCode).html(value.CountryName));
        $("#CountryID,#CountryID1").val("IND").trigger('change');
    })
}