var idStudent;
var idProvince;
var idDistrict;
var idWard;
var activeValue = true;
var clickEditData = 0;
var editingData = 0;

var clickRemoveData = 0;

var clickActiveData = 0;


function OnToolbarItemClick(s, e) {
    var index = gvStudent.GetFocusedRowIndex();
    if (e.item.name == "AddData") {
        ResetValueControl();
        PopupControlStudent.Show();
        LoadProvince();
    }
    if (e.item.name == "EditData") {
        if (index > -1) {
            clickEditData = 1;
            OnGridFocusedRowChanged(s, e);
        }
        else {
            toastr.error("Vui lòng chọn học sinh cần sửa");
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
    if (e.item.name == "AdminDataStudent") {
        PopupControlFilterStudent.Show();
    }
    
    if (e.item.name == "ActiveData") {
        if (index > -1) {
            clickActiveData = 1;
            OnGridFocusedRowChanged(s, e);
        }
    }

    if (e.item.name == "ImportData") {
        PopupControlImportStudent.Show();
    }

}
function ResetValueControl() {
    
    textBoxCode.SetText(null);
    textBoxFullName.SetText(null);
    comboBoxMale.SetValue(null);
    textBoxPhoneNumber.SetText(null);
    comboBoxDistrict.SetValue(null);
    comboBoxWard.SetValue(null);
    comboBoxProvince.SetValue(null);
    memoStreet.SetText(null);
}

function ResetValueControlTicket() {

    textBoxName.SetText(null);
    MemoNote.SetText(null);
    comboBoxPriority.SetValue(0);
}

function OnGridFocusedRowChanged(s, e) {
    s.GetRowValues(s.GetFocusedRowIndex(), 'ID;Code;FullName;Male;BirthDay;PhoneNumber;ProvinceId;DistrictId;WardId;Street', OnGetRowValues);
}
function OnGetRowValues(values) {
    idStudent = values[0];
    if (clickEditData == 1) {
        clickEditData = 0;
        idProvince = values[6];
        idDistrict = values[7];
        idWard = values[8];
        PopupControlStudent.Show();
        LoadProvince();
        LoadDistrict();
        LoadWard();
        textBoxCode.SetText(values[1]);
        textBoxFullName.SetText(values[2]);
        if (values[3] == true) {
            comboBoxMale.SetValue(1);
        }
        else {
            comboBoxMale.SetValue(0);
        }
        
        dateEditBirthDay.SetDate(values[4]);
        textBoxPhoneNumber.SetText(values[5]);
        memoStreet.SetText(values[9]);
        editingData = 1;
    }
    
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
    gvStudent.PerformCallback({ active: activeValue });
}

function onSubmitClickFilterStudent(s, e) {
    PopupControlFilterStudent.Hide();
}

function onSubmitClick(s, e) {
    const regIntWord = /[^0-9a-zA-Z]+/;
    const regMobilePhone = /(03|05|07|08|09|01[2|6|8|9])+([0-9]{8})\b/;
    if (textBoxCode.GetText().length == 0) {
        toastr.error("Mã nhân viên không thể bỏ trống");
        return;
    }
    if (regIntWord.test(textBoxCode.GetText()) == true) {
        toastr.error("Mã nhân viên không chứa ký tự đặc biệt");
        return;
    }
    if (textBoxFullName.GetText().length == 0) {
        toastr.error("Họ tên không thể bỏ trống");
        return;
    }
    if (dateEditBirthDay.GetDate() == null) {
        toastr.error("Ngày sinh không thể bỏ trống");
        return;
    }
    if (textBoxPhoneNumber.GetText().length > 0 && regMobilePhone.test(textBoxPhoneNumber.GetText()) == false) {
        toastr.error("Số điện thoại di động nhập không đúng");
        return;
    }
    if (comboBoxProvince.GetValue() == null) {
        toastr.error("Vui lòng chọn tỉnh thành");
        return;
    }
    if (comboBoxDistrict.GetValue() == null) {
        toastr.error("Vui lòng chọn quận huyện");
        return;
    }
    if (comboBoxWard.GetValue() == null) {
        toastr.error("Vui lòng chọn phường xã");
        return;
    }
    if (memoStreet.GetText().length == 0) {
        toastr.error("Vui lòng nhập số nhà, đường");
        return;
    }

    if (editingData == 1) {
        editingData = 0;
        EditData();
    } else {
        AddData();
    }

    
}

function onCancelClick(s, e) {
    PopupControlStudent.Hide();
    clickAction = 0;
}

function ProvinceSelectedIndexChanged(s, e) {
    idProvince = s.lastSuccessValue;
    if (idProvince != null) {
        idDistrict = null;
        idWard = null;
        comboBoxDistrict.SetValue(null);
        comboBoxWard.SetValue(null);
        LoadDistrict();
    }
    else {
        comboBoxDistrict.SetValue(null);
        comboBoxWard.SetValue(null);
    }
}

function DistrictSelectedIndexChanged(s, e) {
    idDistrict = s.lastSuccessValue;
    if (idDistrict != null) {
        idWard = null;
        comboBoxWard.SetValue(null);
        LoadWard();
    }
    else {
        comboBoxWard.SetValue(null);
    }
}

function ProvinceTextChanged(s, e) {
    var text = comboBoxProvince.GetText();
    var value = comboBoxProvince.FindItemByText(text);
    if (value != null) {
        idProvince = value.value;
    }
    else {
        comboBoxProvince.SetValue(null);
    }
}

function TypeValueChanged(s, e) {
    if (s.lastSuccessValue != null) {
        if (s.lastSuccessValue == 0) {
            activeValue = true;
            gvStudent.PerformCallback({ active: activeValue });
        }
        else {
            activeValue = false;
            gvStudent.PerformCallback({ active: activeValue });
        }

    }
}

function LoadProvince() {

    Loading.Show();
    $.ajax({
        url: "/Student/ComboboxProvincePartital",
        data: {
            
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentProvince").html(data);
                comboBoxProvince.SetValue(idProvince);
                
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

function LoadDistrict() {

    Loading.Show();
    $.ajax({
        url: "/Student/ComboboxDistrictPartital",
        data: {
            province: idProvince
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentDistrict").html(data);
                comboBoxDistrict.SetValue(idDistrict);
                
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

function LoadWard() {

    Loading.Show();
    $.ajax({
        url: "/Student/ComboboxWardPartital",
        data: {
            district: idDistrict
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentWard").html(data);
                comboBoxWard.SetValue(idWard);
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

function AddData() {
    Loading.Show();
    $.ajax({
        url: "/Student/AddData",
        data: {
            studentCode: textBoxCode.GetText(),
            fullName: textBoxFullName.GetText(),
            male: comboBoxMale.GetValue(),
            birthDay: dateEditBirthDay.GetDate().toLocaleDateString("en-GB"),
            phoneNumber: textBoxPhoneNumber.GetText(),
            province: comboBoxProvince.GetValue(),
            district: comboBoxDistrict.GetValue(),
            ward: comboBoxWard.GetValue(),
            street: memoStreet.GetText()
        },
        type: 'POST',
        success: function (data) {
            if (data.status != 0) {
                toastr.error(data.msg);
                Loading.Hide();
                return;
            }
            toastr.success("Thêm thông tin học sinh thành công");
            gvStudent.PerformCallback({});
            PopupControlStudent.Hide();
            Loading.Hide();
            
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
            clickAction = 0;
            Loading.Hide();
            

        }
    });
}

function EditData() {
    
    Loading.Show();
    $.ajax({
        url: "/Student/EditData",
        data: {
            id: idStudent,
            studentCode: textBoxCode.GetText(),
            fullName: textBoxFullName.GetText(),
            male: comboBoxMale.GetValue(),
            birthDay: dateEditBirthDay.GetDate().toLocaleDateString("en-GB"),
            phoneNumber: textBoxPhoneNumber.GetText(),
            province: comboBoxProvince.GetValue(),
            district: comboBoxDistrict.GetValue(),
            ward: comboBoxWard.GetValue(),
            street: memoStreet.GetText()
        },
        type: 'POST',
        success: function (data) {
            if (data.status != 0) {
                toastr.error(data.msg);
                Loading.Hide();
                return;
            }
            toastr.success("Cập nhật thông tin học sinh thành công");
            gvStudent.PerformCallback({});
            PopupControlStudent.Hide();
            Loading.Hide();
            Loading.Hide();

        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
            clickAction = 0;
            Loading.Hide();


        }
    });
}

function RemoveData() {

    Loading.Show();
    $.ajax({
        url: "/Student/RemoveData",
        data: {
            id: idStudent,
            active: activeValue
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentStudent").html(data);

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
        url: "/Student/ActiveData",
        data: {
            id: idStudent,
            active: activeValue
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentStudent").html(data);

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


function OnRowDoubleClick(s, e) {
    onKeyEnterViewStudent();
}

function onKeyEnterViewStudent() {
    var index = gvStudent.GetFocusedRowIndex();
    if (index > -1) {
        gvStudent.GetRowValues(gvStudent.GetFocusedRowIndex(), 'ID;FullName', onKeyEnterAction);
    }
    else {
        toastr.error("Vui lòng chọn học sinh cần xem");
        return;
    }

}

function onKeyEnterAction(values) {
    idStudent = values[0];
    PopupControlHistoryStudent.Show();
    LoadSubClassData();
}

function LoadSubClassData() {
    Loading.Show();
    $.ajax({
        url: "/Student/LoadSubClass",
        data: {
            id: idStudent
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentSubClassHistoryStudent").html(data);

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

function onCancelClickHistoryStudent(s, e) {
    PopupControlHistoryStudent.Hide();
}

function onDownloadTemplateClickImportStudent(s, e) {
   
    DownloadFileTemplateImport();
}

function onDownloadFileOnline(urlFile) {
    var element = document.createElement('a');
    var path = window.location.origin + "" + urlFile;
    element.setAttribute('href', path);

    element.style.display = 'none';
    document.body.appendChild(element);

    element.click();

    document.body.removeChild(element);
}

function onSubmitClickImportStudent(s, e) {

    if (comboBoxGradeImport.GetValue() == null) {
        toastr.error("Vui lòng chọn lớp cần import");
        return;
    }

    var fileUploadCheck = $("#files").get(0);
    var filesCheck = fileUploadCheck.files;
    if (filesCheck.length == 0) {
        toastr.error("Vui lòng chọn tập tin cần import");
        return;
    }

    UploadFiles();
}

function onCancelClickImportStudent(s, e) {
    PopupControlImportStudent.Hide();
}

function onCancelNoticationClick(s, e) {
    PopupControlNotication.Hide();
}

function DownloadFileTemplateImport() {
    Loading.Show();
    $.ajax({
        url: "/Student/DownloadTemplateStudentImport",
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

    var gradeImport = comboBoxGradeImport.GetValue();
    fileData.append("grade", gradeImport);

    $.ajax({
        url: "/Student/UploadFiles",
        type: 'POST',
        contentType: false, // Not to set any content header
        processData: false, // Not to process data
        data: fileData,
        async: true,
        success: function (data) {
            PopupControlImportStudent.Hide();
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

            gvStudent.PerformCallback({ active: activeValue });

            Loading.Hide();

        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);

            Loading.Hide();


        }
    });
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
        url: "/Student/AddGrade",
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

            LoadGradeData();

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

function LoadGradeData() {
    Loading.Show();
    $.ajax({
        url: "/Student/LoadGradeData",
        data: {
            
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentImportGrade").html(data);

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

function CreateGrade() {
    PopupControlAddGrade.Show();
}