function CourseFilterSelectedIndexChanged(s, e) {
    if (s.lastSuccessValue != null) {
        onSetCourseFilter();
    }
}

function ScholasticFilterSelectedIndexChanged(s, e) {
    comboBoxSubClassFilter.SetValue(null);
    if (s.lastSuccessValue != null) {
        LoadGradeDataFilter();
    } 
}

function onSetCourseFilter() {
    
    var menuActive = document.getElementById("menu-active").value;
    if (menuActive != null && menuActive != undefined) {
        if (menuActive == "Lesson") {
            Loading.Show();
            $.ajax({
                url: "/Home/SetCourseFilter",
                data: {
                    course: comboBoxCourseFilter.GetValue()
                },
                type: 'POST',
                success: function (data) {

                    if (data == "") {

                    }
                    else {
                        $("#contentTopicLessonFilter").html(data);
                    }

                    LoadLessonData();

                    Loading.Hide();

                },
                error: function (xhr, ajaxOptions, thrownError) {
                    alert(xhr.status);
                    alert(thrownError);
                    Loading.Hide();
                }
            });
        }

        if (menuActive == "Library") {
            Loading.Show();
            $.ajax({
                url: "/Library/SetCourseFilter",
                data: {
                    course: comboBoxCourseFilter.GetValue()
                },
                type: 'POST',
                success: function (data) {

                    if (data == "") {

                    }
                    else {
                        $("#contentTopicLibraryFilter").html(data);
                    }

                    LoadLibraryData();

                    Loading.Hide();

                },
                error: function (xhr, ajaxOptions, thrownError) {
                    alert(xhr.status);
                    alert(thrownError);
                    Loading.Hide();
                }
            });
        }

        if (menuActive == "Question") {
            Loading.Show();
            $.ajax({
                url: "/Question/SetCourseFilter",
                data: {
                    course: comboBoxCourseFilter.GetValue()
                },
                type: 'POST',
                success: function (data) {

                    if (data == "") {

                    }
                    else {
                        $("#contentTopicQuestionFilter").html(data);
                    }

                    gvLibraryQuestion.PerformCallback({
                        active: true,
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

        if (menuActive == "Exam") {
            Loading.Show();
            $.ajax({
                url: "/Exam/SetCourseFilter",
                data: {
                    course: comboBoxCourseFilter.GetValue()
                },
                type: 'POST',
                success: function (data) {

                    if (data == "") {

                    }
                    else {
                        $("#contentTopicExamFilter").html(data);
                    }

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

    }
   
    
}

function LoadGradeDataFilter() {
    var menuActive = document.getElementById("menu-active").value;
    if (menuActive != null && menuActive != undefined) {
        if (menuActive == "SubClass") {
            Loading.Show();
            $.ajax({
                url: "/SubClass/LoadGradeDataFilter",
                data: {
                    id: comboBoxScholasticFilter.GetValue()
                },
                type: 'POST',
                success: function (data) {

                    if (data == "") {

                    }
                    else {
                        $("#contentSubClassFilter").html(data);
                    }
                    gvSubClass.PerformCallback({
                        active: activeValue,
                        grade: comboBoxSubClassFilter.GetValue() == null ? 0 : comboBoxSubClassFilter.GetValue()
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

        if (menuActive == "Score") {
            Loading.Show();
            $.ajax({
                url: "/Score/LoadGradeDataFilter",
                data: {
                    id: comboBoxScholasticFilter.GetValue()
                },
                type: 'POST',
                success: function (data) {

                    if (data == "") {

                    }
                    else {
                        $("#contentGradeScoreFilter").html(data);
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
    }
}

function TopicLessonFilterSelectedIndexChanged(s, e) {
    LoadLessonData();
}

function LoadLessonData() {

    Loading.Show();
    $.ajax({
        url: "/Home/LoadLesson",
        data: {
            topic: comboBoxTopicLessonFilter.GetValue() == null ? 0 : comboBoxTopicLessonFilter.GetValue(),
            search: txtLessonSearch.GetText()
        },
        type: 'POST',
        success: function (data) {

            if (data == "") {

            }
            else {
                $("#content-lesson").html(data);
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

function TopicLibraryFilterSelectedIndexChanged(s, e) {
    LoadLibraryData();
}

function LoadLibraryData() {
    Loading.Show();
    $.ajax({
        url: "/Library/LoadLibrary",
        data: {
            topic: comboBoxTopicLibraryFilter.GetValue() == null ? 0 : comboBoxTopicLibraryFilter.GetValue(),
            type: comboBoxTypeLibrary.GetValue() == null ? 0: comboBoxTypeLibrary.GetValue(),
            search: txtLibrarySearch.GetText()
        },
        type: 'POST',
        success: function (data) {

            if (data == "") {

            }
            else {
                $("#content-library").html(data);
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

function LessonSearchTextChanged(s, e) {
    if (comboBoxTopicLessonFilter.GetValue() != null && comboBoxCourseFilter.GetValue() != null) {
        LoadLessonData();
    }
}

function LibrarySearchTextChanged(s, e) {
    if (comboBoxTopicLibraryFilter.GetValue() != null && comboBoxCourseFilter.GetValue() != null) {
        LoadLibraryData();
    }
}

//question

function TopicQuestionFilterSelectedIndexChanged(s, e) {
    gvLibraryQuestion.PerformCallback({
        active: true,
        course: comboBoxCourseFilter.GetValue() == null ? 0 : comboBoxCourseFilter.GetValue(),
        topic: comboBoxTopicQuestionFilter.GetValue() == null ? 0 : comboBoxTopicQuestionFilter.GetValue(),
        filter: $('#filter-type-question').is(":checked")
    });
}

//exam

function TopicExamFilterSelectedIndexChanged(s, e) {
    gvExam.PerformCallback({
        active: true,
        course: comboBoxCourseFilter.GetValue() == null ? 0 : comboBoxCourseFilter.GetValue(),
        topic: comboBoxTopicExamFilter.GetValue() == null ? 0 : comboBoxTopicExamFilter.GetValue(),
        filter: $('#filter-type-exam').is(":checked")
    });
}

function OnTutorial() {
    var menuActiveData = document.getElementById("menu-active").value;
    if (menuActiveData != null && menuActiveData != undefined) {
        if (menuActiveData == "Lesson") {
            PopupControlTutorialLesson.Show();
        }
        if (menuActiveData == "Library") {
            PopupControlTutorialLibrary.Show();
        }
    }
}

function onCancelClickTutorialLesson(s, e) {
    PopupControlTutorialLesson.Hide();
}

function onCancelClickTutorialLibrary(s, e) {
    PopupControlTutorialLibrary.Hide();
}


function TypeLibrarySelectedIndexChanged(s, e) {
    if (s.lastSuccessValue != null) {
        LoadLibraryData();
    } 
}