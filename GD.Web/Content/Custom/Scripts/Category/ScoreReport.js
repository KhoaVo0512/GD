function GradeScoreReportFilterSelectedIndexChanged(s, e) {
    
    if (comboBoxScholasticFilter.GetValue() == null) {
        toastr.error("Vui lòng chọn năm học cần xem");
        return;
    }
    if (s.lastSuccessValue != null) {
        LoadCourseByGradeScoreReport();
    }
}

function LoadCourseByGradeScoreReport() {
    Loading.Show();
    $.ajax({
        url: "/ScoreReport/LoadCourseByGrade",
        data: {
            scholastic: comboBoxScholasticFilter.GetValue(),
            grade: comboBoxGradeScoreReportFilter.GetValue()
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {

                $("#contentCourseScoreReportFilter").html(data);
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

function CourseScoreReportFilterSelectedIndexChanged(s, e) {
    if (comboBoxGradeScoreReportFilter.GetValue() == null) {
        toastr.error("Vui lòng chọn lớp cần xem");
        return;
    }
    if (s.lastSuccessValue != null) {

        if (panelScoreReport.GetActiveTabIndex() == 0) {
            LoadPieScoreHKIReport();
        }
        if (panelScoreReport.GetActiveTabIndex() == 1) {
            LoadPieScoreHKIIReport();
        }
        if (panelScoreReport.GetActiveTabIndex() == 2) {
            LoadPieScoreCNReport();
        }

    }
}

function ScoreReportActiveTabChanged(s, e) {
    if (comboBoxScholasticFilter.GetValue() == null) {
        toastr.error("Vui lòng chọn năm học cần xem");
        return;
    }
    if (comboBoxGradeScoreReportFilter.GetValue() == null) {
        toastr.error("Vui lòng chọn lớp học cần xem");
        return;
    }
    if (comboBoxCourseScoreReportFilter.GetValue() == null) {
        toastr.error("Vui lòng chọn môn học cần xem");
        return;
    }

    if (panelScoreReport.GetActiveTabIndex() == 0) {
        LoadPieScoreHKIReport();
    }
    if (panelScoreReport.GetActiveTabIndex() == 1) {
        LoadPieScoreHKIIReport();
    }
    if (panelScoreReport.GetActiveTabIndex() == 2) {
        LoadPieScoreCNReport();
    }
}

function LoadPieScoreHKIReport() {
    Loading.Show();
    $.ajax({
        url: "/ScoreReport/LoadPieScoreHKIReport",
        data: {
            scholastic: comboBoxScholasticFilter.GetValue(),
            grade: comboBoxGradeScoreReportFilter.GetValue(),
            course: comboBoxCourseScoreReportFilter.GetValue()
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentScoreHKIReport").html(data);
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

function LoadPieScoreHKIIReport() {
    Loading.Show();
    $.ajax({
        url: "/ScoreReport/LoadPieScoreHKIIReport",
        data: {
            scholastic: comboBoxScholasticFilter.GetValue(),
            grade: comboBoxGradeScoreReportFilter.GetValue(),
            course: comboBoxCourseScoreReportFilter.GetValue()
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentScoreHKIIReport").html(data);
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

function LoadPieScoreCNReport() {
    Loading.Show();
    $.ajax({
        url: "/ScoreReport/LoadPieScoreCNReport",
        data: {
            scholastic: comboBoxScholasticFilter.GetValue(),
            grade: comboBoxGradeScoreReportFilter.GetValue(),
            course: comboBoxCourseScoreReportFilter.GetValue()
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {
                $("#contentScoreCNReport").html(data);
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