var pathLoadAgain;
var nameLoadAgain;
var categoryLoadAgain;
var openVideo = 0;
var contentLenght = 0;
function CreateLesson() {
    if (navigator.onLine == true) {
        CreateOnline();
    }
    else {
        CreateOffline();
    }
}

function CreateOnline() {

    if (document.body.clientWidth > 1200) {
        $('#create-online-template').modal('show');
        LoadEditorGoogle();
    }
    else {
        toastr.info("Soạn thảo sẽ tốt hơn khi sử dụng PC");
    }

}

function CreateOffline() {
    $('#content-template').modal('show');
    LoadTemplateLessonData();
}

function LoadEditorGoogle() {
    Loading.Show();
    
    $.ajax({
        url: "/Home/LoadEditorGoogle",
        data: {
            
        },
        type: 'POST',
        success: function (data) {

            if (data == "") {

            }
            else {
                $("#content-iframe-google").html(data);
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

function LoadContentGoogle(urlGoogle) {
    Loading.Show();

    $.ajax({
        url: "/Home/LoadContentGoogle",
        data: {
            link: urlGoogle
        },
        type: 'POST',
        success: function (data) {

            if (data == "") {

            }
            else {
                $("#content-powperpoint-online").html(data);
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


function ViewFileContent(nameData, categoryData, urlData, urlGoogle, noteData) {
    
    if (getExtention(urlData) == ".pdf") {
        var url = window.location.origin + "/Home/ViewFilePage?url=" + urlData;
        window.open(url, '_blank');
    }
    else {

        var arrayDocument = [".doc", ".docx"];
        let indexDocument = arrayDocument.indexOf(getExtention(urlData));

        if (indexDocument > -1) {
            
            PopupControlContentRichText.Show();
            LoadRichTextData(urlData);
            return;
        }

        var arrayPowerpoint = [".pptx", ".pptm", ".ppt", ".potx", ".potm", ".pot", ".ppsx", ".ppsm", ".pps"];
        let indexPowerpoint = arrayPowerpoint.indexOf(getExtention(urlData));
        if (indexPowerpoint > -1) {
            if (navigator.onLine == true) {
                if (urlGoogle != undefined && urlGoogle.length > 0) {
                    $('#view-powperpoint-online').modal('show');
                    LoadContentGoogle(urlGoogle);
                }
                else {

                    onDownloadFileOnline(urlData);
                }
            }
            else {
                Loading.Show();
                $.ajax({
                    url: "/Home/LoadFile",
                    data: {
                        category: categoryData,
                        name: urlData
                    },
                    type: 'POST',
                    success: function (data) {
                        if (data.status != 0) {
                            toastr.error(data.msg);
                            Loading.Hide();
                            return;
                        }
                        if (data.same) {
                            PopupControlLessonNotication.Show();
                            var htmlData = "<font>Đã có tập tin trùng tên, theo đường dẫn sau: " + "<br><br><b>Đường dẫn:</b> <i>" + data.path + "</i><br><br>Nếu bạn bấm <b>Tiếp tục</b> sẽ ghi đè tập tin hiện có, nếu bạn bấm <b>Mở lại</b> sẽ thực hiện mở lại tập tin hiện có. Bạn hãy lưu ý để tránh mất dữ liệu!" + "</font>";
                            $("#contentLessonNotication").html(htmlData);
                            nameLoadAgain = data.nameRoot;
                            categoryLoadAgain = data.categoryRoot;
                            pathLoadAgain = data.path;
                        }
                        else {
                            toastr.success("Mở tập tin thành công");
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
        else {
            //$('#view-file').modal('show');
            var arrayVideo = [".avi", ".flv", ".wmv", ".mov", ".mp4", ".mpeg", ".divx", ".3gp"];
            let indexVideo = arrayVideo.indexOf(getExtention(urlData));
            var url = window.location.origin + "/Content/Upload/Lesson/" + urlData;
            
            if (indexVideo > -1) {
                openVideo = 1;
                let myVideo = null;
                myVideo = GLightbox({
                    elements: [
                        {
                            'href': url,
                            'type': 'video',
                            'source': 'youtube', //vimeo, youtube or local
                            'height': '100vh'
                        }
                    ],
                    autoplayVideos: false,
                });
                myVideo.open();
                
                /*
                if (document.body.clientWidth > 1200) {
                    document.getElementById("content-view-file").innerHTML = "<video id='video-lesson' controls='true' controlsList='nodownload' style='display:block;margin-left:auto;margin-right:auto;height:80vh;' autoplay loop controls><source src='" + url + "' type='video/mp4'>Your browser does not support the video tag.</video>";
                } else {
                    document.getElementById("content-view-file").innerHTML = "<video id='video-lesson' controls='true' controlsList='nodownload' style='display:block;margin-left:auto;margin-right:auto;width:85vw;' autoplay loop controls><source src='" + url + "' type='video/mp4'>Your browser does not support the video tag.</video>";
                }
                */
                
            }

            var arrayImage = [".png", ".jpg", ".jpeg", ".bmp", ".gif"];
            let indexImage = arrayImage.indexOf(getExtention(urlData));

            if (indexImage > -1) {
                let myGallery = null;
                if (noteData != null && noteData.length > 0) {
                    myGallery = GLightbox({
                        elements: [
                            {
                                'href': url,
                                'type': 'image',
                                'title': nameData,
                                'description': noteData,
                            }
                        ]
                    });
                    myGallery.open();
                }
                else {
                    myGallery = GLightbox({
                        elements: [
                            {
                                'href': url,
                                'type': 'image',
                                'title': nameData
                            }
                        ]
                    });
                    myGallery.open();
                }

                /*
                if (document.body.clientWidth > 1200) {
                    document.getElementById("content-view-file").innerHTML = "<img style='display:block;margin-left:auto;margin-right:auto;height:85vh;' class='rounded' src = '" + url + "'/>";
                } else {
                    document.getElementById("content-view-file").innerHTML = "<img style='display:block;margin-left:auto;margin-right:auto;width:85vw;' class='rounded' src = '" + url + "'/>";
                }
                */
                
            }


        }
    }


}

function getExtention(fileName) {
    var i = fileName.lastIndexOf('.');
    if (i === -1) return false;
    return fileName.slice(i).toLowerCase();
}

function onSubmitClickLessonNotication(s, e) {
    LoadFileAgain(true);
}

function onCancelClickLessonNotication(s, e) {
    LoadFileAgain(false);
    
}

function LoadFileAgain(nextData) {
    Loading.Show();
    $.ajax({
        url: "/Home/LoadFileAgain",
        data: {
            categoryRoot: categoryLoadAgain,
            nameRoot: nameLoadAgain,
            pathOld: pathLoadAgain,
            next: nextData
        },
        type: 'POST',
        success: function (data) {
            if (data.status != 0) {
                toastr.error(data.msg);
                Loading.Hide();
                PopupControlLessonNotication.Hide();
                return;
            }

            toastr.success("Mở tập tin thành công");
            Loading.Hide();
            PopupControlLessonNotication.Hide();

        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
            Loading.Hide();
            PopupControlLessonNotication.Hide();

        }
    });
}

function LoadTemplateLessonData() {

    Loading.Show();
    $.ajax({
        url: "/Home/LoadTemplateLesson",
        data: {
            course: comboBoxCourseFilter.GetValue() == null ? 0 : comboBoxCourseFilter.GetValue(),
            search: txtTemplateLessonSearch.GetText(),
            all: $('#all-templatelesson').is(":checked")
        },
        type: 'POST',
        success: function (data) {

            if (data == "") {

            }
            else {
                $("#content-template-lesson").html(data);
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

function TemplateLessonSearchTextChanged(s, e) {
    LoadTemplateLessonData();
}

function onChangeFilterAllTemplateLesson() {
    
    if (comboBoxCourseFilter.GetValue() == null && $('#all-templatelesson').is(":checked") == false) {
        toastr.error("Chưa có lớp được chọn không thể lọc theo môn học")
        $("#all-templatelesson").prop("checked", true);
    }

    LoadTemplateLessonData();
}

function onDownloadFileOnline(urlFile) {
    var element = document.createElement('a');
    var path = window.location.origin + "/Content/Upload/Lesson/" + urlFile;
    element.setAttribute('href', path);

    element.style.display = 'none';
    document.body.appendChild(element);

    element.click();

    document.body.removeChild(element);
}

function OpenImportFile() {
    PopupControlImportFile.Show();
}

function onSubmitClickImportFile(s, e) {
    if (txtNameFile.GetText().length == 0) {
        toastr.error("Vui lòng nhập tên");
        return;
    }

    if (comboBoxCourseFilter.GetValue() == null) {
        toastr.error("Vui lòng chọn môn học");
        return;
    }

    if (comboBoxTopicLessonFilter.GetValue() == null) {
        toastr.error("Vui lòng chọn chủ đề");
        return;
    }

    var fileUpload = $("#files").get(0);
    var files = fileUpload.files;

    if (files.length == 0) {
        toastr.error("Vui lòng chọn file cần tải lên");
        return;
    }

    var avatarUpload = $("#preview-avatar").get(0);
    var avatarsFiles = avatarUpload.files;

    if (avatarsFiles.length == 0) {
        UploadFiles("");
    }
    else {
        UploadAvatar();
    }
}

function onCancelClickImportFile(s, e) {
    PopupControlImportFile.Hide();
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
        url: "/Home/UploadAvatar",
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

function UploadFiles(urlAvatar) {

    var avatarLink = "";

    if (urlAvatar != null && urlAvatar != undefined && urlAvatar.length > 2) {
        avatarLink = urlAvatar;
    }

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
    var courseImport = comboBoxCourseFilter.GetValue();
    var topicImport = comboBoxTopicLessonFilter.GetValue();
    var categoryImport = 1;
    fileData.append("name", nameImport);
    fileData.append("course", courseImport);
    fileData.append("topic", topicImport);
    fileData.append("category", categoryImport);
    fileData.append("avatar", avatarLink);
    $.ajax({
        url: "/Home/UploadFiles",
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

function LoadRichTextData(urlData) {
    Loading.Show();

    $.ajax({
        url: "/Home/LoadRichText",
        data: {
            url: urlData
        },
        type: 'POST',
        success: function (data) {

            if (data == "") {

            }
            else {
                $("#contentRichText").html(data);
                
            }

            Loading.Hide();

        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
            Loading.Hide();
        },
        
    });
    setTimeout(() => {
        var content = document.getElementById("RichEdit_View").innerHTML.length;
        console.log(content);
        this.contentLenght = content + 10;
    }, 1000);
}
function checkLenghtContent() {
    var content = document.getElementById("RichEdit_View").innerHTML.length;
    if (content == this.contentLenght)
        onCancelContentRichTextClick();
    else onCloseContentRichTextClick();
}
function onCancelContentRichTextClick(s, e) {
    PopupControlContentRichText.Hide();
}
function onSaveContentRichTextClick(s, e) {

    LoadingSave.Show();
    const saveEvent = new KeyboardEvent('keydown', {
        key: 's',
        ctrlKey: true,  // Set Ctrl key to true for Windows/Linux, Command key for macOS
        metaKey: true,  // Set meta key to true for macOS
    });

    // Dispatch the event to the document
    document.dispatchEvent(saveEvent);
    setTimeout(() => { LoadingSave.Hide(); }, 3000);
    setTimeout(() => { PopupControlContentRichText.Hide(); }, 3000);
    
}
function onCloseContentRichTextClick(s, e) {
    var content = document.getElementById("RichEdit_View").innerHTML.length;
    console.log(content);
    PopupControlContentInformation.Show();
}
function onCancelContentInformation(s, e) {
    PopupControlContentInformation.Hide();
}
function onNoSaveContentInformation(s, e) {
    PopupControlContentInformation.Hide();
    PopupControlContentRichText.Hide();
}
function onSaveContentRichInformation(s, e) {
    LoadingSave.Show();
    const saveEvent = new KeyboardEvent('keydown', {
        key: 's',
        ctrlKey: true,  // Set Ctrl key to true for Windows/Linux, Command key for macOS
        metaKey: true,  // Set meta key to true for macOS
    });

    // Dispatch the event to the document
    document.dispatchEvent(saveEvent);
    setTimeout(() => { LoadingSave.Hide(); }, 3000);
    setTimeout(() => { onNoSaveContentInformation(); }, 3000);
}
function showSymbols(s, e) {
    s.commands.insertSymbol.execute("an example text", "Arial");
    console.log("hihi");
}