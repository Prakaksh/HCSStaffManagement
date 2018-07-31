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



//function for Data Table Destroy & Re-Create
function createDataTable(destroy, tableName, url, fnDataTableCallBack, columns, paramObj, colDefs, order) {
    if (destroy) {
        var table = tableName.DataTable();
        table.destroy();
    };
    debugger;
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
                fnAuthorizationFailure(xhr, obj, data, fnError);
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