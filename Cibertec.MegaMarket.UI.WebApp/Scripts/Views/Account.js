(function ($) {
    $('#FrmLogin :input').change(function () {
        $(".mensaje-error")
            .removeClass("alert alert-danger")
            .text("");
    });

    $('#FrmLogin').validate({
        ignore: '*:not([name])',
        rules: {},
        messages: {},
        highlight: function (element) {
            $(element).closest('.form-error-mensage').addClass('has-error');
        },
        unhighlight: function (element) {
            $(element).closest('.form-error-mensage').removeClass('has-error');
        },
        errorElement: 'span',
        errorClass: 'help-block',
        errorPlacement: function (error, element) {
            error.appendTo(element.closest('.form-error-mensage'));
        },
        submitHandler: function (form) {
            $(".mensaje-error")
                .removeClass("alert alert-danger")
                .text("");

            var oAccount= new Ingemmet.funciones(form);
            oAccount.AjaxOperacion(function (output) {
                console.log("output", output);
                if (varData.Estado == 0) {
                    $(".mensaje-error")
                        .addClass("alert alert-danger")
                        .text(varData.Mensaje);
                }
                else
                    window.location = varData.Url;
            });
            return false;
        }
    });
})(jQuery);