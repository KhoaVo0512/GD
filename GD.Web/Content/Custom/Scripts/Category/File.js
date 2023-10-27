var idCourse;
var idTopic;
var idCourseEdit;
var idTopicEdit;
var linkEdit;
var idFile;
var pathFile;
var categoryFile;
var authorFile;
var previewAvatar;
var descriptionFile;
var activeValue = true;
var clickRemoveData = 0;
var clickActiveData = 0;
var clickEditData = 0;

function getExtention(fileName) {
    var i = fileName.lastIndexOf('.');
    if (i === -1) return false;
    return fileName.slice(i);
}

function OnToolbarItemClick(s, e) {
    var index = gvFile.GetFocusedRowIndex();
    if (e.item.name == "AddData") {
        PopupControlImportFile.Show();
        LoadCourse();

    }
    if (e.item.name == "EditData") {
        if (index > -1) {
            clickEditData = 1;
            OnGridFocusedRowChanged(s, e);
        }
        else {
            toastr.error("Vui lòng chọn dữ liệu cần thay đổi");
            return;
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
    }
    if (e.item.name == "ActiveData") {
        if (index > -1) {
            clickActiveData = 1;
            OnGridFocusedRowChanged(s, e);
        }
    }
    if (e.item.name == "AdminDataFile") {
        PopupControlFilterFile.Show();
    }
    
}
function OnGridFocusedRowChanged(s, e) {
    s.GetRowValues(s.GetFocusedRowIndex(), 'ID;Name;Path;CourseId;TopicId;Description;Category;Author;PreviewImage;ApproveBy', OnGetRowValues);
}
function OnGetRowValues(values) {
    idFile = values[0];
    pathFile = values[2];
    idCourseEdit = values[3];
    idTopicEdit = values[4];
    linkEdit = values[5];
    categoryFile = values[6];
    authorFile = values[7];
    previewAvatar = values[8];
    descriptionFile = values[9];

    if (clickEditData == 1) {
        clickEditData = 0;
        
        PopupControlEditImportFile.Show();
        txtNameEditFile.SetText(values[1]);
        txtAuthorEdit.SetText(authorFile);
        mnLinkFileEdit.SetText(values[5]);
        comboBoxCategoryEdit.SetValue(values[6]);
        mnDescriptionFileEdit.SetText(values[9]);
        LoadCourseEdit();
        LoadTopicEdit();
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
    gvFile.PerformCallback({ active: activeValue });
}

function onSubmitClickFilterFile(s, e) {
    PopupControlFilterFile.Hide();
}

function TypeValueChanged(s, e) {
    if (s.lastSuccessValue != null) {
        if (s.lastSuccessValue == 0) {
            activeValue = true;
            gvFile.PerformCallback({ active: activeValue });
        }
        else {
            activeValue = false;
            gvFile.PerformCallback({ active: activeValue });
        }
        
    }
}

function RemoveData() {

    Loading.Show();
    $.ajax({
        url: "/File/RemoveData",
        data: {
            id: idFile,
            path: pathFile,
            category: categoryFile,
            active: activeValue
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentFile").html(data);

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
        url: "/File/ActiveData",
        data: {
            id: idFile,
            active: activeValue
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentFile").html(data);

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

function LoadCourse() {

    Loading.Show();
    $.ajax({
        url: "/File/ComboboxCoursePartital",
        data: {

        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentCourse").html(data);
                comboBoxCourse.SetValue(idCourse);
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


function CourseSelectedIndexChanged(s, e) {
    idCourse = s.lastSuccessValue;
    if (idCourse != null) {
        idTopic = null;
        comboBoxTopic.SetValue(null);
        LoadTopic();
    }
    else {
        comboBoxTopic.SetValue(null);
    }
}

function LoadTopic() {

    Loading.Show();
    $.ajax({
        url: "/File/ComboboxTopicPartital",
        data: {
            course: idCourse
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentTopic").html(data);
                comboBoxTopic.SetValue(idTopic);

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

function onSubmitClickImportFile(s, e) {
    if (txtNameFile.GetText().length == 0) {
        toastr.error("Vui lòng nhập tên");
        return;
    }
    if (txtAuthor.GetText().length == 0) {
        toastr.error("Vui lòng nhập tác giả");
        return;
    }
    if (comboBoxCourse.GetValue() == null) {
        toastr.error("Vui lòng chọn môn học");
        return;
    }
    if (comboBoxTopic.GetValue() == null) {
        toastr.error("Vui lòng chọn chủ đề");
        return;
    }
    if (comboBoxCategory.GetValue() == null) {
        toastr.error("Vui lòng chọn danh mục của tài liệu");
        return;
    }

    if (comboBoxCategory.GetValue() == 2 && txtNameFile.GetText().length > 22) {
        toastr.error("Vui lòng nhập tên không vượt quá 22 ký tự đối vối mẫu giáo án");
        return;
    }

    UploadAvatar();
}

function onCancelClickImportFile(s, e) {
    PopupControlImportFile.Hide();
}

function UploadFiles(urlAvatar) {
    if (urlAvatar != null && urlAvatar != undefined && urlAvatar.length > 0) {
        Loading.Show();
        var fileUpload = $("#files").get(0);
        var files = fileUpload.files;
        // Create FormData object
        var fileData = new FormData();
        // Looping over all files and add it to FormData object
        for (var i = 0; i < files.length; i++) {
            fileData.append(files[i].name, files[i]);
        }
        var nameImport = txtNameFile.GetText();
        var authorImport = txtAuthor.GetText();
        var courseImport = comboBoxCourse.GetValue();
        var topicImport = comboBoxTopic.GetValue();
        var linkImport = mnLinkFile.GetText();
        var noteImport = mnDescriptionFile.GetText();
        var categoryImport = comboBoxCategory.GetValue();
        fileData.append("name", nameImport);
        fileData.append("course", courseImport);
        fileData.append("topic", topicImport);
        fileData.append("link", linkImport);
        fileData.append("description", noteImport);
        fileData.append("category", categoryImport);
        fileData.append("author", authorImport);
        fileData.append("avatar", urlAvatar);
        $.ajax({
            url: "/File/UploadFiles",
            type: 'POST',
            contentType: false, // Not to set any content header
            processData: false, // Not to process data
            data: fileData,
            async: true,
            success: function (data) {
                PopupControlImportFile.Hide();
                $("#files").val(null);

                if (data.status != 0) {

                    PopupControlNotication.Show();
                    var htmlData = "<font> Tải lên không thành công: " + "<br>" + data.msg + "<br>" + "</font>";
                    $("#viewNotication").html(htmlData);
                    Loading.Hide();
                    return;
                }

                PopupControlNotication.Show();
                var htmlData = "<font> Tải lên thành công " + data.count + " tập tin." + "<br>" + data.msg + "<br>" + "</font>";
                $("#viewNotication").html(htmlData);

                gvFile.PerformCallback({});

                Loading.Hide();

            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(xhr.status);
                alert(thrownError);

                Loading.Hide();


            }
        });
    }
    else {
        toastr.error("Chưa tồn tại hình ảnh đại diện");
        return;
    }
    
}

function onCancelNoticationClick(s, e) {
    PopupControlNotication.Hide();
}

function UploadAvatar() {
    Loading.Show();
    var avatarUpload = $("#preview-avatar").get(0);
    var avatars = avatarUpload.files;
    // Create FormData object
    var avatarData = new FormData();
    // Looping over all files and add it to FormData object
    for (var i = 0; i < avatars.length; i++) {
        avatarData.append(avatars[i].name, avatars[i]);
    }
    
    $.ajax({
        url: "/File/UploadAvatar",
        type: 'POST',
        contentType: false, // Not to set any content header
        processData: false, // Not to process data
        data: avatarData,
        async: true,
        success: function (data) {
            //PopupControlImportFile.Hide();
            $("#preview-avatar").val(null);

            if (data.status != 0) {

                toastr.error(data.msg);
                Loading.Hide();
                return;
            }

            UploadFiles(data.url);

            Loading.Hide();

        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);

            Loading.Hide();


        }
    });
}

function UploadAvatarEdit() {
    Loading.Show();
    var avatarUpload = $("#preview-avatar-edit").get(0);
    var avatars = avatarUpload.files;
    // Create FormData object
    var avatarData = new FormData();
    // Looping over all files and add it to FormData object
    for (var i = 0; i < avatars.length; i++) {
        avatarData.append(avatars[i].name, avatars[i]);
    }

    $.ajax({
        url: "/File/UploadAvatar",
        type: 'POST',
        contentType: false, // Not to set any content header
        processData: false, // Not to process data
        data: avatarData,
        async: true,
        success: function (data) {
            //PopupControlImportFile.Hide();
            $("#preview-avatar-edit").val(null);

            if (data.status != 0) {

                toastr.error(data.msg);
                Loading.Hide();
                return;
            }

            UpdateData(data.url);

            Loading.Hide();

        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);

            Loading.Hide();


        }
    });
}


//edit

function LoadCourseEdit() {

    Loading.Show();
    $.ajax({
        url: "/File/ComboboxCourseEditPartital",
        data: {

        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentCourseEdit").html(data);
                comboBoxCourseEdit.SetValue(idCourseEdit);
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


function CourseEditSelectedIndexChanged(s, e) {
    idCourseEdit = s.lastSuccessValue;
    if (idCourseEdit != null) {
        idTopic = null;
        comboBoxTopicEdit.SetValue(null);
        LoadTopicEdit();
    }
    else {
        comboBoxTopicEdit.SetValue(null);
    }
}

function LoadTopicEdit() {

    Loading.Show();
    $.ajax({
        url: "/File/ComboboxTopicEditPartital",
        data: {
            course: idCourseEdit
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentTopicEdit").html(data);
                comboBoxTopicEdit.SetValue(idTopicEdit);

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

function onSubmitClickEditImportFile(s, e) {
    if (txtNameEditFile.GetText().length == 0) {
        toastr.error("Vui lòng nhập tên");
        return;
    }
    if (txtAuthorEdit.GetText().length == 0) {
        toastr.error("Vui lòng nhập tác giả");
        return;
    }
    if (comboBoxCourseEdit.GetValue() == null) {
        toastr.error("Vui lòng chọn môn học");
        return;
    }
    if (comboBoxTopicEdit.GetValue() == null) {
        toastr.error("Vui lòng chọn chủ đề");
        return;
    }
    if (comboBoxCategoryEdit.GetValue() == null) {
        toastr.error("Vui lòng chọn danh mục của tài liệu");
        return;
    }

    var avatarUpload = $("#preview-avatar-edit").get(0);
    var avatarsEdit = avatarUpload.files;

    if (avatarsEdit.length == 0) {
        UpdateData("");
    }
    else {
        UploadAvatarEdit();
    }
    

}

function onCancelClickEditImportFile(s, e) {
    PopupControlEditImportFile.Hide();
}

function UpdateData(urlAvatar) {
    if ((urlAvatar != null && urlAvatar != undefined && urlAvatar.length > 0) || (previewAvatar != null && previewAvatar != undefined && previewAvatar.length > 0)) {
        Loading.Show();
        $.ajax({
            url: "/File/UpdateData",
            data: {
                id: idFile,
                name: txtNameEditFile.GetText(),
                author: txtAuthorEdit.GetText(),
                course: comboBoxCourseEdit.GetValue(),
                topic: comboBoxTopicEdit.GetValue(),
                link: mnLinkFileEdit.GetText(),
                description: mnDescriptionFileEdit.GetText(),
                category: comboBoxCategoryEdit.GetValue(),
                avatar: urlAvatar
            },
            type: 'POST',
            success: function (data) {
                if (data.status != 0) {
                    toastr.error(data.msg);
                    Loading.Hide();
                    return;
                }
                PopupControlEditImportFile.Hide();
                toastr.success("Cập nhật thành công");
                gvFile.PerformCallback({ active: activeValue });

                Loading.Hide();
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(xhr.status);
                alert(thrownError);

                Loading.Hide();

            }
        });
    }
    else {
        toastr.error("Chưa tồn tại hình ảnh đại diện");
        return;
    }
}
