$(function () {

    $("#UserRegistrationModal button[name = 'register']").prop("disabled", true);
    var acceptUserAgreementCheck = $("#UserRegistrationModal input[name = 'AcceptUserAgreement']").click(onUserAgreementClick);

    function onUserAgreementClick() {
        if ($(this).is(":checked")) {
            $("#UserRegistrationModal button[name = 'register']").prop("disabled", false);
        }
        else {
            $("#UserRegistrationModal button[name = 'register']").prop("disabled", true);
        }
    }

    $("#UserRegistrationModal input[name = 'Email']").blur(function () {

        var email = $("#UserRegistrationModal input[name = 'Email']").val();

        var url = "UserAuth/UserNameExists?userName=" + email;

        $.ajax({
            type: "GET",
            url: url,
            success: function (data) {
                if (data == true) {

                    PresentClosableBootstrapAlert("#alert_placeholder_register", "danger",
                        "Invalid Email", "This email address has already been registered.");
                }
                else {
                    CloseAlert("#alert_placeholder_register");
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                var errorText = "Status: " + xhr.status + " - " + xhr.statusText;

                PresentClosableBootstrapAlert("#alert_placeholder_register", "danger", "Error!", errorText);

                console.error(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);

            }
        });
    });

    var registerButton = $("#UserRegistrationModal button[name = 'register']").click(onUserRegisterClick);

    function onUserRegisterClick() {

        //var url = "UserAuth/RegisterUser";

        var antiForgeryToken = $("#UserRegistrationModal input[name = '__RequestVerificationToken']").val();

        var phoneNumber = $("#UserRegistrationModal input[name = 'PhoneNumber']").val();
        var email = $("#UserRegistrationModal input[name = 'Email']").val();
        var password = $("#UserRegistrationModal input[name = 'Password']").val();
        var confirmPassword = $("#UserRegistrationModal input[name = 'ConfirmPassword']").val();

        var user = {
            __RequestVerificationToken: antiForgeryToken,
            PhoneNumber: phoneNumber,
            Email: email,
            Password: password,
            ConfirmPassword: confirmPassword,
            AcceptUserAgreement: true,
        };

        $.ajax({
            type: 'post',
            url: 'UserAuth/RegisterUser',
            data: user,
            success: function (data) {
                //alert(data);
                var parsed = $.parseHTML(data);

                var hasErros = $(parsed).find("input[name = 'RegistrationInvalid']").val() == "true";

                if (hasErros) {
                    $("#UserRegistrationModal").html(data);

                    registerButton = $("#UserRegistrationModal button[name = 'register']").click(onUserRegisterClick);

                    $("#UserRegistrationForm").removeData("validator");
                    $("#UserRegistrationForm").removeData("unobtrusiveValidation");
                    $.validator.unobtrusive.parse("#UserRegistrationForm");

                }
                else {
                    location.href = 'Home/Index';
                }
            },
            error: function (xhr, ajaxOption, thrownError) {
                //alert("Failed");
                console.error(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
            }
        })
    }
});