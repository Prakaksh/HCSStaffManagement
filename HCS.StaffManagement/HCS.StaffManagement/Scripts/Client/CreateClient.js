$(document).ready(function()
{
        //AutoComplete Text Turn Off
        $('form').attr('autocomplete', 'off');
})

function SaveClient() {
    debugger;
    var objsave = new Object();
    objsave.ClientName = $('#ClientName').val();
    objsave.ClientGSTIN = $('#ClientGSTIN').val();
    objsave.ClientAddress1 = $('#ClientAddress1').val();
    objsave.ClientAddress2 = $('#ClientAddress').val();
    objsave.CountryID = $('#CountryID').val();
    objsave.CountryStateID = $('#CountryStateID').val();
    objsave.City = $('#City').val();
    objsave.PinCode = $('#PinCode').val();
    objsave.MobileNo = $('#MobileNo').val();
    objsave.ContactNo = $('#ContactNo').val();
    objsave.EmailID = $('#EmailID').val();

    fnAjax("/Client/ClientInsertUpdate", "POST", objsave, fnSuccess, fnError)
    function fnSuccess() {
        alert("Created Successfully")

    }
    function fnError() { }
}

$('#btnSaveEmployee').on('click', function () {
    SaveClient();
});