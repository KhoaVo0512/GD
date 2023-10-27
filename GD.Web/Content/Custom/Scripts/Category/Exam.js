var idExam;
var activeValueExam = true;
var clickEditDataExam = 0;
var clickRemoveDataExam = 0;
var clickActiveDataExam = 0;
var finishAddExam = false;

function CreateExam() {
    finishAddExam = false;
    ResetValueControl();
    $('#add-exam').modal('show');

}

function ResetValueControl() {
    comboBoxCourseAddExam.SetValue(null);
    comboBoxTopicAddExam.SetValue(null);
    textBoxName.SetText(null);
    spinEditNumberTest.SetValue(null);
    document.getElementById("header-library-question").style.display = "none";
    document.getElementById("IdExamAdd").value = "";
}

function onChangeFilterType() {

    gvExam.PerformCallback({
        active: true,
        course: comboBoxCourseFilter.GetValue() == null ? 0 : comboBoxCourseFilter.GetValue(),
        topic: comboBoxTopicExamFilter.GetValue() == null ? 0 : comboBoxTopicExamFilter.GetValue(),
        filter: $('#filter-type-exam').is(":checked")
    });
}

function OnToolbarItemExamClick(s, e) {
    var index = gvExam.GetFocusedRowIndex();

    if (e.item.name == "EditData") {
        if (index > -1) {
            clickEditDataExam = 1;
            OnGridFocusedRowChangedExam(s, e);
        }
        else {
            toastr.error("Vui lòng chọn bộ đề cần thao tác");
            return;
        }
    }

    if (e.item.name == "RemoveData") {
        if (index > -1) {
            var result = confirm("Dữ liệu sẽ mất không thể khôi phục, bạn có chắc chắn muốn xóa?");
            if (result) {
                clickRemoveDataExam = 1;
                OnGridFocusedRowChangedExam(s, e);
            }
        }
        else {
            toastr.error("Vui lòng chọn bộ đề cần thao tác");
            return;
        }
    }
    if (e.item.name == "ActiveData") {
        if (index > -1) {
            clickActiveDataExam = 1;
            OnGridFocusedRowChangedExam(s, e);
        }
        else {
            toastr.error("Vui lòng chọn bộ đề cần thao tác");
            return;
        }
    }
    if (e.item.name == "AdminDataExam") {
        PopupControlFilterExam.Show();
    }

    if (e.item.name == "ImportData") {
        PopupControlImportExam.Show();
    }

}

function OnGridFocusedRowChangedExam(s, e) {
    s.GetRowValues(s.GetFocusedRowIndex(), 'ID;Name;TopicId;NumberTest;Time;View', OnGetRowValuesExam);
}

function OnGetRowValuesExam(values) {
    idExam = values[0];
    if (clickEditDataExam == 1) {
        clickEditDataExam = 0;
        if (idExam == null) {
            toastr.error("Dữ liệu chưa được tải xong");
            return;
        }
        $('#edit-exam').modal('show');
        LoadCourseEditByTopic(values[2]);
        textBoxNameEdit.SetText(values[1]);
        spinEditNumberTimeEdit.SetValue(values[4]);
        spinEditNumberTestEdit.SetValue(values[3]);
        if (values[5] != null && values[5].length > 0) {
            var arraryView = values[5].split(',');
            checkBoxListViewEditExam.SelectValues(arraryView);
        }
    }
    if (clickRemoveDataExam == 1) {
        RemoveDataExam();
    }
    if (clickActiveDataExam == 1) {
        ActiveDataExam();
    }
}

function CFOnBeginCallBackExam(s, e) {
    e.customArgs["active"] = activeValueExam;
    e.customArgs["course"] = comboBoxCourseFilter.GetValue() == null ? 0 : comboBoxCourseFilter.GetValue();
    e.customArgs["filter"] = $('#filter-type-exam').is(":checked");
    e.customArgs["topic"] = comboBoxTopicExamFilter.GetValue() == null ? 0 : comboBoxTopicExamFilter.GetValue();
}

function CFInitGridviewExam(s, e) {
    gvExam.PerformCallback({
        active: activeValueExam,
        course: comboBoxCourseFilter.GetValue() == null ? 0 : comboBoxCourseFilter.GetValue(),
        topic: comboBoxTopicExamFilter.GetValue() == null ? 0 : comboBoxTopicExamFilter.GetValue(),
        filter: $('#filter-type-exam').is(":checked")
    });
}

function RemoveDataExam() {

    Loading.Show();
    $.ajax({
        url: "/Exam/RemoveDataExam",
        data: {
            id: idExam,
            course: comboBoxCourseFilter.GetValue() == null ? 0 : comboBoxCourseFilter.GetValue(),
            active: activeValueExam,
            filter: $('#filter-type-exam').is(":checked"),
            topic: comboBoxTopicExamFilter.GetValue() == null ? 0 : comboBoxTopicExamFilter.GetValue(),
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentExam").html(data);

            }
            clickRemoveDataExam = 0;
            Loading.Hide();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
            clickRemoveDataExam = 0;
            Loading.Hide();

        }
    });
}

function ActiveDataExam() {

    Loading.Show();
    $.ajax({
        url: "/Exam/ActiveDataExam",
        data: {
            id: idExam,
            course: comboBoxCourseFilter.GetValue() == null ? 0 : comboBoxCourseFilter.GetValue(),
            active: activeValueExam,
            filter: $('#filter-type-exam').is(":checked"),
            topic: comboBoxTopicExamFilter.GetValue() == null ? 0 : comboBoxTopicExamFilter.GetValue(),
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentExam").html(data);

            }
            clickActiveDataExam = 0;
            Loading.Hide();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
            clickActiveDataExam = 0;
            Loading.Hide();

        }
    });
}

function onSubmitClickFilterExam(s, e) {
    PopupControlFilterExam.Hide();
}

function TypeExamValueChanged(s, e) {
    if (s.lastSuccessValue != null) {

        if (s.lastSuccessValue == 0) {
            activeValueExam = true;
            gvExam.PerformCallback({
                active: activeValueExam,
                course: comboBoxCourseFilter.GetValue() == null ? 0 : comboBoxCourseFilter.GetValue(),
                topic: comboBoxTopicExamFilter.GetValue() == null ? 0 : comboBoxTopicExamFilter.GetValue(),
                filter: $('#filter-type-exam').is(":checked")
            });
        }
        else {
            activeValueExam = false;
            gvExam.PerformCallback({
                active: activeValueExam,
                course: comboBoxCourseFilter.GetValue() == null ? 0 : comboBoxCourseFilter.GetValue(),
                topic: comboBoxTopicExamFilter.GetValue() == null ? 0 : comboBoxTopicExamFilter.GetValue(),
                filter: $('#filter-type-exam').is(":checked")
            });
        }
    }
}

function CourseAddExamSelectedIndexChanged(s, e) {
    if (s.lastSuccessValue == null) {
        toastr.error("Vui lòng chọn môn học");
        return;
    }
    document.getElementById("header-library-question").style.display = "none";
    LoadTopicAddExam();
}

function LoadTopicAddExam() {

    Loading.Show();
    $.ajax({
        url: "/Exam/ComboboxTopicAddExamPartital",
        data: {
            course: comboBoxCourseAddExam.GetValue()
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentTopicAddExam").html(data);
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

//cau truc cau hoi
function CFOnBeginCallBackExamLevel(s, e) {
    e.customArgs["exam"] = document.getElementById("IdExamAdd").value == null ? 0 : Number(document.getElementById("IdExamAdd").value);
    e.customArgs["course"] = comboBoxCourseAddExam.GetValue() == null ? 0 : comboBoxCourseAddExam.GetValue();
    e.customArgs["topic"] = comboBoxTopicAddExam.GetValue() == null ? 0 : comboBoxTopicAddExam.GetValue();
}

function CFInitGridviewExamLevel(s, e) {
    gvExamLevel.PerformCallback({
        exam: document.getElementById("IdExamAdd").value == null ? 0 : Number(document.getElementById("IdExamAdd").value),
        course: comboBoxCourseAddExam.GetValue() == null ? 0 : comboBoxCourseAddExam.GetValue(),
        topic: comboBoxTopicAddExam.GetValue() == null ? 0 : comboBoxTopicAddExam.GetValue()
    });
}

function OnGridFocusedRowChangedExamLevel(s, e) {
    s.GetRowValues(s.GetFocusedRowIndex(), 'ID;Number', OnGetRowValuesExamLevel);
}

function OnGetRowValuesExamLevel(values) {
   
}

function OnToolbarItemExamLevelClick(s, e) {
    var index = gvExamLevel.GetFocusedRowIndex();
}

function TopicAddExamSelectedIndexChanged(s, e) {
   
    if (s.lastSuccessValue != null) {
        if (comboBoxCourseAddExam.GetValue() != null) {
            if (document.getElementById("IdExamAdd").value == null || document.getElementById("IdExamAdd").value.toString().length == 0) {
                CreateExamDataDefault();
            }
            else {
                LoadLibraryQuestion();
            }
        }
        else {
            document.getElementById("header-library-question").style.display = "none";
            toastr.error("Vui lòng chọn môn học");
            return;
        }
    }
    else {
        document.getElementById("header-library-question").style.display = "none";
        toastr.error("Vui lòng chọn chủ đề");
        return;
    }
}

function CreateExamDataDefault() {
    Loading.Show();
    $.ajax({
        url: "/Exam/CreateExamDefault",
        data: {
            course: comboBoxCourseAddExam.GetValue(),
            topic: comboBoxTopicAddExam.GetValue()
        },
        type: 'POST',
        success: function (data) {
            if (data.status != 0) {
                toastr.error(data.msg);
                Loading.Hide();
                return;
            }

            document.getElementById("IdExamAdd").value = data.id;

            console.log(document.getElementById("IdExamAdd").value);

            LoadLibraryQuestion();

            Loading.Hide();

        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
            Loading.Hide();


        }
    });
}

function DeleteExamDataDefault() {
    Loading.Show();
    $.ajax({
        url: "/Exam/DeleteExamDefault",
        data: {
            id: document.getElementById("IdExamAdd").value
        },
        type: 'POST',
        success: function (data) {
            if (data.status != 0) {
                toastr.error(data.msg);
                Loading.Hide();
                return;
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

function ListSourceAddExamValueChanged(s, e) {
    LoadLibraryQuestion();
}

function LoadLibraryQuestion() {

    Loading.Show();
    $.ajax({
        url: "/Exam/LoadLibraryQuestion",
        data: {
            course: comboBoxCourseAddExam.GetValue(),
            topic: comboBoxTopicAddExam.GetValue(),
            by: radioButtonListSourceAddExam.GetValue()
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {
                document.getElementById("header-library-question").style.display = "none";
            }
            else {
                document.getElementById("header-library-question").style.display = "block";
                $("#content-library-question").html(data);
            }

            Loading.Hide();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
            document.getElementById("header-library-question").style.display = "none";
            Loading.Hide();

        }
    });
}

function CreateExamSubmit() {
    //console.log(checkBoxListViewAddExam.GetSelectedValues());
    
    if (comboBoxCourseAddExam.GetValue() == null) {
        toastr.error("Vui lòng chọn môn học");
        return;
    }

    if (comboBoxTopicAddExam.GetValue() == null) {
        toastr.error("Vui lòng chọn môn học");
        return;
    }

    if (textBoxName.GetText().length == 0) {
        toastr.error("Vui lòng nhập tên bộ đề");
        return;
    }

    if (spinEditNumberTest.GetValue() == null) {
        toastr.error("Vui lòng nhập số lượng tạo đề con");
        return;
    }

    if (spinEditNumberTime.GetValue() == null) {
        toastr.error("Vui lòng nhập thời gian làm bài");
        return;
    }

    if (checkBoxListViewAddExam.GetSelectedValues().length == 0) {
        toastr.error("Vui lòng chọn ít nhất một chế độ hiển thị");
        return;
    }

    if (document.getElementById("IdExamAdd").value == null || document.getElementById("IdExamAdd").value.toString().length == 0) {
        toastr.error("Dữ liệu tạo bộ đề chưa đúng");
        return;
    }
    
    Loading.Show();
    $.ajax({
        url: "/Exam/AddExam",
        data: {
            id: document.getElementById("IdExamAdd").value,
            course: comboBoxCourseAddExam.GetValue(),
            topic: comboBoxTopicAddExam.GetValue(),
            name: textBoxName.GetText(),
            number: spinEditNumberTest.GetValue(),
            time: spinEditNumberTime.GetValue(),
            view: checkBoxListViewAddExam.GetSelectedValues().toString()
        },
        type: 'POST',
        success: function (data) {
            if (data.status != 0) {
                toastr.error(data.msg);
                Loading.Hide();
                return;
            }
            finishAddExam = true;
            $('#add-exam').modal('hide');

            toastr.success("Tạo bộ đề thành công");

            gvExam.PerformCallback({
                active: activeValueExam,
                course: comboBoxCourseFilter.GetValue() == null ? 0 : comboBoxCourseFilter.GetValue(),
                topic: comboBoxTopicExamFilter.GetValue() == null ? 0 : comboBoxTopicExamFilter.GetValue(),
                filter: $('#filter-type-exam').is(":checked")
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

function OnRowDoubleClickExam(s, e) {
    var index = gvExam.GetFocusedRowIndex();
    if (index > -1) {
        gvExam.GetRowValues(gvExam.GetFocusedRowIndex(), 'ID;Name', onDoubleClickAction);
    }
    else {
        toastr.error("Vui lòng chọn bộ đề cần xem");
        return;
    }
}

function onDoubleClickAction(values) {
    if (comboBoxCourseFilter.GetValue() == null) {
        toastr.error("Vui lòng chọn môn học");
        return;
    }
    idExam = values[0];
    $('#view-test').modal('show');
    LoadTestData();
}

function LoadTestData() {

    Loading.Show();
    $.ajax({
        url: "/Exam/LoadTestByExam",
        data: {
            id: idExam,
            course: comboBoxCourseFilter.GetValue()
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#content-detail-viewtest").html(data);

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

function RemoveTest(test, idExam) {
    if (idExam == null) {
        toastr.error("Dữ liệu không đúng vui lòng kiểm tra lại");
        return;
    }
    Loading.Show();
    $.ajax({
        url: "/Exam/RemoveTest",
        data: {
            id: test,
            exam: idExam
        },
        type: 'POST',
        success: function (data) {
            if (data.status != 0) {
                toastr.error(data.msg);
                Loading.Hide();
                return;
            }

            toastr.success("Xóa đề thi thành công");

            LoadTestData();

            gvExam.PerformCallback({
                active: true,
                course: comboBoxCourseFilter.GetValue() == null ? 0 : comboBoxCourseFilter.GetValue(),
                topic: comboBoxTopicExamFilter.GetValue() == null ? 0 : comboBoxTopicExamFilter.GetValue(),
                filter: $('#filter-type-exam').is(":checked")
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

function ViewQuestionByTest(test) {
    /*
    $('#view-question-test').modal('show');
    LoadQuestionByTest(test);
    */

    var completeLink = window.location.origin + "/Exam/PreViewPrint?id=" + test;
    console.log(completeLink);
    window.open = (completeLink, '_blank');
}

function LoadQuestionByTest(test) {

    Loading.Show();
    $.ajax({
        url: "/Exam/LoadQuestionByTest",
        data: {
            id: Number(test)
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#content-detail-viewquestion").html(data);

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

//cau truc cau hoi edit
function CFOnBeginCallBackExamLevelEdit(s, e) {
    e.customArgs["exam"] = idExam == null ? 0 : idExam;
    e.customArgs["course"] = comboBoxCourseEditExam.GetValue() == null ? 0 : comboBoxCourseEditExam.GetValue();
    e.customArgs["topic"] = comboBoxTopicEditExam.GetValue() == null ? 0 : comboBoxTopicEditExam.GetValue();
}

function CFInitGridviewExamLevelEdit(s, e) {
    gvExamLevelEdit.PerformCallback({
        exam: idExam == null ? 0 : idExam,
        course: comboBoxCourseEditExam.GetValue() == null ? 0 : comboBoxCourseEditExam.GetValue(),
        topic: comboBoxTopicEditExam.GetValue() == null ? 0 : comboBoxTopicEditExam.GetValue()
    });
}

function OnGridFocusedRowChangedExamLevelEdit(s, e) {
    s.GetRowValues(s.GetFocusedRowIndex(), 'ID;Number', OnGetRowValuesExamLevelEdit);
}

function OnGetRowValuesExamLevelEdit(values) {

}

function OnToolbarItemExamLevelEditClick(s, e) {
    var index = gvExamLevelEdit.GetFocusedRowIndex();
}

function CourseEditExamSelectedIndexChanged(s, e) {
    if (s.lastSuccessValue == null) {
        toastr.error("Vui lòng chọn môn học");
        return;
    }
    document.getElementById("header-library-question-edit").style.display = "none";
    LoadTopicEditExam();
}

function LoadTopicEditExamDefault(topic, courseData) {

    Loading.Show();
    $.ajax({
        url: "/Exam/ComboboxTopicEditExamPartital",
        data: {
            course: courseData
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentTopicEditExam").html(data);
                comboBoxTopicEditExam.SetValue(topic);
                LoadLibraryQuestionEditDefault(courseData, topic);
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

function LoadTopicEditExam() {

    Loading.Show();
    $.ajax({
        url: "/Exam/ComboboxTopicEditExamPartital",
        data: {
            course: comboBoxCourseEditExam.GetValue()
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentTopicEditExam").html(data);
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

function TopicEditExamSelectedIndexChanged(s, e) {

    if (s.lastSuccessValue != null) {
        if (comboBoxCourseEditExam.GetValue() != null) {
            LoadLibraryQuestionEdit();
        }
        else {
            document.getElementById("header-library-question-edit").style.display = "none";
            toastr.error("Vui lòng chọn môn học");
            return;
        }
    }
    else {
        document.getElementById("header-library-question-edit").style.display = "none";
        toastr.error("Vui lòng chọn chủ đề");
        return;
    }
}

function ListSourceEditExamValueChanged(s, e) {
    LoadLibraryQuestionEdit();
}

function LoadLibraryQuestionEditDefault(courseData, topicData) {

    Loading.Show();
    $.ajax({
        url: "/Exam/LoadLibraryQuestion",
        data: {
            course: courseData,
            topic: topicData,
            by: radioButtonListSourceEditExam.GetValue()
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {
                document.getElementById("header-library-question-edit").style.display = "none";
            }
            else {
                document.getElementById("header-library-question-edit").style.display = "block";
                $("#content-library-question-edit").html(data);
            }

            Loading.Hide();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
            document.getElementById("header-library-question-edit").style.display = "none";
            Loading.Hide();

        }
    });
}

function LoadLibraryQuestionEdit() {

    Loading.Show();
    $.ajax({
        url: "/Exam/LoadLibraryQuestion",
        data: {
            course: comboBoxCourseEditExam.GetValue(),
            topic: comboBoxTopicEditExam.GetValue(),
            by: radioButtonListSourceEditExam.GetValue()
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {
                document.getElementById("header-library-question-edit").style.display = "none";
            }
            else {
                document.getElementById("header-library-question-edit").style.display = "block";
                $("#content-library-question-edit").html(data);
            }

            Loading.Hide();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
            document.getElementById("header-library-question-edit").style.display = "none";
            Loading.Hide();

        }
    });
}

function LoadCourseEditByTopic(topicData) {
    Loading.Show();
    $.ajax({
        url: "/Exam/LoadCourseEditByTopic",
        data: {
            topic: topicData
        },
        type: 'POST',
        success: function (data) {
            if (data.status != 0) {
                toastr.error(data.msg);
                Loading.Hide();
                return;
            }

            comboBoxCourseEditExam.SetValue(data.id);
            LoadTopicEditExamDefault(topicData, data.id);

            Loading.Hide();

        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
            Loading.Hide();


        }
    });
}

function EditExamSubmit() {
    //console.log(checkBoxListViewEditExam.GetSelectedValues());

    if (comboBoxCourseEditExam.GetValue() == null) {
        toastr.error("Vui lòng chọn môn học");
        return;
    }

    if (comboBoxTopicEditExam.GetValue() == null) {
        toastr.error("Vui lòng chọn môn học");
        return;
    }

    if (textBoxNameEdit.GetText().length == 0) {
        toastr.error("Vui lòng nhập tên bộ đề");
        return;
    }

    if (spinEditNumberTestEdit.GetValue() == null) {
        toastr.error("Vui lòng nhập số lượng tạo đề con");
        return;
    }

    if (spinEditNumberTimeEdit.GetValue() == null) {
        toastr.error("Vui lòng nhập thời gian làm bài");
        return;
    }

    if (checkBoxListViewEditExam.GetSelectedValues().length == 0) {
        toastr.error("Vui lòng chọn ít nhất một chế độ hiển thị");
        return;
    }

    if (idExam == null) {
        toastr.error("Dữ liệu tạo bộ đề chưa đúng");
        return;
    }

    Loading.Show();
    $.ajax({
        url: "/Exam/EditExam",
        data: {
            id: idExam,
            course: comboBoxCourseEditExam.GetValue(),
            topic: comboBoxTopicEditExam.GetValue(),
            name: textBoxNameEdit.GetText(),
            number: spinEditNumberTestEdit.GetValue(),
            time: spinEditNumberTimeEdit.GetValue(),
            view: checkBoxListViewEditExam.GetSelectedValues().toString()
        },
        type: 'POST',
        success: function (data) {
            if (data.status != 0) {
                toastr.error(data.msg);
                Loading.Hide();
                return;
            }

            $('#edit-exam').modal('hide');

            toastr.success("Sửa bộ đề thành công");

            gvExam.PerformCallback({
                active: activeValueExam,
                course: comboBoxCourseFilter.GetValue() == null ? 0 : comboBoxCourseFilter.GetValue(),
                topic: comboBoxTopicExamFilter.GetValue() == null ? 0 : comboBoxTopicExamFilter.GetValue(),
                filter: $('#filter-type-exam').is(":checked")
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