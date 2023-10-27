var idTypeScore;
var activeValue = true;
var clickRemoveData = 0;
var clickActiveData = 0;

function OnToolbarItemClick(s, e) {
    var index = gvTypeScore.GetFocusedRowIndex();
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
    if (e.item.name == "AdminDataTypeScore") {
        PopupControlFilterTypeScore.Show();
    }
    
}
function OnGridFocusedRowChanged(s, e) {
    s.GetRowValues(s.GetFocusedRowIndex(), 'ID;Name', OnGetRowValues);
}
function OnGetRowValues(values) {
    idTypeScore = values[0];
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
    gvTypeScore.PerformCallback({ active: activeValue });
}

function onSubmitClickFilterTypeScore(s, e) {
    PopupControlFilterTypeScore.Hide();
}

function TypeValueChanged(s, e) {
    if (s.lastSuccessValue != null) {
        if (s.lastSuccessValue == 0) {
            activeValue = true;
            gvTypeScore.PerformCallback({ active: activeValue });
        }
        else {
            activeValue = false;
            gvTypeScore.PerformCallback({ active: activeValue });
        }
        
    }
}

function RemoveData() {

    Loading.Show();
    $.ajax({
        url: "/TypeScore/RemoveData",
        data: {
            id: idTypeScore,
            active: activeValue
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentTypeScore").html(data);

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
        url: "/TypeScore/ActiveData",
        data: {
            id: idTypeScore,
            active: activeValue
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentTypeScore").html(data);

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