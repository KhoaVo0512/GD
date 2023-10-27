var idApplicationRole;
var idApplicationGroup;
var idApplicationUser;
var idEmployee;
var idLevel;

var clickRemoveDataApplicationGroup = 0;
var clickActionApplicationGroup = 0;

var clickRemoveDataApplicationUser = 0;
var clickActionApplicationUser = 0;
var clickBlockApplicationUser = 0;
var clickActionResetPassword = 0;

//Application Role
var arrayApplicationRoleText = [];
var arrayApplicationRoleValue = [];

//Application Group
var arrayApplicationGroupText = [];
var arrayApplicationGroupValue = [];

//Menu
var arrayMenuText = [];
var arrayMenuValue = [];

//Course
var arrayCourseText = [];
var arrayCourseValue = [];

//Grade
var arrayGradeText = [];
var arrayGradeValue = [];

//GradeGroup
var arrayGradeGroupText = [];
var arrayGradeGroupValue = [];

//Employee

var idEmployee;
var activeValue = true;
var clickRemoveData = 0;
var clickActiveData = 0;

function OnToolbarItemClick(s, e) {
    var index = gvEmployee.GetFocusedRowIndex();
    if (e.item.name == "RemoveData") {
        if (index > -1) {
            var result = confirm("Dữ liệu sẽ mất không thể khôi phục, bạn có chắc chắn muốn xóa?");
            if (result) {
                clickRemoveData = 1;
                OnGridFocusedRowChanged(s, e);
            }
        }
        else {
            toastr.error("Vui lòng chọn thông tin");
            return;
        }
    }
    if (e.item.name == "ActiveData") {
        if (index > -1) {
            clickActiveData = 1;
            OnGridFocusedRowChanged(s, e);
        }
        else {
            toastr.error("Vui lòng chọn thông tin");
            return;
        }
    }
    if (e.item.name == "AdminDataEmployee") {
        PopupControlFilterEmployee.Show();
    }

}
function OnGridFocusedRowChanged(s, e) {
    s.GetRowValues(s.GetFocusedRowIndex(), 'ID;FullName', OnGetRowValues);
}
function OnGetRowValues(values) {
    idEmployee = values[0];
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
    gvEmployee.PerformCallback({ active: activeValue });
}

function onSubmitClickFilterEmployee(s, e) {
    PopupControlFilterEmployee.Hide();
}

function TypeValueChanged(s, e) {
    if (s.lastSuccessValue != null) {
        if (s.lastSuccessValue == 0) {
            activeValue = true;
            gvEmployee.PerformCallback({ active: activeValue });
        }
        else {
            activeValue = false;
            gvEmployee.PerformCallback({ active: activeValue });
        }

    }
}

function RemoveData() {

    Loading.Show();
    $.ajax({
        url: "/Permission/RemoveData",
        data: {
            id: idEmployee,
            active: activeValue
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentEmployee").html(data);

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
        url: "/Permission/ActiveData",
        data: {
            id: idEmployee,
            active: activeValue
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentEmployee").html(data);

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

//Application Role
function OnToolbarItemClickApplicationRole(s, e) {


}

function OnGridFocusedRowChangedApplicationRole(s, e) {
    s.GetRowValues(s.GetFocusedRowIndex(), 'Id;Name', OnGetRowValuesApplicationRole);
}

function OnGetRowValuesApplicationRole(values) {
    idApplicationRole = values[0];
}

function CFOnBeginCallBackApplicationRole(s, e) {

}

function CFInitGridviewApplicationRole(s, e) {
    gvApplicationRole.PerformCallback({});
}

//Application Group
function OnToolbarItemClickApplicationGroup(s, e) {
    var index = gvApplicationGroup.GetFocusedRowIndex();
    if (e.item.name == "AddDataApplicationGroup") {
        clickActionApplicationGroup = 1;
        ResetValueControlApplicationGroup();
        PopupControlApplicationGroup.Show();
        LoadApplicationRole();
        LoadMenu();
    }
    if (e.item.name == "EditDataApplicationGroup") {
        if (index > -1) {
            ResetValueControlApplicationGroup();
            clickActionApplicationGroup = 2;
            OnGridFocusedRowChangedApplicationGroup(s, e);

        }
    }
    if (e.item.name == "AdminDataApplicationGroup") {
        PopupControlFilterApplicationGroup.Show();
    }
    if (e.item.name == "RemoveDataApplicationGroup") {
        if (index > -1) {
            var result = confirm("Dữ liệu sẽ mất không thể khôi phục, bạn có chắc chắn muốn xóa?");
            if (result) {
                clickRemoveDataApplicationGroup = 1;
                OnGridFocusedRowChangedApplicationGroup(s, e);
            }
        }
    }

}

function ResetValueControlApplicationGroup() {
    textBoxNameApplicationGroup.SetText(null);

    arrayApplicationRoleText = [];
    arrayApplicationRoleValue = [];
    arrayMenuText = [];
    arrayMenuValue = [];
}

function OnGridFocusedRowChangedApplicationGroup(s, e) {
    s.GetRowValues(s.GetFocusedRowIndex(), 'ID;Name', OnGetRowValuesApplicationGroup);
}

function OnGetRowValuesApplicationGroup(values) {
    idApplicationGroup = values[0];
    if (clickActionApplicationGroup == 2) {

        GetListRoleByGroupId();
        GetListMenuByGroupId();
        textBoxNameApplicationGroup.SetText(values[1]);
        PopupControlApplicationGroup.Show();
    }

    if (clickRemoveDataApplicationGroup == 1) {
        RemoveDataApplicationGroup();
    }
}

function CFOnBeginCallBackApplicationGroup(s, e) {

}

function CFInitGridviewApplicationGroup(s, e) {
    gvApplicationGroup.PerformCallback({});
}

//Application User
function OnToolbarItemClickApplicationUser(s, e) {

    var index = gvApplicationUser.GetFocusedRowIndex();
    if (e.item.name == "AddDataApplicationUser") {
        clickActionApplicationUser = 1;
        ResetValueControlApplicationUser();
        PopupControlApplicationUser.Show();
        LoadEmployee();
        LoadLevel();
        LoadApplicationGroup();
        LoadGradeGroup();
        LoadCourse();
        LoadGrade();

    }
    if (e.item.name == "EditDataApplicationUser") {
        if (index > -1) {
            ResetValueControlApplicationUser();
            clickActionApplicationUser = 2;
            OnGridFocusedRowChangedApplicationUser(s, e);
        }
        else {
            toastr.error("Vui lòng chọn tài khoản");
            return;
        }
    }

    if (e.item.name == "ResetPasswordApplicationUser") {
        if (index > -1) {
            
            clickActionResetPassword = 1;
            OnGridFocusedRowChangedApplicationUser(s, e);
        }
        else {
            toastr.error("Vui lòng chọn tài khoản");
            return;
        }
    }

    if (e.item.name == "RemoveDataApplicationUser") {
        if (index > -1) {
            var result = confirm("Dữ liệu sẽ mất không thể khôi phục, bạn có chắc chắn muốn xóa?");
            if (result) {
                clickRemoveDataApplicationUser = 1;
                OnGridFocusedRowChangedApplicationUser(s, e);
            }
        }
        else {
            toastr.error("Vui lòng chọn tài khoản");
            return;
        }
    }
    if (e.item.name == "BlockApplicationUser") {
        if (index > -1) {
            var result = confirm("Người dùng sẽ không thể vào hệ thống, bạn có chắc chắn muốn khóa?");
            if (result) {
                clickBlockApplicationUser = 1;
                OnGridFocusedRowChangedApplicationUser(s, e);
            }
        }
        else {
            toastr.error("Vui lòng chọn tài khoản");
            return;
        }
    }
    if (e.item.name == "UnblockApplicationUser") {
        if (index > -1) {
            var result = confirm("Sau khi mở, người dùng sẽ đăng nhập vào hệ thống, bạn có chắc chắn muốn mở khóa?");
            if (result) {
                clickBlockApplicationUser = 2;
                OnGridFocusedRowChangedApplicationUser(s, e);
            }
        }
        else {
            toastr.error("Vui lòng chọn tài khoản");
            return;
        }
    }

    if (e.item.name == "ImportDataApplicationUser") {
        PopupControlImport.Show();
    }

}

function ResetValueControlApplicationUser() {
    idEmployee = null;
    idLevel = null;
    txtUserName.SetText(null);
    arrayApplicationGroupText = [];
    arrayApplicationGroupValue = [];
    arrayGradeGroupText = [];
    arrayGradeGroupValue = [];
    arrayCourseText = [];
    arrayCourseValue = [];
    arrayGradeText = [];
    arrayGradeValue = [];

}

function ResetValueCourseAndGrade() {
    comboBoxCourse.SetText(null);

    listBoxCourse.SelectValues(null);
    arrayCourseText = [];
    arrayCourseValue = [];

    comboBoxGrade.SetText(null);

    listBoxGrade.SelectValues(null);
    arrayGradeText = [];
    arrayGradeValue = [];
}

function OnGridFocusedRowChangedApplicationUser(s, e) {
    s.GetRowValues(s.GetFocusedRowIndex(), 'Id;EmployeeId;LevelId;UserName', OnGetRowValuesApplicationUser);
}

function OnGetRowValuesApplicationUser(values) {
    idApplicationUser = values[0];

    if (clickActionApplicationUser == 2) {
        idEmployee = values[1];
        idLevel = values[2];
        LoadEmployee();
        LoadLevel();

        GetListGroupByUserId();
        GetListGradeGroupByUserId();
        GetListCourseByUserId();
        GetListGradeByUserId();
        PopupControlApplicationUser.Show();
        txtUserName.SetText(values[3]);

    }

    if (clickRemoveDataApplicationUser == 1) {
        RemoveDataApplicationUser();
    }

    if (clickBlockApplicationUser == 1 || clickBlockApplicationUser == 2) {
        UpdateStatusApplicationUser();
    }

    if (clickActionResetPassword == 1) {
        clickActionResetPassword = 0;
        ResetPasswordApplicationUser();
    }
}

function CFOnBeginCallBackApplicationUser(s, e) {

}

function CFInitGridviewApplicationUser(s, e) {
    gvApplicationUser.PerformCallback({});
}

function UnCheck(ArryCheck, Oid) {

    if (ArryCheck.length > 0) {
        for (var i = 0; i < ArryCheck.length; i++) {
            if (Oid == ArryCheck[i].value) {
                return false;
            }

        }
        return true;
    }
    else {
        return true;
    }

}

//Submit Application Group
function onSubmitClickApplicationGroup(s, e) {
    var checkData = CheckRegApplicationGroup();
    if (checkData != null) {
        toastr.error(checkData);
    }
    else {

        if (clickActionApplicationGroup == 1) {
            AddDataApplicationGroup();
        }
        else if (clickActionApplicationGroup == 2) {
            EditDataApplicationGroup();
        }

        PopupControlApplicationGroup.Hide();
    }
}

function onSubmitClickFilterApplicationGroup(s, e) {

}

function onCancelClickApplicationGroup(s, e) {
    PopupControlApplicationGroup.Hide();
    clickActionApplicationGroup = 0;
}

//Submit Application User

function onSubmitClickApplicationUser(s, e) {
    var checkData = CheckRegApplicationUser();
    if (checkData != null) {
        toastr.error(checkData);
    }
    else {

        if (clickActionApplicationUser == 1) {
            AddDataApplicationUser();
        }
        else if (clickActionApplicationUser == 2) {
            EditDataApplicationUser();
        }

        PopupControlApplicationUser.Hide();
    }
}

function onCancelClickApplicationUser(s, e) {
    PopupControlApplicationUser.Hide();
    clickActionApplicationUser = 0;
}

//Function Dropdow List

function IsSameCheck(ArrayCheck, Oid) {
    for (var i = 0; i < ArrayCheck.length; i++) {
        if (ArrayCheck[i] == Oid)
            return true;
    }
    return false;
}

function getTextByValues(listbox, values) {
    var texts = [];
    var item;
    for (var i = 0; i < values.length; i++) {
        item = listbox.FindItemByValue(values[i]);
        if (item != null)
            texts.push(item.text);
    }
    return texts;
}
function getArrayTextByValues(listbox, values) {
    var texts = [];
    var item;
    for (var i = 0; i < values.length; i++) {
        item = listbox.FindItemByValue(values[i]);
        if (item != null)
            texts.push(item.texts[0]);
    }
    return texts;
}
function getSelectedItemsText(items) {
    var texts = [];
    for (var i = 0; i < items.length; i++)
        texts.push(items[i]);
    return texts.join(textSeparator);
}

var textSeparator = ";";

//Application Role

function ApplicationRoleSelectedIndexChanged(s, e) {
    var selectedItems = listBoxApplicationRole.GetSelectedItems();

    if (selectedItems.length > 0) {

        if (e.index == -1) {
            arrayApplicationRoleText = [];
            arrayApplicationRoleValue = [];

            for (var i = 0; i < selectedItems.length; i++) {
                arrayApplicationRoleText.push(selectedItems[i].texts[0]);
                arrayApplicationRoleValue.push(selectedItems[i].value);

            }
            comboBoxApplicationRole.SetText(arrayApplicationRoleText.join(textSeparator));

        }
        else {
            for (var i = 0; i < selectedItems.length; i++) {
                if (arrayApplicationRoleValue.length > 0) {
                    //xem đã tồn tại chưa, nếu chưa thì add vào
                    if (IsSameCheck(arrayApplicationRoleValue, selectedItems[i].value) == false) {
                        arrayApplicationRoleText.push(selectedItems[i].texts[0]);
                        arrayApplicationRoleValue.push(selectedItems[i].value);
                        comboBoxApplicationRole.SetText(arrayApplicationRoleText.join(textSeparator));



                    }
                    //kiểm tra không check
                    else if (UnCheck(selectedItems, listBoxApplicationRole.GetItem(e.index).value) == true && IsSameCheck(arrayApplicationRoleValue, listBoxApplicationRole.GetItem(e.index).value) == true) {
                        var indexItem = arrayApplicationRoleValue.indexOf(listBoxApplicationRole.GetItem(e.index).value);
                        arrayApplicationRoleValue.splice(indexItem, 1);
                        var indexItemText = arrayApplicationRoleText.indexOf(listBoxApplicationRole.GetItem(e.index).texts[0]);
                        arrayApplicationRoleText.splice(indexItemText, 1);
                        comboBoxApplicationRole.SetText(arrayApplicationRoleText.join(textSeparator));


                    }

                }
                else {

                    arrayApplicationRoleValue.push(selectedItems[i].value);
                    arrayApplicationRoleText.push(selectedItems[i].texts[0]);
                    comboBoxApplicationRole.SetText(arrayApplicationRoleText.join(textSeparator));

                }

            }
        }

    }
    else {
        if (e.index > -1) {

            var indexItem = arrayApplicationRoleValue.indexOf(listBoxApplicationRole.GetItem(e.index).value);
            arrayApplicationRoleValue.splice(indexItem, 1);
            var indexItemText = arrayApplicationRoleText.indexOf(listBoxApplicationRole.GetItem(e.index).texts[0]);
            arrayApplicationRoleText.splice(indexItemText, 1);
            comboBoxApplicationRole.SetText(arrayApplicationRoleText.join(textSeparator));

        }
        else {

            arrayApplicationRoleText = [];
            arrayApplicationRoleValue = [];
            comboBoxApplicationRole.SetText(null);

        }
    }

}
function ApplicationRoleTextChanged(dropDown, args) {
    listBoxApplicationRole.UnselectAll();

    var texts = dropDown.GetText().split(textSeparator);

    var values = getValuesByTextsApplicationRole(texts);

    listBoxApplicationRole.SelectValues(values);
    comboBoxApplicationRole.SetText(arrayApplicationRoleText.join(textSeparator));

}

function getValuesByTextsApplicationRole(texts) {


    var item;
    for (var i = 0; i < texts.length; i++) {
        item = listBoxApplicationRole.FindItemByText(texts[i]);
        if (item == null && IsSameCheck(arrayApplicationRoleText, texts[i]) == false) {

            arrayApplicationRoleValue.splice(i, 1);
            arrayApplicationRoleText.splice(i, 1);

        }
        if (item != null && IsSameCheck(arrayApplicationRoleText, item.text) == false) {

            arrayApplicationRoleText.push(item.texts[0]);
            arrayApplicationRoleValue.push(item.value);

        }
    }
    return arrayApplicationRoleValue;

}

//Menu

function MenuSelectedIndexChanged(s, e) {
    var selectedItems = listBoxMenu.GetSelectedItems();

    if (selectedItems.length > 0) {

        if (e.index == -1) {
            arrayMenuText = [];
            arrayMenuValue = [];

            for (var i = 0; i < selectedItems.length; i++) {
                arrayMenuText.push(selectedItems[i].texts[0]);
                arrayMenuValue.push(selectedItems[i].value);

            }
            comboBoxMenu.SetText(arrayMenuText.join(textSeparator));

        }
        else {
            for (var i = 0; i < selectedItems.length; i++) {
                if (arrayMenuValue.length > 0) {
                    //xem đã tồn tại chưa, nếu chưa thì add vào
                    if (IsSameCheck(arrayMenuValue, selectedItems[i].value) == false) {
                        arrayMenuText.push(selectedItems[i].texts[0]);
                        arrayMenuValue.push(selectedItems[i].value);
                        comboBoxMenu.SetText(arrayMenuText.join(textSeparator));



                    }
                    //kiểm tra không check
                    else if (UnCheck(selectedItems, listBoxMenu.GetItem(e.index).value) == true && IsSameCheck(arrayMenuValue, listBoxMenu.GetItem(e.index).value) == true) {
                        var indexItem = arrayMenuValue.indexOf(listBoxMenu.GetItem(e.index).value);
                        arrayMenuValue.splice(indexItem, 1);
                        var indexItemText = arrayMenuText.indexOf(listBoxMenu.GetItem(e.index).texts[0]);
                        arrayMenuText.splice(indexItemText, 1);
                        comboBoxMenu.SetText(arrayMenuText.join(textSeparator));


                    }

                }
                else {

                    arrayMenuValue.push(selectedItems[i].value);
                    arrayMenuText.push(selectedItems[i].texts[0]);
                    comboBoxMenu.SetText(arrayMenuText.join(textSeparator));

                }

            }
        }

    }
    else {
        if (e.index > -1) {

            var indexItem = arrayMenuValue.indexOf(listBoxMenu.GetItem(e.index).value);
            arrayMenuValue.splice(indexItem, 1);
            var indexItemText = arrayMenuText.indexOf(listBoxMenu.GetItem(e.index).texts[0]);
            arrayMenuText.splice(indexItemText, 1);
            comboBoxMenu.SetText(arrayMenuText.join(textSeparator));

        }
        else {

            arrayMenuText = [];
            arrayMenuValue = [];
            comboBoxMenu.SetText(null);

        }
    }

}
function MenuTextChanged(dropDown, args) {
    listBoxMenu.UnselectAll();

    var texts = dropDown.GetText().split(textSeparator);

    var values = getValuesByTextsMenu(texts);

    listBoxMenu.SelectValues(values);
    comboBoxMenu.SetText(arrayMenuText.join(textSeparator));

}

function getValuesByTextsMenu(texts) {

    var item;
    for (var i = 0; i < texts.length; i++) {
        item = listBoxMenu.FindItemByText(texts[i]);
        if (item == null && IsSameCheck(arrayMenuText, texts[i]) == false) {

            arrayMenuValue.splice(i, 1);
            arrayMenuText.splice(i, 1);

        }
        if (item != null && IsSameCheck(arrayMenuText, item.text) == false) {

            arrayMenuText.push(item.texts[0]);
            arrayMenuValue.push(item.value);

        }
    }
    return arrayMenuValue;

}

//Application Group
function ApplicationGroupSelectedIndexChanged(s, e) {
    var selectedItems = listBoxApplicationGroup.GetSelectedItems();

    if (selectedItems.length > 0) {

        if (e.index == -1) {
            arrayApplicationGroupText = [];
            arrayApplicationGroupValue = [];

            for (var i = 0; i < selectedItems.length; i++) {
                arrayApplicationGroupText.push(selectedItems[i].text);
                arrayApplicationGroupValue.push(selectedItems[i].value);

            }
            comboBoxApplicationGroup.SetText(arrayApplicationGroupText.join(textSeparator));

        }
        else {
            for (var i = 0; i < selectedItems.length; i++) {
                if (arrayApplicationGroupValue.length > 0) {
                    //xem đã tồn tại chưa, nếu chưa thì add vào
                    if (IsSameCheck(arrayApplicationGroupValue, selectedItems[i].value) == false) {
                        arrayApplicationGroupText.push(selectedItems[i].text);
                        arrayApplicationGroupValue.push(selectedItems[i].value);
                        comboBoxApplicationGroup.SetText(arrayApplicationGroupText.join(textSeparator));



                    }
                    //kiểm tra không check
                    else if (UnCheck(selectedItems, listBoxApplicationGroup.GetItem(e.index).value) == true && IsSameCheck(arrayApplicationGroupValue, listBoxApplicationGroup.GetItem(e.index).value) == true) {
                        var indexItem = arrayApplicationGroupValue.indexOf(listBoxApplicationGroup.GetItem(e.index).value);
                        arrayApplicationGroupValue.splice(indexItem, 1);
                        var indexItemText = arrayApplicationGroupText.indexOf(listBoxApplicationGroup.GetItem(e.index).text);
                        arrayApplicationGroupText.splice(indexItemText, 1);
                        comboBoxApplicationGroup.SetText(arrayApplicationGroupText.join(textSeparator));


                    }

                }
                else {

                    arrayApplicationGroupValue.push(selectedItems[i].value);
                    arrayApplicationGroupText.push(selectedItems[i].text);
                    comboBoxApplicationGroup.SetText(arrayApplicationGroupText.join(textSeparator));

                }

            }
        }

    }
    else {
        if (e.index > -1) {

            var indexItem = arrayApplicationGroupValue.indexOf(listBoxApplicationGroup.GetItem(e.index).value);
            arrayApplicationGroupValue.splice(indexItem, 1);
            var indexItemText = arrayApplicationGroupText.indexOf(listBoxApplicationGroup.GetItem(e.index).text);
            arrayApplicationGroupText.splice(indexItemText, 1);
            comboBoxApplicationGroup.SetText(arrayApplicationGroupText.join(textSeparator));

        }
        else {

            arrayApplicationGroupText = [];
            arrayApplicationGroupValue = [];
            comboBoxApplicationGroup.SetText(null);

        }
    }


}
function ApplicationGroupTextChanged(dropDown, args) {
    listBoxApplicationGroup.UnselectAll();

    var texts = dropDown.GetText().split(textSeparator);

    var values = getValuesByTextsApplicationGroup(texts);

    listBoxApplicationGroup.SelectValues(values);
    comboBoxApplicationGroup.SetText(arrayApplicationGroupText.join(textSeparator));

}

function getValuesByTextsApplicationGroup(texts) {
    var item;
    for (var i = 0; i < texts.length; i++) {
        item = listBoxApplicationGroup.FindItemByText(texts[i]);
        if (item == null && IsSameCheck(arrayApplicationGroupText, texts[i]) == false) {

            arrayApplicationGroupValue.splice(i, 1);
            arrayApplicationGroupText.splice(i, 1);

        }
        if (item != null && IsSameCheck(arrayApplicationGroupText, item.text) == false) {

            arrayApplicationGroupText.push(item.text);
            arrayApplicationGroupValue.push(item.value);

        }
    }
    return arrayApplicationGroupValue;

}

//GradeGroup
function GradeGroupSelectedIndexChanged(s, e) {
    var selectedItems = listBoxGradeGroup.GetSelectedItems();

    if (selectedItems.length > 0) {

        if (e.index == -1) {
            arrayGradeGroupText = [];
            arrayGradeGroupValue = [];

            for (var i = 0; i < selectedItems.length; i++) {
                arrayGradeGroupText.push(selectedItems[i].texts[0]);
                arrayGradeGroupValue.push(selectedItems[i].value);

            }
            comboBoxGradeGroup.SetText(arrayGradeGroupText.join(textSeparator));

        }
        else {
            for (var i = 0; i < selectedItems.length; i++) {
                if (arrayGradeGroupValue.length > 0) {
                    //xem đã tồn tại chưa, nếu chưa thì add vào
                    if (IsSameCheck(arrayGradeGroupValue, selectedItems[i].value) == false) {
                        arrayGradeGroupText.push(selectedItems[i].texts[0]);
                        arrayGradeGroupValue.push(selectedItems[i].value);
                        comboBoxGradeGroup.SetText(arrayGradeGroupText.join(textSeparator));



                    }
                    //kiểm tra không check
                    else if (UnCheck(selectedItems, listBoxGradeGroup.GetItem(e.index).value) == true && IsSameCheck(arrayGradeGroupValue, listBoxGradeGroup.GetItem(e.index).value) == true) {
                        var indexItem = arrayGradeGroupValue.indexOf(listBoxGradeGroup.GetItem(e.index).value);
                        arrayGradeGroupValue.splice(indexItem, 1);
                        var indexItemText = arrayGradeGroupText.indexOf(listBoxGradeGroup.GetItem(e.index).texts[0]);
                        arrayGradeGroupText.splice(indexItemText, 1);
                        comboBoxGradeGroup.SetText(arrayGradeGroupText.join(textSeparator));


                    }

                }
                else {

                    arrayGradeGroupValue.push(selectedItems[i].value);
                    arrayGradeGroupText.push(selectedItems[i].texts[0]);
                    comboBoxGradeGroup.SetText(arrayGradeGroupText.join(textSeparator));

                }

            }
        }

    }
    else {
        if (e.index > -1) {

            var indexItem = arrayGradeGroupValue.indexOf(listBoxGradeGroup.GetItem(e.index).value);
            arrayGradeGroupValue.splice(indexItem, 1);
            var indexItemText = arrayGradeGroupText.indexOf(listBoxGradeGroup.GetItem(e.index).texts[0]);
            arrayGradeGroupText.splice(indexItemText, 1);
            comboBoxGradeGroup.SetText(arrayGradeGroupText.join(textSeparator));

        }
        else {

            arrayGradeGroupText = [];
            arrayGradeGroupValue = [];
            comboBoxGradeGroup.SetText(null);

        }
    }
    ResetValueCourseAndGrade();
    LoadCourse();
    LoadGrade();

}
function GradeGroupTextChanged(dropDown, args) {
    listBoxGradeGroup.UnselectAll();

    var texts = dropDown.GetText().split(textSeparator);

    var values = getValuesByTextsGradeGroup(texts);

    listBoxGradeGroup.SelectValues(values);
    comboBoxGradeGroup.SetText(arrayGradeGroupText.join(textSeparator));
    ResetValueCourseAndGrade();
    LoadCourse();
    LoadGrade();

}

function getValuesByTextsGradeGroup(texts) {

    var item;
    for (var i = 0; i < texts.length; i++) {
        item = listBoxGradeGroup.FindItemByText(texts[i]);
        if (item == null && IsSameCheck(arrayGradeGroupText, texts[i]) == false) {

            arrayGradeGroupValue.splice(i, 1);
            arrayGradeGroupText.splice(i, 1);

        }
        if (item != null && IsSameCheck(arrayGradeGroupText, item.text) == false) {

            arrayGradeGroupText.push(item.texts[0]);
            arrayGradeGroupValue.push(item.value);

        }
    }
    return arrayGradeGroupValue;

}

function EmployeeSelectedIndexChanged(s, e) {

}

function EmployeeTextChanged(s, e) {
    var text = comboBoxEmployee.GetText();
    var value = comboBoxEmployee.FindItemByText(text);
    if (value != null) {
        idEmployee = value.value;
    }
    else {
        comboBoxEmployee.SetValue(null);
    }
}

function LevelSelectedIndexChanged(s, e) {

}

function LevelTextChanged(s, e) {
    var text = comboBoxLevel.GetText();
    var value = comboBoxLevel.FindItemByText(text);
    if (value != null) {
        idLevel = value.value;
    }
    else {
        comboBoxLevel.SetValue(null);
    }
}

function CheckRegApplicationGroup() {


    if (textBoxNameApplicationGroup.GetText().length == 0) {
        return "Tên nhóm quyền không thể bỏ trống";
    }
    else if (arrayApplicationRoleValue.length == 0) {
        return "Vui lòng chọn quyền hạn cho nhóm quyền";
    }
    else if (arrayMenuValue.length == 0) {
        return "Vui lòng chọn menu cho nhóm quyền";
    }
    else {
        return null;
    }
}

function CheckRegApplicationUser() {


    if (comboBoxEmployee.GetValue() == null) {
        return "Vui lòng chọn người cần cấp quyền";
    }
    else if (comboBoxLevel.GetValue() == null) {
        return "Vui lòng chọn cấp độ cho người dùng";
    }
    else if (arrayApplicationGroupValue.length == 0) {
        return "Vui lòng chọn nhóm quyền cho người dùng";
    }
    else {
        return null;
    }
}

function LoadApplicationRole() {

    Loading.Show();
    $.ajax({
        url: "/Permission/DropDownEditApplicationRolePartial",
        data: {

        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentDropDownEditApplicationRole").html(data);

                comboBoxApplicationRole.SetText(arrayApplicationRoleText.join(textSeparator));

                listBoxApplicationRole.SelectValues(arrayApplicationRoleValue);
            }

            Loading.Hide();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);

            Loading.Hide();

        }
    });
}

function LoadMenu() {

    Loading.Show();
    $.ajax({
        url: "/Permission/DropDownEditMenuPartial",
        data: {

        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentDropDownEditMenu").html(data);

                comboBoxMenu.SetText(arrayMenuText.join(textSeparator));

                listBoxMenu.SelectValues(arrayMenuValue);
            }

            Loading.Hide();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);

            Loading.Hide();

        }
    });
}

function GetListRoleByGroupId() {

    Loading.Show();
    $.ajax({
        url: "/Permission/GetListRoleByGroupId",
        data: {
            applicationGroup: idApplicationGroup
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                for (var i = 0; i < data.length; i++) {
                    arrayApplicationRoleValue.push(data[i].Id);
                    arrayApplicationRoleText.push(data[i].Name);
                }
            }
            LoadApplicationRole();
            Loading.Hide();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
            LoadApplicationRole();
            Loading.Hide();

        }
    });
}

function GetListMenuByGroupId() {

    Loading.Show();
    $.ajax({
        url: "/Permission/GetListMenuByGroupId",
        data: {
            applicationGroup: idApplicationGroup
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                for (var i = 0; i < data.length; i++) {
                    arrayMenuValue.push(data[i].ID);
                    arrayMenuText.push(data[i].Name);
                }


            }
            LoadMenu();
            Loading.Hide();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
            LoadMenu();
            Loading.Hide();

        }
    });
}

function LoadApplicationGroup() {

    Loading.Show();
    $.ajax({
        url: "/Permission/DropDownEditApplicationGroupPartial",
        data: {

        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentDropDownEditApplicationGroup").html(data);

                comboBoxApplicationGroup.SetText(arrayApplicationGroupText.join(textSeparator));

                listBoxApplicationGroup.SelectValues(arrayApplicationGroupValue);
            }

            Loading.Hide();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);

            Loading.Hide();

        }
    });
}

function LoadGradeGroup() {

    Loading.Show();
    $.ajax({
        url: "/Permission/DropDownEditGradeGroupPartial",
        data: {

        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentDropDownEditGradeGroup").html(data);

                comboBoxGradeGroup.SetText(arrayGradeGroupText.join(textSeparator));

                listBoxGradeGroup.SelectValues(arrayGradeGroupValue);
            }

            Loading.Hide();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);

            Loading.Hide();

        }
    });
}

function LoadEmployee() {

    Loading.Show();
    $.ajax({
        url: "/Permission/ComboboxEmployeePartital",
        data: {

        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentComboBoxEmployee").html(data);
                comboBoxEmployee.SetValue(idEmployee);
            }

            Loading.Hide();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);

            Loading.Hide();

        }
    });
}

function LoadLevel() {

    Loading.Show();
    $.ajax({
        url: "/Permission/ComboboxLevelPartital",
        data: {

        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentComboBoxLevel").html(data);
                comboBoxLevel.SetValue(idLevel);
            }

            Loading.Hide();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);

            Loading.Hide();

        }
    });
}

//Add Application Group
function AddDataApplicationGroup() {
    Loading.Show();
    $.ajax({
        url: "/Permission/AddDataApplicationGroup",
        data: {
            name: textBoxNameApplicationGroup.GetText(),
            roles: arrayApplicationRoleValue,
            menus: arrayMenuValue
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentApplicationGroup").html(data);

            }
            clickActionApplicationGroup = 0;
            Loading.Hide();

        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
            clickActionApplicationGroup = 0;
            Loading.Hide();


        }
    });
}

function EditDataApplicationGroup() {
    Loading.Show();
    $.ajax({
        url: "/Permission/EditDataApplicationGroup",
        data: {
            id: idApplicationGroup,
            name: textBoxNameApplicationGroup.GetText(),
            roles: arrayApplicationRoleValue,
            menus: arrayMenuValue
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentApplicationGroup").html(data);

            }
            clickActionApplicationGroup = 0;
            Loading.Hide();

        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
            clickActionApplicationGroup = 0;
            Loading.Hide();


        }
    });
}

function RemoveDataApplicationGroup() {

    Loading.Show();
    $.ajax({
        url: "/Permission/RemoveDataApplicationGroup",
        data: {
            id: idApplicationGroup
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentApplicationGroup").html(data);

            }
            clickRemoveDataApplicationGroup = 0;
            Loading.Hide();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
            clickRemoveDataApplicationGroup = 0;
            Loading.Hide();

        }
    });
}

function GetListGroupByUserId() {

    Loading.Show();
    $.ajax({
        url: "/Permission/GetListGroupByUserId",
        data: {
            userId: idApplicationUser
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {

                for (var i = 0; i < data.length; i++) {
                    arrayApplicationGroupValue.push(data[i].ID);
                    arrayApplicationGroupText.push(data[i].Name);
                }

            }
            LoadApplicationGroup();
            Loading.Hide();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
            LoadApplicationGroup();
            Loading.Hide();

        }
    });
}

function GetListGradeGroupByUserId() {

    Loading.Show();
    $.ajax({
        url: "/Permission/GetListGradeGroupByUserId",
        data: {
            userId: idApplicationUser
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {

                for (var i = 0; i < data.length; i++) {
                    arrayGradeGroupValue.push(data[i].ID);
                    arrayGradeGroupText.push(data[i].Name);
                }

            }
            LoadGradeGroup();
            Loading.Hide();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
            LoadGradeGroup();
            Loading.Hide();

        }
    });
}

function GetListCourseByUserId() {

    Loading.Show();
    $.ajax({
        url: "/Permission/GetListCourseByUserId",
        data: {
            userId: idApplicationUser
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {

                for (var i = 0; i < data.length; i++) {
                    arrayCourseValue.push(data[i].ID);
                    arrayCourseText.push(data[i].Name);
                }

            }
            LoadCourse();
            Loading.Hide();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
            LoadCourse();
            Loading.Hide();

        }
    });
}

function GetListGradeByUserId() {

    Loading.Show();
    $.ajax({
        url: "/Permission/GetListGradeByUserId",
        data: {
            userId: idApplicationUser
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {

                for (var i = 0; i < data.length; i++) {
                    arrayGradeValue.push(data[i].ID);
                    arrayGradeText.push(data[i].Name);
                }

            }
            LoadGrade();
            Loading.Hide();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
            LoadGrade();
            Loading.Hide();

        }
    });
}

//Add Application User
function AddDataApplicationUser() {
    Loading.Show();
    $.ajax({
        url: "/Permission/AddDataApplicationUser",
        data: {
            username: txtUserName.GetText(),
            employee: comboBoxEmployee.GetValue(),
            level: comboBoxLevel.GetValue(),
            applicationGroups: arrayApplicationGroupValue,
            gradeGroups: arrayGradeGroupValue,
            courses: arrayCourseValue,
            grades: arrayGradeValue
        },
        type: 'POST',
        success: function (data) {
            if (data.status != 0) {
                toastr.error(data.msg);
                Loading.Hide();
                return;
            }
            clickActionApplicationUser = 0;
            toastr.success("Tạo tài khoản thành công");
            gvApplicationUser.PerformCallback({});
            Loading.Hide();

        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
            clickActionApplicationUser = 0;
            Loading.Hide();


        }
    });
}

function EditDataApplicationUser() {
    Loading.Show();
    $.ajax({
        url: "/Permission/EditDataApplicationUser",
        data: {
            id: idApplicationUser,
            username: txtUserName.GetText(),
            employee: comboBoxEmployee.GetValue(),
            level: comboBoxLevel.GetValue(),
            applicationGroups: arrayApplicationGroupValue,
            gradeGroups: arrayGradeGroupValue,
            courses: arrayCourseValue,
            grades: arrayGradeValue
        },
        type: 'POST',
        success: function (data) {
            if (data.status != 0) {
                toastr.error(data.msg);
                Loading.Hide();
                return;
            }
            clickActionApplicationUser = 0;
            toastr.success("Cập nhật tài khoản thành công");
            gvApplicationUser.PerformCallback({});
            Loading.Hide();

        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
            clickActionApplicationUser = 0;
            Loading.Hide();


        }
    });
}

function ResetPasswordApplicationUser() {
    Loading.Show();
    $.ajax({
        url: "/Permission/ResetPasswordApplicationUser",
        data: {
            id: idApplicationUser
        },
        type: 'POST',
        success: function (data) {
            if (data.status != 0) {
                toastr.error(data.msg);
                Loading.Hide();
                return;
            }

            toastr.success("Khôi phục mật khẩu thành công");
            gvApplicationUser.PerformCallback({});
            
            Loading.Hide();

        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
            Loading.Hide();


        }
    });
}

function RemoveDataApplicationUser() {

    Loading.Show();
    $.ajax({
        url: "/Permission/RemoveDataApplicationUser",
        data: {
            id: idApplicationUser
        },
        type: 'POST',
        success: function (data) {
            if (data.status != 0) {
                toastr.error(data.msg);
                Loading.Hide();
                return;
            }
            toastr.success("Xóa tài khoản thành công");
            gvApplicationUser.PerformCallback({});

            clickRemoveDataApplicationUser = 0;
            Loading.Hide();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
            clickRemoveDataApplicationUser = 0;
            Loading.Hide();

        }
    });
}

function UpdateStatusApplicationUser() {

    Loading.Show();
    $.ajax({
        url: "/Permission/UpdateStatusApplicationUser",
        data: {
            id: idApplicationUser,
            block: clickBlockApplicationUser
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentApplicationUser").html(data);

            }
            clickBlockApplicationUser = 0;
            Loading.Hide();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
            clickBlockApplicationUser = 0;
            Loading.Hide();

        }
    });
}

function onSubmitClickImport(s, e) {
    UploadFiles();
    PopupControlImport.Hide();
}

function onCancelClickImport(s, e) {
    PopupControlImport.Hide();
}

function UploadFiles() {
    Loading.Show();
    var fileUpload = $("#files").get(0);
    var files = fileUpload.files;
    // Create FormData object
    var fileData = new FormData();
    // Looping over all files and add it to FormData object
    for (var i = 0; i < files.length; i++) {
        fileData.append(files[i].name, files[i]);
    }
    $.ajax({
        url: "/Permission/UploadFiles",
        type: 'POST',
        contentType: false, // Not to set any content header
        processData: false, // Not to process data
        data: fileData,
        async: true,
        success: function (data) {
            if (data == true) {
                $("#files").val(null);
                gvApplicationUser.PerformCallback({});

            }
            else {
                $("#files").val(null);
                toastr.error(data);

            }

            Loading.Hide();

        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);

            Loading.Hide();


        }
    });
}


//chuyen khoa
function CourseSelectedIndexChanged(s, e) {
    var selectedItems = listBoxCourse.GetSelectedItems();

    if (selectedItems.length > 0) {

        if (e.index == -1) {
            arrayCourseText = [];
            arrayCourseValue = [];

            for (var i = 0; i < selectedItems.length; i++) {
                arrayCourseText.push(selectedItems[i].texts[0]);
                arrayCourseValue.push(selectedItems[i].value);

            }
            comboBoxCourse.SetText(arrayCourseText.join(textSeparator));

        }
        else {
            for (var i = 0; i < selectedItems.length; i++) {
                if (arrayCourseValue.length > 0) {
                    //xem đã tồn tại chưa, nếu chưa thì add vào
                    if (IsSameCheck(arrayCourseValue, selectedItems[i].value) == false) {
                        arrayCourseText.push(selectedItems[i].texts[0]);
                        arrayCourseValue.push(selectedItems[i].value);
                        comboBoxCourse.SetText(arrayCourseText.join(textSeparator));



                    }
                    //kiểm tra không check
                    else if (UnCheck(selectedItems, listBoxCourse.GetItem(e.index).value) == true && IsSameCheck(arrayCourseValue, listBoxCourse.GetItem(e.index).value) == true) {
                        var indexItem = arrayCourseValue.indexOf(listBoxCourse.GetItem(e.index).value);
                        arrayCourseValue.splice(indexItem, 1);
                        var indexItemText = arrayCourseText.indexOf(listBoxCourse.GetItem(e.index).texts[0]);
                        arrayCourseText.splice(indexItemText, 1);
                        comboBoxCourse.SetText(arrayCourseText.join(textSeparator));


                    }

                }
                else {

                    arrayCourseValue.push(selectedItems[i].value);
                    arrayCourseText.push(selectedItems[i].texts[0]);
                    comboBoxCourse.SetText(arrayCourseText.join(textSeparator));

                }

            }
        }

    }
    else {
        if (e.index > -1) {

            var indexItem = arrayCourseValue.indexOf(listBoxCourse.GetItem(e.index).value);
            arrayCourseValue.splice(indexItem, 1);
            var indexItemText = arrayCourseText.indexOf(listBoxCourse.GetItem(e.index).texts[0]);
            arrayCourseText.splice(indexItemText, 1);
            comboBoxCourse.SetText(arrayCourseText.join(textSeparator));

        }
        else {

            arrayCourseText = [];
            arrayCourseValue = [];
            comboBoxCourse.SetText(null);

        }
    }

}
function CourseTextChanged(dropDown, args) {
    listBoxCourse.UnselectAll();

    var texts = dropDown.GetText().split(textSeparator);

    var values = getValuesByTextsCourse(texts);

    listBoxCourse.SelectValues(values);
    comboBoxCourse.SetText(arrayCourseText.join(textSeparator));

}

function getValuesByTextsCourse(texts) {

    var item;
    for (var i = 0; i < texts.length; i++) {
        item = listBoxCourse.FindItemByText(texts[i]);
        if (item == null && IsSameCheck(arrayCourseText, texts[i]) == false) {

            arrayCourseValue.splice(i, 1);
            arrayCourseText.splice(i, 1);

        }
        if (item != null && IsSameCheck(arrayCourseText, item.text) == false) {

            arrayCourseText.push(item.texts[0]);
            arrayCourseValue.push(item.value);

        }
    }
    return arrayCourseValue;

}


function LoadCourse() {
    
    Loading.Show();
    $.ajax({
        url: "/Permission/DropDownEditCoursePartial",
        data: {
            gradeGroups: arrayGradeGroupValue
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentDropDownEditCourse").html(data);

                comboBoxCourse.SetText(arrayCourseText.join(textSeparator));

                listBoxCourse.SelectValues(arrayCourseValue);
            }

            Loading.Hide();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);

            Loading.Hide();

        }
    });
}

//lop

function GradeSelectedIndexChanged(s, e) {
    var selectedItems = listBoxGrade.GetSelectedItems();

    if (selectedItems.length > 0) {

        if (e.index == -1) {
            arrayGradeText = [];
            arrayGradeValue = [];

            for (var i = 0; i < selectedItems.length; i++) {
                arrayGradeText.push(selectedItems[i].texts[0]);
                arrayGradeValue.push(selectedItems[i].value);

            }
            comboBoxGrade.SetText(arrayGradeText.join(textSeparator));

        }
        else {
            for (var i = 0; i < selectedItems.length; i++) {
                if (arrayGradeValue.length > 0) {
                    //xem đã tồn tại chưa, nếu chưa thì add vào
                    if (IsSameCheck(arrayGradeValue, selectedItems[i].value) == false) {
                        arrayGradeText.push(selectedItems[i].texts[0]);
                        arrayGradeValue.push(selectedItems[i].value);
                        comboBoxGrade.SetText(arrayGradeText.join(textSeparator));



                    }
                    //kiểm tra không check
                    else if (UnCheck(selectedItems, listBoxGrade.GetItem(e.index).value) == true && IsSameCheck(arrayGradeValue, listBoxGrade.GetItem(e.index).value) == true) {
                        var indexItem = arrayGradeValue.indexOf(listBoxGrade.GetItem(e.index).value);
                        arrayGradeValue.splice(indexItem, 1);
                        var indexItemText = arrayGradeText.indexOf(listBoxGrade.GetItem(e.index).texts[0]);
                        arrayGradeText.splice(indexItemText, 1);
                        comboBoxGrade.SetText(arrayGradeText.join(textSeparator));


                    }

                }
                else {

                    arrayGradeValue.push(selectedItems[i].value);
                    arrayGradeText.push(selectedItems[i].texts[0]);
                    comboBoxGrade.SetText(arrayGradeText.join(textSeparator));

                }

            }
        }

    }
    else {
        if (e.index > -1) {

            var indexItem = arrayGradeValue.indexOf(listBoxGrade.GetItem(e.index).value);
            arrayGradeValue.splice(indexItem, 1);
            var indexItemText = arrayGradeText.indexOf(listBoxGrade.GetItem(e.index).texts[0]);
            arrayGradeText.splice(indexItemText, 1);
            comboBoxGrade.SetText(arrayGradeText.join(textSeparator));

        }
        else {

            arrayGradeText = [];
            arrayGradeValue = [];
            comboBoxGrade.SetText(null);

        }
    }

}
function GradeTextChanged(dropDown, args) {
    listBoxGrade.UnselectAll();

    var texts = dropDown.GetText().split(textSeparator);

    var values = getValuesByTextsGrade(texts);

    listBoxGrade.SelectValues(values);
    comboBoxGrade.SetText(arrayGradeText.join(textSeparator));

}

function getValuesByTextsGrade(texts) {

    var item;
    for (var i = 0; i < texts.length; i++) {
        item = listBoxGrade.FindItemByText(texts[i]);
        if (item == null && IsSameCheck(arrayGradeText, texts[i]) == false) {

            arrayGradeValue.splice(i, 1);
            arrayGradeText.splice(i, 1);

        }
        if (item != null && IsSameCheck(arrayGradeText, item.text) == false) {

            arrayGradeText.push(item.texts[0]);
            arrayGradeValue.push(item.value);

        }
    }
    return arrayGradeValue;

}

function LoadGrade() {

    Loading.Show();
    $.ajax({
        url: "/Permission/DropDownEditGradePartial",
        data: {
            gradeGroups: arrayGradeGroupValue
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentDropDownEditGrade").html(data);

                comboBoxGrade.SetText(arrayGradeText.join(textSeparator));

                listBoxGrade.SelectValues(arrayGradeValue);
            }

            Loading.Hide();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);

            Loading.Hide();

        }
    });
}