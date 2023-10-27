﻿var idWard;
var activeValue = true;
var clickRemoveData = 0;
var clickActiveData = 0;

function OnToolbarItemClick(s, e) {
    var index = gvWard.GetFocusedRowIndex();
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
    if (e.item.name == "AdminDataWard") {
        PopupControlFilterWard.Show();
    }
    
}
function OnGridFocusedRowChanged(s, e) {
    s.GetRowValues(s.GetFocusedRowIndex(), 'ID;Name', OnGetRowValues);
}
function OnGetRowValues(values) {
    idWard = values[0];
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
    gvWard.PerformCallback({ active: activeValue });
}

function onSubmitClickFilterWard(s, e) {
    PopupControlFilterWard.Hide();
}

function TypeValueChanged(s, e) {
    if (s.lastSuccessValue != null) {
        if (s.lastSuccessValue == 0) {
            activeValue = true;
            gvWard.PerformCallback({ active: activeValue });
        }
        else {
            activeValue = false;
            gvWard.PerformCallback({ active: activeValue });
        }
        
    }
}

function RemoveData() {

    Loading.Show();
    $.ajax({
        url: "/Ward/RemoveData",
        data: {
            id: idWard,
            active: activeValue
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentWard").html(data);

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
        url: "/Ward/ActiveData",
        data: {
            id: idWard,
            active: activeValue
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentWard").html(data);

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