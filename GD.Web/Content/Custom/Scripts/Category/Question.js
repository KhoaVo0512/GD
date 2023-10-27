var idLibraryQuestion;
var activeValueLibraryQuestion = true;
var clickRemoveDataLibraryQuestion = 0;
var clickActiveDataLibraryQuestion = 0;

//cau tra loi
var numberAnswerAddShow = 2;
var showAnswerOneAdd = true;
var showAnswerTwoAdd = true;
var showAnswerThreeAdd = false;
var showAnswerFourAdd  = false;
var showAnswerFiveAdd  = false;
var showAnswerSixAdd  = false;
var showAnswerSevenAdd = false;
var showAnswerEightAdd = false;

function CreateQuestion() {
    ResetValueControl();
    $('#add-question').modal('show');
}

function onChangeFilterType() {

    gvLibraryQuestion.PerformCallback({
        active: activeValueLibraryQuestion,
        course: comboBoxCourseFilter.GetValue() == null ? 0 : comboBoxCourseFilter.GetValue(),
        topic: comboBoxTopicQuestionFilter.GetValue() == null ? 0 : comboBoxTopicQuestionFilter.GetValue(),
        filter: $('#filter-type-question').is(":checked")
    });
}

function OnRowDoubleClickLibraryQuestion(s, e) {
    onKeyEnterViewQuestion();
}

function OnToolbarItemLibraryQuestionClick(s, e) {
    var index = gvLibraryQuestion.GetFocusedRowIndex();
    
    if (e.item.name == "RemoveData") {
        if (index > -1) {
            var result = confirm("Dữ liệu sẽ mất không thể khôi phục, bạn có chắc chắn muốn xóa?");
            if (result) {
                clickRemoveDataLibraryQuestion = 1;
                OnGridFocusedRowChangedLibraryQuestion(s, e);
            }
        }
        else {
            toastr.error("Vui lòng chọn câu hỏi cần thao tác");
            return;
        }
    }
    if (e.item.name == "ActiveData") {
        if (index > -1) {
            clickActiveDataLibraryQuestion = 1;
            OnGridFocusedRowChangedLibraryQuestion(s, e);
        }
        else {
            toastr.error("Vui lòng chọn câu hỏi cần thao tác");
            return;
        }
    }
    if (e.item.name == "AdminDataQuestion") {
        PopupControlFilterLibraryQuestion.Show();
    }

    if (e.item.name == "ImportData") {
        PopupControlImportQuestion.Show();
    }

}

function OnGridFocusedRowChangedLibraryQuestion(s, e) {
    s.GetRowValues(s.GetFocusedRowIndex(), 'ID;Name', OnGetRowValuesLibraryQuestion);
}

function OnGetRowValuesLibraryQuestion(values) {
    idLibraryQuestion = values[0];
    if (clickRemoveDataLibraryQuestion == 1) {
        RemoveDataLibraryQuestion();
    }
    if (clickActiveDataLibraryQuestion == 1) {
        ActiveDataLibraryQuestion();
    }
}

function CFOnBeginCallBackLibraryQuestion(s, e) {
    e.customArgs["active"] = activeValueLibraryQuestion;
    e.customArgs["course"] = comboBoxCourseFilter.GetValue() == null ? 0 : comboBoxCourseFilter.GetValue();
    e.customArgs["filter"] = $('#filter-type-question').is(":checked");
    e.customArgs["topic"] = comboBoxTopicQuestionFilter.GetValue() == null ? 0 : comboBoxTopicQuestionFilter.GetValue();
}

function CFInitGridviewLibraryQuestion(s, e) {
    gvLibraryQuestion.PerformCallback({
        active: activeValueLibraryQuestion,
        course: comboBoxCourseFilter.GetValue() == null ? 0 : comboBoxCourseFilter.GetValue(),
        topic: comboBoxTopicQuestionFilter.GetValue() == null ? 0 : comboBoxTopicQuestionFilter.GetValue(),
        filter: $('#filter-type-question').is(":checked")
    });
}

function RemoveDataLibraryQuestion() {

    Loading.Show();
    $.ajax({
        url: "/Question/RemoveDataLibraryQuestion",
        data: {
            id: idLibraryQuestion,
            course: comboBoxCourseFilter.GetValue() == null ? 0 : comboBoxCourseFilter.GetValue(),
            active: activeValueLibraryQuestion,
            filter: $('#filter-type-question').is(":checked"),
            topic: comboBoxTopicQuestionFilter.GetValue() == null ? 0 : comboBoxTopicQuestionFilter.GetValue(),
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentLibraryQuestion").html(data);

            }
            clickRemoveDataLibraryQuestion = 0;
            Loading.Hide();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
            clickRemoveDataLibraryQuestion = 0;
            Loading.Hide();

        }
    });
}

function ActiveDataLibraryQuestion() {

    Loading.Show();
    $.ajax({
        url: "/Question/ActiveDataLibraryQuestion",
        data: {
            id: idLibraryQuestion,
            course: comboBoxCourseFilter.GetValue() == null ? 0 : comboBoxCourseFilter.GetValue(),
            active: activeValueLibraryQuestion,
            filter: $('#filter-type-question').is(":checked"),
            topic: comboBoxTopicQuestionFilter.GetValue() == null ? 0 : comboBoxTopicQuestionFilter.GetValue(),
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentLibraryQuestion").html(data);

            }
            clickActiveDataLibraryQuestion = 0;
            Loading.Hide();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
            clickActiveDataLibraryQuestion = 0;
            Loading.Hide();

        }
    });
}

function onSubmitClickFilterLibraryQuestion(s, e) {
    PopupControlFilterLibraryQuestion.Hide();
}

function TypeLibraryQuestionValueChanged(s, e) {
    if (s.lastSuccessValue != null) {

        if (s.lastSuccessValue == 0) {
            activeValueLibraryQuestion = true;
            gvLibraryQuestion.PerformCallback({
                active: activeValueLibraryQuestion,
                course: comboBoxCourseFilter.GetValue() == null ? 0 : comboBoxCourseFilter.GetValue(),
                topic: comboBoxTopicQuestionFilter.GetValue() == null ? 0 : comboBoxTopicQuestionFilter.GetValue(),
                filter: $('#filter-type-question').is(":checked")
            });
        }
        else {
            activeValueLibraryQuestion = false;
            gvLibraryQuestion.PerformCallback({
                active: activeValueLibraryQuestion,
                course: comboBoxCourseFilter.GetValue() == null ? 0 : comboBoxCourseFilter.GetValue(),
                topic: comboBoxTopicQuestionFilter.GetValue() == null ? 0 : comboBoxTopicQuestionFilter.GetValue(),
                filter: $('#filter-type-question').is(":checked")
            });
        }
    }
}
//ket thuc thu vien

function CourseAddQuestionSelectedIndexChanged(s, e) {
    if (s.lastSuccessValue == null) {
        toastr.error("Vui lòng chọn môn học");
        return;
    }
    LoadTopicAddQuestion();
}

function TypeAddQuestionSelectedIndexChanged(s, e) {
    if (comboBoxTypeAddQuestion.GetValue() == null) {
        toastr.error("Vui lòng chọn loại câu hỏi");
        return;
    }
    LoadLevelAddQuestion();
    CheckTypeQuestion();
}

function CheckTypeQuestion() {
    Loading.Show();
    $.ajax({
        url: "/Question/CheckTypeQuestion",
        data: {
            id: comboBoxTypeAddQuestion.GetValue()
        },
        type: 'POST',
        success: function (data) {
            if (data.status != 0) {
                toastr.error(data.msg);
                Loading.Hide();
                return;
            }

            if (data.choice == 1) {
                document.getElementById("content-manyanswer-addquestion").style.display = "block";
                document.getElementById("content-answer-addquestion").style.display = "block";
                document.getElementById("content-linenumber-addquestion").style.display = "none";
                document.getElementById("content-answerone-addquestion").style.display = "block";
                document.getElementById("content-answertwo-addquestion").style.display = "block";
                //console.log(document.getElementById("content-linenumber-addquestion").style.display);
                comboBoxManyAnswerAddQuestion.SetValue(0);
                spinEditLineNumberAddQuestion.SetValue(0);
            }
            else {
                document.getElementById("content-manyanswer-addquestion").style.display = "none";
                document.getElementById("content-answer-addquestion").style.display = "none";
                document.getElementById("content-linenumber-addquestion").style.display = "block";
                document.getElementById("content-answerone-addquestion").style.display = "none";
                document.getElementById("content-answertwo-addquestion").style.display = "none";
                comboBoxManyAnswerAddQuestion.SetValue(0);
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

function LoadTopicAddQuestion() {

    Loading.Show();
    $.ajax({
        url: "/Question/ComboboxTopicAddQuestionPartital",
        data: {
            course: comboBoxCourseAddQuestion.GetValue()
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentTopicAddQuestion").html(data);
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

function LoadLevelAddQuestion() {

    Loading.Show();
    $.ajax({
        url: "/Question/ComboboxLevelAddQuestionPartital",
        data: {
            type: comboBoxTypeAddQuestion.GetValue()
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentLevelAddQuestion").html(data);
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


function LoadLevelEditQuestionDefault(typeData, levelData) {

    Loading.Show();
    $.ajax({
        url: "/Question/ComboboxLevelEditQuestionPartital",
        data: {
            type: typeData
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentLevelEditQuestion").html(data);

                //set level
                comboBoxLevelEditQuestion.SetValue(levelData);
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

function LoadLevelEditQuestion() {

    Loading.Show();
    $.ajax({
        url: "/Question/ComboboxLevelEditQuestionPartital",
        data: {
            type: comboBoxTypeEditQuestion.GetValue()
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentLevelEditQuestion").html(data);
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

//tat cau tra loi

function AddAnswerOneAddQuestion() {
    if (numberAnswerAddShow > 7) {
        toastr.error("Chỉ có thể thêm tối đa 8 câu trả lời");
        return;
    }
    numberAnswerAddShow++;
    if (showAnswerOneAdd == false) {
        document.getElementById("content-answerone-addquestion").style.display = "block";
        showAnswerOneAdd = true;
        toastr.success("Thêm phần nhập đáp án thành công");
        return;
    }

    if (showAnswerTwoAdd == false) {
        document.getElementById("content-answertwo-addquestion").style.display = "block";
        showAnswerTwoAdd = true;
        toastr.success("Thêm phần nhập đáp án thành công");
        return;
    }

    if (showAnswerThreeAdd == false) {
        document.getElementById("content-answerthree-addquestion").style.display = "block";
        showAnswerThreeAdd = true;
        toastr.success("Thêm phần nhập đáp án thành công");
        return;
    }

    if (showAnswerFourAdd == false) {
        document.getElementById("content-answerfour-addquestion").style.display = "block";
        showAnswerFourAdd = true;
        toastr.success("Thêm phần nhập đáp án thành công");
        return;
    }

    if (showAnswerFiveAdd == false) {
        document.getElementById("content-answerfive-addquestion").style.display = "block";
        showAnswerFiveAdd = true;
        toastr.success("Thêm phần nhập đáp án thành công");
        return;
    }

    if (showAnswerSixAdd == false) {
        document.getElementById("content-answersix-addquestion").style.display = "block";
        showAnswerSixAdd = true;
        toastr.success("Thêm phần nhập đáp án thành công");
        return;
    }

    if (showAnswerSevenAdd == false) {
        document.getElementById("content-answerseven-addquestion").style.display = "block";
        showAnswerSevenAdd = true;
        toastr.success("Thêm phần nhập đáp án thành công");
        return;
    }

    if (showAnswerEightAdd == false) {
        document.getElementById("content-answereight-addquestion").style.display = "block";
        showAnswerEightAdd = true;
        toastr.success("Thêm phần nhập đáp án thành công");
        return;
    }
}

function CloseAnswerOneAddQuestion() {
    numberAnswerAddShow--;
    showAnswerOneAdd = false;
    document.getElementById("content-answerone-addquestion").style.display = "none";
}

function CloseAnswerTwoAddQuestion() {
    numberAnswerAddShow--;
    showAnswerTwoAdd = false;
    document.getElementById("content-answertwo-addquestion").style.display = "none";
}

function CloseAnswerThreeAddQuestion() {
    numberAnswerAddShow--;
    showAnswerThreeAdd = false;
    document.getElementById("content-answerthree-addquestion").style.display = "none";
}

function CloseAnswerFourAddQuestion() {
    numberAnswerAddShow--;
    showAnswerFourAdd = false;
    document.getElementById("content-answerfour-addquestion").style.display = "none";
}

function CloseAnswerFiveAddQuestion() {
    numberAnswerAddShow--;
    showAnswerFiveAdd = false;
    document.getElementById("content-answerfive-addquestion").style.display = "none";
}

function CloseAnswerSixAddQuestion() {
    numberAnswerAddShow--;
    showAnswerSixAdd = false;
    document.getElementById("content-answersix-addquestion").style.display = "none";
}

function CloseAnswerSevenAddQuestion() {
    numberAnswerAddShow--;
    showAnswerSevenAdd = false;
    document.getElementById("content-answerseven-addquestion").style.display = "none";
}

function CloseAnswerEightAddQuestion() {
    numberAnswerAddShow--;
    showAnswerEightAdd = false;
    document.getElementById("content-answereight-addquestion").style.display = "none";
}

function CreateQuestionSubmit() {
    //ResetValueControl();

    if (comboBoxCourseAddQuestion.GetValue() == null) {
        toastr.error("Vui lòng chọn môn học");
        return;
    }

    if (comboBoxTopicAddQuestion.GetValue() == null) {
        toastr.error("Vui lòng chọn chủ đề");
        return;
    }

    if (comboBoxTypeAddQuestion.GetValue() == null) {
        toastr.error("Vui lòng chọn loại câu hỏi");
        return;
    }

    if (comboBoxLevelAddQuestion.GetValue() == null) {
        toastr.error("Vui lòng chọn độ khó câu hỏi");
        return;
    }

    var manyAnserAddQuestion = 0;
    var lineNumberAddQuestion = 0;

    if (document.getElementById("content-manyanswer-addquestion").style.display == "block") {
        if (comboBoxManyAnswerAddQuestion.GetValue() == null) {
            toastr.error("Vui lòng chọn số đáp án");
            return;
        }

        var numberChoiceTrue = CheckChoiceAnswer();

        //console.log(numberChoiceTrue);

        if (comboBoxManyAnswerAddQuestion.GetValue() == 1 && numberChoiceTrue < 2) {
            toastr.error("Số đáp án đang chọn là nhiều đáp án, nhưng câu trả lời chưa có 2 đáp án đúng trở lên");
            return;
        }

        if (comboBoxManyAnswerAddQuestion.GetValue() == 0 && numberChoiceTrue != 1) {
            toastr.error("Số đáp án đang chọn là một đáp án, câu trả lời chỉ có duy nhất một đáp án đúng");
            return;
        }

        manyAnserAddQuestion = comboBoxManyAnswerAddQuestion.GetValue();
    }

    if (document.getElementById("content-linenumber-addquestion").style.display == "block") {
        if (spinEditLineNumberAddQuestion.GetValue() == null) {
            toastr.error("Vui lòng nhập số dòng chừa để trả lời");
            return;
        }
        lineNumberAddQuestion = spinEditLineNumberAddQuestion.GetValue();
    }

    if (spinEditPointAddQuestion.GetValue() == null) {
        toastr.error("Vui lòng nhập điểm cho câu hỏi");
        return;
    }

    var editorContentAddQuestionText = CKEDITOR.instances['ContentAddQuestion'].getData();

    if (editorContentAddQuestionText.length == 0) {
        toastr.error("Vui lòng nhập nội dung cho câu hỏi");
        return;
    }

    //cau mot

    var editorContentAnswerOneAddQuestionText = "";
    var choiceAnswerOneAddQuestion = 0;

    if (document.getElementById("content-answerone-addquestion").style.display == "block") {
        editorContentAnswerOneAddQuestionText = CKEDITOR.instances['ContentAnswerOneAddQuestion'].getData();
        if (editorContentAnswerOneAddQuestionText.length == 0) {
            toastr.error("Vui lòng nhập nội dung cho đáp án");
            return;
        }
        choiceAnswerOneAddQuestion = $("input[type=radio][name=choice-answerone-addquestion]:checked").val();
    }

    //cau hai

    var editorContentAnswerTwoAddQuestionText = "";
    var choiceAnswerTwoAddQuestion = 0;

    if (document.getElementById("content-answertwo-addquestion").style.display == "block") {
        editorContentAnswerTwoAddQuestionText = CKEDITOR.instances['ContentAnswerTwoAddQuestion'].getData();
        if (editorContentAnswerTwoAddQuestionText.length == 0) {
            toastr.error("Vui lòng nhập nội dung cho đáp án");
            return;
        }
        choiceAnswerTwoAddQuestion = $("input[type=radio][name=choice-answertwo-addquestion]:checked").val();
    }

    //cau ba

    var editorContentAnswerThreeAddQuestionText = "";
    var choiceAnswerThreeAddQuestion = 0;

    if (document.getElementById("content-answerthree-addquestion").style.display == "block") {
        editorContentAnswerThreeAddQuestionText = CKEDITOR.instances['ContentAnswerThreeAddQuestion'].getData();
        if (editorContentAnswerThreeAddQuestionText.length == 0) {
            toastr.error("Vui lòng nhập nội dung cho đáp án");
            return;
        }
        choiceAnswerThreeAddQuestion = $("input[type=radio][name=choice-answerthree-addquestion]:checked").val();
    }

    //cau bon

    var editorContentAnswerFourAddQuestionText = "";
    var choiceAnswerFourAddQuestion = 0;

    if (document.getElementById("content-answerfour-addquestion").style.display == "block") {
        editorContentAnswerFourAddQuestionText = CKEDITOR.instances['ContentAnswerFourAddQuestion'].getData();
        if (editorContentAnswerFourAddQuestionText.length == 0) {
            toastr.error("Vui lòng nhập nội dung cho đáp án");
            return;
        }

        choiceAnswerFourAddQuestion = $("input[type=radio][name=choice-answerfour-addquestion]:checked").val();
    }

    //cau nam

    var editorContentAnswerFiveAddQuestionText = "";
    var choiceAnswerFiveAddQuestion = 0;

    if (document.getElementById("content-answerfive-addquestion").style.display == "block") {
        editorContentAnswerFiveAddQuestionText = CKEDITOR.instances['ContentAnswerFiveAddQuestion'].getData();
        if (editorContentAnswerFiveAddQuestionText.length == 0) {
            toastr.error("Vui lòng nhập nội dung cho đáp án");
            return;
        }
        choiceAnswerFiveAddQuestion = $("input[type=radio][name=choice-answerfive-addquestion]:checked").val();
    }

    //cau sau

    var editorContentAnswerSixAddQuestionText = "";
    var choiceAnswerSixAddQuestion = 0;

    if (document.getElementById("content-answersix-addquestion").style.display == "block") {
        editorContentAnswerSixAddQuestionText = CKEDITOR.instances['ContentAnswerSixAddQuestion'].getData();
        if (editorContentAnswerSixAddQuestionText.length == 0) {
            toastr.error("Vui lòng nhập nội dung cho đáp án");
            return;
        }
        choiceAnswerSixAddQuestion = $("input[type=radio][name=choice-answersix-addquestion]:checked").val();
    }

    //cau bay

    var editorContentAnswerSevenAddQuestionText = "";
    var choiceAnswerSevenAddQuestion = 0;

    if (document.getElementById("content-answerseven-addquestion").style.display == "block") {
        editorContentAnswerSevenAddQuestionText = CKEDITOR.instances['ContentAnswerSevenAddQuestion'].getData();
        if (editorContentAnswerSevenAddQuestionText.length == 0) {
            toastr.error("Vui lòng nhập nội dung cho đáp án");
            return;
        }
        choiceAnswerSevenAddQuestion = $("input[type=radio][name=choice-answerseven-addquestion]:checked").val();
    }

    //cau tam
    var editorContentAnswerEightAddQuestionText = "";
    var choiceAnswerEightAddQuestion = 0;

    if (document.getElementById("content-answereight-addquestion").style.display == "block") {
        var editorContentAnswerEightAddQuestionText = CKEDITOR.instances['ContentAnswerEightAddQuestion'].getData();
        if (editorContentAnswerEightAddQuestionText.length == 0) {
            toastr.error("Vui lòng nhập nội dung cho đáp án");
            return;
        }
        choiceAnswerEightAddQuestion = $("input[type=radio][name=choice-answereight-addquestion]:checked").val();
    }
    /*
    console.log(comboBoxCourseAddQuestion.GetValue());
    console.log(comboBoxTopicAddQuestion.GetValue());
    console.log(comboBoxTypeAddQuestion.GetValue());
    console.log(comboBoxLevelAddQuestion.GetValue());
    console.log(comboBoxManyAnswerAddQuestion.GetValue());
    console.log(spinEditPointAddQuestion.GetValue());
    console.log(spinEditLineNumberAddQuestion.GetValue());
    console.log(editorContentAnswerOneAddQuestionText);
    console.log(choiceAnswerOneAddQuestion);
    console.log(editorContentAnswerTwoAddQuestionText);
    console.log(choiceAnswerTwoAddQuestion);
    console.log(editorContentAnswerThreeAddQuestionText);
    console.log(choiceAnswerThreeAddQuestion);
    console.log(editorContentAnswerFourAddQuestionText);
    console.log(choiceAnswerFourAddQuestion);
    console.log(editorContentAnswerFiveAddQuestionText);
    console.log(choiceAnswerFiveAddQuestion);
    console.log(editorContentAnswerSixAddQuestionText);
    console.log(choiceAnswerSixAddQuestion);
    console.log(editorContentAnswerSevenAddQuestionText);
    console.log(choiceAnswerSevenAddQuestion);
    console.log(editorContentAnswerEightAddQuestionText);
    console.log(choiceAnswerEightAddQuestion);
    */
    Loading.Show();
    $.ajax({
        url: "/Question/AddQuestion",
        data: JSON.stringify({
            course: comboBoxCourseAddQuestion.GetValue(),
            topic: comboBoxTopicAddQuestion.GetValue(),
            type: comboBoxTypeAddQuestion.GetValue(),
            level: comboBoxLevelAddQuestion.GetValue(),
            muti: comboBoxManyAnswerAddQuestion.GetValue() == null ? 0 : comboBoxManyAnswerAddQuestion.GetValue(),
            point: spinEditPointAddQuestion.GetValue(),
            line: spinEditLineNumberAddQuestion.GetValue() == null ? 0 : spinEditLineNumberAddQuestion.GetValue(),
            contentQuestion: editorContentAddQuestionText,
            answerOneContent: editorContentAnswerOneAddQuestionText,
            answerOneChoice: choiceAnswerOneAddQuestion,
            answerTwoContent: editorContentAnswerTwoAddQuestionText,
            answerTwoChoice: choiceAnswerTwoAddQuestion,
            answerThreeContent: editorContentAnswerThreeAddQuestionText,
            answerThreeChoice: choiceAnswerThreeAddQuestion,
            answerFourContent: editorContentAnswerFourAddQuestionText,
            answerFourChoice: choiceAnswerFourAddQuestion,
            answerFiveContent: editorContentAnswerFiveAddQuestionText,
            answerFiveChoice: choiceAnswerFiveAddQuestion,
            answerSixContent: editorContentAnswerSixAddQuestionText,
            answerSixChoice: choiceAnswerSixAddQuestion,
            answerSevenContent: editorContentAnswerSevenAddQuestionText,
            answerSevenChoice: choiceAnswerSevenAddQuestion,
            answerEightContent: editorContentAnswerEightAddQuestionText,
            answerEightChoice: choiceAnswerEightAddQuestion
        }),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        success: function (data) {
            if (data.status != 0) {
                toastr.error(data.msg);
                Loading.Hide();
                return;
            }
            toastr.success("Thêm câu hỏi thành công");

            gvLibraryQuestion.PerformCallback({
                active: activeValueLibraryQuestion,
                course: comboBoxCourseFilter.GetValue() == null ? 0 : comboBoxCourseFilter.GetValue(),
                topic: comboBoxTopicQuestionFilter.GetValue() == null ? 0 : comboBoxTopicQuestionFilter.GetValue(),
                filter: $('#filter-type-question').is(":checked")
            });

            $('#add-question').modal('hide');
            Loading.Hide();

        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
            Loading.Hide();


        }
    });

    
}

function CheckChoiceAnswer() {
    var numberChoice = 0;
    
    if ($("input[type=radio][name=choice-answerone-addquestion]:checked").val() == true) {
        numberChoice++;
    }

    if ($("input[type=radio][name=choice-answertwo-addquestion]:checked").val() == true) {
        numberChoice++;
    }

    if ($("input[type=radio][name=choice-answerthree-addquestion]:checked").val() == true) {
        numberChoice++;
    }

    if ($("input[type=radio][name=choice-answerfour-addquestion]:checked").val() == true) {
        numberChoice++;
    }

    if ($("input[type=radio][name=choice-answerfive-addquestion]:checked").val() == true) {
        numberChoice++;
    }

    if ($("input[type=radio][name=choice-answersix-addquestion]:checked").val() == true) {
        numberChoice++;
    }

    if ($("input[type=radio][name=choice-answerseven-addquestion]:checked").val() == true) {
        numberChoice++;
    }

    if ($("input[type=radio][name=choice-answereight-addquestion]:checked").val() == true) {
        numberChoice++;
    }

    return numberChoice;
}

function onKeyEnterViewQuestion() {
    var index = gvLibraryQuestion.GetFocusedRowIndex();
    if (index > -1) {
        gvLibraryQuestion.GetRowValues(gvLibraryQuestion.GetFocusedRowIndex(), 'ID;Name', onKeyEnterAction);
    }
    else {
        toastr.error("Vui lòng chọn câu hỏi cần xem");
        return;
    }
    
}

function onKeyEnterAction(values) {
    idLibraryQuestion = values[0];
    $('#view-question').modal('show');
    LoadDetailQuestion();
}

function LoadDetailQuestion() {

    Loading.Show();
    $.ajax({
        url: "/Question/LoadDetailQuestion",
        data: {
            id: idLibraryQuestion
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

//chinh sua cau hoi

var idEditQuestion;

function EditQuestionDetail(idData, typeData, levelData, mutiData, lineData, topicData, pointData) {
    idEditQuestion = idData;

    $('#edit-question').modal('show');
    LoadContentEditQuestion();
    //course, topic
    LoadIdCourseEditQuestion(topicData);
    //check type
    CheckTypeQuestionEditDefault(typeData);
    //set type
    comboBoxTypeEditQuestion.SetValue(typeData);

    LoadLevelEditQuestionDefault(typeData, levelData);

    //set muti
    if (mutiData == "True") {
        comboBoxManyAnswerEditQuestion.SetValue(1);
    }
    else {
        comboBoxManyAnswerEditQuestion.SetValue(0);
    }
    
    //set line
    spinEditLineNumberEditQuestion.SetValue(lineData);
    //set point
    spinEditPointEditQuestion.SetValue(pointData);
}

function LoadContentEditQuestion() {
    Loading.Show();
    $.ajax({
        url: "/Question/LoadContentEditQuestion",
        data: {
            id: idEditQuestion
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#content-editquestion").html(data);

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

function LoadTopicEditQuestionDefault(courseData, topicData) {

    Loading.Show();
    $.ajax({
        url: "/Question/ComboboxTopicEditQuestionPartital",
        data: {
            course: courseData
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentTopicEditQuestion").html(data);

                comboBoxTopicEditQuestion.SetValue(topicData);
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

function LoadIdCourseEditQuestion(topicData) {

    Loading.Show();
    $.ajax({
        url: "/Question/GetIdCourseEditQuestion",
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

            comboBoxCourseEditQuestion.SetValue(data.course);

            LoadTopicEditQuestionDefault(data.course, topicData);
            
            Loading.Hide();

        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
            Loading.Hide();


        }
    });
}

function CourseEditQuestionSelectedIndexChanged(s, e) {
    if (s.lastSuccessValue == null) {
        toastr.error("Vui lòng chọn môn học");
        return;
    }
    LoadTopicEditQuestion();
}

function LoadTopicEditQuestion() {

    Loading.Show();
    $.ajax({
        url: "/Question/ComboboxTopicEditQuestionPartital",
        data: {
            course: comboBoxCourseEditQuestion.GetValue()
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentTopicEditQuestion").html(data);
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

function TypeEditQuestionSelectedIndexChanged(s, e) {
    if (comboBoxTypeEditQuestion.GetValue() == null) {
        toastr.error("Vui lòng chọn loại câu hỏi");
        return;
    }
    LoadLevelEditQuestion();
    CheckTypeQuestionEdit();
}

function CheckTypeQuestionEditDefault(type) {
    Loading.Show();
    $.ajax({
        url: "/Question/CheckTypeQuestion",
        data: {
            id: type
        },
        type: 'POST',
        success: function (data) {
            if (data.status != 0) {
                toastr.error(data.msg);
                Loading.Hide();
                return;
            }

            if (data.choice == 1) {
                document.getElementById("content-manyanswer-editquestion").style.display = "block";
                document.getElementById("content-linenumber-editquestion").style.display = "none";
                //console.log(document.getElementById("content-linenumber-addquestion").style.display);
            }
            else {
                document.getElementById("content-manyanswer-editquestion").style.display = "none";
                document.getElementById("content-linenumber-editquestion").style.display = "block";
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

function CheckTypeQuestionEdit() {
    Loading.Show();
    $.ajax({
        url: "/Question/CheckTypeQuestion",
        data: {
            id: comboBoxTypeEditQuestion.GetValue()
        },
        type: 'POST',
        success: function (data) {
            if (data.status != 0) {
                toastr.error(data.msg);
                Loading.Hide();
                return;
            }

            if (data.choice == 1) {
                document.getElementById("content-manyanswer-editquestion").style.display = "block";
                document.getElementById("content-linenumber-editquestion").style.display = "none";
                spinEditLineNumberEditQuestion.SetValue(0);
            }
            else {
                document.getElementById("content-manyanswer-editquestion").style.display = "none";
                document.getElementById("content-linenumber-editquestion").style.display = "block";
                comboBoxManyAnswerEditQuestion.SetValue(0);
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

function EditQuestionSubmit() {
    if (comboBoxCourseEditQuestion.GetValue() == null) {
        toastr.error("Vui lòng chọn môn học");
        return;
    }

    if (comboBoxTopicEditQuestion.GetValue() == null) {
        toastr.error("Vui lòng chọn chủ đề");
        return;
    }

    if (comboBoxTypeEditQuestion.GetValue() == null) {
        toastr.error("Vui lòng chọn loại câu hỏi");
        return;
    }

    if (comboBoxLevelEditQuestion.GetValue() == null) {
        toastr.error("Vui lòng chọn độ khó câu hỏi");
        return;
    }

    if (document.getElementById("content-manyanswer-editquestion").style.display == "block") {
        if (comboBoxManyAnswerEditQuestion.GetValue() == null) {
            toastr.error("Vui lòng chọn số đáp án");
            return;
        }

        var oldManyChoice = document.getElementById("OldManyEditQuestion").value;
        var numberAnswerChoiceEditQuestion = Number(document.getElementById("NumberAnswerChoiceEditQuestion").value);

        //console.log(numberAnswerChoiceEditQuestion);
        //console.log(oldManyChoice);

        if (comboBoxManyAnswerEditQuestion.GetValue() == 0 && oldManyChoice == "True" && numberAnswerChoiceEditQuestion > 1) {
            toastr.error("Vui lòng sửa đáp án còn 1 câu đúng trước, câu hỏi này trước đó nhiều đáp án đúng");
            return;
        }

    }

    if (document.getElementById("content-linenumber-editquestion").style.display == "block") {
        if (spinEditLineNumberEditQuestion.GetValue() == null) {
            toastr.error("Vui lòng nhập số dòng chừa để trả lời");
            return;
        }
    }

    if (spinEditPointEditQuestion.GetValue() == null) {
        toastr.error("Vui lòng nhập điểm cho câu hỏi");
        return;
    }

    var editorContentEditQuestionText = CKEDITOR.instances['Content'].getData();

    if (editorContentEditQuestionText.length == 0) {
        toastr.error("Vui lòng nhập nội dung cho câu hỏi");
        return;
    }

    var idQuestionEditCheckAgain = document.getElementById("EditQuestionID").value;

    if (idQuestionEditCheckAgain == "none") {
        toastr.error("Không tồn tại dữ liệu về câu hỏi");
        return;
    }

    Loading.Show();
    $.ajax({
        url: "/Question/UpdateQuestion",
        data: JSON.stringify({
            id: Number(idQuestionEditCheckAgain),
            course: comboBoxCourseEditQuestion.GetValue(),
            topic: comboBoxTopicEditQuestion.GetValue(),
            type: comboBoxTypeEditQuestion.GetValue(),
            level: comboBoxLevelEditQuestion.GetValue(),
            muti: comboBoxManyAnswerEditQuestion.GetValue() == null ? 0 : comboBoxManyAnswerEditQuestion.GetValue(),
            point: spinEditPointEditQuestion.GetValue(),
            line: spinEditLineNumberEditQuestion.GetValue() == null ? 0 : spinEditLineNumberEditQuestion.GetValue(),
            contentQuestion: editorContentEditQuestionText
        }),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        success: function (data) {
            if (data.status != 0) {
                toastr.error(data.msg);
                Loading.Hide();
                return;
            }
            toastr.success("Chỉnh sửa câu hỏi thành công");

            //load lai

            gvLibraryQuestion.PerformCallback({
                active: activeValueLibraryQuestion,
                course: comboBoxCourseFilter.GetValue() == null ? 0 : comboBoxCourseFilter.GetValue(),
                topic: comboBoxTopicQuestionFilter.GetValue() == null ? 0 : comboBoxTopicQuestionFilter.GetValue(),
                filter: $('#filter-type-question').is(":checked")
            });

            $('#edit-question').modal('hide');

            LoadDetailQuestion();

            Loading.Hide();

        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
            Loading.Hide();


        }
    });
    
}

var idAnswerEdit;

function EditAnswerDetail(idAnswer, correctAnswer) {
    idAnswerEdit = idAnswer;

    $('#edit-answer').modal('show');
    LoadContentEditAnswer();

    if (correctAnswer == "True") {
        $("input[type=radio][name=choice-answer-editanswer][value=" + 1 + "]").prop('checked', true);
    }
    else {
        $("input[type=radio][name=choice-answer-editanswer][value=" + 0 + "]").prop('checked', true);
    }

    
}

function LoadContentEditAnswer() {
    Loading.Show();
    $.ajax({
        url: "/Question/LoadContentEditAnswer",
        data: {
            id: idAnswerEdit
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#content-editanswer").html(data);

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

function UpdateAnswerSubmit() {


    var idQuestionEditCheckAgain = document.getElementById("EditAnswerIDQuestion").value;

    if (idQuestionEditCheckAgain == "none") {
        toastr.error("Không tồn tại dữ liệu về câu hỏi");
        return;
    }

    var editorContentEditAnswerText = CKEDITOR.instances['ContentAnswerEdit'].getData();

    if (editorContentEditAnswerText.length == 0) {
        toastr.error("Vui lòng nhập nội dung cho câu trả lời");
        return;
    }

    var idAnswerCheckAgain = document.getElementById("IDAnswerEditAnswer").value;

    var choiceAnswerEditAnswer = $("input[type=radio][name=choice-answer-editanswer]:checked").val();

    var numberChoiceEditAnswer = Number(document.getElementById("NumberAnswerChoiceEditAnswer").value);

    var oldManyChoice = document.getElementById("OldManyEditAnswer").value;

    var oldCorrect = document.getElementById("OldCorrectEditAnswer").value == "True" ? 1 : 0;

    if (oldCorrect != choiceAnswerEditAnswer) {
        if (choiceAnswerEditAnswer == 1) {
            var sumChoiceAnswer = numberChoiceEditAnswer + 1;
            if (oldManyChoice == "False" && sumChoiceAnswer > 1) {
                toastr.error("Câu hỏi đang chọn loại một đáp án, không thể chọn đáp án này là đúng");
                return;
            }
        }
        else {
            var sumChoiceAnswer = numberChoiceEditAnswer - 1;
            if (oldManyChoice == "False" && sumChoiceAnswer != 1) {
                toastr.error("Câu hỏi cần có ít nhất một đáp án đúng");
                return;
            }
            if (oldManyChoice == "True" && sumChoiceAnswer < 1) {
                toastr.error("Câu hỏi cần có ít nhất một đáp án đúng");
                return;
            }
            if (oldManyChoice == "True" && sumChoiceAnswer < 2) {
                toastr.warning("Câu hỏi đang chọn loại nhiều đáp án, số đáp án đúng đang bé hơn 2");
            }
        }
    }

    Loading.Show();
    $.ajax({
        url: "/Question/UpdateAnswer",
        data: JSON.stringify({
            question: Number(idQuestionEditCheckAgain),
            id: idAnswerCheckAgain,
            content: editorContentEditAnswerText,
            choice: choiceAnswerEditAnswer
        }),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        success: function (data) {
            if (data.status != 0) {
                toastr.error(data.msg);
                Loading.Hide();
                return;
            }
            toastr.success("Chỉnh sửa trả lời thành công");

            //load lai

            gvLibraryQuestion.PerformCallback({
                active: activeValueLibraryQuestion,
                course: comboBoxCourseFilter.GetValue() == null ? 0 : comboBoxCourseFilter.GetValue(),
                topic: comboBoxTopicQuestionFilter.GetValue() == null ? 0 : comboBoxTopicQuestionFilter.GetValue(),
                filter: $('#filter-type-question').is(":checked")
            });

            $('#edit-answer').modal('hide');

            LoadDetailQuestion();

            Loading.Hide();

        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
            Loading.Hide();


        }
    });
}

function RemoveAnswerSubmit() {
    var idQuestionEditCheckAgain = document.getElementById("EditAnswerIDQuestion").value;

    if (idQuestionEditCheckAgain == "none") {
        toastr.error("Không tồn tại dữ liệu về câu hỏi");
        return;
    }

    var idAnswerCheckAgain = document.getElementById("IDAnswerEditAnswer").value;

    if (idAnswerCheckAgain == "none") {
        toastr.error("Không tồn tại dữ liệu về câu trả lời");
        return;
    }

    var numberChoiceEditAnswer = Number(document.getElementById("NumberAnswerChoiceEditAnswer").value);

    var oldManyChoice = document.getElementById("OldManyEditAnswer").value;

    var oldCorrect = document.getElementById("OldCorrectEditAnswer").value == "True" ? 1 : 0;

    var numberAnswerEditAnswer = Number(document.getElementById("OldNumberAnswerEditAnswer").value);

    var sumNumberAnswer = numberAnswerEditAnswer - 1;

    //cau hoi phai con 1 dap an
    if (sumNumberAnswer == 0) {
        toastr.error("Câu hỏi cần ít nhất có một đáp án");
        return;
    }
    else {
        if (oldCorrect == 1) {
            var sumChoiceAnswer = numberChoiceEditAnswer - 1;
            if (oldManyChoice == "False" && sumChoiceAnswer != 1) {
                toastr.error("Câu hỏi đang chọn loại một đáp án, phải có một đáp án đúng");
                return;
            }
            if (oldManyChoice == "True" && sumChoiceAnswer < 1) {
                toastr.error("Câu hỏi đang chọn loại nhiều đáp án, phải có ít nhất một đáp án đúng");
                return;
            }
            if (oldManyChoice == "True" && sumChoiceAnswer == 1) {
                toastr.warning("Câu hỏi đang chọn loại nhiều đáp án, Sau khi xóa sẽ chỉ còn một đáp án đúng");
            }
        }
        
    }

    Loading.Show();
    $.ajax({
        url: "/Question/RemoveAnswer",
        data: {
            id: idAnswerCheckAgain
        },
        type: 'POST',
        success: function (data) {
            if (data.status != 0) {
                toastr.error(data.msg);
                Loading.Hide();
                return;
            }
            toastr.success("Chỉnh sửa trả lời thành công");

            //load lai

            gvLibraryQuestion.PerformCallback({
                active: activeValueLibraryQuestion,
                course: comboBoxCourseFilter.GetValue() == null ? 0 : comboBoxCourseFilter.GetValue(),
                topic: comboBoxTopicQuestionFilter.GetValue() == null ? 0 : comboBoxTopicQuestionFilter.GetValue(),
                filter: $('#filter-type-question').is(":checked")
            });

            $('#edit-answer').modal('hide');

            LoadDetailQuestion();

            Loading.Hide();

        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
            Loading.Hide();

        }
    });

}

function AddAnswerView() {
    var idQuestionViewAddAnswer = document.getElementById("IDQuestionViewQuestion").value;

    var choiceQuestionViewAnswer = Number(document.getElementById("TypeChoiceQuestionViewQuestion").value);

    if (choiceQuestionViewAnswer == 0) {
        toastr.error("Câu hỏi tự luận không thể thêm câu trả lời");
        return;
    }

    if (idQuestionViewAddAnswer == null || idQuestionViewAddAnswer == undefined) {
        toastr.error("Không tồn tại dữ liệu câu hỏi");
        return;
    }

    idEditQuestion = idQuestionViewAddAnswer;

    $('#add-answer').modal('show');

    
}

function AddAnswerSubmit() {


    var editorContentAnswerAddAnswerText = "";
    var choiceAnswerAddAnswer = 0;

    var editorContentAnswerAddAnswerText = CKEDITOR.instances['ContentAnswerAddQuestion'].getData();
    if (editorContentAnswerAddAnswerText.length == 0) {
        toastr.error("Vui lòng nhập nội dung cho đáp án");
        return;
    }
    choiceAnswerAddAnswer = $("input[type=radio][name=choice-answer-addanswer]:checked").val();

    Loading.Show();
    $.ajax({
        url: "/Question/AddAnswer",
        data: JSON.stringify({
            question: idEditQuestion,
            content: editorContentAnswerAddAnswerText,
            choice: choiceAnswerAddAnswer
        }),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        success: function (data) {
            if (data.status != 0) {
                toastr.error(data.msg);
                Loading.Hide();
                return;
            }
            toastr.success("Thêm câu trả lời thành công");

            //load lai

            gvLibraryQuestion.PerformCallback({
                active: activeValueLibraryQuestion,
                course: comboBoxCourseFilter.GetValue() == null ? 0 : comboBoxCourseFilter.GetValue(),
                topic: comboBoxTopicQuestionFilter.GetValue() == null ? 0 : comboBoxTopicQuestionFilter.GetValue(),
                filter: $('#filter-type-question').is(":checked")
            });

            $('#add-answer').modal('hide');

            LoadDetailQuestion();

            Loading.Hide();

        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
            Loading.Hide();


        }
    });

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

function onDownloadTemplateClickImportQuestion(s, e) {
    if (comboBoxTypeQuestionImport.GetValue() == null) {
        toastr.error("Vui lòng chọn loại câu hỏi cần thao tác");
        return;
    }

    if (comboBoxTypeQuestionImport.GetValue() == 1) {
        var result = confirm("Hệ thống sẽ bắt đầu tải tập tin mẫu cho câu hỏi trắc nghiệm, bạn có chắc chắn muốn thực hiện?");
        if (result) {
            DownloadFileTemplateImport();
        }
    }

    if (comboBoxTypeQuestionImport.GetValue() == 2) {
        var result = confirm("Hệ thống sẽ bắt đầu tải tập tin mẫu cho câu hỏi tự luận, bạn có chắc chắn muốn thực hiện?");
        if (result) {
            DownloadFileTemplateImport();
        }
    }

}


function DownloadFileTemplateImport() {
    Loading.Show();
    $.ajax({
        url: "/Question/DownloadTemplateQuestionImport",
        data: {
            type: comboBoxTypeQuestionImport.GetValue()
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

function onCancelClickImportQuestion(s, e) {
    $("#files").val(null);
    comboBoxTypeQuestionImport.SetValue(1);
    PopupControlImportQuestion.Hide();
}

function CourseQuestionImportSelectedIndexChanged(s, e) {
    comboBoxTopicQuestionImport.SetValue(null);
    if (s.lastSuccessValue != null) {
        LoadTopicQuestionImport();
    }
}

function LoadTopicQuestionImport() {

    Loading.Show();
    $.ajax({
        url: "/Question/ComboboxTopicQuestionImportPartital",
        data: {
            course: comboBoxCourseQuestionImport.GetValue()
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentTopicQuestionImport").html(data);

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

function onSubmitClickImportQuestion(s, e) {
    if (comboBoxTypeQuestionImport.GetValue() == null) {
        toastr.error("Vui lòng chọn loại câu hỏi cần import");
        return;
    }
    if (comboBoxCourseQuestionImport.GetValue() == null) {
        toastr.error("Vui lòng chọn môn học cần import");
        return;
    }
    if (comboBoxTopicQuestionImport.GetValue() == null) {
        toastr.error("Vui lòng chọn chủ đề cần import");
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
    var typeImport = comboBoxTypeQuestionImport.GetValue();
    var courseImport = comboBoxCourseQuestionImport.GetValue();
    var topicImport = comboBoxTopicQuestionImport.GetValue();
   
    fileData.append("type", typeImport);
    fileData.append("course", courseImport);
    fileData.append("topic", topicImport);

    $.ajax({
        url: "/Question/UploadFiles",
        type: 'POST',
        contentType: false, // Not to set any content header
        processData: false, // Not to process data
        data: fileData,
        async: true,
        success: function (data) {
            PopupControlImportQuestion.Hide();
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

            gvLibraryQuestion.PerformCallback({
                active: activeValueLibraryQuestion,
                course: comboBoxCourseFilter.GetValue() == null ? 0 : comboBoxCourseFilter.GetValue(),
                topic: comboBoxTopicQuestionFilter.GetValue() == null ? 0 : comboBoxTopicQuestionFilter.GetValue(),
                filter: $('#filter-type-question').is(":checked")
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
