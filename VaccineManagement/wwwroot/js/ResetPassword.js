$(function () {

    $("#ResetPasswordForm input[name = 'resetPassword']").click(onResetPasswordClick);

    function onResetPasswordClick() {

        var email = $("#ResetPasswordForm input[name = 'Email']").val();
        var password = $("#ResetPasswordForm input[name = 'Password']").val();
        var confirmPassword = $("#ResetPasswordForm input[name = 'ConfirmPassword']").val();
        var token = $("#ResetPasswordForm input[name = 'Token']").val();

        var modelReset = {
            Email: email,
            Password: password,
            ConfirmPassword: confirmPassword,
            Token: token,
        }
        $.ajax({
            type: 'POST',
            url: 'ResetPassword',
            data: modelReset,
            success: function (data) {
                //alert(data);
                if (data == true) {
                    Swal.fire(
                        'Good job!',
                        'Your password has changed!',
                        'success'
                    ).then((result) => {
                        if (result.isConfirmed) {
                            location.href = 'https://localhost:44387/';
                        }
                    })
                }
                else {
                    Swal.fire({
                        icon: 'error',
                        title: 'Oops...',
                        text: 'Something went wrong!',
                    })
                }
            },
            error: function (xhr, ajaxOption, thrownError) {
                alert("Failed");
                console.error(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
            }
        })
    }
});