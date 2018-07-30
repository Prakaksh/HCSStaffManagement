//Constant Month Names
const monthNames = ["January", "February", "March", "April", "May", "June",
  "July", "August", "September", "October", "November", "December"
];

//Function for Global ajax calls
function fnAjax(Url, Method, objdata, DataType, ContentType, fnSuccess, fnError) {
    $.ajax({
        url: Url,
        method: Method,
        //dataType: (DataType != null ? DataType : "json"),
        //contentType: (ContentType != null ? ContentType : "application/x-www-form-urlencoded; charset=UTF-8"),
        data: objdata,
        success: fnSuccess,
        error: fnError
    });
}

//Function for Dropdown binding
function fnDdlBind(Url, Method, objdata, DataType, ContentType, controlID, propKey, propVal, selectText) {
    $(controlID).empty();
    $.ajax({
        url: Url,
        method: Method,
        dataType: (DataType != null ? DataType : "json"),
        contentType: (ContentType != null ? ContentType : "application/x-www-form-urlencoded; charset=UTF-8"),
        data: objdata,
        success: function (result) {
            if (result.length > 0) {
                var html = "<option value=''>" + selectText + "</option>";
                $.each(result, function (i, item) {
                    html += "<option value='" + item[propKey] + "'>" + item[propVal] + "</option>";
                }); //Prakash there? I'm having lunch now.. okay
                //banni uta madana...
                //ok...preparing chicken..here...you carry on
            }
        },
        error: fnError
    });
}


//$('.datepicker').datetimepicker({
//    format: 'MM/DD/YYYY',
//    icons: {
//        time: "fa fa-clock-o",
//        date: "fa fa-calendar",
//        up: "fa fa-chevron-up",
//        down: "fa fa-chevron-down",
//        previous: 'fa fa-chevron-left',
//        next: 'fa fa-chevron-right',
//        today: 'fa fa-screenshot',
//        clear: 'fa fa-trash',
//        close: 'fa fa-remove',
//        inline: true
//    }
//});