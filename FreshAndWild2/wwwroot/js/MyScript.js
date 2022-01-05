$(function () {
    $("#btnSubmit").click(function () {
        var formData = new FormData();
        formData.append("Email", $("#email").val());
        formData.append("MotDePasseConnexion", $("#motDePasse").val());
        $.ajax({
            url: "/Connexion/ConnexionAdherent",
            type: 'POST',
            cache: false,
            contentType: false,
            processData: false,
            data: formData,
            statusCode: {
                200: function (data) {
                    // close current window
                    window.close();
                    // reload parent window
                    window.opener.location.reload();
                },
                501: function (data) {
                    // redirect current window to /connexion/errorconnexion
                    window.location.replace("/Connexion/ErrorConnexion");
                }
            },
        });
    });
});

$(function () {
    $("#termBtn").click(function () {
        window.close();
        window.opener.location.replace("/Home/Index");
    });
});

$(function () {
    $("#termBtnCnx").click(function () {
        window.location.replace("/Home/Index");
    });
});


//$(function () {
//    $(".add_to_cart").click(function () {
//        window.open("/Connexion/connexion");
//    });
//});


//$(document).ready(function () {
//    $('.nav-link').click(function (e) {

//        $('.nav-link').removeClass('active');
//        $(this).addClass('active');

//    });
//});