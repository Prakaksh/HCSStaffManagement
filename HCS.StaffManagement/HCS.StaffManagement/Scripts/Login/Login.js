

$('#btnLogin').click(function () {
    alert("HI");
    var objlogin = new Object();
    objlogin.EmailID = $('#EmailID').val();
    objlogin.Password = $('#Password').val();
    fnAjax("/Login/Login", "POST", objEmp, fnSuccess, fnError)
    function fnSuccess() {
        alert("Created Successfully")

    }
    function fnError() { }
});