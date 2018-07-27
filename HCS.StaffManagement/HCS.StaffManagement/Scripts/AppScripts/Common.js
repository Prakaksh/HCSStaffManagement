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
            "url": ServiceURL + url,
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