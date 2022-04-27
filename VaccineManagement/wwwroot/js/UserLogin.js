$(function () {
    var userButton = $("#UserLoginModal button[name = 'login']").click(onUserLoginClick);

    function onUserLoginClick() {

        var url = "UserAuth/Login";

        var antiForgeryToken = $("#UserLoginModal input[name = '__RequestVerificationToken']").val();

        var email = $("#UserLoginModal input[name = 'Email']").val();
        var password = $("#UserLoginModal input[name = 'Password']").val();
        var rememberme = $("#UserLoginModal input[name = 'RememberMe']").prop('checked');

        var userInput = {
            __RequestVerificationToken: antiForgeryToken,
            Email: email,
            Password: password,
            RememberMe: rememberme,
        };

        $.ajax({
            type: "POST",
            url: url,
            data: userInput, 
            success: function (data) {

                var parsed = $.parseHTML(data);

                var hasErrors = $(parsed).find("input[name = 'LoginInvalid']").val() == "true";

                if (hasErrors) {
                    $("#UserLoginModal").html(data);

                    userLoginButton = $("#UserLoginModal button[name = 'login']").click(onUserLoginClick);

                    //var form = $("#UserLoginForm");

                    //$(form).removeData("validator");
                    //$(form).removeData("unobtrusiveValidation");
                    //$.validator.unobtrusive.parse(form);


                }
                else {
                    location.href = 'Admin/Dashboard';
                }
            },
            error: function (xhr, ajaxOption, thrownError) {
                console.error(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
            }

        });

    }
})