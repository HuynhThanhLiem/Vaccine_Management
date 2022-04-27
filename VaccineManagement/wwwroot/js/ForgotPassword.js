$(function () {

    $("#ForgotPasswordModal button[name = 'forgotPassword']").click(onForgotPasswordClick);

    function onForgotPasswordClick() {

        var email = $("#ForgotPasswordModal input[name = 'Email']").val();

        var model = {
            Email: email,
            IsSent: false,
        }
        

        $.ajax({
            type: 'post',
            url: 'UserAuth/ForgotPassword',
            data: model,
            success: function (data) {
                //alert(data);
                if (data == true) {

                    PresentClosableBootstrapAlert("#alert_placeholder_forgotPassword", "success",
                        "Email have sent",
                        "We've sent an email. Please check it to reset password!</br> Should you not receive it, wait a minute and then press <b>\"submit\"</b> again!");
                }
                else {
                    CloseAlert("#alert_placeholder_forgotPassword");
                }
            },
            error: function (xhr, ajaxOption, thrownError) {
                alert("Failed");
                console.error(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
            }
        })
    } 
});