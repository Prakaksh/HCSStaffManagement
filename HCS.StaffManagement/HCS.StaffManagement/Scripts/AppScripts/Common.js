
//Sweet Alert Functionality
//showAlter: function(type) {

//}
$(document).ready(function () {
    $("input:text,form").attr("autocomplete", "off");
  
});

var QualificationList = {
    "Qualification": [
        { "QualificationCode": 1, "QualificationName": "Select Qualification" },
        { "QualificationCode": "SSLC", "QualificationName": "SSLC" },
        { "QualificationCode": "PUC", "QualificationName": "PUC" },
        { "QualificationCode": "BTECH", "QualificationName": "Btech" },
        { "QualificationCode": "ME", "QualificationName": "M.E" },
        { "QualificationCode": "MTECH", "QualificationName": "Mtech" },
        { "QualificationCode": "BSC", "QualificationName": "B.Sc" },
        { "QualificationCode": "MSC", "QualificationName": "M.Sc" },
        { "QualificationCode": "BE", "QualificationName": "B.E" },
        { "QualificationCode": "MBA", "QualificationName": "MBA" },
        { "QualificationCode": "PGD", "QualificationName": "PGD" },
        { "QualificationCode": "BCOM", "QualificationName": "B.Com" },
        { "QualificationCode": "OTHER", "QualificationName": "Other Bachelors" }
        ]
}  



var MaritalStatusList = {
    "MaritalStatus": [
        { "MaritalStatusCode": "1", "MaritalStatusName": "Select MaritalStatus" },
        { "MaritalStatusCode": "MR", "MaritalStatusName": "Married" },
        { "MaritalStatusCode": "SP", "MaritalStatusName": "Separated" },
        { "MaritalStatusCode": "WD", "MaritalStatusName": "Widowed" },
        { "MaritalStatusCode": "DV", "MaritalStatusName": "Divorced" },
        { "MaritalStatusCode": "NM", "MaritalStatusName": "Never Married" }
    ]
}


var CountryList = {
    "Country": [
        { "CountryCode": "1", "CountryName": "Select Country" },
        { "CountryCode": "IND", "CountryName": "India" }
        ]
}

// This function To Check Image Extension Type .jpeg,jpg,png, ext-- 
function isImage(ImageID) {
    var extension = ImageID.val().split('.').pop().toLowerCase()
    if ($.inArray(extension, ['gif', 'png', 'jpg', 'jpeg']) === -1) {
        return false;
    }
    else { return true }
}


HCSStaff = {
    showAlert: function (type) {
        if (type == 'success-message') {
            swal({
                title: "Created Successfully! ",
                buttonsStyling: false,
                confirmButtonClass: "btn btn-success",
                type: "success"
            });
        } 
        if (type == 'invalid-message') {
            swal({
                //title: "Auto close alert!",
                text: "invalid format !",
                type: 'error',
                confirmButtonClass: "btn btn-info",
                buttonsStyling: false,

            });
        }
        if (type == 'image-size') {
            swal({
                //title: "Auto close alert!",
                text: "Please check image size !",
                type: 'error',
                confirmButtonClass: "btn btn-info",
                buttonsStyling: false,

            });
        }
    },
}

//$('.datepicker').off('change').on('change', function () {
//    debugger;
//    var ele = $(this).parent.find('div');
//    ele.removeClass('label-floating')
//})


$('.datepicker').datetimepicker({

    format: 'DD-MM-YYYY',
    useCurrent: false, 
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
}).on('dp.change', function (e) {
   // this next line fixed the floating label issue for me     
  $(this).parent('.label-floating').removeClass('is-empty');
    });


//$(".datepicker").off('click').on('click',function () {
//    var ele = $(this).parent().find('div');
//    $(ele).addClass('is-focused');
//});


//Function for Global ajax calls
function fnAjax(Url, Method, objdata,fnSuccess, fnError) {
    $.ajax({
        url: Url,
        method: Method,
        //dataType: (DataType != null ? DataType : "json"),
        'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8',
        data: objdata,
        success: function (result, status, XMLHttpRequest) {
            fnSuccess(result);
        },
        error: function (xhr, error, data) {
            function fnError() { };
        }
    });
}


//This Function Only for Image or File uploading
function fnFileUpload(URL, fileData, fnSuccess) {
    debugger;
    $.ajax({
        url: URL,
        type: "POST",
        contentType: false, // Not to set any content header  
        processData: false, // Not to process data  
        data: fileData,
        success: function (result) {
            fnSuccess(result);
        },
        error: function (err) {
            
            HCSStaff.showAlert('image-size');
        }
    });
}

//Function for Dropdown binding
function fnDDLBind(controlID, Url, propKey, propVal, selectText, objdata) {
    $.ajax({
        url: BaseUrl+Url,
        contentType:"application/x-www-form-urlencoded; charset=UTF-8",
        data: objdata,
        success: function (result) {
           $(controlID).empty();
          var html;
            if (result.length > 0) {
                html = "<option value='0'>" + selectText + "</option>";
                $.each(result, function (i, item) {
                    html += "<option value='" + item[propKey] + "'>" + item[propVal] + "</option>";
                }); 
            }
            $(controlID).append(html);
        },
        error: function (xhr, error, data) {
            function fnError() { };
        }
    });
}



//function for Data Table Destroy & Re-Create
function createDataTable(destroy, tableName, url, fnDataTableCallBack, columns, paramObj, colDefs, order) {
    if (destroy) {
        var table = tableName.DataTable();
        table.destroy();
    };
    tableName.DataTable({
        "columns": columns,
        "columnDefs": colDefs,
        "bDestroy": true,
        "ajax": {
         
            "url": BaseUrl + url,
            "type": "GET",
            "data": paramObj,
            "dataSrc": "",
            //"headers":
            //    {
            //        "Key": localStorage.getItem("access-token").split(',')[0],
            //        'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8',
            //    },
            "error": function (xhr, obj, data) {
               // fnAuthorizationFailure(xhr, obj, data, fnError);
            }
        },
        "order": order,
        "fnDrawCallback": function () { fnDataTableCallBack(); $('.tooltipped').tooltip(); },
        //"order": order
    });
}



//function to get Row data for particular Row under data table
function returnRowData(current, table) {
    var tblObj = table.dataTable();
    var row = $(current).closest("tr").get(0);
    var rowPos = tblObj.fnGetPosition(row);
    var rowData = tblObj.fnGetData(rowPos);
    return rowData;
}


////function to get Row data for particular Row under data table
//function RoleType(RoleName) {
//    switch (RoleName) {
//        case 'Admin':
//            return window.location = "/Home/AdminDashboard.cshtml";
//        case 'Manager':
//            return window.location = '/Home/AdminDashboard';          
//        case 'SuperAdmin':
//            return window.location = '/Home/SuperAdminDashboard';
//        default :
//            $("#divError").html("Please enter valid credentials");
       
//    }
//}


$(".DigitOnlyValidation").keypress(function (e) {
    //if the letter is not digit then display error and don't type anything
    if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
        //display error message
        //$("#errmsg").html("Digits Only").show().fadeOut("slow");
        return false;
    }
});


//var Country = '{ "employees" : [' +
//    '{ "CountryID":"1" , "CountryName":"India" } ]}';
//var objCountry = JSON.parse(Country);