var Cotizador = Cotizador || {};
Cotizador.Home = Cotizador.Home || {};

Cotizador.Home = (function () {
    "use strict";
    let HomeLoad = function () {
        let Comun = Cotizador.Comun;        

        this.initialize = function () {
            getModels();
            getYears();
        };

        let getModels = function () {
            $("#brand").change(function () {
                let idBrand = $(this).val()
                $.ajax({
                    url: `/Catalogs/GetModels`,
                    data: { IdBrand: idBrand }
                }).done(function (response) {
                    $("#model").html("")
                    $("#model").append(new Option("-- Seleccione --", ""));
                    response.data.forEach(function (item, index) {                        
                        $("#model").append(new Option(item.ModelName, item.Id));
                        $("#model").removeAttr("disabled")
                    })
                });
            })
        }

        let getYears = function () {
            $("#model").change(function () {
                let idModel = $(this).val()
                $.ajax({
                    url: `/Catalogs/GetYears`,
                    data: { IdModel: idModel }
                }).done(function (response) {
                    $("#year").html("")
                    $("#year").append(new Option("-- Seleccione --", ""));
                    response.data.forEach(function (item, index) {
                        $("#year").append(new Option(item.YearName, item.Id));
                        $("#year").removeAttr("disabled")
                    })
                });
            })
        }
    };

    return new HomeLoad();
})();
(function ($, window, document) {
    "use strict";
    $(function () {
        Cotizador.Home.initialize();
    });
})(window.jQuery, window, document);