// JQUERY DIALOG
(function ($) {

    $.ui.dialog.prototype.fullscreen = false;
    $.ui.dialog.prototype.options.autoReposition = true;

    var old = $.ui.dialog.prototype._createTitlebar;
    var open = $.ui.dialog.prototype.open;
    var resize = $.ui.dialog.prototype._autoResize;

    $.ui.dialog.prototype._createTitlebar = function () {
        old.call(this);
        var oldHeight = this.options.height,
            oldWidth = this.options.width,
            $dialog = this.element;


        this.uiDialogTitlebarFullScreen = $("<button type='button'></button>")
            .button({
                label: this.options.fullScreenText,
                icons: {
                    primary: "ui-icon-newwin"
                },
                text: false
            })
            .addClass("ui-dialog-titlebar-fullscreen")
            .appendTo(this.uiDialogTitlebar);

        this._on(this.uiDialogTitlebarFullScreen, {
            click: function (event) {
                event.preventDefault();
                if (this.fullscreen) {
                    if (oldWidth > window.innerWidth)
                        this._setOptions({ width: window.innerWidth - 30 });

                    else if (oldHeight > innerHeight)
                        this._setOptions({ height: innerHeight - 30 });
                    else
                        this._setOptions({
                            height: oldHeight,
                            width: oldWidth
                        });
                } else {
                    this._setOptions({
                        height: window.innerHeight - 30,
                        width: window.innerWidth - 30
                    });
                }
                this.fullscreen = !this.fullscreen;
                $dialog.dialog('widget').position({ my: "center", at: "center", of: window });
            }
        });
    };

    $.ui.dialog.prototype._autoResize = function () {
        resize.call(this);
        var wWidth = $(window).width();

    }

    $.ui.dialog.prototype.open = function () {
        open.apply(this, arguments);

        var _this = this,
            $dialog = this.element,
            oldHeight = this.options.height,
            oldWidth = this.options.width;

        var resize = function () {
            var wHeight = window.innerHeight,
                wWidth = window.innerWidth;

            if (_this.fullscreen || (oldWidth > wWidth && oldHeight > wHeight)) {
                _this._setOptions({
                    height: wHeight - 30,
                    width: wWidth - 30
                });
            } else if (oldWidth > wWidth) {
                _this._setOptions({ width: wWidth - 30 });

            } else if (oldHeight > wHeight) {
                _this._setOptions({ height: wHeight - 30 });
            } else {
                _this._setOptions({
                    height: oldHeight,
                    width: oldWidth
                });
            }

            $dialog.dialog('widget').position({ my: "center", at: "center", of: window });
        }

        resize();

        $(window).resize(resize);
    }

    //$(window).resize(function () {
    //    $(".ui-dialog-content:visible").each(function () {
    //        if ($(this).dialog('option', 'autoReposition')) {
    //            $(this).dialog('widget').position({ my: "center", at: "center", of: window });
    //        }
    //    });
    //});

})(jQuery);

// BOTONERA FORMULARIOS
(function ($) {
    $.widget("ingemmet.botoneraFormulario", {
        options: {
            target: null
        },

        _create: function () {
            this.element.attr({
                "data-target": this.options.target
            });

            this._on({
                click: this._onClickEvent,
            });

        },

        _setOption: function (key, value) {
            this.options[key] = value;
        },

        _onClickEvent: function (e) {
            var event = this._eventTypeButton(this.element[0].name),
                target = this.options.target,
                input = $(target).find("input[name=Operacion]");

            if (typeof event != null && typeof target != 'undefined') {
                if (input) {
                    $(target).find("input[name=Operacion]").val(event);
                    $('button[type=submit]', target).trigger('click');
                } else {
                    console.error("El input input[name=Operacion] no esta definido en el formulario");
                }
            }
        },

        _eventTypeButton: function (name) {
            var eventType = null;
            switch (name) {
                case "event_insert":
                    eventType = "INS";
                    break;
                case "event_update":
                    eventType = "UPD";
                    break;
                case "event_delete":
                    eventType = "DEL";
                    break;
                case "event_reset":
                    eventType = "RESET";
                    break;
            }
            return eventType;
        },

        ajaxOperation: function (event, data) {
            alert();
        }
    });
})(jQuery);