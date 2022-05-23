var Cotizador = Cotizador || {};
Cotizador.Home = Cotizador.Home || {};

Cotizador.Home = (function () {
    "use strict";
    let HomeLoad = function () {
        let Comun = Cotizador.Comun;        

        this.initialize = function () {
            getModels()
            getYears()
            validatePrice()
            validateHitch()
            simulate()
            payOff()            
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

        let validatePrice = function () {
            $("#price").focusin(function () {
                $("#priceHelp").html("")
                $("#btnCotizar").removeAttr("disabled")
            })

            $("#price").focusout(function () {
                let value = parseFloat($("#price").cleanVal());
                if (value) {
                    let minPrice = parseFloat(localStorage.getItem(Cotizador.Comun.KeySettings[0]));
                    let maxPrice = parseFloat(localStorage.getItem(Cotizador.Comun.KeySettings[1]));
                    if (!(minPrice <= value && maxPrice >= value)) {
                        $("#priceHelp").html("Ingresa un monto entre <span class='money' >" + minPrice + "</span> y <span class='money' >" + maxPrice + "</span>")
                        Comun.MaskInputs();
                        $("#btnCotizar").attr("disabled", "disabled")
                    }
                }
                
            })
        }

        let validateHitch = function () {
            $("#hitch").focusin(function () {
                $("#hitchHelp").html("");
                $("#btnCotizar").removeAttr("disabled")
            })

            $("#hitch").focusout(function () {
                let value = $("#hitch").cleanVal()
                if (value) {                    
                    let percentHitch = parseFloat(localStorage.getItem(Cotizador.Comun.KeySettings[2]));
                    let price = parseFloat($("#price").cleanVal());
                    let minHitch = parseInt((percentHitch * price) / 100)
                    if (value < minHitch) {
                        $("#hitchHelp").html("El enganche mínimo debe ser de <span class='money' >" + minHitch + "</span>  (" + percentHitch + " % de <span class='money' >" + price + "</span>)")
                        Comun.MaskInputs();
                        $("#btnCotizar").attr("disabled", "disabled")
                    }
                    if (value > price) {
                        $("#hitchHelp").text("El enganche no puede superar el precio del vehículo")
                        $("#btnCotizar").attr("disabled", "disabled")
                    }
                }
            })
        }

        let simulate = function () {
            $("#formCotizar").submit(function (event) {
                event.preventDefault();                
                let price = $("#price").cleanVal()
                let hitch = $("#hitch").cleanVal()
                $("#total").html("<span class='money text-center d-block'>" + (price - hitch)+"</span>")
                $("#simulate").removeClass("d-none")
                $("#imgBanner").addClass("d-none")
                Comun.MaskInputs()
            })
        }

        let payOff = function () {
            $("#btnSimulate").click(function () {
                let price = $("#price").cleanVal()
                let hitch = $("#hitch").cleanVal()
                $.ajax({
                    type: "POST",
                    url: `/Home/PayOff`,
                    data: { price: price, hitch: hitch },
                }).done(function (response) {
                    $("#mdlMounthsBody").html("")
                    $("#mdlMounthsBody").html(response)
                    $("#mdlMounths").modal("show")
                    getCredit();
                });
            })
        }

        let getCredit = function () {
            $(".btnSolicitar").click(function () {
                $("#mdlMounths").modal("hide")
                $.alert({
                    title: 'Agradecemos tu preferencia',
                    content: 'Un asesor se pondra en contacto contigo',
                });
                setTimeout(function () {
                    window.location.reload()
                }, 3000)                
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