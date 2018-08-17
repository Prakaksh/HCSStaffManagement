$(document).ready(function () {
    fnCountry();
    var objState = new Object();
    objState.CountryID = 1;
    fnDDLBind("#ddlState", "/Master/CountryStateGet", "CountryStateID", "StateName", "Select State", objState);
    //$("#ddlState").val("0").trigger('change');
    $("input:text,form").attr("autocomplete", "off");
});

//  Client Save Success Section 
var onAjaxRequestSuccess = function (result) {
    if (result == 'success') {
        HCSStaff.showAlert('success-message');
        $("#form0")[0].reset();
        //return window.location = "/Client/Client";
    }
   else if (result.result == 'exist') {
        HCSStaff.showAlert('exist-message');
    }
};


function fnCountry() {
    $.each(CountryList.Country, function (data, value) {
        $("#ddlCountry").append($("<option></option>").val(value.CountryCode).html(value.CountryName));
        $("#ddlCountry").val("1").trigger('change');
    });
}

//function SaveClient() {
//    debugger;
//    var objsave = new Object();
//    objsave.ClientName = $('#ClientName').val();
//    objsave.ClientGSTIN = $('#ClientGSTIN').val();
//    objsave.ClientAddress1 = $('#ClientAddress1').val();
//    objsave.ClientAddress2 = $('#ClientAddress').val();
//    objsave.CountryID = $('#CountryID').val();
//    objsave.CountryStateID = $('#CountryStateID').val();
//    objsave.City = $('#City').val();
//    objsave.PinCode = $('#PinCode').val();
//    objsave.MobileNo = $('#MobileNo').val();
//    objsave.ContactNo = $('#ContactNo').val();
//    objsave.EmailID = $('#EmailID').val();

//    fnAjax("/Client/ClientInsertUpdate", "POST", objsave, fnSuccess, fnError)
//    function fnSuccess() {

//        alert("Created Successfully")

//    }
//    function fnError() { }
//}

//$('#btnSaveClient').on('click', function () {
//   // SaveClient();
//});