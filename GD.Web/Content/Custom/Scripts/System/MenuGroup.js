var idMenuGroup;
var activeValue = true;
var clickRemoveData = 0;
var clickActiveData = 0;

function OnToolbarItemClick(s, e) {

    var index = gvMenuGroup.GetFocusedRowIndex();

    if (e.item.name == "RemoveData") {
        if (index > -1) {
            var result = confirm("Dữ liệu sẽ mất không thể khôi phục, bạn có chắc chắn muốn xóa?");
            if (result) {
                clickRemoveData = 1;
                OnGridFocusedRowChanged(s, e);
            }
        }
    }

    if (e.item.name == "AdminDataMenuGroup") {
        PopupControlFilterMenuGroup.Show();
    }

    if (e.item.name == "ActiveData") {
        if (index > -1) {
            clickActiveData = 1;
            OnGridFocusedRowChanged(s, e);
        }
    }

}
function OnGridFocusedRowChanged(s, e) {
    s.GetRowValues(s.GetFocusedRowIndex(), 'ID;Name', OnGetRowValues);
}
function OnGetRowValues(values) {

    idMenuGroup = values[0];

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
    gvMenuGroup.PerformCallback({ active: activeValue });
}

function onSubmitClickFilterMenuGroup(s, e) {
    PopupControlFilterMenuGroup.Hide();
}

function TypeValueChanged(s, e) {
    if (s.lastSuccessValue != null) {
        if (s.lastSuccessValue == 0) {
            activeValue = true;
            gvMenuGroup.PerformCallback({ active: activeValue });
        }
        else {
            activeValue = false;
            gvMenuGroup.PerformCallback({ active: activeValue });
        }

    }
}

function RemoveData() {

    Loading.Show();
    $.ajax({
        url: "/MenuGroup/RemoveData",
        data: {
            id: idMenuGroup,
            active: activeValue
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentMenuGroup").html(data);

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
        url: "/MenuGroup/ActiveData",
        data: {
            id: idMenuGroup,
            active: activeValue
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentMenuGroup").html(data);

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