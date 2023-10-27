﻿var idLevel;
var activeValue = true;
var clickRemoveData = 0;
var clickActiveData = 0;

function OnToolbarItemClick(s, e) {
    var index = gvLevel.GetFocusedRowIndex();
    if (e.item.name == "RemoveData") {
        if (index > -1) {
            var result = confirm("Dữ liệu sẽ mất không thể khôi phục, bạn có chắc chắn muốn xóa?");
            if (result) {
                clickRemoveData = 1;
                OnGridFocusedRowChanged(s, e);
            }
        }
    }
    if (e.item.name == "ActiveData") {
        if (index > -1) {
            clickActiveData = 1;
            OnGridFocusedRowChanged(s, e);
        }
    }
    if (e.item.name == "AdminDataLevel") {
        PopupControlFilterLevel.Show();
    }
    
}
function OnGridFocusedRowChanged(s, e) {
    s.GetRowValues(s.GetFocusedRowIndex(), 'ID;Name', OnGetRowValues);
}
function OnGetRowValues(values) {
    idLevel = values[0];
    if (clickRemoveData == 1) {
        RemoveData();
    }
    if (clickActiveData == 1) {
        ActiveData();
    }
}
function CFOnBeginCallBack(s, e) {
    e.customArgs["active"] = activeValue;
}

function CFInitGridview(s, e) {
    gvLevel.PerformCallback({ active: activeValue });
}

function onSubmitClickFilterLevel(s, e) {
    PopupControlFilterLevel.Hide();
}

function TypeValueChanged(s, e) {
    if (s.lastSuccessValue != null) {
        if (s.lastSuccessValue == 0) {
            activeValue = true;
            gvLevel.PerformCallback({ active: activeValue });
        }
        else {
            activeValue = false;
            gvLevel.PerformCallback({ active: activeValue });
        }
        
    }
}

function RemoveData() {

    Loading.Show();
    $.ajax({
        url: "/Level/RemoveData",
        data: {
            id: idLevel,
            active: activeValue
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentLevel").html(data);

            }
            clickRemoveData = 0;
            Loading.Hide();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
            clickRemoveData = 0;
            Loading.Hide();

        }
    });
}

function ActiveData() {

    Loading.Show();
    $.ajax({
        url: "/Level/ActiveData",
        data: {
            id: idLevel,
            active: activeValue
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentLevel").html(data);

            }
            clickActiveData = 0;
            Loading.Hide();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
            clickActiveData = 0;
            Loading.Hide();

        }
    });
}