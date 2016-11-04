window.MegaMarket = window.MegaMarket || {};

(function ($) {
    var proxy = $.fn.serializeArray;

    jQuery.extend(jQuery.validator.messages, {
        required: "Este campo es obligatorio.",
        remote: "Por favor, rellena este campo.",
        email: "Por favor, escribe una dirección de correo válida",
        url: "Por favor, escribe una URL válida.",
        date: "Por favor, escribe una fecha válida.",
        dateISO: "Por favor, escribe una fecha (ISO) válida.",
        number: "Por favor, escribe un número entero válido.",
        digits: "Por favor, escribe sólo dígitos.",
        creditcard: "Por favor, escribe un número de tarjeta válido.",
        equalTo: "Por favor, escribe el mismo valor de nuevo.",
        accept: "Por favor, escribe un valor con una extensión aceptada.",
        maxlength: jQuery.validator.format("Por favor, no escribas más de {0} caracteres."),
        minlength: jQuery.validator.format("Por favor, no escribas menos de {0} caracteres."),
        rangelength: jQuery.validator.format("Por favor, escribe un valor entre {0} y {1} caracteres."),
        range: jQuery.validator.format("Por favor, escribe un valor entre {0} y {1}."),
        max: jQuery.validator.format("Por favor, escribe un valor menor o igual a {0}."),
        min: jQuery.validator.format("Por favor, escribe un valor mayor o igual a {0}.")
    });

    $.fn.serializeArray = function () {
        var inputs = this.find(':disabled');
        inputs.prop('disabled', false);
        var serialized = proxy.apply(this, arguments);
        inputs.prop('disabled', true);
        return serialized;
    };

    $.fn.serializeFormJSON = function () {
        var o = {};
        var a = this.serializeArray();
        $.each(a, function () {
            if (o[this.name]) {
                if (!o[this.name].push) {
                    o[this.name] = [o[this.name]];
                }
                o[this.name].push(this.value || '');
            } else {
                o[this.name] = this.value || '';
            }
        });
        return o;
    };

    MegaMarket.AjaxProcessing = function (form) {
        this.form = form;

        this.FormCollection = function (callback) {
            $.ajax({
                type: "POST",
                url: this.form.action,
                data: $(this.form).serializeFormJSON(),
                dataType: "json",
                success: function (res) {
                    callback(varData = (typeof res) == 'string' ? eval('(' + res + ')') : res);
                },
                error: function () {
                    var res = { Estado: 2 };
                    eFlexis.dialog.Message(res);
                }
            });
        }

        this.FormEntity = function (callback) {
            $.ajax({
                type: "POST",
                url: this.form.action,
                data: JSON.stringify($(this.form).serializeFormJSON()),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (res) {
                    callback(varData = (typeof res) == 'string' ? eval('(' + res + ')') : res);
                },
                error: function () {
                    var res = { Estado: 2 };
                    eFlexis.dialog.Message(res);
                }
            });
        }
    }

    MegaMarket.showModalPartialView = function (modal, url) {
        MegaMarket[modal].load(url, function () {

        }).dialog('open');

        MegaMarket[modal].dialog('widget').position({
            my: "center", at: "center", of: window
        });
    }

    MegaMarket.formatDataTableData = function (aoData) {
        var r = {};
        var x;
        for (x in aoData) {
            r[aoData[x].name] = aoData[x].value
        }
        return { tableParams: r };
    }
})(jQuery);

