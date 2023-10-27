function onLogin() {
    var username = "" + document.getElementById("username").value;
    var password = "" + document.getElementById("password").value;
    if (username.length == 0) {
        toastr.error("Vui lòng nhập tài khoản");
        return;
    }
    if (password.length == 0) {
        toastr.error("Vui lòng nhập mật khẩu");
        return;
    }
    Login();
}

function Login() {
    document.getElementById("login-loading").style.display = 'block';
    document.getElementById("login-button").style.display = 'none';
    document.getElementById("login-error").style.display = 'none';
    $.ajax({
        url: "/Account/SignIn",
        data: {
            username: document.getElementById("username").value,
            password: document.getElementById("password").value
        },
        type: 'POST',
        success: function (data) {

            if (data.status != 0) {
                toastr.error(data.msg);
                document.getElementById("login-loading").style.display = 'none';
                document.getElementById("login-button").style.display = 'block';
                document.getElementById("login-error").style.display = 'block';
                $("#login-error-message").html(data.msg);
                return;
            }

            
            var completeLink = window.location.origin + "/Home/Index";
            window.location.href = completeLink;

            //document.getElementById("login-loading").style.display = 'none';
            //document.getElementById("login-button").style.display = 'block';
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
            document.getElementById("login-loading").style.display = 'none';
            document.getElementById("login-button").style.display = 'block';
        }
    });
}