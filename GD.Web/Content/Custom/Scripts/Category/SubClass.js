var idSubClass;
var activeValue = true;

var clickEditData = 0;
var clickRemoveData = 0;
var clickActiveData = 0;

//Student Add Sub Class
var arrayStudentAddSubClassText = [];
var arrayStudentAddSubClassValue = [];

function SubClassFilterSelectedIndexChanged(s, e) {
    if (s.lastSuccessValue != null) {
        gvSubClass.PerformCallback({
            active: activeValue,
            grade: comboBoxSubClassFilter.GetValue() == null ? 0 : comboBoxSubClassFilter.GetValue(),
            scholastic: comboBoxScholasticFilter.GetValue() == null ? 0 : comboBoxScholasticFilter.GetValue()
        });
    }
}

function OnToolbarItemClick(s, e) {
    var index = gvSubClass.GetFocusedRowIndex();
    if (e.item.name == "AddData") {
        PopupControlAddSubClass.Show();
        //reset
        arrayStudentAddSubClassText = [];
        arrayStudentAddSubClassValue = [];
        comboBoxScholasticAddSubClass.SetValue(null);
        comboBoxGradeAddSubClass.SetValue(null);
        listBoxStudentAddSubClass.UnselectAll();
        var dataHtml = "<p> <i> Tổng số: " + 0 + " học sinh </i></p>";
        $("#contentViewNumber").html(dataHtml);
    }
    if (e.item.name == "UpLevel") {
        if (comboBoxScholasticFilter.GetValue() == null) {
            toastr.error("Vui lòng chọn năm học");
            return;
        }

        if (comboBoxSubClassFilter.GetValue() == null) {
            toastr.error("Vui lòng chọn lớp");
            return;
        }

        var result = confirm("Hệ thống sẽ tự động thực hiện chuyển toàn bộ thông tin học sinh vào lớp mới, bạn có chắc chắn muốn thực hiện?");
        if (result) {
            UpLevelGrade();
        }
    }


    if (e.item.name == "RemoveData") {
        if (index > -1) {

            var result = confirm("Dữ liệu sẽ mất không thể khôi phục, bạn có chắc chắn muốn xóa?");
            if (result) {
                clickRemoveData = 1;
                OnGridFocusedRowChanged(s, e);
            }
        }
        else {
            toastr.error("Vui lòng chọn học sinh cần xóa");
        }
    }
    if (e.item.name == "AdminDataSubClass") {
        PopupControlFilterSubClass.Show();
    }

    if (e.item.name == "ActiveData") {
        if (index > -1) {
            clickActiveData = 1;
            OnGridFocusedRowChanged(s, e);
        }
    }

    if (e.item.name == "ImportData") {
        PopupControlImportSubClass.Show();
    }

}

function OnGridFocusedRowChanged(s, e) {
    s.GetRowValues(s.GetFocusedRowIndex(), 'ID;StudentId;GradeId', OnGetRowValues);
}
function OnGetRowValues(values) {
    

    if (clickRemoveData == 1) {
        RemoveData();

    }
    if (clickActiveData == 1) {
        ActiveData();

    }
}

function CFOnBeginCallBack(s, e) {
    e.customArgs["active"] = activeValue;
    e.customArgs["grade"] = comboBoxSubClassFilter.GetValue() == null ? 0 : comboBoxSubClassFilter.GetValue();
    e.customArgs["scholastic"] = comboBoxScholasticFilter.GetValue() == null ? 0 : comboBoxScholasticFilter.GetValue();
}

function CFInitGridview(s, e) {
    gvSubClass.PerformCallback({
        active: activeValue,
        grade: comboBoxSubClassFilter.GetValue() == null ? 0 : comboBoxSubClassFilter.GetValue(),
        scholastic: comboBoxScholasticFilter.GetValue() == null ? 0 : comboBoxScholasticFilter.GetValue()
    });
}

function RemoveData() {

    Loading.Show();
    $.ajax({
        url: "/SubClass/RemoveData",
        data: {
            id: idSubClass,
            active: activeValue
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentSubClass").html(data);

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
        url: "/SubClass/ActiveData",
        data: {
            id: idSubClass,
            active: activeValue
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentSubClass").html(data);

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

function CreateGrade() {
    PopupControlAddGrade.Show();
}

function onSubmitClickAddGrade(s, e) {
    if (textBoxPrefix.GetText().length == 0) {
        toastr.error("Vui lòng nhập hậu tố tên lớp");
        return;
    }
    if (comboBoxScholasticAddGrade.GetValue() == null) {
        toastr.error("Vui lòng chọn năm học");
        return;
    }
    if (comboBoxGradeGroupAddGrade.GetValue() == null) {
        toastr.error("Vui lòng chọn khối lớp");
        return;
    }
    AddGrade();
}

function onCancelClickAddGrade(s, e) {
    PopupControlAddGrade.Hide();
}

function AddGrade() {
    Loading.Show();
    $.ajax({
        url: "/SubClass/AddGrade",
        data: {
            prefix: textBoxPrefix.GetText(),
            scholastic: comboBoxScholasticAddGrade.GetValue(),
            gradeGroup: comboBoxGradeGroupAddGrade.GetValue(),
            note: memoNote.GetText()
        },
        type: 'POST',
        success: function (data) {
            if (data.status != 0) {
                toastr.error(data.msg);
                Loading.Hide();
                return;
            }

            toastr.success("Tạo lớp thành công");
            PopupControlAddGrade.Hide();
            Loading.Hide();

        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
            Loading.Hide();


        }
    });
}

function ScholasticAddSubClassSelectedIndexChanged(s, e) {
    if (s.lastSuccessValue != null) {
        LoadGradeAddSubClass();
    }
}

function LoadGradeAddSubClass() {
    Loading.Show();
    $.ajax({
        url: "/SubClass/LoadGradeAddSubClass",
        data: {
            id: comboBoxScholasticAddSubClass.GetValue()
        },
        type: 'POST',
        success: function (data) {

            if (data == "") {

            }
            else {
                $("#contentGradeAddSubClass").html(data);
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

function onSubmitClickAddSubClass(s, e) {
    if (comboBoxScholasticAddSubClass.GetValue() == null) {
        toastr.error("Vui lòng chọn năm học trước");
        arrayStudentAddSubClassText = [];
        arrayStudentAddSubClassValue = [];
        listBoxStudentAddSubClass.UnselectAll();
        return;
    }
    if (comboBoxGradeAddSubClass.GetValue() == null) {
        toastr.error("Vui lòng chọn lớp trước");
        arrayStudentAddSubClassText = [];
        arrayStudentAddSubClassValue = [];
        listBoxStudentAddSubClass.UnselectAll();
        return;
    }
    if (arrayStudentAddSubClassValue.length == 0) {
        toastr.error("Vui lòng chọn học sinh cần chia lớp");
        arrayStudentAddSubClassText = [];
        arrayStudentAddSubClassValue = [];
        listBoxStudentAddSubClass.UnselectAll();
        return;
    }
    AddSudentSubClass();
}

function onCancelClickAddSubClass(s, e) {
    PopupControlAddSubClass.Hide();
}

function IsSameCheck(ArrayCheck, Oid) {
    for (var i = 0; i < ArrayCheck.length; i++) {
        if (ArrayCheck[i] == Oid)
            return true;
    }
    return false;
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

function GradeAddSubClassSelectedIndexChanged(s, e) {
    if (s.lastSuccessValue != null && comboBoxScholasticAddSubClass.GetValue() != null) {
        arrayStudentAddSubClassText = [];
        arrayStudentAddSubClassValue = [];
        listBoxStudentAddSubClass.UnselectAll();
        LoadStudentOtherGrade();
    }
}

function LoadStudentOtherGrade() {
    Loading.Show();
    $.ajax({
        url: "/SubClass/LoadStudentOtherGrade",
        data: {
            scholastic: comboBoxScholasticAddSubClass.GetValue(),
            grade: comboBoxGradeAddSubClass.GetValue()
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentStudentAddSubClass").html(data);
                arrayStudentAddSubClassText = [];
                arrayStudentAddSubClassValue = [];
                listBoxStudentAddSubClass.UnselectAll();
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

function StudentAddSubClassSelectedIndexChanged(s, e) {
   
    if (comboBoxScholasticAddSubClass.GetValue() == null) {
        toastr.error("Vui lòng chọn năm học trước");
        arrayStudentAddSubClassText = [];
        arrayStudentAddSubClassValue = [];
        listBoxStudentAddSubClass.UnselectAll();
        return;
    }
    if (comboBoxGradeAddSubClass.GetValue() == null) {
        toastr.error("Vui lòng chọn lớp trước");
        arrayStudentAddSubClassText = [];
        arrayStudentAddSubClassValue = [];
        listBoxStudentAddSubClass.UnselectAll();
        return;
    }

    var selectedItems = listBoxStudentAddSubClass.GetSelectedItems();

    if (selectedItems.length > 0) {

        if (e.index == -1) {
            arrayStudentAddSubClassText = [];
            arrayStudentAddSubClassValue = [];

            for (var i = 0; i < selectedItems.length; i++) {
                arrayStudentAddSubClassText.push(selectedItems[i].texts[0]);
                arrayStudentAddSubClassValue.push(selectedItems[i].value);

            }

        }
        else {
            for (var i = 0; i < selectedItems.length; i++) {
                if (arrayStudentAddSubClassValue.length > 0) {
                    //xem đã tồn tại chưa, nếu chưa thì add vào
                    if (IsSameCheck(arrayStudentAddSubClassValue, selectedItems[i].value) == false) {
                        arrayStudentAddSubClassText.push(selectedItems[i].texts[0]);
                        arrayStudentAddSubClassValue.push(selectedItems[i].value);




                    }
                    //kiểm tra không check
                    else if (UnCheck(selectedItems, listBoxStudentAddSubClass.GetItem(e.index).value) == true && IsSameCheck(arrayStudentAddSubClassValue, listBoxStudentAddSubClass.GetItem(e.index).value) == true) {
                        var indexItem = arrayStudentAddSubClassValue.indexOf(listBoxStudentAddSubClass.GetItem(e.index).value);
                        arrayStudentAddSubClassValue.splice(indexItem, 1);
                        var indexItemText = arrayStudentAddSubClassText.indexOf(listBoxStudentAddSubClass.GetItem(e.index).texts[0]);
                        arrayStudentAddSubClassText.splice(indexItemText, 1);



                    }

                }
                else {

                    arrayStudentAddSubClassValue.push(selectedItems[i].value);
                    arrayStudentAddSubClassText.push(selectedItems[i].texts[0]);


                }

            }
        }

    }
    else {
        if (e.index > -1) {

            var indexItem = arrayStudentAddSubClassValue.indexOf(listBoxStudentAddSubClass.GetItem(e.index).value);
            arrayStudentAddSubClassValue.splice(indexItem, 1);
            var indexItemText = arrayStudentAddSubClassText.indexOf(listBoxStudentAddSubClass.GetItem(e.index).texts[0]);
            arrayStudentAddSubClassText.splice(indexItemText, 1);


        }
        else {

            arrayStudentAddSubClassText = [];
            arrayStudentAddSubClassValue = [];


        }
    }

    var dataHtml = "<p> <i> Tổng số: " + arrayStudentAddSubClassValue.length + " học sinh </i></p>";

    $("#contentViewNumber").html(dataHtml);
}

function AddSudentSubClass() {
    Loading.Show();
    $.ajax({
        url: "/SubClass/AddSudentSubClass",
        data: {
            scholastic: comboBoxScholasticAddSubClass.GetValue(),
            grade: comboBoxGradeAddSubClass.GetValue(),
            students: arrayStudentAddSubClassValue
        },
        type: 'POST',
        success: function (data) {
            if (data.status != 0) {
                toastr.error(data.msg);
                Loading.Hide();
                return;
            }

            toastr.success("Chia lớp mới thành công");
            gvSubClass.PerformCallback({
                active: activeValue,
                grade: comboBoxSubClassFilter.GetValue() == null ? 0 : comboBoxSubClassFilter.GetValue(),
                scholastic: comboBoxScholasticFilter.GetValue() == null ? 0 : comboBoxScholasticFilter.GetValue()
            });
            PopupControlAddSubClass.Hide();
            Loading.Hide();

        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
            Loading.Hide();


        }
    });
}

function UpLevelGrade() {
    Loading.Show();
    $.ajax({
        url: "/SubClass/UpLevelGrade",
        data: {
            scholastic: comboBoxScholasticFilter.GetValue(),
            grade: comboBoxSubClassFilter.GetValue()
        },
        type: 'POST',
        success: function (data) {
            if (data.status != 0) {
                toastr.error(data.msg);
                Loading.Hide();
                return;
            }

            toastr.success("Thực hiện lên lớp mới thành công");
            gvSubClass.PerformCallback({
                active: activeValue,
                grade: comboBoxSubClassFilter.GetValue() == null ? 0 : comboBoxSubClassFilter.GetValue(),
                scholastic: comboBoxScholasticFilter.GetValue() == null ? 0 : comboBoxScholasticFilter.GetValue()
            });
            PopupControlAddSubClass.Hide();
            Loading.Hide();

        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
            Loading.Hide();


        }
    });
}

function onDownloadTemplateClickImportSubClass(s, e) {
    DownloadFileTemplateImport();
}

function DownloadFileTemplateImport() {
    Loading.Show();
    $.ajax({
        url: "/SubClass/DownloadTemplateSubClassImport",
        data: {

        },
        type: 'POST',
        success: function (data) {

            if (data.status != 0) {
                toastr.error(data.msg);
                Loading.Hide();
                return;
            }

            if (navigator.onLine == false) {
                if (data.url != null && data.url != undefined && data.url.length > 0) {
                    onDownloadFileOnline(data.url);
                }
                else {
                    toastr.error("Không tồn tại tài liệu");
                    Loading.Hide();
                    return;
                }

            }

            toastr.success("Tải thành công");

            Loading.Hide();

        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
            Loading.Hide();

        }
    });
}

function onSubmitClickImportSubClass(s, e) {
    if (comboBoxScholasticFilter.GetValue() == null) {
        toastr.error("Vui lòng chọn năm học");
        return;
    }

    if (comboBoxSubClassFilter.GetValue() == null) {
        toastr.error("Vui lòng chọn lớp");
        return;
    }

    UploadFiles();
}

function onCancelClickImportSubClass(s, e) {
    PopupControlImportSubClass.Hide();
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

    var scholasticImport = comboBoxScholasticFilter.GetValue();
    var gradeImport = comboBoxSubClassFilter.GetValue();

    fileData.append("scholastic", scholasticImport);
    fileData.append("grade", gradeImport);

    $.ajax({
        url: "/SubClass/UploadFiles",
        type: 'POST',
        contentType: false, // Not to set any content header
        processData: false, // Not to process data
        data: fileData,
        async: true,
        success: function (data) {
            PopupControlImportSubClass.Hide();
            $("#files").val(null);

            if (data.status != 0) {

                PopupControlNotication.Show();
                var htmlData = "<font> Tải lên không thành công: " + "<br>" + data.msg + "<br>" + "</font>";
                $("#viewNotication").html(htmlData);
                Loading.Hide();
                return;
            }

            PopupControlNotication.Show();
            var htmlData = "<font>" + data.msg + "</font>";
            $("#viewNotication").html(htmlData);

            gvSubClass.PerformCallback({
                active: activeValue,
                grade: comboBoxSubClassFilter.GetValue() == null ? 0 : comboBoxSubClassFilter.GetValue(),
                scholastic: comboBoxScholasticFilter.GetValue() == null ? 0 : comboBoxScholasticFilter.GetValue()
            });

            Loading.Hide();

        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);

            Loading.Hide();


        }
    });
}

function onCancelNoticationClick(s, e) {
    PopupControlNotication.Hide();
}