$(document).ready(function () {
    //AutoComplete Text Turn Off
    $('form').attr('autocomplete', 'off');
});



//function formValidation() {
//    $.validator.addMethod(
//        "regex",
//        function (value, element, regexp) {
//            var re = new RegExp(regexp);
//            return this.optional(element) || re.test(value);
//        }
//        //, "Please check your input."
//    );
//    $("#loginform").validate({
//        rules: {
//            EmailID: {
//                required: true,
//                noSpace: true,
//                email: true,
//                maxlength: 50,
//                regex: /^[+a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/i
//            }
//        },
//        messages: {
//            EmailID: {
//                required: "Enter Email ID ",
//                email: "Enter Correct Email ID",
//                maxlength:"Enter character beetween 1 to 50"
//            }
//        },
//        errorElement: 'div',
//        errorPlacement: function (error, element) {
//            var placement = $(element).data('error');
//            if (placement) {
//                $(placement).append(error)
//            } else {
//                error.insertAfter(element);
//            }
//        }
//    });
//}

