function GradeScoreFilterSelectedIndexChanged(s, e) {
    
    if (comboBoxScholasticFilter.GetValue() == null) {
        toastr.error("Vui lòng chọn năm học cần xem");
        return;
    }
    if (s.lastSuccessValue != null) {
        LoadCourseByGrade();
    }
}

function LoadCourseByGrade() {
    Loading.Show();
    $.ajax({
        url: "/Score/LoadCourseByGrade",
        data: {
            scholastic: comboBoxScholasticFilter.GetValue(),
            grade: comboBoxGradeScoreFilter.GetValue()
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {

                $("#contentCourseScoreFilter").html(data);
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

function CourseScoreFilterSelectedIndexChanged(s, e) {
    if (comboBoxGradeScoreFilter.GetValue() == null) {
        toastr.error("Vui lòng chọn lớp cần xem");
        return;
    }
    if (s.lastSuccessValue != null) {

        if (panelScore.GetActiveTabIndex() == 0) {
            LoadDataScoreHKI();
        }
        if (panelScore.GetActiveTabIndex() == 1) {
            LoadDataScoreHKII();
        }
        if (panelScore.GetActiveTabIndex() == 2) {
            LoadDataScoreCN();
        }

    }
}

function LoadDataScoreHKI() {
    Loading.Show();
    $.ajax({
        url: "/Score/LoadDataScoreHKI",
        data: {
            scholastic: comboBoxScholasticFilter.GetValue(),
            grade: comboBoxGradeScoreFilter.GetValue(),
            course: comboBoxCourseScoreFilter.GetValue()
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {
                
            }
            else {
                
                $("#contentScoreHKI").html(data);
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

function LoadDataScoreHKII() {
    Loading.Show();
    $.ajax({
        url: "/Score/LoadDataScoreHKII",
        data: {
            scholastic: comboBoxScholasticFilter.GetValue(),
            grade: comboBoxGradeScoreFilter.GetValue(),
            course: comboBoxCourseScoreFilter.GetValue()
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {

                $("#contentScoreHKII").html(data);
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

function LoadDataScoreCN() {
    Loading.Show();
    $.ajax({
        url: "/Score/LoadDataScoreCN",
        data: {
            scholastic: comboBoxScholasticFilter.GetValue(),
            grade: comboBoxGradeScoreFilter.GetValue(),
            course: comboBoxCourseScoreFilter.GetValue()
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {

                $("#contentScoreCN").html(data);
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

function SearchDataScoreHKI() {
    Loading.Show();
    $.ajax({
        url: "/Score/SearchDataScoreHKI",
        data: {
            search: txtScoreSearch.GetText(),
            scholastic: comboBoxScholasticFilter.GetValue(),
            grade: comboBoxGradeScoreFilter.GetValue(),
            course: comboBoxCourseScoreFilter.GetValue()
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {

                $("#contentScoreHKI").html(data);
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

function SearchDataScoreHKII() {
    Loading.Show();
    $.ajax({
        url: "/Score/SearchDataScoreHKII",
        data: {
            search: txtScoreSearch.GetText(),
            scholastic: comboBoxScholasticFilter.GetValue(),
            grade: comboBoxGradeScoreFilter.GetValue(),
            course: comboBoxCourseScoreFilter.GetValue()
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {

                $("#contentScoreCN").html(data);
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

function SearchDataScoreCN() {
    Loading.Show();
    $.ajax({
        url: "/Score/SearchDataScoreCN",
        data: {
            search: txtScoreSearch.GetText(),
            scholastic: comboBoxScholasticFilter.GetValue(),
            grade: comboBoxGradeScoreFilter.GetValue(),
            course: comboBoxCourseScoreFilter.GetValue()
        },
        type: 'POST',
        success: function (data) {
            if (data == "") {

            }
            else {

                $("#contentScoreHKII").html(data);
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

function ScoreActiveTabChanged(s, e) {
    if (comboBoxScholasticFilter.GetValue() == null) {
        toastr.error("Vui lòng chọn năm học cần xem");
        return;
    }
    if (comboBoxGradeScoreFilter.GetValue() == null) {
        toastr.error("Vui lòng chọn lớp học cần xem");
        return;
    }
    if (comboBoxCourseScoreFilter.GetValue() == null) {
        toastr.error("Vui lòng chọn môn học cần xem");
        return;
    }

    txtScoreSearch.SetText(null);
    
    if (panelScore.GetActiveTabIndex() == 0) {
        LoadDataScoreHKI();
    }
    if (panelScore.GetActiveTabIndex() == 1) {
        LoadDataScoreHKII();
    }
    if (panelScore.GetActiveTabIndex() == 2) {
        LoadDataScoreCN();
    }
}

function ScoreSearchTextChanged(s, e) {
    if (comboBoxScholasticFilter.GetValue() == null) {
        toastr.error("Vui lòng chọn năm học cần xem");
        txtScoreSearch.SetText(null);
        return;
    }
    if (comboBoxGradeScoreFilter.GetValue() == null) {
        toastr.error("Vui lòng chọn lớp học cần xem");
        txtScoreSearch.SetText(null);
        return;
    }
    if (comboBoxCourseScoreFilter.GetValue() == null) {
        toastr.error("Vui lòng chọn môn học cần xem");
        txtScoreSearch.SetText(null);
        return;
    }
    if (panelScore.GetActiveTabIndex() == 0) {
        if (txtScoreSearch.GetText().length > 0) {
            SearchDataScoreHKI();
        }
        else {
            LoadDataScoreHKI();
        }
            
    }
    if (panelScore.GetActiveTabIndex() == 1) {

        if (txtScoreSearch.GetText().length > 0) {
            SearchDataScoreHKII();
        }
        else {
            LoadDataScoreHKII();
        }
    }
    if (panelScore.GetActiveTabIndex() == 2) {

        if (txtScoreSearch.GetText().length > 0) {
            SearchDataScoreCN();
        }
        else {
            LoadDataScoreCN();
        }
    }
    
}

function OnChangePoint(id, name) {
    
    var idCallValue = name + "-" + id;
    //console.log(id);
    //console.log(name);
    //console.log(document.getElementById(idCallValue).value);
    //console.log(idCallValue);
    var point = -1;
    if (document.getElementById(idCallValue).value.length > 0) {
        point = document.getElementById(idCallValue).value;
    }
    UpdateScore(id, name, point);
}

function UpdateScore(idScore, nameScore, pointScore) {
    Loading.Show();
    $.ajax({
        url: "/Score/UpdateScore",
        data: {
            id: idScore,
            name: nameScore,
            point: pointScore
        },
        type: 'POST',
        success: function (data) {
            if (data.status != 0) {
                toastr.error(data.msg);
                Loading.Hide();
                return;
            }

            toastr.success("Cập nhật thành công");

            if (data.dtb) {

                var dataHtml = "" + data.number;
                $("#dtb-" + idScore).html(dataHtml);

            }
            else {
                var dataHtml = "Chưa có";
                $("#dtb-" + idScore).html(dataHtml);
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

function OnPrinterScore() {
    if (comboBoxScholasticFilter.GetValue() == null) {
        toastr.error("Vui lòng chọn năm học cần xem");
        txtScoreSearch.SetText(null);
        return;
    }
    if (comboBoxGradeScoreFilter.GetValue() == null) {
        toastr.error("Vui lòng chọn lớp học cần xem");
        txtScoreSearch.SetText(null);
        return;
    }
    if (comboBoxCourseScoreFilter.GetValue() == null) {
        toastr.error("Vui lòng chọn môn học cần xem");
        txtScoreSearch.SetText(null);
        return;
    }

    if (panelScore.GetActiveTabIndex() == 0 || panelScore.GetActiveTabIndex() == 1) {
        PrinterScoreData();
    }
    else {
        PrinterScoreDataCN();
    }
}

function PrinterScoreData() {
    Loading.Show();
    $.ajax({
        url: "/Score/PrinterScore",
        data: {
            scholastic: comboBoxScholasticFilter.GetValue(),
            grade: comboBoxGradeScoreFilter.GetValue(),
            course: comboBoxCourseScoreFilter.GetValue(),
            type: panelScore.GetActiveTabIndex()
        },
        type: 'POST',
        success: function (data) {
            if (data.status != 0) {
                toastr.error(data.msg);
                Loading.Hide();
                return;
            }
            
            window.open("/Score/ExportPDF", "PrintingFrame");
            var frameElement = document.getElementById("FrameToPrint");
            frameElement.addEventListener("load", function (e) {
                if (frameElement.contentDocument.contentType !== "text/html") {
                    frameElement.contentWindow.print();
                    Loading.Hide();
                }
            });
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
            clickPrint = 0;
            Loading.Hide();

        }
    });
}

function PrinterScoreDataCN() {
    Loading.Show();
    $.ajax({
        url: "/Score/PrinterScore",
        data: {
            scholastic: comboBoxScholasticFilter.GetValue(),
            grade: comboBoxGradeScoreFilter.GetValue(),
            course: comboBoxCourseScoreFilter.GetValue(),
            type: panelScore.GetActiveTabIndex()
        },
        type: 'POST',
        success: function (data) {
            if (data.status != 0) {
                toastr.error(data.msg);
                Loading.Hide();
                return;
            }

            window.open("/Score/ExportPDFCN", "PrintingFrame");
            var frameElement = document.getElementById("FrameToPrint");
            frameElement.addEventListener("load", function (e) {
                if (frameElement.contentDocument.contentType !== "text/html") {
                    frameElement.contentWindow.print();
                    Loading.Hide();
                }
            });
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
            clickPrint = 0;
            Loading.Hide();

        }
    });
}